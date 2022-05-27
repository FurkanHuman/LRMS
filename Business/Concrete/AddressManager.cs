﻿using Business.Abstract;
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
            IResult result = BusinessRules.Run(_cityService.Get(address.City.Id), _countryService.GetByCountry(address.Country.Id));
            if (result != null)
                return result;

            address.IsDeleted = false;
            _addressDal.Add(address);
            return new SuccessResult(AddressConstants.AddSuccess);
        }

        public IResult Delete(Guid addressGId)
        {
            Address address = _addressDal.Get(a => a.Id == addressGId && !a.IsDeleted);
            if (address == null)
                return new ErrorResult(AddressConstants.NotMatch);

            _addressDal.Delete(address);
            return new SuccessResult(AddressConstants.DeleteSuccess);
        }

        public IResult ShadowDelete(Guid addressGId)
        {
            Address address = _addressDal.Get(a => a.Id == addressGId && !a.IsDeleted);
            if (address == null)
                return new ErrorResult(AddressConstants.NotMatch);

            address.IsDeleted = true;
            _addressDal.Update(address);
            return new SuccessResult(AddressConstants.ShadowDeleteSuccess);
        }

        [ValidationAspect(typeof(AddressValidator), Priority = 1)]
        public IResult Update(Address address)
        {
            IResult result = BusinessRules.Run(_cityService.Get(address.City.Id), _countryService.GetByCountry(address.Country.Id));
            if (result != null)
                return result;

            address.IsDeleted = false;
            _addressDal.Update(address);
            return new SuccessResult(AddressConstants.UpdateSuccess);
        }

        public IDataResult<List<Address>> GetAll()
        {
            return new SuccessDataResult<List<Address>>(_addressDal.GetAll().ToList(), AddressConstants.DataGet);
        }

        public IDataResult<Address> GetById(Guid guid)
        {
            Address address = _addressDal.Get(a => a.Id == guid && !a.IsDeleted);

            return address == null
                ? new ErrorDataResult<Address>(AddressConstants.NotMatch)
                : new SuccessDataResult<Address>(address, AddressConstants.DataGet);
        }

        public IDataResult<List<Address>> GetByCityId(int cityId)
        {
            List<Address> addresses = _addressDal.GetAll(a => a.City.Id == cityId && !a.IsDeleted).ToList();
            return addresses == null
                ? new ErrorDataResult<List<Address>>(AddressConstants.NotMatch)
                : new SuccessDataResult<List<Address>>(addresses, AddressConstants.DataGet);
        }

        public IDataResult<List<Address>> GetByCountryId(int countryId)
        {
            List<Address> addresses = _addressDal.GetAll(a => a.Country.Id == countryId && !a.IsDeleted).ToList();
            return addresses == null
                ? new ErrorDataResult<List<Address>>(AddressConstants.NotMatch)
                : new SuccessDataResult<List<Address>>(addresses, AddressConstants.DataGet);
        }

        public IDataResult<List<Address>> GetByGeoLocation(string geoLocation)
        {
            List<Address> addresses = _addressDal.GetAll(a => a.GeoLocation == geoLocation && !a.IsDeleted).ToList();
            return addresses == null
                ? new ErrorDataResult<List<Address>>(AddressConstants.NotMatch)
                : new SuccessDataResult<List<Address>>(addresses, AddressConstants.DataGet);
        }

        public IDataResult<List<Address>> GetByPostalCode(string postalCode)
        {
            List<Address> addresses = _addressDal.GetAll(a => a.PostalCode == postalCode && !a.IsDeleted).ToList();
            return addresses == null
                ? new ErrorDataResult<List<Address>>(AddressConstants.NotMatch)
                : new SuccessDataResult<List<Address>>(addresses, AddressConstants.DataGet);
        }

        public IDataResult<List<Address>> GetBySearchString(string searchStr)
        {
            List<Address> addresses = _addressDal.GetAll(a => a.AddressLine1 + a.AddressLine2 == searchStr && !a.IsDeleted).ToList();
            return addresses == null
                ? new ErrorDataResult<List<Address>>(AddressConstants.NotMatch)
                : new SuccessDataResult<List<Address>>(addresses, AddressConstants.DataGet);
        }
    }
}
