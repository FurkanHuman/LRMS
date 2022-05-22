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
        
        public CountryManager(ICountryDal countryDal)
        {
            _countryDal = countryDal;
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
            if (country == null)
                return new ErrorResult(CountryConstants.NotMatch);

            country.IsDeleted = true;
            _countryDal.Update(country);
            return new SuccessResult(CountryConstants.ShadowDeleteSuccess);
        }

        [ValidationAspect(typeof(ClountryValidator), Priority = 1)]
        public IResult Update(Country country)
        {
            IResult result = BusinessRules.Run(CountryControl(country));
            if (result != null)
                return result;

            _countryDal.Update(country);

            return new SuccessResult(CountryConstants.UpdateSuccess);
        }

        public IDataResult<List<Country>> GetAll()
        {
            return new SuccessDataResult<List<Country>>(_countryDal.GetAll().ToList(), CountryConstants.DataGet);
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
            int? countryNameId = _countryDal.Get(c => c.CountryName.ToLowerInvariant().Contains(country.CountryName.ToLowerInvariant()) && !c.IsDeleted).Id;
            int? countryCodeId = _countryDal.Get(c => c.CountryCode.ToLowerInvariant().Contains(country.CountryCode.ToLowerInvariant()) && !c.IsDeleted).Id;

            if (countryCodeId != countryNameId)
                return new ErrorResult(CountryConstants.CountryNameAndCodeNotMatch);

            return new SuccessResult();
        }
    }
}
