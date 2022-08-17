namespace Business.Concrete
{
    public class TechnicalPlaceholderManager : ITechnicalPlaceholderService
    {
        private readonly ITechnicalPlaceholderDal _placeholderDal;

        public TechnicalPlaceholderManager(ITechnicalPlaceholderDal placeholderDal)
        {
            _placeholderDal = placeholderDal;
        }

        [ValidationAspect(typeof(TechnicalPlaceholderValidator), Priority = 1)]
        public IResult Add(TechnicalPlaceholder technicalPlaceholder)
        {
            technicalPlaceholder.IsDeleted = false;
            _placeholderDal.Add(technicalPlaceholder);
            return new SuccessResult(TechnicalPlaceholderConstants.AddSuccess);
        }

        public IResult Delete(Guid id)
        {
            TechnicalPlaceholder technicalPlaceholder = _placeholderDal.Get(tph => tph.Id == id);
            if (technicalPlaceholder == null)
                return new ErrorResult(TechnicalNumberConstants.DataNoGet);

            _placeholderDal.Delete(technicalPlaceholder);
            return new SuccessResult(TechnicalPlaceholderConstants.DeleteSuccess);
        }

        public IResult ShadowDelete(Guid id)
        {
            TechnicalPlaceholder technicalPlaceholder = _placeholderDal.Get(tph => tph.Id == id);
            if (technicalPlaceholder == null)
                return new ErrorResult(TechnicalNumberConstants.DataNoGet);

            _placeholderDal.Update(technicalPlaceholder);
            return new SuccessResult(TechnicalPlaceholderConstants.DeleteSuccess);
        }

        [ValidationAspect(typeof(TechnicalPlaceholderValidator), Priority = 1)]
        public IResult Update(TechnicalPlaceholder technicalPlaceholder)
        {
            _placeholderDal.Update(technicalPlaceholder);
            return new SuccessResult(TechnicalPlaceholderConstants.UpdateSuccess);
        }

        public IDataResult<TechnicalPlaceholder> GetById(Guid id)
        {
            TechnicalPlaceholder technicalPlaceholder = _placeholderDal.Get(T => T.Id == id);
            return technicalPlaceholder == null
                ? new ErrorDataResult<TechnicalPlaceholder>(TechnicalPlaceholderConstants.DataNotGet)
                : new SuccessDataResult<TechnicalPlaceholder>(technicalPlaceholder, TechnicalPlaceholderConstants.DataGet);
        }

        public IDataResult<IList<TechnicalPlaceholder>> GetAllByIds(Guid[] ids)
        {
            IList<TechnicalPlaceholder> technicalPlaceholder = _placeholderDal.GetAll(t => ids.Contains(t.Id) && !t.IsDeleted);
            return technicalPlaceholder == null
                ? new ErrorDataResult<IList<TechnicalPlaceholder>>(TechnicalPlaceholderConstants.DataNotGet)
                : new SuccessDataResult<IList<TechnicalPlaceholder>>(technicalPlaceholder, TechnicalPlaceholderConstants.DataGet);
        }

        public IDataResult<IList<TechnicalPlaceholder>> GetAllByColumnCode(string columnCode)
        {
            IList<TechnicalPlaceholder> technicalPlaceholder = _placeholderDal.GetAll(t => t.ColumnCode.Contains(columnCode) && !t.IsDeleted);
            return technicalPlaceholder == null
                ? new ErrorDataResult<IList<TechnicalPlaceholder>>(TechnicalPlaceholderConstants.DataNotGet)
                : new SuccessDataResult<IList<TechnicalPlaceholder>>(technicalPlaceholder, TechnicalPlaceholderConstants.DataGet);
        }

        public IDataResult<IList<TechnicalPlaceholder>> GetAllByRowCode(string rowCode)
        {
            IList<TechnicalPlaceholder> technicalPlaceholder = _placeholderDal.GetAll(t => t.RowCode.Contains(rowCode) && !t.IsDeleted);
            return technicalPlaceholder == null
                ? new ErrorDataResult<IList<TechnicalPlaceholder>>(TechnicalPlaceholderConstants.DataNotGet)
                : new SuccessDataResult<IList<TechnicalPlaceholder>>(technicalPlaceholder, TechnicalPlaceholderConstants.DataGet);
        }

        public IDataResult<IList<TechnicalPlaceholder>> GetAllBySpecialLocation(string specialLocation)
        {
            IList<TechnicalPlaceholder> technicalPlaceholder = _placeholderDal.GetAll(t => t.SpecialLocation.Contains(specialLocation) && !t.IsDeleted);
            return technicalPlaceholder == null
                ? new ErrorDataResult<IList<TechnicalPlaceholder>>(TechnicalPlaceholderConstants.DataNotGet)
                : new SuccessDataResult<IList<TechnicalPlaceholder>>(technicalPlaceholder, TechnicalPlaceholderConstants.DataGet);
        }

        public IDataResult<IList<TechnicalPlaceholder>> GetAllByName(string name)
        {
            return new ErrorDataResult<IList<TechnicalPlaceholder>>(TechnicalPlaceholderConstants.Disabled);
        }

        public IDataResult<IList<TechnicalPlaceholder>> GetAllByFilter(Expression<Func<TechnicalPlaceholder, bool>>? filter = null)
        {
            return new SuccessDataResult<IList<TechnicalPlaceholder>>(_placeholderDal.GetAll(filter));
        }

        public IDataResult<IList<TechnicalPlaceholder>> GetAllByIsDeleted()
        {
            return new SuccessDataResult<IList<TechnicalPlaceholder>>(_placeholderDal.GetAll(ph => ph.IsDeleted));
        }

        public IDataResult<IList<TechnicalPlaceholder>> GetAll()
        {
            return new SuccessDataResult<IList<TechnicalPlaceholder>>(_placeholderDal.GetAll(ph => !ph.IsDeleted));
        }
    }
}
