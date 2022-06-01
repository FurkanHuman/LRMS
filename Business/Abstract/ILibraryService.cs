using Business.Abstract.Base;
using Core.Utilities.Result.Abstract;
using Entities.Concrete.Infos;

namespace Business.Abstract
{
    public interface ILibraryService : IBaseEntityService<Library>
    {
        IResult Delete(Guid id);
        IResult ShadowDelete(Guid id);
        IDataResult<Library> GetById(Guid id);
        IDataResult<List<Library>> GetLibraryTypes(byte libType);
        IDataResult<Library> GetByAdderssId(Guid addressId);
        IDataResult<List<Library>> GetByLibraryInCountryId(int countryId);
        IDataResult<List<Library>> GetByAddressName(string addressName);
        IDataResult<List<Library>> GetByAddressLines(string addressLine);
        IDataResult<List<Library>> GetByLibraryInCountryName(string countryName);
        IDataResult<List<Library>> GetByLibraryInCountryCode(string countryCode);
        IDataResult<List<Library>> GetByLibraryInCityId(int cityId);
        IDataResult<List<Library>> GetByLibraryInCityName(string cityName);
        IDataResult<List<Library>> GetByLibraryInPostalCode(string postalCode);
        IDataResult<List<Library>> GetByLibraryInGeoLocation(string geoLoc);
        IDataResult<Library> GetByCommunicationId(Guid commId);
        IDataResult<List<Library>> GetByCommunicationName(string commName);
        IDataResult<Library> GetByCommunicationPhone(string commPhone);
        IDataResult<Library> GetByCommunicationFaxNumber(string commFaxNumber);
        IDataResult<Library> GetByCommunicationEmail(string commEmail);
        IDataResult<Library> GetByCommunicationWebSite(string commWebSite);
        IDataResult<Dictionary<byte, string>> GetAllEnumToDictionaryLibraryTypes();
    }
}
