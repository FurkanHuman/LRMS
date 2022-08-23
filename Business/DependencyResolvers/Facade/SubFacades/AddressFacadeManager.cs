namespace Business.DependencyResolvers.Facade.SubFacades
{
    public class AddressFacadeManager : IAddressFacadeService
    {
        private readonly ICityService _cityService;
        private readonly ICountryService _countryService;

        public AddressFacadeManager(ICityService cityService, ICountryService countryService)
        {
            _cityService = cityService;
            _countryService = countryService;
        }

        public ICityService CityService() => _cityService;

        public ICountryService CountryService() => _countryService;
    }
}
