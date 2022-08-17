namespace DataAccess.Concrete
{
    public class EfCountryDal : EfEntityRepositoryBase<Country, PostgreDbContext>, ICountryDal
    {
    }
}
