namespace Business.Concrete
{
    public class AddressManager : IAddressService
    {
        private readonly IAddressDal _addressDal;
        public AddressManager(IAddressDal addressDal)
        {
            _addressDal = addressDal;
        }

        [ValidationAspect(typeof(AddressValidator), Priority = 1)]
        public IResult Add(Address address)
        {
            //var city = _facadeService.CityService().GetById(address.City.Id);
            //var country = _facadeService.CountryService().GetById(address.Country.Id);

            IResult result = BusinessRules.Run(/*city, country*/);
            if (result != null)
                return result;

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
            //var city = _facadeService.CityService().GetById(address.City.Id);
            //var country = _facadeService.CountryService().GetById(address.Country.Id);

            IResult result = BusinessRules.Run(/*city, country*/);
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

        public IDataResult<AddressDto> DtoGetById(Guid id)
        {
            AddressDto addressDto = _addressDal.DtoGet(a => a.Id == id);
            return addressDto == null
                ? new ErrorDataResult<AddressDto>(AddressConstants.NotMatch)
                : new SuccessDataResult<AddressDto>(addressDto, AddressConstants.DataGet);
        }

        public IDataResult<IList<Address>> GetAllByIds(Guid[] ids)
        {
            IList<Address> addresses = _addressDal.GetAll(a => ids.Contains(a.Id) && !a.IsDeleted);
            return addresses == null
                ? new ErrorDataResult<IList<Address>>(AddressConstants.NotMatch)
                : new SuccessDataResult<IList<Address>>(addresses, AddressConstants.DataGet);
        }

        public IDataResult<IList<AddressDto>> DtoGetAllByIds(Guid[] ids)
        {
            IList<AddressDto> addressDtos = _addressDal.DtoGetAll(a => ids.Contains(a.Id) && !a.IsDeleted);
            return addressDtos == null
                ? new ErrorDataResult<IList<AddressDto>>(AddressConstants.NotMatch)
                : new SuccessDataResult<IList<AddressDto>>(addressDtos, AddressConstants.DataGet);
        }

        public IDataResult<IList<Address>> GetAllByCityId(int cityId)
        {
            IList<Address> addresses = _addressDal.GetAll(a => a.CityId == cityId && !a.IsDeleted);
            return addresses == null
                ? new ErrorDataResult<IList<Address>>(AddressConstants.NotMatch)
                : new SuccessDataResult<IList<Address>>(addresses, AddressConstants.DataGet);
        }

        public IDataResult<IList<AddressDto>> DtoGetAllByCityId(int cityId)
        {
            IList<AddressDto> addressDtos = _addressDal.DtoGetAll(a => a.CityId == cityId && !a.IsDeleted);
            return addressDtos == null
                ? new ErrorDataResult<IList<AddressDto>>(AddressConstants.NotMatch)
                : new SuccessDataResult<IList<AddressDto>>(addressDtos, AddressConstants.DataGet);
        }

        public IDataResult<IList<Address>> GetAllByCountryId(int countryId)
        {
            IList<Address> addresses = _addressDal.GetAll(a => a.CountryId == countryId && !a.IsDeleted);
            return addresses == null
                ? new ErrorDataResult<IList<Address>>(AddressConstants.NotMatch)
                : new SuccessDataResult<IList<Address>>(addresses, AddressConstants.DataGet);
        }

        public IDataResult<IList<AddressDto>> DtoGetAllByCountryId(int countryId)
        {
            IList<AddressDto> addressDtos = _addressDal.DtoGetAll(a => a.CountryId == countryId && !a.IsDeleted);
            return addressDtos == null
                ? new ErrorDataResult<IList<AddressDto>>(AddressConstants.NotMatch)
                : new SuccessDataResult<IList<AddressDto>>(addressDtos, AddressConstants.DataGet);
        }

        public IDataResult<IList<Address>> GetAllByGeoLocation(string geoLocation)
        {
            IList<Address> addresses = _addressDal.GetAll(a => a.GeoLocation == geoLocation && !a.IsDeleted);
            return addresses == null
                ? new ErrorDataResult<IList<Address>>(AddressConstants.NotMatch)
                : new SuccessDataResult<IList<Address>>(addresses, AddressConstants.DataGet);
        }

        public IDataResult<IList<AddressDto>> DtoGetAllByGeoLocation(string geoLocation)
        {
            IList<AddressDto> addressDtos = _addressDal.DtoGetAll(a => a.GeoLocation == geoLocation && !a.IsDeleted);
            return addressDtos == null
                ? new ErrorDataResult<IList<AddressDto>>(AddressConstants.NotMatch)
                : new SuccessDataResult<IList<AddressDto>>(addressDtos, AddressConstants.DataGet);
        }

        public IDataResult<IList<Address>> GetAllByPostalCode(string postalCode)
        {
            IList<Address> addresses = _addressDal.GetAll(a => a.PostalCode == postalCode && !a.IsDeleted);
            return addresses == null
                ? new ErrorDataResult<IList<Address>>(AddressConstants.NotMatch)
                : new SuccessDataResult<IList<Address>>(addresses, AddressConstants.DataGet);
        }
        public IDataResult<IList<AddressDto>> DtoGetAllByPostalCode(string postalCode)
        {
            IList<AddressDto> addressDtos = _addressDal.DtoGetAll(a => a.PostalCode == postalCode && !a.IsDeleted);
            return addressDtos == null
                ? new ErrorDataResult<IList<AddressDto>>(AddressConstants.NotMatch)
                : new SuccessDataResult<IList<AddressDto>>(addressDtos, AddressConstants.DataGet);
        }

        public IDataResult<IList<Address>> GetAllBySearchString(string searchStr)
        {
            IList<Address> addresses = _addressDal.GetAll(a => (a.AddressLine1 + a.AddressLine2).Contains(searchStr) && !a.IsDeleted);
            return addresses == null
                ? new ErrorDataResult<IList<Address>>(AddressConstants.NotMatch)
                : new SuccessDataResult<IList<Address>>(addresses, AddressConstants.DataGet);
        }

        public IDataResult<IList<AddressDto>> DtoGetAllBySearchString(string searchStr)
        {
            IList<AddressDto> addressDtos = _addressDal.DtoGetAll(a => (a.AddressLine1 + a.AddressLine2).Contains(searchStr) && !a.IsDeleted);
            return addressDtos == null
                ? new ErrorDataResult<IList<AddressDto>>(AddressConstants.NotMatch)
                : new SuccessDataResult<IList<AddressDto>>(addressDtos, AddressConstants.DataGet);
        }

        public IDataResult<IList<Address>> GetAllByName(string name)
        {
            IList<Address> addresses = _addressDal.GetAll(a => a.AddressName.Contains(name));
            return addresses == null
                ? new ErrorDataResult<IList<Address>>(AddressConstants.NotMatch)
                : new SuccessDataResult<IList<Address>>(addresses, AddressConstants.DataGet);
        }

        public IDataResult<IList<AddressDto>> DtoGetAllByName(string name)
        {
            IList<AddressDto> addressDtos = _addressDal.DtoGetAll(a => a.AddressName.Contains(name) && !a.IsDeleted);
            return addressDtos == null
                ? new ErrorDataResult<IList<AddressDto>>(AddressConstants.NotMatch)
                : new SuccessDataResult<IList<AddressDto>>(addressDtos, AddressConstants.DataGet);
        }

        public IDataResult<IList<Address>> GetAllByFilter(Expression<Func<Address, bool>>? filter = null)
        {
            return new SuccessDataResult<IList<Address>>(_addressDal.GetAll(filter), AddressConstants.DataGet);
        }

        public IDataResult<IList<AddressDto>> DtoGetAllByFilter(Expression<Func<Address, bool>>? filter = null)
        {
            throw new NotImplementedException();
        }

        public IDataResult<IList<Address>> GetAll()
        {
            return new SuccessDataResult<IList<Address>>(_addressDal.GetAll(a => !a.IsDeleted), AddressConstants.DataGet);
        }

        public IDataResult<IList<AddressDto>> DtoGetAll()
        {
            return new SuccessDataResult<IList<AddressDto>>(_addressDal.DtoGetAll(a => !a.IsDeleted), AddressConstants.DataGet);
        }

        public IDataResult<IList<Address>> GetAllByIsDeleted()
        {
            return new SuccessDataResult<IList<Address>>(_addressDal.GetAll(a => a.IsDeleted), AddressConstants.DataGet);
        }

        public IDataResult<IList<AddressDto>> DtoGetAllByIsDeleted()
        {
            return new SuccessDataResult<IList<AddressDto>>(_addressDal.DtoGetAll(a => a.IsDeleted), AddressConstants.DataGet);
        }
    }
}
