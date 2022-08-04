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
        IDataResult<IList<Edition>> GetAllByAddressName(string addressName);
        IDataResult<IList<Edition>> GetAllByAddressLine(string addressLine);
        IDataResult<IList<Edition>> GetAllByCommunicationName(string commName);
        IDataResult<IList<Edition>> GetAllByEditionNumber(int eNumber);
        IDataResult<IList<Edition>> GetAllByEditionInCountryId(int countryId);
        IDataResult<IList<Edition>> GetAllByEditionInCountryName(string countryName);
        IDataResult<IList<Edition>> GetAllByEditionInCountryCode(string countryCode);
        IDataResult<IList<Edition>> GetAllByEditionInCityId(int cityId);
        IDataResult<IList<Edition>> GetAllByEditionInCityName(string cityName);
        IDataResult<IList<Edition>> GetAllByEditionInPostalCode(string postalCode);
        IDataResult<IList<Edition>> GetAllByEditionInGeoLocation(string geoLoc);
        IDataResult<IList<Edition>> GetAllByDateOfPublication(DateTime dateOfPublication);
        IDataResult<IList<Edition>> GetAllByDateOfPublicationMinMax(DateTime minDate, DateTime maxDate);
    }
}
