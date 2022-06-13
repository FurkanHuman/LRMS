using Business.Abstract.Base;
using Core.Utilities.Result.Abstract;
using Entities.Concrete.Infos;

namespace Business.Abstract
{
    public interface IEditionService : IBaseEntityService<Edition, Guid>
    {

        IDataResult<Edition> GetByCommunicationId(Guid commId);
        IDataResult<Edition> GetByCommunicationPhone(string commPhone);
        IDataResult<Edition> GetByCommunicationFaxNumber(string commFaxNumber);
        IDataResult<Edition> GetByCommunicationEmail(string commEmail);
        IDataResult<Edition> GetByCommunicationWebSite(string commWebSite);
        IDataResult<Edition> GetByAdderssId(Guid addressId);
        IDataResult<List<Edition>> GetByAddressName(string addressName);
        IDataResult<List<Edition>> GetByAddressLines(string addressLine);
        IDataResult<List<Edition>> GetByCommunicationName(string commName);
        IDataResult<List<Edition>> GetByEditionNumbers(int eNumber);
        IDataResult<List<Edition>> GetByEditionInCountryId(int countryId);
        IDataResult<List<Edition>> GetByEditionInCountryName(string countryName);
        IDataResult<List<Edition>> GetByEditionInCountryCode(string countryCode);
        IDataResult<List<Edition>> GetByEditionInCityId(int cityId);
        IDataResult<List<Edition>> GetByEditionInCityName(string cityName);
        IDataResult<List<Edition>> GetByEditionInPostalCode(string postalCode);
        IDataResult<List<Edition>> GetByEditionInGeoLocation(string geoLoc);
        IDataResult<List<Edition>> GetByDateOfPublication(DateTime dateOfPublication);
        IDataResult<List<Edition>> GetByDateOfPublicationMinMax(DateTime minDate, DateTime maxDate);
    }
}
