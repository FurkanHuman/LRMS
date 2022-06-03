using Business.Abstract.Base;
using Core.Utilities.Result.Abstract;
using Entities.Concrete.Infos;

namespace Business.Abstract
{
    public interface IAddressService : IBaseEntityService<Address, Guid>
    {
        IDataResult<List<Address>> GetByPostalCode(string postalCode);
        IDataResult<List<Address>> GetByCityId(int cityId);
        IDataResult<List<Address>> GetByCountryId(int countryId);
        IDataResult<List<Address>> GetByGeoLocation(string geoLocation);
        IDataResult<List<Address>> GetBySearchString(string searchStr);
    }
}
