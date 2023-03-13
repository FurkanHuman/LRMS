using Application.Services.AddressService;
using Application.Services.BranchService;
using Application.Services.CategoryService;
using Application.Services.CityService;
using Application.Services.CloudStorageService;
using Application.Services.CommunicationService;
using Application.Services.ComposerService;
using Application.Services.ConsultantService;
using Application.Services.CounterService;
using Application.Services.CountryService;
using Application.Services.CoverCapService;
using Application.Services.DimensionService;
using Application.Services.DirectorService;
using Application.Services.EditionService;
using Application.Services.EditorService;
using Application.Services.EMaterialFileService;
using Application.Services.GraphicDesignerService;
using Application.Services.GraphicDirectorService;
using Application.Services.ImageService;
using Application.Services.InterpretersService;
using Application.Services.LanguageService;
using Application.Services.LibraryService;
using Application.Services.OtherPeopleService;
using Application.Services.PublisherService;
using Application.Services.RedactionService;
using Application.Services.ReferenceService;
using Application.Services.ResearcherService;
using Application.Services.StockService;
using Application.Services.TechnicalNumberService;
using Application.Services.TechnicalPlaceholderService;
using Application.Services.UniversityService;
using Application.Services.WriterService;
using Microsoft.Extensions.DependencyInjection;

namespace Application.Services.ServiceRegistrations;

public static class LrmsInfoRegistration
{
    public static IServiceCollection AddLrmsInfoRegistration(this IServiceCollection services)
    {
        // LRMS Info

        services.AddScoped<IAddressService, AddressManager>();
        services.AddScoped<IBranchService, BranchManager>();
        services.AddScoped<ICategoryService, CategoryManager>();
        services.AddScoped<ICityService, CityManager>();
        services.AddScoped<ICloudStorageService, CloudStorageManager>();
        services.AddScoped<ICommunicationService, CommunicationManager>();
        services.AddScoped<IComposerService, ComposerManager>();
        services.AddScoped<IConsultantService, ConsultantManager>();
        services.AddScoped<ICounterService, CounterManager>();
        services.AddScoped<ICountryService, CountryManager>();
        services.AddScoped<ICoverCapService, CoverCapManager>();
        services.AddScoped<IDimensionService, DimensionManager>();
        services.AddScoped<IDirectorService, DirectorManager>();
        services.AddScoped<IEditionService, EditionManager>();
        services.AddScoped<IEditorService, EditorManager>();
        services.AddScoped<IEMaterialFileService, EMaterialFileManager>();
        services.AddScoped<IGraphicDesignerService, GraphicDesignerManager>();
        services.AddScoped<IGraphicDirectorService, GraphicDirectorManager>();
        services.AddScoped<IImageService, ImageManager>();
        services.AddScoped<IInterpretersService, InterpretersManager>();
        services.AddScoped<ILanguageService, LanguageManager>();
        services.AddScoped<ILibraryService, LibraryManager>();
        services.AddScoped<IOtherPeopleService, OtherPeopleManager>();
        services.AddScoped<IPublisherService, PublisherManager>();
        services.AddScoped<IRedactionService, RedactionManager>();
        services.AddScoped<IReferenceService, ReferenceManager>();
        services.AddScoped<IResearcherService, ResearcherManager>();
        services.AddScoped<IStockService, StockManager>();
        services.AddScoped<ITechnicalNumberService, TechnicalNumberManager>();
        services.AddScoped<ITechnicalPlaceholderService, TechnicalPlaceholderManager>();
        services.AddScoped<IUniversityService, UniversityManager>();
        services.AddScoped<IWriterService, WriterManager>();

        return services;
    }
}
