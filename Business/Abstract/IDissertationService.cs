using Business.Abstract.Base;
using Core.Utilities.Result.Abstract;
using Entities.Concrete;

namespace Business.Abstract
{
    public interface IDissertationService : IMaterialBaseService<Dissertation>
    {
        IDataResult<Dissertation> GetByApprovalStatus(Guid id);
        IDataResult<List<Dissertation>> GetAllByCity(int cityId);
        IDataResult<List<Dissertation>> GetAllByCountry(int countryId);
        IDataResult<List<Dissertation>> GetAllByDateTimeYear(ushort year, ushort? yearMax = null);
        IDataResult<List<Dissertation>> GetAllByDissertationNumber(int dissertationNumber);
        IDataResult<List<Dissertation>> GetAllByLanguage(int languageId);
        IDataResult<List<Dissertation>> GetAllByUniversity(Guid universityId);
    }
}
