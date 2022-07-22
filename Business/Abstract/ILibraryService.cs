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
        IDataResult<List<Library>> GetAllByAddressName(string addressName);
        IDataResult<List<Library>> GetAllByAddressLine(string addressLine);
        IDataResult<List<Library>> GetAllByCommunicationName(string commName);
        IDataResult<List<Library>> GetAllByLibraryType(byte libType);
        IDataResult<List<Library>> GetAllByLibraryInCountryId(int countryId);
        IDataResult<List<Library>> GetAllByLibraryInCountryName(string countryName);
        IDataResult<List<Library>> GetAllByLibraryInCountryCode(string countryCode);
        IDataResult<List<Library>> GetAllByLibraryInCityId(int cityId);
        IDataResult<List<Library>> GetAllByLibraryInCityName(string cityName);
        IDataResult<List<Library>> GetAllByLibraryInPostalCode(string postalCode);
        IDataResult<List<Library>> GetAllByLibraryInGeoLocation(string geoLoc);
        IDataResult<Dictionary<byte, string>> GetAllEnumToDictionaryLibraryType();
    }
}
