namespace DataAccess.Concrete
{
    public class EfBranchDal : EfEntityRepositoryBase<Branch, BranchDto, PostgreDbContext>, IBranchDal
    {
    }
}
