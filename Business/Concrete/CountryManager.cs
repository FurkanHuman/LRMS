using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Business;
using Core.Utilities.Result.Abstract;
using Core.Utilities.Result.Concrete;
using DataAccess.Abstract;
using Entities.Concrete.Infos;

namespace Business.Concrete
{
    public class CountryManager : ICountryService
    {
        private readonly ICountryDal _countryDal;
        private readonly ICityDal _cityDal;

        public CountryManager(ICountryDal countryDal, ICityDal cityDal)
        {
            _countryDal = countryDal;
            _cityDal = cityDal;
        }

        [ValidationAspect(typeof(ClountryValidator), Priority = 1)]
        public IResult Add(Country country)
        {
            IResult result = BusinessRules.Run(CountryControl(country));
            if (result != null)
                return result;

            country.IsDeleted = false;

            _countryDal.Add(country);
            return new SuccessResult(CountryConstants.AddSuccess);
        }

        public IResult AddCities(int countryId, int[] cityIds)
        {
            Country country = _countryDal.Get(c => c.Id.Equals(countryId) && !c.IsDeleted);

            if (country != null)
                return new ErrorResult(CountryConstants.NotMatch);

            IResult result = BusinessRules.Run(CountryControl(country), CityControl(cityIds));
            if (result != null)
                return result;

            List<City> cities = new();

            foreach (int cId in cityIds)
            {
                City city = _cityDal.Get(c => c.Id == cId);
                cities.Add(city);
            }

            country.Cities = cities;
            _countryDal.Add(country);
            return new SuccessResult(CountryConstants.AddSuccess);
        }

        public IResult Delete(int conutryId)
        {
            Country country = _countryDal.Get(c => c.Id.Equals(conutryId) && !c.IsDeleted);
            if (country == null)
                return new ErrorResult(CountryConstants.NotMatch);

            _countryDal.Delete(country);
            return new SuccessResult(CountryConstants.DeleteSuccess);
        }

        public IResult ShadowDelete(int conutryId)
        {
            Country country = _countryDal.Get(c => c.Id.Equals(conutryId) && !c.IsDeleted);
            return country != null
                ? new ErrorResult(CountryConstants.NotMatch)
                : new SuccessResult(CountryConstants.ShadowDeleteSuccess);
        }

        [ValidationAspect(typeof(ClountryValidator), Priority = 1)]
        public IResult Update(int oldCountryId, Country newCountry)
        {
            IResult result = BusinessRules.Run(CountryControl(newCountry));
            if (result != null)
                return result;

            Country oldCountry = _countryDal.Get(c => c.Id == oldCountryId && !c.IsDeleted);
            if (oldCountry == null)
                return new ErrorResult(CountryConstants.NotMatch);

            newCountry.Id = oldCountryId;

            _countryDal.Update(newCountry);

            return new SuccessResult(CountryConstants.UpdateSuccess);
        }

        public IDataResult<List<Country>> GetAll()
        {
            return new SuccessDataResult<List<Country>>(_countryDal.GetAll().ToList(), CountryConstants.DataGet);

        }

        public IDataResult<List<City>> GetByCities(int countryId)
        {
            List<City> cities = _countryDal.Get(c => c.Id == countryId && !c.IsDeleted).Cities;
            return cities == null
                ? new ErrorDataResult<List<City>>(CountryConstants.NotMatch)
                : new SuccessDataResult<List<City>>(cities, CountryConstants.DataGet);
        }

        public IDataResult<Country> GetByCountry(int countryId)
        {
            Country country = _countryDal.Get(c => c.Id == countryId && !c.IsDeleted);
            return country == null
                ? new ErrorDataResult<Country>(CountryConstants.DataNotGet)
                : new SuccessDataResult<Country>(country, CountryConstants.DataGet);
        }

        private IResult CountryControl(Country country)
        {
            // Todo fix it. #issues, brain melted compare system.


            int? countryNameId = _countryDal.Get(c => c.CountryName.ToLowerInvariant().Contains(country.CountryName.ToLowerInvariant()) && !c.IsDeleted).Id;
            int? countryCodeId = _countryDal.Get(c => c.CountryCode.ToLowerInvariant().Contains(country.CountryCode.ToLowerInvariant()) && !c.IsDeleted).Id;
            int? citiesId = _countryDal.Get(c => c.Cities.Equals(country.Cities) && !c.IsDeleted).Id;

            if (countryCodeId != countryNameId || countryCodeId != citiesId || countryNameId != citiesId)
                return new ErrorResult(CountryConstants.CountryNameAndCodeAndCitiesNotMatch);

            return new ErrorResult(CountryConstants.Disabled + " CountryControl()");
        }

        private IResult CityControl(City city)
        {
            City cityControl = _cityDal.Get(c => c == city && !c.IsDeleted);

            if (cityControl == null)
                return new ErrorResult(CityConstants.CityNotFound);

            return new SuccessResult();
        }

        private IResult CityControl(int[] Cities)
        {
            foreach (int cId in Cities)
            {
                City city = _cityDal.Get(c => c.Id == cId && !c.IsDeleted);

                if (city == null || !CityControl(city).Success)
                    return new ErrorResult(CityConstants.CityNotFound);
            }

            return new SuccessResult();
        }

    }
}
