namespace DataAccess.Abstract
{
    public interface IBranchDal : IEntityRepository<Branch>, IDtoRepository<Branch, BranchDto>
    {
    }
}
