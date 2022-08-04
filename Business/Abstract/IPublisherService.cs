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
        IDataResult<IList<Publisher>> GetAllByAddressName(string addressName);
        IDataResult<IList<Publisher>> GetAllByAddressLine(string addressLine);
        IDataResult<IList<Publisher>> GetAllByPublisherInCityId(int cityId);
        IDataResult<IList<Publisher>> GetAllByPublisherInCityName(string cityName);
        IDataResult<IList<Publisher>> GetAllByCommunicationName(string commName);
        IDataResult<IList<Publisher>> GetAllByPublisherInCountryId(int countryId);
        IDataResult<IList<Publisher>> GetAllByPublisherInCountryName(string countryName);
        IDataResult<IList<Publisher>> GetAllByPublisherInCountryCode(string countryCode);
        IDataResult<IList<Publisher>> GetAllByPublisherInGeoLocation(string geoLoc);
        IDataResult<IList<Publisher>> GetAllByPublisherInPostalCode(string postalCode);
        IDataResult<IList<Publisher>> GetAllByDateOfPublication(DateTime dateOfPublication);
        IDataResult<IList<Publisher>> GetAllByDateOfPublicationMinMax(DateTime minDate, DateTime maxDate);
    }
}
