using Business.Abstract.Base;
using Core.Utilities.Result.Abstract;
using Entities.Concrete;

namespace Business.Abstract
{
    public interface IDissertationService : IMaterialBaseService<Dissertation>
    {
        IDataResult<Dissertation> GetByApprovalStatus(Guid id);
        IDataResult<IList<Dissertation>> GetAllByCity(int cityId);
        IDataResult<IList<Dissertation>> GetAllByCountry(int countryId);
        IDataResult<IList<Dissertation>> GetAllByDateTimeYear(ushort year, ushort? yearMax = null);
        IDataResult<IList<Dissertation>> GetAllByDissertationNumber(int dissertationNumber);
        IDataResult<IList<Dissertation>> GetAllByLanguage(int languageId);
        IDataResult<IList<Dissertation>> GetAllByUniversity(Guid universityId);
    }
}
