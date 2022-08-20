namespace Business.Abstract
{
    public interface ICityService : IBaseEntityService<City, int>, IBaseDtoService<City, CityDto, int>
    {
    }
}
