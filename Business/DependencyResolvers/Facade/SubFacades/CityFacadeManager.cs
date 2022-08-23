namespace Business.DependencyResolvers.Facade.SubFacades
{
    public class CityFacadeManager : ICityFacadeService
    {
        private readonly ICountryService _countryService;

        public CityFacadeManager(ICountryService countryService)
        {
            _countryService = countryService;
        }

        public ICountryService CountryService() => _countryService;
    }
}
