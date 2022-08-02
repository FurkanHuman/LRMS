using Business.Abstract.Base;
using Core.Utilities.Result.Abstract;
using Entities.Concrete;

namespace Business.Abstract
{
    public interface IThesisService : IMaterialBaseService<Thesis>
    {
        IDataResult<IEnumerable<Thesis>> GetAllByUniversityId(Guid universityId);
        IDataResult<IEnumerable<Thesis>> GetAllByUniversityId(Guid[] universityIds);
        IDataResult<IEnumerable<Thesis>> GetAllByThesisDegree(byte degree);
        IDataResult<IEnumerable<Thesis>> GetAllByResearcherId(Guid researcherId);
        IDataResult<IEnumerable<Thesis>> GetAllByResearcherIds(Guid[] researcherIds);
        IDataResult<IEnumerable<Thesis>> GetAllByConsultantId(Guid consultantId);
        IDataResult<IEnumerable<Thesis>> GetAllByConsultantIds(Guid[] consultantIds);
        IDataResult<IEnumerable<Thesis>> GetAllByCityId(int cityId);
        IDataResult<IEnumerable<Thesis>> GetAllByCityName(string cityName);
        IDataResult<IEnumerable<Thesis>> GetAllByCountryId(int countryId);
        IDataResult<IEnumerable<Thesis>> GetAllByCountryCode(string countryCode);
        IDataResult<IEnumerable<Thesis>> GetAllByDateTimeYear(ushort year);
        IDataResult<IEnumerable<Thesis>> GetAllBylangaugeId(int langaugeId);
        IDataResult<IEnumerable<Thesis>> GetAllByThesisNumber(int thesisNumber);
        IDataResult<IEnumerable<Thesis>> GetAllByPermissionStatus(bool status);
        IDataResult<IEnumerable<Thesis>> GetAllByApprovalStatus(bool status);
    }
}