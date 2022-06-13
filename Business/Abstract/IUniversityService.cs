﻿using Business.Abstract.Base;
using Core.Utilities.Result.Abstract;
using Entities.Concrete.Infos;

namespace Business.Abstract
{
    public interface IUniversityService : IBaseEntityService<University, Guid>
    {
        IDataResult<University> GetByAddressId(Guid id);
        IDataResult<List<University>> GetByBranchId(int branchId);
        IDataResult<List<University>> GetByBranchNames(string branchName);
        IDataResult<List<University>> GetByCityId(int cityId);
        IDataResult<List<University>> GetByCityNames(string cityName);
        IDataResult<List<University>> GetByCountryId(int countryId);
        IDataResult<List<University>> GetByCountryNames(string countryName);
        IDataResult<List<University>> GetByInstituteNames(string instituteName);
    }
}
