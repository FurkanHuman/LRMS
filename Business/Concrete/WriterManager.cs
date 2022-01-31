using Business.Abstract;
using Business.Constants;
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

        private static int namelength = 3;
        private static int surnameNamelength = 2;

        public WriterManager(IWriterDal writerDal)
        {
            _writerDal = writerDal;
        }

        public IResult Add(Writer entity)
        {
            IResult result = BusinessRules.Run(WriterControl(entity));
            if (result != null)
                return result;
            _writerDal.Add(entity);
            return new SuccessResult(WriterConstants.AddSucces);
        }

        public IResult Delete(Writer entity)
        {
            IResult result = BusinessRules.Run(WriterControl(entity));
            if (result != null)
                return result;
            entity.IsDeleted = true;
            _writerDal.Update(entity);
            return new SuccessResult(WriterConstants.AddSucces);
        }

        public IResult Update(Writer entity)
        {
            IResult result = BusinessRules.Run(WriterControl(entity), UpdateControl(entity));
            if (result != null)
                return result;
            _writerDal.Update(entity);
            return new SuccessResult(WriterConstants.AddSucces);
        }

        public IDataResult<List<Writer>> GetByFilterList(Expression<Func<Writer, bool>>? filter = null)
        {
            return new SuccessDataResult<List<Writer>>(_writerDal.GetAll(filter).ToList(), WriterConstants.DataGet);
        }

        public IDataResult<Writer> GetById(int id)
        {
            return new SuccessDataResult<Writer>(_writerDal.Get(i => i.Id == id && !i.IsDeleted));
        }

        public IDataResult<Writer> GetByName(string name)
        {
            Writer Writer = _writerDal.Get(n => n.Name.ToLower().Contains(name.ToLower()) && !n.IsDeleted);
            return Writer == null
                ? new ErrorDataResult<Writer>(WriterConstants.DataNotGet)
                : new SuccessDataResult<Writer>(Writer, WriterConstants.DataGet);
        }

        public IDataResult<Writer> GetBySurname(string surname)
        {
            Writer Writer = _writerDal.Get(n => n.SurName.ToLower().Contains(surname.ToLower()) && !n.IsDeleted);
            return Writer == null
                ? new ErrorDataResult<Writer>(WriterConstants.DataNotGet)
                : new SuccessDataResult<Writer>(Writer, WriterConstants.DataGet);
        }

        public IDataResult<List<Writer>> GetNamePreAttachmentList(string namePreAttachment)
        {
            return new SuccessDataResult<List<Writer>>(_writerDal.GetAll(n => n.NamePreAttachment.ToLower().Contains(namePreAttachment.ToLower()) && !n.IsDeleted).ToList());
        }

        public IDataResult<List<Writer>> GetList()
        {
            return new SuccessDataResult<List<Writer>>(_writerDal.GetAll().ToList(), WriterConstants.DataGet);
        }

        private static IResult WriterControl(Writer entity)
        {
            if (entity == null)
                return new ErrorResult(WriterConstants.WriterNull);
            if (entity.Name.Equals(null) || entity.Name.Equals(string.Empty) || entity.Name.Length >= namelength)
                return new ErrorResult(WriterConstants.WriterNameLengthNotEnough);
            if (entity.SurName.Equals(null) || entity.SurName.Equals(string.Empty) || entity.SurName.Length >= surnameNamelength)
                return new ErrorResult(WriterConstants.WriterNameLengthNotEnough);

            return new SuccessResult();
        }

        private IResult UpdateControl(Writer entity)
        {
            Writer updateWriter = _writerDal.Get(i => i == entity);

            if (updateWriter == null)
                return new ErrorResult(WriterConstants.WriterNull);
            if (entity.Name.Equals(updateWriter.Name) || entity.SurName.Equals(updateWriter.SurName)
                || entity.Name.Length >= namelength && entity.SurName.Length >= surnameNamelength)
                return new ErrorResult(WriterConstants.WriterEquals);

            return new SuccessResult();
        }

    }
}
