using Business.Abstract.Base;
using Core.Utilities.Result.Abstract;
using Entities.Concrete;

namespace Business.Abstract
{
    public interface IDissertationService : IMaterialBaseService<Dissertation>
    {
        IDataResult<Dissertation> GetByApprovalStatus(Guid id);
        IDataResult<List<Dissertation>> GetByCities(int cityId);
        IDataResult<List<Dissertation>> GetByCityName(string cityName);
        IDataResult<List<Dissertation>> GetByCountries(int CountryId);
        IDataResult<List<Dissertation>> GetByCountryName(string countryName);
        IDataResult<List<Dissertation>> GetByDateTimeYear(ushort year, ushort? yearMax = null);
        IDataResult<List<Dissertation>> GetByDissertationNumber(int dissertationNumber);
        IDataResult<List<Dissertation>> GetByLanguages(int languageId);
        IDataResult<List<Dissertation>> GetByLanguagesName(string languageName);
        IDataResult<List<Dissertation>> GetByUniversity(Guid universityId);
        IDataResult<List<Dissertation>> GetByUniversityName(string universityName);
    }
}
