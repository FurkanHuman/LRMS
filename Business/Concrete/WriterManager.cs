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
            return new SuccessResult(WriterConstants.AddSucces);
        }

        public IResult Delete(Writer entity)
        {
            _writerDal.Delete(entity);
            return new SuccessResult(WriterConstants.AddSucces);
        }

        public IResult Update(Writer entity)
        {
            _writerDal.Update(entity);
            return new SuccessResult(WriterConstants.AddSucces);
        }

        public IDataResult<List<Writer>> GetByFilterList(Expression<Func<Writer, bool>>? filter = null)
        {
            return new SuccessDataResult<List<Writer>>(_writerDal.GetAll(filter).ToList(), WriterConstants.DataGet);
        }

        public IDataResult<Writer> GetById(int id)
        {
            return new SuccessDataResult<Writer>(_writerDal.Get(i => i.Id == id && !i.IsDeleted), WriterConstants.DataGet);
        }

        public IDataResult<Writer> GetByName(string name)
        {
            Writer Writer = _writerDal.Get(n => n.Name.ToLowerInvariant().Contains(name.ToLowerInvariant()) && !n.IsDeleted);
            return Writer == null
                ? new ErrorDataResult<Writer>(WriterConstants.DataNotGet)
                : new SuccessDataResult<Writer>(Writer, WriterConstants.DataGet);
        }

        public IDataResult<Writer> GetBySurname(string surname)
        {
            Writer Writer = _writerDal.Get(n => n.SurName.ToLowerInvariant().Contains(surname.ToLowerInvariant()) && !n.IsDeleted);
            return Writer == null
                ? new ErrorDataResult<Writer>(WriterConstants.DataNotGet)
                : new SuccessDataResult<Writer>(Writer, WriterConstants.DataGet);
        }

        public IDataResult<List<Writer>> GetNamePreAttachmentList(string namePreAttachment)
        {
            return new SuccessDataResult<List<Writer>>(_writerDal.GetAll(n => n.NamePreAttachment.ToLowerInvariant().Contains(namePreAttachment.ToLowerInvariant()) && !n.IsDeleted).ToList());
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
            && entity.NamePreAttachment != null).Any();
            return !result
                ? new ErrorResult(WriterConstants.WriterNameOrSurnameExist)
                : new SuccessResult(WriterConstants.DataGet);
        }
    }
}
