using Business.Abstract;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Business;
using Core.Utilities.Result.Abstract;
using Core.Utilities.Result.Concrete;
using DataAccess.Abstract;
using Entities.Concrete.Infos;

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
            IResult result = BusinessRules.Run(DimensionExist(dimension));
            if (result != null)
                return new ErrorResult();

            _dimensionDal.Add(dimension);
            return new SuccessResult();
        }

        public IResult Delete(Dimension dimension)
        {
            _dimensionDal.Delete(dimension);
            return new SuccessResult();
        }

        public IResult Update(Dimension dimension)
        {
            IResult result = BusinessRules.Run(DimensionExist(dimension));
            if (result != null)
                return new ErrorResult();

            _dimensionDal.Update(dimension);
            return new SuccessResult();
        }

        public IDataResult<Dimension> Get(Dimension dimension)
        {
            Dimension dimensionGet = _dimensionDal.Get(d =>
            d.Width.Equals(dimension) &&
            d.Length.Equals(dimension.Length) &&
            d.Height.Equals(dimension.Height));

            return dimensionGet == null
                ? new ErrorDataResult<Dimension>()
                : new SuccessDataResult<Dimension>();
        }

        public IDataResult<List<Dimension>> GetAll()
        {
            return new SuccessDataResult<List<Dimension>>(_dimensionDal.GetAll().ToList());
        }

        public IDataResult<Dimension> GetById(int id)
        {
            Dimension dimensionGet = _dimensionDal.Get(d => d.Id.Equals(id));
            return dimensionGet == null
                ? new ErrorDataResult<Dimension>()
                : new SuccessDataResult<Dimension>(dimensionGet);
        }

        public IDataResult<List<Dimension>> GetByX(double xMM)
        {
            List<Dimension> dimensionXmm = _dimensionDal.GetAll(d => d.Width.Equals(xMM)).ToList();

            return dimensionXmm == null
                ? new ErrorDataResult<List<Dimension>>()
                : new SuccessDataResult<List<Dimension>>(dimensionXmm);
        }

        public IDataResult<List<Dimension>> GetByY(double yMM)
        {
            List<Dimension> dimensionYmm = _dimensionDal.GetAll(d => d.Height.Equals(yMM)).ToList();

            return dimensionYmm == null
                ? new ErrorDataResult<List<Dimension>>()
                : new SuccessDataResult<List<Dimension>>(dimensionYmm);
        }

        public IDataResult<List<Dimension>> GetByZ(double zMM)
        {
            List<Dimension> dimensionZmm = _dimensionDal.GetAll(d => d.Length.Equals(zMM)).ToList();

            return dimensionZmm == null
                ? new ErrorDataResult<List<Dimension>>()
                : new SuccessDataResult<List<Dimension>>(dimensionZmm);
        }

        private IResult DimensionExist(Dimension dimension)
        {
            bool dimensionCheck = _dimensionDal.GetAll(d =>
             d.Length.Equals(dimension.Length) &&
             d.Height.Equals(dimension.Height) &&
             d.Width.Equals(dimension.Width)).Any();

            return dimensionCheck
                ? new SuccessResult()
                : new ErrorResult();
        }
    }
}
