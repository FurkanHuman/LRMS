namespace DataAccess.Abstract
{
    public interface ICityDal : IEntityRepository<City>, IDtoRepository<City, CityDto>
    {
    }
}
