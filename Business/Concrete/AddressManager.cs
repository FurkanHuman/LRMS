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
    public class AddressManager : IAddressService
    {
        private readonly IAddressDal _addressDal;
        private readonly ICityService _cityService;
        private readonly ICountryService _countryService;

        public AddressManager(IAddressDal addressDal, ICityService cityService, ICountryService countryService)
        {
            _addressDal = addressDal;
            _cityService = cityService;
            _countryService = countryService;
        }

        [ValidationAspect(typeof(AddressValidator), Priority = 1)]
        public IResult Add(Address address)
        {
            var city = _cityService.GetById(address.City.Id);
            var country = _countryService.GetById(address.Country.Id);

            IResult result = BusinessRules.Run(city, country);
            if (result != null)
                return result;

            address.City = city.Data;
            address.Country = country.Data;
            address.IsDeleted = false;

            _addressDal.Add(address);
            return new SuccessResult(AddressConstants.AddSuccess);
        }

        public IResult Delete(Guid id)
        {
            Address address = _addressDal.Get(a => a.Id == id);
            if (address == null)
                return new ErrorResult(AddressConstants.NotMatch);

            _addressDal.Delete(address);
            return new SuccessResult(AddressConstants.DeleteSuccess);
        }

        public IResult ShadowDelete(Guid id)
        {
            Address address = _addressDal.Get(a => a.Id == id && !a.IsDeleted);
            if (address == null)
                return new ErrorResult(AddressConstants.NotMatch);

            address.IsDeleted = true;
            _addressDal.Update(address);
            return new SuccessResult(AddressConstants.ShadowDeleteSuccess);
        }

        [ValidationAspect(typeof(AddressValidator), Priority = 1)]
        public IResult Update(Address address)
        {
            IResult result = BusinessRules.Run(_cityService.GetById(address.City.Id), _countryService.GetById(address.Country.Id));
            if (result != null)
                return result;

            _addressDal.Update(address);
            return new SuccessResult(AddressConstants.UpdateSuccess);
        }

        public IDataResult<Address> GetById(Guid id)
        {
            Address address = _addressDal.Get(a => a.Id == id);
            return address == null
                ? new ErrorDataResult<Address>(AddressConstants.NotMatch)
                : new SuccessDataResult<Address>(address, AddressConstants.DataGet);
        }

        public IDataResult<IList<Address>> GetAllByIds(Guid[] ids)
        {
            IList<Address> addresses = _addressDal.GetAll(a => ids.Contains(a.Id) && !a.IsDeleted);
            return addresses == null
                ? new ErrorDataResult<IList<Address>>(AddressConstants.NotMatch)
                : new SuccessDataResult<IList<Address>>(addresses, AddressConstants.DataGet);
        }

        public IDataResult<IList<Address>> GetAllByCityId(int cityId)
        {
            IList<Address> addresses = _addressDal.GetAll(a => a.City.Id == cityId && !a.IsDeleted);
            return addresses == null
                ? new ErrorDataResult<IList<Address>>(AddressConstants.NotMatch)
                : new SuccessDataResult<IList<Address>>(addresses, AddressConstants.DataGet);
        }

        public IDataResult<IList<Address>> GetAllByCountryId(int countryId)
        {
            IList<Address> addresses = _addressDal.GetAll(a => a.Country.Id == countryId && !a.IsDeleted);
            return addresses == null
                ? new ErrorDataResult<IList<Address>>(AddressConstants.NotMatch)
                : new SuccessDataResult<IList<Address>>(addresses, AddressConstants.DataGet);
        }

        public IDataResult<IList<Address>> GetAllByGeoLocation(string geoLocation)
        {
            IList<Address> addresses = _addressDal.GetAll(a => a.GeoLocation == geoLocation && !a.IsDeleted);
            return addresses == null
                ? new ErrorDataResult<IList<Address>>(AddressConstants.NotMatch)
                : new SuccessDataResult<IList<Address>>(addresses, AddressConstants.DataGet);
        }

        public IDataResult<IList<Address>> GetAllByPostalCode(string postalCode)
        {
            IList<Address> addresses = _addressDal.GetAll(a => a.PostalCode == postalCode && !a.IsDeleted);
            return addresses == null
                ? new ErrorDataResult<IList<Address>>(AddressConstants.NotMatch)
                : new SuccessDataResult<IList<Address>>(addresses, AddressConstants.DataGet);
        }

        public IDataResult<IList<Address>> GetAllBySearchString(string searchStr)
        {
            IList<Address> addresses = _addressDal.GetAll(a => (a.AddressLine1 + a.AddressLine2).Contains(searchStr) && !a.IsDeleted);
            return addresses == null
                ? new ErrorDataResult<IList<Address>>(AddressConstants.NotMatch)
                : new SuccessDataResult<IList<Address>>(addresses, AddressConstants.DataGet);
        }

        public IDataResult<IList<Address>> GetAllByName(string name)
        {
            IList<Address> addresses = _addressDal.GetAll(a => a.AddressName.Contains(name));
            return addresses == null
                ? new ErrorDataResult<IList<Address>>(AddressConstants.NotMatch)
                : new SuccessDataResult<IList<Address>>(addresses, AddressConstants.DataGet);
        }

        public IDataResult<IList<Address>> GetAllByFilter(Expression<Func<Address, bool>>? filter = null)
        {
            return new SuccessDataResult<IList<Address>>(_addressDal.GetAll(filter), AddressConstants.DataGet);
        }

        public IDataResult<IList<Address>> GetAll()
        {
            return new SuccessDataResult<IList<Address>>(_addressDal.GetAll(a => !a.IsDeleted), AddressConstants.DataGet);
        }

        public IDataResult<IList<Address>> GetAllByIsDeleted()
        {
            return new SuccessDataResult<IList<Address>>(_addressDal.GetAll(a => a.IsDeleted), AddressConstants.DataGet);
        }
    }
}
