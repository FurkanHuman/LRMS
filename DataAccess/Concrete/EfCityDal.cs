namespace DataAccess.Concrete
{
    public class EfCityDal : EfEntityRepositoryBase<City, CityDto, PostgreDbContext>, ICityDal
    {
    }
}
