namespace Business.Abstract
{
    public interface IUniversityService : IBaseEntityService<University, Guid>
    {
        IDataResult<University> GetByAddressId(Guid id);
        IDataResult<IList<University>> GetAllByBranchId(int branchId);
        IDataResult<IList<University>> GetAllByBranchName(string branchName);
        IDataResult<IList<University>> GetAllByCityId(int cityId);
        IDataResult<IList<University>> GetAllByCityName(string cityName);
        IDataResult<IList<University>> GetAllByCountryId(int countryId);
        IDataResult<IList<University>> GetAllByCountryName(string countryName);
        IDataResult<IList<University>> GetAllByInstituteName(string instituteName);
    }
}
