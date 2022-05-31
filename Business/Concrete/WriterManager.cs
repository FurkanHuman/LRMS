using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Business;
using Core.Utilities.Result.Abstract;
using Core.Utilities.Result.Concrete;
using DataAccess.Abstract;
using Entities.Concrete.Infos;
using System.Linq.Expressions;

namespace Business.Concrete
{
    public class WriterManager : IWriterService
    {
        private readonly IWriterDal _writerDal;

        public WriterManager(IWriterDal writerDal)
        {
            _writerDal = writerDal;
        }

        [ValidationAspect(typeof(WriterValidator), Priority = 1)]
        public IResult Add(Writer entity)
        {
            IResult result = BusinessRules.Run(WriterNameOrSurnameExist(entity));
            if (result != null)
                return result;
            entity.IsDeleted = false;
            _writerDal.Add(entity);
            return new SuccessResult(WriterConstants.AddSuccess);
        }

        public IResult Delete(Guid id)
        {
            Writer writer = _writerDal.Get(w => w.Id == id && !w.IsDeleted);
            if (writer == null)
                return new ErrorResult(WriterConstants.NotMatch);

            _writerDal.Delete(writer);
            return new SuccessResult(WriterConstants.DeleteSuccess);
        }

        public IResult ShadowDelete(Guid id)
        {
            Writer writer = _writerDal.Get(w => w.Id == id && !w.IsDeleted);
            if (writer == null)
                return new ErrorResult(WriterConstants.NotMatch);

            writer.IsDeleted = true;
            _writerDal.Update(writer);
            return new SuccessResult(WriterConstants.ShadowDeleteSuccess);
        }

        [ValidationAspect(typeof(WriterValidator), Priority = 1)]
        public IResult Update(Writer entity)
        {
            _writerDal.Update(entity);
            return new SuccessResult(WriterConstants.UpdateSuccess);
        }

        public IDataResult<List<Writer>> GetByFilterList(Expression<Func<Writer, bool>>? filter = null)
        {
            return new SuccessDataResult<List<Writer>>(_writerDal.GetAll(filter).ToList(), WriterConstants.DataGet);
        }

        public IDataResult<Writer> GetById(Guid id)
        {
            return new SuccessDataResult<Writer>(_writerDal.Get(i => i.Id == id), WriterConstants.DataGet);
        }

        public IDataResult<List<Writer>> GetByNames(string name)
        {
            List<Writer> writers = _writerDal.GetAll(n => n.Name.Contains(name, StringComparison.CurrentCultureIgnoreCase) && !n.IsDeleted).ToList();
            return writers == null
                ? new ErrorDataResult<List<Writer>>(WriterConstants.DataNotGet)
                : new SuccessDataResult<List<Writer>>(writers, WriterConstants.DataGet);
        }

        public IDataResult<List<Writer>> GetBySurnames(string surname)
        {
            List<Writer> writers = _writerDal.GetAll(n => n.Name.Contains(surname, StringComparison.CurrentCultureIgnoreCase) && !n.IsDeleted).ToList();
            return writers == null
                ? new ErrorDataResult<List<Writer>>(WriterConstants.DataNotGet)
                : new SuccessDataResult<List<Writer>>(writers, WriterConstants.DataGet);
        }

        public IDataResult<List<Writer>> GetNamePreAttachmentList(string namePreAttachment)
        {
            return new SuccessDataResult<List<Writer>>(_writerDal.GetAll(n => n.NamePreAttachment.ToLowerInvariant().Contains(namePreAttachment.ToLowerInvariant())
            && !n.IsDeleted).ToList(), WriterConstants.DataGet);
        }

        public IDataResult<List<Writer>> GetByFilterLists(Expression<Func<Writer, bool>>? filter = null)
        {
            return new SuccessDataResult<List<Writer>>(_writerDal.GetAll(filter).ToList(), WriterConstants.DataGet);
        }

        public IDataResult<List<Writer>> GetAllBySecrets()
        {
            return new SuccessDataResult<List<Writer>>(_writerDal.GetAll(w => w.IsDeleted).ToList(), WriterConstants.DataGet);
        }

        public IDataResult<List<Writer>> GetAll()
        {
            return new SuccessDataResult<List<Writer>>(_writerDal.GetAll(w=>!w.IsDeleted).ToList(), WriterConstants.DataGet);
        }

        private IResult WriterNameOrSurnameExist(Writer entity)
        {
            bool result = _writerDal.GetAll(w => w.Name.Equals(entity.Name, StringComparison.CurrentCultureIgnoreCase)
            && w.SurName.Equals(entity.SurName, StringComparison.CurrentCultureIgnoreCase)
            && w.NamePreAttachment.Equals(null)
            && entity.NamePreAttachment != null).Any();
            return result
                ? new ErrorResult(WriterConstants.WriterNameOrSurnameExist)
                : new SuccessResult(WriterConstants.DataGet);
        }
    }
}
