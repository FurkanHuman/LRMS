using Core.Utilities.Result.Abstract;
using Entities.Concrete.Infos;

namespace Business.Abstract
{
    public interface IAddressService
    {
        IResult Add(Address address);
        IResult Delete(Guid addressGId);
        IResult ShadowDelete(Guid addressGId);
        IResult Update(Address address);
        IDataResult<Address> GetById(Guid guid);
        IDataResult<List<Address>> GetByPostalCode(string postalCode);
        IDataResult<List<Address>> GetByCityId(int cityId);
        IDataResult<List<Address>> GetByCountryId(int countryId);
        IDataResult<List<Address>> GetByGeoLocation(string geoLocation);
        IDataResult<List<Address>> GetBySearchString(string searchStr);
        IDataResult<List<Address>> GetAll();
    }
}
