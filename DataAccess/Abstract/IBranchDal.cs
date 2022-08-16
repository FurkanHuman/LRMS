using Core.DataAccess;
using Entities.Concrete.Infos;
using Entities.DTOs.Infos;

namespace DataAccess.Abstract
{
    public interface IBranchDal : IEntityRepository<Branch>, IDtoRepository<Branch, BranchDto>
    {
    }
}
