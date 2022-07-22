using Business.Abstract.Base;
using Core.Utilities.Result.Abstract;
using Entities.Concrete.Infos;

namespace Business.Abstract
{
    public interface IPublisherService : IBaseEntityService<Publisher, Guid>
    {
        IDataResult<Publisher> GetByAddressId(Guid addressId);
        IDataResult<Publisher> GetByCommunicationId(Guid commId);
        IDataResult<Publisher> GetByCommunicationEmail(string commEmail);
        IDataResult<Publisher> GetByCommunicationFaxNumber(string commFaxNumber);
        IDataResult<Publisher> GetByCommunicationPhone(string commPhone);
        IDataResult<Publisher> GetByCommunicationWebSite(string commWebSite);
        IDataResult<List<Publisher>> GetAllByAddressName(string addressName);
        IDataResult<List<Publisher>> GetAllByAddressLine(string addressLine);
        IDataResult<List<Publisher>> GetAllByPublisherInCityId(int cityId);
        IDataResult<List<Publisher>> GetAllByPublisherInCityName(string cityName);
        IDataResult<List<Publisher>> GetAllByCommunicationName(string commName);
        IDataResult<List<Publisher>> GetAllByPublisherInCountryId(int countryId);
        IDataResult<List<Publisher>> GetAllByPublisherInCountryName(string countryName);
        IDataResult<List<Publisher>> GetAllByPublisherInCountryCode(string countryCode);
        IDataResult<List<Publisher>> GetAllByPublisherInGeoLocation(string geoLoc);
        IDataResult<List<Publisher>> GetAllByPublisherInPostalCode(string postalCode);
        IDataResult<List<Publisher>> GetAllByDateOfPublication(DateTime dateOfPublication);
        IDataResult<List<Publisher>> GetAllByDateOfPublicationMinMax(DateTime minDate, DateTime maxDate);
    }
}
