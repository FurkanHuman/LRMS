namespace Business.Concrete
{   // todo: return a code
    public class DimensionManager : IDimensionService
    {
        private readonly IDimensionDal _dimensionDal;

        public DimensionManager(IDimensionDal dimensionDal)
        {
            _dimensionDal = dimensionDal;
        }

        [ValidationAspect(typeof(DimensionValidator), Priority = 1)]
        public IResult Add(Dimension dimension)
        {
            IResult? result = BusinessRules.Run(DimensionExist(dimension));
            if (result != null)
                return result;

            _dimensionDal.Add(dimension);
            return new SuccessResult(DimensionConstants.AddSuccess);
        }

        public IResult Delete(Guid id)
        {
            Dimension? dimension = _dimensionDal.Get(d => d.Id == id);
            if (dimension == null)
                return new ErrorResult(DimensionConstants.NotMatch);

            _dimensionDal.Delete(dimension);
            return new SuccessResult(DimensionConstants.DeleteSuccess);
        }

        public IResult ShadowDelete(Guid id)
        {
            Dimension? dimension = _dimensionDal.Get(d => d.Id == id && !d.IsDeleted);
            if (dimension == null)
                return new ErrorResult(DimensionConstants.NotMatch);

            dimension.IsDeleted = true;
            _dimensionDal.Update(dimension);
            return new SuccessResult(DimensionConstants.DeleteSuccess);
        }

        [ValidationAspect(typeof(DimensionValidator), Priority = 1)]
        public IResult Update(Dimension dimension)
        {
            IResult? result = BusinessRules.Run(DimensionExist(dimension));
            if (result != null)
                return result;

            _dimensionDal.Update(dimension);
            return new SuccessResult(DimensionConstants.UpdateSuccess);
        }

        public IDataResult<Dimension> GetByDimension(Dimension dimension)
        {
            Dimension dimensionGet = _dimensionDal.Get(d =>
            d.Width.Equals(dimension) &&
            d.Length.Equals(dimension.Length) &&
            d.Height.Equals(dimension.Height));

            return dimensionGet == null
                ? new ErrorDataResult<Dimension>(DimensionConstants.DataNotGet)
                : new SuccessDataResult<Dimension>(dimensionGet, DimensionConstants.DataGet);
        }
        public IDataResult<IList<Dimension>> GetAllByXYZMinMax(double minXmm, double? maxXmm, double minYmm, double? maxYmm, double minZmm, double? maxZmm)
        {
            IList<Dimension> dimensions = _dimensionDal.GetAll(d =>
            d.Width >= minXmm && d.Width <= maxXmm &&
            d.Length >= minYmm && d.Length <= maxYmm &&
            d.Height >= minZmm && d.Height <= maxZmm &&
            !d.IsDeleted);

            return dimensions.Count == 0
                ? new ErrorDataResult<IList<Dimension>>(DimensionConstants.DataNotGet)
                : new SuccessDataResult<IList<Dimension>>(dimensions, DimensionConstants.DataGet);
        }

        public IDataResult<IList<Dimension>> GetAllByXandY(double xMM, double yMM)
        {
            IList<Dimension> dimensions = _dimensionDal.GetAll(d => d.Width.Equals(xMM) && d.Length.Equals(yMM) && !d.IsDeleted);

            return dimensions == null
                ? new ErrorDataResult<IList<Dimension>>(DimensionConstants.DataNotGet)
                : new SuccessDataResult<IList<Dimension>>(dimensions, DimensionConstants.DataGet);
        }

        public IDataResult<IList<Dimension>> GetAllByYandZ(double yMM, double zMM)
        {
            IList<Dimension> dimensions = _dimensionDal.GetAll(d => d.Length.Equals(yMM) && d.Height.Equals(zMM) && !d.IsDeleted);

            return dimensions == null
                ? new ErrorDataResult<IList<Dimension>>(DimensionConstants.DataNotGet)
                : new SuccessDataResult<IList<Dimension>>(dimensions, DimensionConstants.DataGet);
        }

        public IDataResult<IList<Dimension>> GetAllByZandX(double zMM, double xMM)
        {
            IList<Dimension> dimensions = _dimensionDal.GetAll(d => d.Height.Equals(zMM) && d.Width.Equals(xMM) && !d.IsDeleted);

            return dimensions == null
                ? new ErrorDataResult<IList<Dimension>>(DimensionConstants.DataNotGet)
                : new SuccessDataResult<IList<Dimension>>(dimensions, DimensionConstants.DataGet);
        }

        public IDataResult<Dimension> GetById(Guid id)
        {
            Dimension dimensionGet = _dimensionDal.Get(d => d.Id == id);
            return dimensionGet == null
                ? new ErrorDataResult<Dimension>(DimensionConstants.DataNotGet)
                : new SuccessDataResult<Dimension>(dimensionGet, DimensionConstants.DataGet);
        }

        public IDataResult<IList<Dimension>> GetAllByIds(Guid[] ids)
        {
            IList<Dimension> dimension = _dimensionDal.GetAll(d => ids.Contains(d.Id) && !d.IsDeleted);

            return dimension == null
                ? new ErrorDataResult<IList<Dimension>>(DimensionConstants.DataNotGet)
                : new SuccessDataResult<IList<Dimension>>(dimension, DimensionConstants.DataGet);
        }

        public IDataResult<IList<Dimension>> GetAllByX(double xMM)
        {
            IList<Dimension> dimensionXmm = _dimensionDal.GetAll(d => d.Width.Equals(xMM));

            return dimensionXmm == null
                ? new ErrorDataResult<IList<Dimension>>(DimensionConstants.DataNotGet)
                : new SuccessDataResult<IList<Dimension>>(dimensionXmm, DimensionConstants.DataGet);
        }

        public IDataResult<IList<Dimension>> GetAllByY(double yMM)
        {
            IList<Dimension> dimensionYmm = _dimensionDal.GetAll(d => d.Height.Equals(yMM));

            return dimensionYmm == null
                ? new ErrorDataResult<IList<Dimension>>(DimensionConstants.DataNotGet)
                : new SuccessDataResult<IList<Dimension>>(dimensionYmm, DimensionConstants.DataGet);
        }

        public IDataResult<IList<Dimension>> GetAllByZ(double zMM)
        {
            IList<Dimension> dimensionZmm = _dimensionDal.GetAll(d => d.Length.Equals(zMM));

            return dimensionZmm == null
                ? new ErrorDataResult<IList<Dimension>>(DimensionConstants.DataNotGet)
                : new SuccessDataResult<IList<Dimension>>(dimensionZmm, DimensionConstants.DataGet);
        }

        public IDataResult<IList<Dimension>> GetAllByName(string name)
        {
            IList<Dimension> dimensions = _dimensionDal.GetAll(d => d.Name.Contains(name));

            return dimensions == null
                ? new ErrorDataResult<IList<Dimension>>(DimensionConstants.DataNotGet)
                : new SuccessDataResult<IList<Dimension>>(dimensions, DimensionConstants.DataGet);
        }

        public IDataResult<IList<Dimension>> GetAllByFilter(Expression<Func<Dimension, bool>>? filter = null)
        {
            return new SuccessDataResult<IList<Dimension>>(_dimensionDal.GetAll(filter), DimensionConstants.DataGet);
        }

        public IDataResult<IList<Dimension>> GetAllByIsDeleted()
        {
            return new SuccessDataResult<IList<Dimension>>(_dimensionDal.GetAll(d => d.IsDeleted), DimensionConstants.DataGet);
        }

        public IDataResult<IList<Dimension>> GetAll()
        {
            return new SuccessDataResult<IList<Dimension>>(_dimensionDal.GetAll(), DimensionConstants.DataGet);
        }

        private IResult DimensionExist(Dimension dimension)
        {
            bool dimensionCheck = _dimensionDal.GetAll(d =>
             d.Length.Equals(dimension.Length) &&
             d.Height.Equals(dimension.Height) &&
             d.Width.Equals(dimension.Width)).Any();

            return dimensionCheck
                ? new SuccessResult()
                : new ErrorResult(DimensionConstants.AlreadyExists);
        }
    }
}