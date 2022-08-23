namespace Business.DependencyResolvers.Facade.SubFacades
{
    public interface ICityFacadeService
    {
        ICountryService CountryService();
    }
}
