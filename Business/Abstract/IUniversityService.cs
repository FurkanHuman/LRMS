using Business.Abstract.Base;
using Core.Utilities.Result.Abstract;
using Entities.Concrete.Infos;

namespace Business.Abstract
{
    public interface IUniversityService : IBaseEntityService<University>
    {
        IResult Delete(Guid id);
        IResult ShadowDelete(Guid id);
        IDataResult<University> GetById(Guid id);
        IDataResult<University> GetByAddressId(Guid id);
        IDataResult<List<University>> GetByInstituteNames(string instituteName);
        IDataResult<List<University>> GetByBranchNames(string branchName);
        IDataResult<List<University>> GetByBranchId(int branchId);
        IDataResult<List<University>> GetByCityNames(string cityName);
        IDataResult<List<University>> GetByCityId(int cityId);
        IDataResult<List<University>> GetByCountryNames(string countryName);
        IDataResult<List<University>> GetByCountryId(int countryId);
    }
}
