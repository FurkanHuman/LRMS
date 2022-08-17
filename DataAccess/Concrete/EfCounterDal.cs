namespace DataAccess.Concrete
{
    public class EfCounterDal : EfEntityRepositoryBase<Counter, PostgreDbContext>, ICounterDal
    {
    }
}
