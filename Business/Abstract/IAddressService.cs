using Business.Abstract.Base;
using Core.Utilities.Result.Abstract;
using Entities.Concrete.Infos;

namespace Business.Abstract
{
    public interface IAddressService : IBaseEntityService<Address, Guid>
    {
        IDataResult<List<Address>> GetAllByPostalCode(string postalCode);
        IDataResult<List<Address>> GetAllByCityId(int cityId);
        IDataResult<List<Address>> GetAllByCountryId(int countryId);
        IDataResult<List<Address>> GetAllByGeoLocation(string geoLocation);
        IDataResult<List<Address>> GetAllBySearchString(string searchStr);
    }
}
