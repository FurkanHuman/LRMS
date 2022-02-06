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
    public class RedactionManager : IRedactionService
    {
        private readonly IRedactionDal _redactionDal;

        public RedactionManager(IRedactionDal redactionDal)
        {
            _redactionDal = redactionDal;
        }

        [ValidationAspect(typeof(RedactionValidator), Priority = 1)]
        public IResult Add(Redaction entity)
        {
            IResult result = BusinessRules.Run(RedactionNameOrSurnameExist(entity));
            if (result != null)
                return result;
            entity.IsDeleted = false;
            _redactionDal.Add(entity);
            return new SuccessResult(RedactionConstants.AddSuccess);
        }

        public IResult Delete(Redaction entity)
        {
            _redactionDal.Delete(entity);
            return new SuccessResult(RedactionConstants.DeleteSuccess);
        }

        public IResult Update(Redaction entity)
        {
            _redactionDal.Update(entity);
            return new SuccessResult(RedactionConstants.UpdateSuccess);
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

        private IResult RedactionNameOrSurnameExist(Redaction entity)
        {
            bool result = _redactionDal.GetAll(w => w.Name.ToUpperInvariant().Equals(entity.Name.ToUpperInvariant())
            && w.SurName.ToUpperInvariant().Equals(entity.SurName.ToUpperInvariant())).Any();
            return result
                ? new ErrorResult(RedactionConstants.NameOrSurnameExists)
                : new SuccessResult(RedactionConstants.DataGet);
        }
    }
}
