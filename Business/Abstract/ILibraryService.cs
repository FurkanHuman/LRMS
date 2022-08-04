using Business.Abstract.Base;
using Core.Utilities.Result.Abstract;
using Entities.Concrete.Infos;

namespace Business.Abstract
{
    public interface ILibraryService : IBaseEntityService<Library, Guid>
    {
        IDataResult<Library> GetByAddressId(Guid addressId);
        IDataResult<Library> GetByCommunicationId(Guid commId);
        IDataResult<Library> GetByCommunicationEmail(string commEmail);
        IDataResult<Library> GetByCommunicationFaxNumber(string commFaxNumber);
        IDataResult<Library> GetByCommunicationPhone(string commPhone);
        IDataResult<Library> GetByCommunicationWebSite(string commWebSite);
        IDataResult<IList<Library>> GetAllByAddressName(string addressName);
        IDataResult<IList<Library>> GetAllByAddressLine(string addressLine);
        IDataResult<IList<Library>> GetAllByCommunicationName(string commName);
        IDataResult<IList<Library>> GetAllByLibraryType(byte libType);
        IDataResult<IList<Library>> GetAllByLibraryInCountryId(int countryId);
        IDataResult<IList<Library>> GetAllByLibraryInCountryName(string countryName);
        IDataResult<IList<Library>> GetAllByLibraryInCountryCode(string countryCode);
        IDataResult<IList<Library>> GetAllByLibraryInCityId(int cityId);
        IDataResult<IList<Library>> GetAllByLibraryInCityName(string cityName);
        IDataResult<IList<Library>> GetAllByLibraryInPostalCode(string postalCode);
        IDataResult<IList<Library>> GetAllByLibraryInGeoLocation(string geoLoc);
        IDataResult<Dictionary<byte, string>> GetAllEnumToDictionaryLibraryType();
    }
}
