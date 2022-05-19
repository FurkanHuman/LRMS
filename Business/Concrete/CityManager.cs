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
    public class CityManager : ICityService
    {
        private readonly ICityDal _cityDal;

        public CityManager(ICityDal cityDal)
        {
            _cityDal = cityDal;
        }

        [ValidationAspect(typeof(CityValidator), Priority = 1)]
        public IResult Add(string cityName)
        {
            IResult result = BusinessRules.Run(CheckCityByExists(cityName));
            if (result != null)
                return result;
            City city = new() { CityName = cityName, IsDeleted = false };

            _cityDal.Add(city);

            return new SuccessResult(CityConstants.AddSuccess);
        }

        public IResult Delete(int cityId)
        {
            IResult result = BusinessRules.Run(CheckCityIdByExists(cityId));
            if (result != null)
                return result;

            City city = new() { Id = cityId };

            _cityDal.Delete(city);
            return new SuccessResult(CityConstants.DeleteSuccess);
        }

        public IDataResult<City> Get(int cityId)
        {
            City city = _cityDal.Get(c => c.Id == cityId && c.IsDeleted.Equals(false) && c.IsDeleted.Equals(null));
            return city == null
                ? new SuccessDataResult<City>(city, CityConstants.DataGet)
                : new ErrorDataResult<City>(CityConstants.CityNotFound);
        }

        public IDataResult<List<City>> GetAll()
        {
            return new SuccessDataResult<List<City>>(_cityDal.GetAll(c => c.IsDeleted.Equals(false) && c.IsDeleted.Equals(null)).ToList<City>(), CityConstants.DataGet);
        }

        public IDataResult<List<City>> GetByFilterLists(Expression<Func<City, bool>>? filter = null)
        {   // Danger Methot
            return new SuccessDataResult<List<City>>(_cityDal.GetAll(filter).ToList<City>(), CityConstants.DataGet);
        }

        public IResult ShadowDelete(int cityId)
        {
            IResult result = BusinessRules.Run(CheckCityIdByExists(cityId));
            if (result != null)
                return result;

            City city = new() { Id = cityId, IsDeleted = true };

            _cityDal.Update(city);
            return new SuccessResult(CityConstants.ShadowDeleteSuccess);
        }

        [ValidationAspect(typeof(CityValidator), Priority = 1)]
        public IResult Update(int cityId, string cityName)
        {
            IResult result = BusinessRules.Run(CheckCityIdAndNameByExists(cityId, cityName));
            if (result != null)
                return result;
            City city = new() { CityName = cityName, IsDeleted = false };

            _cityDal.Update(city);

            return new SuccessResult(CityConstants.UpdateSuccess);
        }

        private IResult CheckCityIdAndNameByExists(int cityId, string cityName)
        {
            City cityExist = _cityDal.Get(c => c.CityName.ToLowerInvariant().Contains(cityName.ToLowerInvariant())
            && c.Id.Equals(cityId));
            return cityExist == null
                ? new SuccessResult()
                : new ErrorResult(CityConstants.NoTMatch);
        }

        private IResult CheckCityByExists(string cityName)
        {
            City cityExist = _cityDal.Get(c => c.CityName.ToLowerInvariant().Contains(cityName.ToLowerInvariant()));
            return cityExist == null
                ? new SuccessResult()
                : new ErrorResult(CityConstants.CityExist);
        }

        private IResult CheckCityIdByExists(int cityId)
        {
            City cityExist = _cityDal.Get(c => c.Id == cityId);
            return cityExist == null
                ? new SuccessResult()
                : new ErrorResult(CityConstants.CityNotFound);
        }
    }
}
