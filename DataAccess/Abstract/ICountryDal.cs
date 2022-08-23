namespace DataAccess.Abstract
{
    public interface ICountryDal : IEntityRepository<Country>, IDtoRepository<Country, CountryDto>
    {
    }
}
