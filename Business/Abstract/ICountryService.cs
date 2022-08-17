namespace Business.Abstract
{
    public interface ICountryService : IBaseEntityService<Country, int>
    {
        IDataResult<IList<Country>> GetAllByCountryCode(string countryCode);
    }
}
