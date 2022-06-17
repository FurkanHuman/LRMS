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
        IDataResult<List<Library>> GetByAddressNames(string addressName);
        IDataResult<List<Library>> GetByAddressLines(string addressLine);
        IDataResult<List<Library>> GetByCommunicationNames(string commName);
        IDataResult<List<Library>> GetByLibraryTypes(byte libType);
        IDataResult<List<Library>> GetByLibraryInCountryId(int countryId);
        IDataResult<List<Library>> GetByLibraryInCountryNames(string countryName);
        IDataResult<List<Library>> GetByLibraryInCountryCode(string countryCode);
        IDataResult<List<Library>> GetByLibraryInCityId(int cityId);
        IDataResult<List<Library>> GetByLibraryInCityNames(string cityName);
        IDataResult<List<Library>> GetByLibraryInPostalCode(string postalCode);
        IDataResult<List<Library>> GetByLibraryInGeoLocation(string geoLoc);
        IDataResult<Dictionary<byte, string>> GetAllEnumToDictionaryLibraryTypes();
    }
}
