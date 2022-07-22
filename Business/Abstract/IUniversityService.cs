using Business.Abstract.Base;
using Core.Utilities.Result.Abstract;
using Entities.Concrete.Infos;

namespace Business.Abstract
{
    public interface IUniversityService : IBaseEntityService<University, Guid>
    {
        IDataResult<University> GetByAddressId(Guid id);
        IDataResult<List<University>> GetAllByBranchId(int branchId);
        IDataResult<List<University>> GetAllByBranchName(string branchName);
        IDataResult<List<University>> GetAllByCityId(int cityId);
        IDataResult<List<University>> GetAllByCityName(string cityName);
        IDataResult<List<University>> GetAllByCountryId(int countryId);
        IDataResult<List<University>> GetAllByCountryName(string countryName);
        IDataResult<List<University>> GetAllByInstituteName(string instituteName);
    }
}
