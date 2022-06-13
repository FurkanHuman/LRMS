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
        IDataResult<List<Publisher>> GetByAddressName(string addressName);
        IDataResult<List<Publisher>> GetByAddressLines(string addressLine);
        IDataResult<List<Publisher>> GetByPublisherInCityId(int cityId);
        IDataResult<List<Publisher>> GetByPublisherInCityName(string cityName);
        IDataResult<List<Publisher>> GetByCommunicationName(string commName);
        IDataResult<List<Publisher>> GetByPublisherInCountryId(int countryId);
        IDataResult<List<Publisher>> GetByPublisherInCountryName(string countryName);
        IDataResult<List<Publisher>> GetByPublisherInCountryCode(string countryCode);
        IDataResult<List<Publisher>> GetByPublisherInGeoLocation(string geoLoc);
        IDataResult<List<Publisher>> GetByPublisherInPostalCode(string postalCode);
        IDataResult<List<Publisher>> GetByDateOfPublication(DateTime dateOfPublication);
        IDataResult<List<Publisher>> GetByDateOfPublicationMinMax(DateTime minDate, DateTime maxDate);
    }
}
