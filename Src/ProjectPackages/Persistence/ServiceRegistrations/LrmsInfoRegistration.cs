using Application.Repositories;
using Microsoft.Extensions.DependencyInjection;
using Persistence.Repositories;

namespace Persistence.ServiceRegistrations;

public static class LrmsInfoRegistration
{
    public static IServiceCollection AddLrmsInfoRegistration(this IServiceCollection services)
    {
        // LRMS Info

        services.AddScoped<IAddressRepository, AddressRepository>();
        services.AddScoped<IBranchRepository, BranchRepository>();
        services.AddScoped<ICategoryRepository, CategoryRepository>();
        services.AddScoped<ICityRepository, CityRepository>();
        services.AddScoped<ICloudStorageRepository, CloudStorageRepository>();
        services.AddScoped<ICommunicationRepository, CommunicationRepository>();
        services.AddScoped<IComposerRepository, ComposerRepository>();
        services.AddScoped<IConsultantRepository, ConsultantRepository>();
        services.AddScoped<ICounterRepository, CounterRepository>();
        services.AddScoped<ICountryRepository, CountryRepository>();
        services.AddScoped<ICoverCapRepository, CoverCapRepository>();
        services.AddScoped<IDimensionRepository, DimensionRepository>();
        services.AddScoped<IDirectorRepository, DirectorRepository>();
        services.AddScoped<IEditionRepository, EditionRepository>();
        services.AddScoped<IEditorRepository, EditorRepository>();
        services.AddScoped<IEMaterialFileRepository, EMaterialFileRepository>();
        services.AddScoped<IGraphicDesignerRepository, GraphicDesignerRepository>();
        services.AddScoped<IGraphicDirectorRepository, GraphicDirectorRepository>();
        services.AddScoped<IImageRepository, ImageRepository>();
        services.AddScoped<IInterpretersRepository, InterpretersRepository>();
        services.AddScoped<ILanguageRepository, LanguageRepository>();
        services.AddScoped<ILibraryRepository, LibraryRepository>();
        services.AddScoped<IOtherPeopleRepository, OtherPeopleRepository>();
        services.AddScoped<IPublisherRepository, PublisherRepository>();
        services.AddScoped<IRedactionRepository, RedactionRepository>();
        services.AddScoped<IReferenceRepository, ReferenceRepository>();
        services.AddScoped<IResearcherRepository, ResearcherRepository>();
        services.AddScoped<IStockRepository, StockRepository>();
        services.AddScoped<ITechnicalNumberRepository, TechnicalNumberRepository>();
        services.AddScoped<ITechnicalPlaceholderRepository, TechnicalPlaceholderRepository>();
        services.AddScoped<IUniversityRepository, UniversityRepository>();
        services.AddScoped<IWriterRepository, WriterRepository>();

        return services;
    }
}
