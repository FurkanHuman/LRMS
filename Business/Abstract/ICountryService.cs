namespace Business.Abstract
{
    public interface ICountryService : IBaseEntityService<Country, int>, IBaseDtoService<Country, CountryDto, int>
    {
        IDataResult<IList<Country>> GetAllByCountryCode(string countryCode);
        IDataResult<IList<CountryDto>> DtoGetAllByCountryCode(string countryCode);
    }
}
