namespace Business.Abstract
{
    public interface IAddressService : IBaseEntityService<Address, Guid>, IBaseDtoService<Address, AddressDto, AddressAddDto, AddressUpdateDto, Guid>
    {
        IDataResult<IList<Address>> GetAllByPostalCode(string postalCode);
        IDataResult<IList<AddressDto>> DtoGetAllByPostalCode(string postalCode);
        IDataResult<IList<Address>> GetAllByCityId(int cityId);
        IDataResult<IList<AddressDto>> DtoGetAllByCityId(int cityId);
        IDataResult<IList<Address>> GetAllByCountryId(int countryId);
        IDataResult<IList<AddressDto>> DtoGetAllByCountryId(int countryId);
        IDataResult<IList<Address>> GetAllByGeoLocation(string geoLocation);
        IDataResult<IList<AddressDto>> DtoGetAllByGeoLocation(string geoLocation);
        IDataResult<IList<Address>> GetAllBySearchString(string searchStr);
        IDataResult<IList<AddressDto>> DtoGetAllBySearchString(string searchStr);
    }
}
