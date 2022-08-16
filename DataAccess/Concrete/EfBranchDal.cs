using Core.DataAccess.PostgreDb;
using DataAccess.Abstract;
using DataAccess.Contexts;
using Entities.Concrete.Infos;
using Entities.DTOs.Infos;

namespace DataAccess.Concrete
{
    public class EfBranchDal : EfEntityRepositoryBase<Branch, BranchDto, PostgreDbContext>, IBranchDal
    {
    }
}
