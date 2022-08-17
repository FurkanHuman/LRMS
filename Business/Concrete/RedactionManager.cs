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

        public IDataResult<IList<Redaction>> GetAllByFilter(Expression<Func<Redaction, bool>>? filter = null)
        {
            return new SuccessDataResult<IList<Redaction>>(_redactionDal.GetAll(filter), RedactionConstants.DataGet);
        }

        public IDataResult<Redaction> GetById(Guid id)
        {
            Redaction redaction = _redactionDal.Get(r => r.Id == id);
            return redaction == null
                ? new ErrorDataResult<Redaction>(RedactionConstants.DataNotGet)
                : new SuccessDataResult<Redaction>(redaction, RedactionConstants.DataGet);
        }

        public IDataResult<IList<Redaction>> GetAllByIds(Guid[] ids)
        {
            IList<Redaction> redactions = _redactionDal.GetAll(r => ids.Contains(r.Id) && !r.IsDeleted);
            return redactions == null
                ? new ErrorDataResult<IList<Redaction>>(RedactionConstants.DataNotGet)
                : new SuccessDataResult<IList<Redaction>>(redactions, RedactionConstants.DataGet);
        }

        public IDataResult<IList<Redaction>> GetAllByName(string name)
        {
            IList<Redaction> redactions = _redactionDal.GetAll(r => r.Name.Contains(name) && !r.IsDeleted);
            return redactions == null
                ? new ErrorDataResult<IList<Redaction>>(RedactionConstants.DataNotGet)
                : new SuccessDataResult<IList<Redaction>>(redactions, RedactionConstants.DataGet);
        }

        public IDataResult<IList<Redaction>> GetAllBySurname(string surname)
        {
            IList<Redaction> redactions = _redactionDal.GetAll(r => r.SurName.Contains(surname) && !r.IsDeleted);
            return redactions == null
                ? new ErrorDataResult<IList<Redaction>>(RedactionConstants.DataNotGet)
                : new SuccessDataResult<IList<Redaction>>(redactions, RedactionConstants.DataGet);
        }

        public IDataResult<IList<Redaction>> GetAllByIsDeleted()
        {
            return new SuccessDataResult<IList<Redaction>>(_redactionDal.GetAll(r => r.IsDeleted), RedactionConstants.DataGet);
        }

        public IDataResult<IList<Redaction>> GetAll()
        {
            return new SuccessDataResult<IList<Redaction>>(_redactionDal.GetAll(r => !r.IsDeleted), RedactionConstants.DataGet);
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