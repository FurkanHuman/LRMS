using Core.Utilities.Result.Abstract;
using Entities.Concrete.Infos;
using System.Linq.Expressions;

namespace Business.Abstract
{
    public interface IUniversityService
    {
        IResult Add(University university);
        IResult Delete(University university);
        IResult ShadowDelete(Guid guid);
        IResult Update(University university);
        IDataResult<University> GetById(Guid guid);
        IDataResult<University> GetByAddressId(Guid guid);
        IDataResult<List<University>> GetByUniversityNames(string universityName);
        IDataResult<List<University>> GetByInstituteNames(string instituteName);
        IDataResult<List<University>> GetByBranchNames(string branchName);
        IDataResult<List<University>> GetByBranchId(int branchId);
        IDataResult<List<University>> GetByCityNames(string cityName);
        IDataResult<List<University>> GetByCityId(int cityId);
        IDataResult<List<University>> GetByCountryNames(string countryName);
        IDataResult<List<University>> GetByCountryId(int countryId);
        IDataResult<List<University>> GetAllByFilter(Expression<Func<University, bool>>? filter = null);
        IDataResult<List<University>> GetAll();
    }
}
