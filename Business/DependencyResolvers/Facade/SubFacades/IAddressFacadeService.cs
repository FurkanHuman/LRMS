namespace Business.DependencyResolvers.Facade.SubFacades
{
    public interface IAddressFacadeService
    {
        ICityService CityService();
        ICountryService CountryService();
    }
}
