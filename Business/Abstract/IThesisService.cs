using Business.Abstract.Base;
using Core.Utilities.Result.Abstract;
using Entities.Concrete;

namespace Business.Abstract
{
    public interface IThesisService : IMaterialBaseService<Thesis>
    {
        IDataResult<IList<Thesis>> GetAllByUniversityId(Guid universityId);
        IDataResult<IList<Thesis>> GetAllByUniversityId(Guid[] universityIds);
        IDataResult<IList<Thesis>> GetAllByThesisDegree(byte degree);
        IDataResult<IList<Thesis>> GetAllByResearcherId(Guid researcherId);
        IDataResult<IList<Thesis>> GetAllByResearcherIds(Guid[] researcherIds);
        IDataResult<IList<Thesis>> GetAllByConsultantId(Guid consultantId);
        IDataResult<IList<Thesis>> GetAllByConsultantIds(Guid[] consultantIds);
        IDataResult<IList<Thesis>> GetAllByCityId(int cityId);
        IDataResult<IList<Thesis>> GetAllByCityName(string cityName);
        IDataResult<IList<Thesis>> GetAllByCountryId(int countryId);
        IDataResult<IList<Thesis>> GetAllByCountryCode(string countryCode);
        IDataResult<IList<Thesis>> GetAllByDateTimeYear(ushort year);
        IDataResult<IList<Thesis>> GetAllBylangaugeId(int langaugeId);
        IDataResult<IList<Thesis>> GetAllByThesisNumber(int thesisNumber);
        IDataResult<IList<Thesis>> GetAllByPermissionStatus(bool status);
        IDataResult<IList<Thesis>> GetAllByApprovalStatus(bool status);
    }
}