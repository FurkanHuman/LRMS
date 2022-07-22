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
        IDataResult<Edition> GetByPublisherId(Guid publisherId);
        IDataResult<List<Edition>> GetAllByAddressName(string addressName);
        IDataResult<List<Edition>> GetAllByAddressLine(string addressLine);
        IDataResult<List<Edition>> GetAllByCommunicationName(string commName);
        IDataResult<List<Edition>> GetAllByEditionNumber(int eNumber);
        IDataResult<List<Edition>> GetAllByEditionInCountryId(int countryId);
        IDataResult<List<Edition>> GetAllByEditionInCountryName(string countryName);
        IDataResult<List<Edition>> GetAllByEditionInCountryCode(string countryCode);
        IDataResult<List<Edition>> GetAllByEditionInCityId(int cityId);
        IDataResult<List<Edition>> GetAllByEditionInCityName(string cityName);
        IDataResult<List<Edition>> GetAllByEditionInPostalCode(string postalCode);
        IDataResult<List<Edition>> GetAllByEditionInGeoLocation(string geoLoc);
        IDataResult<List<Edition>> GetAllByDateOfPublication(DateTime dateOfPublication);
        IDataResult<List<Edition>> GetAllByDateOfPublicationMinMax(DateTime minDate, DateTime maxDate);
    }
}
