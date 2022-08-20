namespace DataAccess.Concrete
{
    public class EfCountryDal : EfEntityRepositoryBase<Country, CountryDto, PostgreDbContext>, ICountryDal
    {
    }
}
