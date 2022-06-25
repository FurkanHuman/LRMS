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

        public IResult Delete(Guid id)
        {
            Redaction redaction = _redactionDal.Get(r => r.Id == id);
            if (redaction == null)
                return new SuccessResult(RedactionConstants.DataNotGet);

            _redactionDal.Delete(redaction);
            return new SuccessResult(RedactionConstants.DeleteSuccess);
        }

        public IResult ShadowDelete(Guid id)
        {
            Redaction redaction = _redactionDal.Get(r => r.Id == id && !r.IsDeleted);
            if (redaction == null)
                return new ErrorResult(RedactionConstants.NotMatch);

            redaction.IsDeleted = true;
            _redactionDal.Update(redaction);
            return new SuccessResult(RedactionConstants.ShadowDeleteSuccess);
        }

        [ValidationAspect(typeof(RedactionValidator), Priority = 1)]
        public IResult Update(Redaction entity)
        {
            _redactionDal.Update(entity);
            return new SuccessResult(RedactionConstants.UpdateSuccess);
        }

        public IDataResult<List<Redaction>> GetAllByFilter(Expression<Func<Redaction, bool>>? filter = null)
        {
            return new SuccessDataResult<List<Redaction>>(_redactionDal.GetAll(filter).ToList(), RedactionConstants.DataGet);
        }

        public IDataResult<Redaction> GetById(Guid id)
        {
            Redaction redaction = _redactionDal.Get(r => r.Id == id);
            return redaction == null
                ? new ErrorDataResult<Redaction>(RedactionConstants.DataNotGet)
                : new SuccessDataResult<Redaction>(redaction, RedactionConstants.DataGet);
        }

        public IDataResult<List<Redaction>> GetByIds(Guid[] ids)
        {
            List<Redaction> redactions = _redactionDal.GetAll(r => ids.Contains(r.Id) && !r.IsDeleted).ToList();
            return redactions == null
                ? new ErrorDataResult<List<Redaction>>(RedactionConstants.DataNotGet)
                : new SuccessDataResult<List<Redaction>>(redactions, RedactionConstants.DataGet);
        }

        public IDataResult<List<Redaction>> GetByNames(string name)
        {
            List<Redaction> redactions = _redactionDal.GetAll(r => r.Name.Contains(name) && !r.IsDeleted).ToList();
            return redactions == null
                ? new ErrorDataResult<List<Redaction>>(RedactionConstants.DataNotGet)
                : new SuccessDataResult<List<Redaction>>(redactions, RedactionConstants.DataGet);
        }

        public IDataResult<List<Redaction>> GetBySurnames(string surname)
        {
            List<Redaction> redactions = _redactionDal.GetAll(r => r.SurName.Contains(surname) && !r.IsDeleted).ToList();
            return redactions == null
                ? new ErrorDataResult<List<Redaction>>(RedactionConstants.DataNotGet)
                : new SuccessDataResult<List<Redaction>>(redactions, RedactionConstants.DataGet);
        }

        public IDataResult<List<Redaction>> GetAllBySecrets()
        {
            return new SuccessDataResult<List<Redaction>>(_redactionDal.GetAll(r => r.IsDeleted).ToList(), RedactionConstants.DataGet);
        }

        public IDataResult<List<Redaction>> GetAll()
        {
            return new SuccessDataResult<List<Redaction>>(_redactionDal.GetAll(r => !r.IsDeleted).ToList(), RedactionConstants.DataGet);
        }

        private IResult RedactionNameOrSurnameExist(Redaction entity)
        {
            bool result = _redactionDal.GetAll(w => w.Name.Equals(entity.Name)
            && w.SurName.Equals(entity.SurName)).Any();
            return result
                ? new ErrorResult(RedactionConstants.NameOrSurnameExists)
                : new SuccessResult(RedactionConstants.DataGet);
        }
    }
}