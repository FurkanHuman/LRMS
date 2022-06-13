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
            Dimension? dimensionGet = _dimensionDal.Get(d =>
            d.Width.Equals(dimension) &&
            d.Length.Equals(dimension.Length) &&
            d.Height.Equals(dimension.Height));

            return dimensionGet == null
                ? new ErrorDataResult<Dimension>(DimensionConstants.DataNotGet)
                : new SuccessDataResult<Dimension>(dimensionGet, DimensionConstants.DataGet);
        }
        public IDataResult<List<Dimension>> GetByXYZMinMax(double minXmm, double? maxXmm, double minYmm, double? maxYmm, double minZmm, double? maxZmm)
        {
            List<Dimension> dimensions = _dimensionDal.GetAll(d =>
            d.Width >= minXmm && d.Width <= maxXmm &&
            d.Length >= minYmm && d.Length <= maxYmm &&
            d.Height >= minZmm && d.Height <= maxZmm &&
            !d.IsDeleted).ToList();

            return dimensions.Count == 0
                ? new ErrorDataResult<List<Dimension>>(DimensionConstants.DataNotGet)
                : new SuccessDataResult<List<Dimension>>(dimensions, DimensionConstants.DataGet);
        }

        public IDataResult<List<Dimension>> GetByXandY(double xMM, double yMM)
        {
            List<Dimension> dimensions = _dimensionDal.GetAll(d => d.Width.Equals(xMM) && d.Length.Equals(yMM) && !d.IsDeleted).ToList();

            return dimensions == null
                ? new ErrorDataResult<List<Dimension>>(DimensionConstants.DataNotGet)
                : new SuccessDataResult<List<Dimension>>(dimensions, DimensionConstants.DataGet);
        }

        public IDataResult<List<Dimension>> GetByYandZ(double yMM, double zMM)
        {
            List<Dimension> dimensions = _dimensionDal.GetAll(d => d.Length.Equals(yMM) && d.Height.Equals(zMM) && !d.IsDeleted).ToList();

            return dimensions == null
                ? new ErrorDataResult<List<Dimension>>(DimensionConstants.DataNotGet)
                : new SuccessDataResult<List<Dimension>>(dimensions, DimensionConstants.DataGet);
        }

        public IDataResult<List<Dimension>> GetByZandX(double zMM, double xMM)
        {
            List<Dimension> dimensions = _dimensionDal.GetAll(d => d.Height.Equals(zMM) && d.Width.Equals(xMM) && !d.IsDeleted).ToList();

            return dimensions == null
                ? new ErrorDataResult<List<Dimension>>(DimensionConstants.DataNotGet)
                : new SuccessDataResult<List<Dimension>>(dimensions, DimensionConstants.DataGet);
        }

        public IDataResult<Dimension> GetById(Guid id)
        {
            Dimension? dimensionGet = _dimensionDal.Get(d => d.Id == id);
            return dimensionGet == null
                ? new ErrorDataResult<Dimension>(DimensionConstants.DataNotGet)
                : new SuccessDataResult<Dimension>(dimensionGet, DimensionConstants.DataGet);
        }

        public IDataResult<List<Dimension>> GetByX(double xMM)
        {
            List<Dimension> dimensionXmm = _dimensionDal.GetAll(d => d.Width.Equals(xMM)).ToList();

            return dimensionXmm == null
                ? new ErrorDataResult<List<Dimension>>(DimensionConstants.DataNotGet)
                : new SuccessDataResult<List<Dimension>>(dimensionXmm, DimensionConstants.DataGet);
        }

        public IDataResult<List<Dimension>> GetByY(double yMM)
        {
            List<Dimension> dimensionYmm = _dimensionDal.GetAll(d => d.Height.Equals(yMM)).ToList();

            return dimensionYmm == null
                ? new ErrorDataResult<List<Dimension>>(DimensionConstants.DataNotGet)
                : new SuccessDataResult<List<Dimension>>(dimensionYmm, DimensionConstants.DataGet);
        }

        public IDataResult<List<Dimension>> GetByZ(double zMM)
        {
            List<Dimension> dimensionZmm = _dimensionDal.GetAll(d => d.Length.Equals(zMM)).ToList();

            return dimensionZmm == null
                ? new ErrorDataResult<List<Dimension>>(DimensionConstants.DataNotGet)
                : new SuccessDataResult<List<Dimension>>(dimensionZmm, DimensionConstants.DataGet);
        }

        public IDataResult<List<Dimension>> GetByNames(string name)
        {
            List<Dimension> dimensions = _dimensionDal.GetAll(d => d.Name.Contains(name)).ToList();

            return dimensions == null
                ? new ErrorDataResult<List<Dimension>>(DimensionConstants.DataNotGet)
                : new SuccessDataResult<List<Dimension>>(dimensions, DimensionConstants.DataGet);
        }

        public IDataResult<List<Dimension>> GetByFilterLists(Expression<Func<Dimension, bool>>? filter = null)
        {
            return new SuccessDataResult<List<Dimension>>(_dimensionDal.GetAll(filter).ToList(), DimensionConstants.DataGet);
        }

        public IDataResult<List<Dimension>> GetAllBySecrets()
        {
            return new SuccessDataResult<List<Dimension>>(_dimensionDal.GetAll(d => d.IsDeleted).ToList(), DimensionConstants.DataGet);
        }

        public IDataResult<List<Dimension>> GetAll()
        {
            return new SuccessDataResult<List<Dimension>>(_dimensionDal.GetAll().ToList(), DimensionConstants.DataGet);
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