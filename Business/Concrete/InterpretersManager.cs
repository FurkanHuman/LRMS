namespace Business.Concrete
{
    public class InterpretersManager : IInterpretersService
    {
        private readonly IInterpretersDal _interpretersDal;

        public InterpretersManager(IInterpretersDal interpretersDal)
        {
            _interpretersDal = interpretersDal;
        }

        [ValidationAspect(typeof(InterpretersValidator), Priority = 1)]
        public IResult Add(Interpreters entity)
        {
            IResult result = BusinessRules.Run(InterpretersNameOrSurnameExist(entity));
            if (result != null)
                return result;

            entity.IsDeleted = false;
            _interpretersDal.Add(entity);
            return new SuccessResult(InterpretersConstants.AddSuccess);
        }

        public IResult Delete(Guid id)
        {
            Interpreters interpreters = _interpretersDal.Get(p => p.Id == id);
            if (interpreters == null)
                return new SuccessResult(InterpretersConstants.DataNotGet);

            _interpretersDal.Delete(interpreters);
            return new SuccessResult(InterpretersConstants.DeleteSuccess);
        }

        public IResult ShadowDelete(Guid id)
        {
            Interpreters interpreters = _interpretersDal.Get(i => i.Id == id && !i.IsDeleted);
            if (interpreters == null)
                return new ErrorResult(InterpretersConstants.NotMatch);

            interpreters.IsDeleted = true;
            _interpretersDal.Update(interpreters);
            return new SuccessResult(InterpretersConstants.DataGet);
        }

        [ValidationAspect(typeof(InterpretersValidator), Priority = 1)]
        public IResult Update(Interpreters entity)
        {
            _interpretersDal.Update(entity);
            return new SuccessResult(InterpretersConstants.UpdateSuccess);
        }

        public IDataResult<Interpreters> GetById(Guid id)
        {
            Interpreters interpreters = _interpretersDal.Get(i => i.Id == id);
            return interpreters == null
                ? new ErrorDataResult<Interpreters>(InterpretersConstants.DataNotGet)
                : new SuccessDataResult<Interpreters>(interpreters, InterpretersConstants.DataGet);
        }

        public IDataResult<IList<Interpreters>> GetAllByIds(Guid[] ids)
        {
            IList<Interpreters> interpreters = _interpretersDal.GetAll(n => ids.Contains(n.Id) && !n.IsDeleted);
            return interpreters == null
                ? new ErrorDataResult<IList<Interpreters>>(InterpretersConstants.DataNotGet)
                : new SuccessDataResult<IList<Interpreters>>(interpreters, InterpretersConstants.DataGet);
        }

        public IDataResult<IList<Interpreters>> GetAllByName(string name)
        {
            IList<Interpreters> interpreters = _interpretersDal.GetAll(n => n.Name.Contains(name) && !n.IsDeleted);
            return interpreters == null
                ? new ErrorDataResult<IList<Interpreters>>(InterpretersConstants.DataNotGet)
                : new SuccessDataResult<IList<Interpreters>>(interpreters, InterpretersConstants.DataGet);
        }

        public IDataResult<IList<Interpreters>> GetAllBySurname(string surname)
        {
            IList<Interpreters> interpreters = _interpretersDal.GetAll(n => n.SurName.Contains(surname) && !n.IsDeleted);
            return interpreters == null
                ? new ErrorDataResult<IList<Interpreters>>(InterpretersConstants.DataNotGet)
                : new SuccessDataResult<IList<Interpreters>>(interpreters, InterpretersConstants.DataGet);
        }

        public IDataResult<IList<Interpreters>> GetAllByWhichToLanguage(string langName)
        {
            IList<Interpreters> interpreterss = _interpretersDal.GetAll(l => l.WhichToLanguage.Contains(langName, StringComparison.CurrentCultureIgnoreCase) && !l.IsDeleted);
            return interpreterss == null
            ? new ErrorDataResult<IList<Interpreters>>(InterpretersConstants.DataNotGet)
            : new SuccessDataResult<IList<Interpreters>>(interpreterss, InterpretersConstants.DataGet);
        }

        public IDataResult<IList<Interpreters>> GetAllByFilter(Expression<Func<Interpreters, bool>>? filter = null)
        {
            return new SuccessDataResult<IList<Interpreters>>(_interpretersDal.GetAll(filter), InterpretersConstants.DataGet);
        }

        public IDataResult<IList<Interpreters>> GetAllByIsDeleted()
        {
            return new SuccessDataResult<IList<Interpreters>>(_interpretersDal.GetAll(i => i.IsDeleted), InterpretersConstants.DataGet);
        }

        public IDataResult<IList<Interpreters>> GetAll()
        {
            return new SuccessDataResult<IList<Interpreters>>(_interpretersDal.GetAll(i => i.IsDeleted), InterpretersConstants.DataGet);
        }

        private IResult InterpretersNameOrSurnameExist(Interpreters entity)
        {
            bool result = _interpretersDal.GetAll(w => w.Name.Equals(entity.Name)
            && w.SurName.Equals(entity.SurName)).Any();
            return result
                ? new ErrorResult(InterpretersConstants.NameOrSurnameExists)
                : new SuccessResult(InterpretersConstants.DataGet);
        }
    }
}
