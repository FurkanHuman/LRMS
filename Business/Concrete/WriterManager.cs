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

        public IResult Delete(Writer entity)
        {
            _writerDal.Delete(entity);
            return new SuccessResult(WriterConstants.DeleteSuccess);
        }

        public IResult ShadowDelete(Guid guid)
        {
            Writer writer = _writerDal.Get(w => w.Id == guid && !w.IsDeleted);
            if (writer == null)
                return new ErrorResult(WriterConstants.NotMatch);

            writer.IsDeleted = true;
            _writerDal.Update(writer);
            return new SuccessResult(WriterConstants.ShadowDeleteSuccess);
        }

        public IResult Update(Writer entity)
        {
            _writerDal.Update(entity);
            return new SuccessResult(WriterConstants.UpdateSuccess);
        }

        public IDataResult<List<Writer>> GetByFilterList(Expression<Func<Writer, bool>>? filter = null)
        {
            return new SuccessDataResult<List<Writer>>(_writerDal.GetAll(filter).ToList(), WriterConstants.DataGet);
        }

        public IDataResult<Writer> GetById(Guid guid)
        {
            return new SuccessDataResult<Writer>(_writerDal.Get(i => i.Id == guid && !i.IsDeleted), WriterConstants.DataGet);
        }

        public IDataResult<List<Writer>> GetByNames(string name)
        {
            List<Writer> writers = _writerDal.GetAll(n => n.Name.ToLowerInvariant().Contains(name.ToLowerInvariant()) && !n.IsDeleted).ToList();
            return writers == null
                ? new ErrorDataResult<List<Writer>>(WriterConstants.DataNotGet)
                : new SuccessDataResult<List<Writer>>(writers, WriterConstants.DataGet);
        }

        public IDataResult<List<Writer>> GetBySurnames(string surname)
        {
            List<Writer> writers = _writerDal.GetAll(n => n.Name.ToLowerInvariant().Contains(surname.ToLowerInvariant()) && !n.IsDeleted).ToList();
            return writers == null
                ? new ErrorDataResult<List<Writer>>(WriterConstants.DataNotGet)
                : new SuccessDataResult<List<Writer>>(writers, WriterConstants.DataGet);
        }

        public IDataResult<List<Writer>> GetNamePreAttachmentList(string namePreAttachment)
        {
            return new SuccessDataResult<List<Writer>>(_writerDal.GetAll(n => n.NamePreAttachment.ToLowerInvariant().Contains(namePreAttachment.ToLowerInvariant())
            && !n.IsDeleted).ToList(), WriterConstants.DataGet);
        }

        public IDataResult<List<Writer>> GetList()
        {
            return new SuccessDataResult<List<Writer>>(_writerDal.GetAll().ToList(), WriterConstants.DataGet);
        }

        private IResult WriterNameOrSurnameExist(Writer entity)
        {
            bool result = _writerDal.GetAll(w => w.Name.ToUpperInvariant().Equals(entity.Name.ToUpperInvariant())
            && w.SurName.ToUpperInvariant().Equals(entity.SurName.ToUpperInvariant())
            && w.NamePreAttachment.Equals(null)
            && entity.NamePreAttachment != null).Any(); // usage true todo
            return result
                ? new ErrorResult(WriterConstants.WriterNameOrSurnameExist)
                : new SuccessResult(WriterConstants.DataGet);
        }
    }
}
