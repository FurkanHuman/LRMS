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
    public class RedactionManager : IRedactionService
    {
        private readonly IRedactionDal _redactionDal;

        private static int namelength = 3;
        private static int surnameNamelength = 2;

        public RedactionManager(IRedactionDal redactionDal)
        {
            _redactionDal = redactionDal;
        }

        public IResult Add(Redaction entity)
        {
            IResult result = BusinessRules.Run(RedactionControl(entity));
            if (result != null)
                return result;
            _redactionDal.Add(entity);
            return new SuccessResult(RedactionConstants.AddSucces);
        }

        public IResult Delete(Redaction entity)
        {
            IResult result = BusinessRules.Run(RedactionControl(entity));
            if (result != null)
                return result;
            entity.IsDeleted = true;
            _redactionDal.Update(entity);
            return new SuccessResult(RedactionConstants.AddSucces);
        }

        public IResult Update(Redaction entity)
        {
            IResult result = BusinessRules.Run(RedactionControl(entity), UpdateControl(entity));
            if (result != null)
                return result;
            _redactionDal.Update(entity);
            return new SuccessResult(RedactionConstants.AddSucces);
        }

        public IDataResult<List<Redaction>> GetByFilterList(Expression<Func<Redaction, bool>>? filter = null)
        {
            return new SuccessDataResult<List<Redaction>>(_redactionDal.GetAll(filter).ToList(), RedactionConstants.DataGet);
        }

        public IDataResult<Redaction> GetById(int id)
        {
            return new SuccessDataResult<Redaction>(_redactionDal.Get(i => i.Id == id && !i.IsDeleted));
        }

        public IDataResult<Redaction> GetByName(string name)
        {
            Redaction Redaction = _redactionDal.Get(n => n.Name.ToLower().Contains(name.ToLower()) && !n.IsDeleted);
            return Redaction == null
                ? new ErrorDataResult<Redaction>(RedactionConstants.DataNotGet)
                : new SuccessDataResult<Redaction>(Redaction, RedactionConstants.DataGet);
        }

        public IDataResult<Redaction> GetBySurname(string surname)
        {
            Redaction Redaction = _redactionDal.Get(n => n.SurName.ToLower().Contains(surname.ToLower()) && !n.IsDeleted);
            return Redaction == null
                ? new ErrorDataResult<Redaction>(RedactionConstants.DataNotGet)
                : new SuccessDataResult<Redaction>(Redaction, RedactionConstants.DataGet);
        }

        public IDataResult<List<Redaction>> GetList()
        {
            return new SuccessDataResult<List<Redaction>>(_redactionDal.GetAll().ToList(), RedactionConstants.DataGet);
        }

        private static IResult RedactionControl(Redaction entity)
        {
            if (entity == null)
                return new ErrorResult(RedactionConstants.RedactionNull);
            if (entity.Name.Equals(null) || entity.Name.Equals(string.Empty) || entity.Name.Length >= namelength)
                return new ErrorResult(RedactionConstants.RedactionNameLengthNotEnough);
            if (entity.SurName.Equals(null) || entity.SurName.Equals(string.Empty) || entity.SurName.Length >= surnameNamelength)
                return new ErrorResult(RedactionConstants.RedactionNameLengthNotEnough);

            return new SuccessResult();
        }

        private IResult UpdateControl(Redaction entity)
        {
            Redaction updateRedaction = _redactionDal.Get(i => i == entity);

            if (updateRedaction == null)
                return new ErrorResult(RedactionConstants.RedactionNull);
            if (entity.Name.Equals(updateRedaction.Name) || entity.SurName.Equals(updateRedaction.SurName)
                || entity.Name.Length >= namelength && entity.SurName.Length >= surnameNamelength)
                return new ErrorResult(RedactionConstants.RedactionEquals);

            return new SuccessResult();
        }
    }
}
