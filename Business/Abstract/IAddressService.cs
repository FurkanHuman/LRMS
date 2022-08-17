namespace Business.Abstract
{
    public interface IAddressService : IBaseEntityService<Address, Guid>
    {
        IDataResult<IList<AddressDto>> GetAlladdressDtos();
        IDataResult<IList<Address>> GetAllByPostalCode(string postalCode);
        IDataResult<IList<Address>> GetAllByCityId(int cityId);
        IDataResult<IList<Address>> GetAllByCountryId(int countryId);
        IDataResult<IList<Address>> GetAllByGeoLocation(string geoLocation);
        IDataResult<IList<Address>> GetAllBySearchString(string searchStr);
    }
}
