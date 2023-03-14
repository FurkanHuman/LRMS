using Application.Services.AcademicJournalService;
using Application.Services.AudioRecordService;
using Application.Services.BookSeriesService;
using Application.Services.BookService;
using Application.Services.CartographicMaterialService;
using Application.Services.DepictionService;
using Application.Services.DissertationService;
using Application.Services.ElectronicsResourceService;
using Application.Services.EncyclopediaService;
using Application.Services.GraphicalImageService;
using Application.Services.KitService;
using Application.Services.MagazineService;
using Application.Services.MicroformService;
using Application.Services.MusicalNoteService;
using Application.Services.NewsPaperService;
using Application.Services.Object3DService;
using Application.Services.PaintingService;
using Application.Services.PosterService;
using Application.Services.ThesisService;
using Microsoft.Extensions.DependencyInjection;

namespace Application.ServiceRegistrations;

public static class LrmsMainRegistration
{
    public static IServiceCollection AddLRMSMainRegistration(this IServiceCollection services)
    {
        // LRMS Main

        services.AddScoped<IAcademicJournalService, AcademicJournalManager>();
        services.AddScoped<IAudioRecordService, AudioRecordManager>();
        services.AddScoped<IBookService, BookManager>();
        services.AddScoped<IBookSeriesService, BookSeriesManager>();
        services.AddScoped<ICartographicMaterialService, CartographicMaterialManager>();
        services.AddScoped<IDepictionService, DepictionManager>();
        services.AddScoped<IDissertationService, DissertationManager>();
        services.AddScoped<IElectronicsResourceService, ElectronicsResourceManager>();
        services.AddScoped<IEncyclopediaService, EncyclopediaManager>();
        services.AddScoped<IGraphicalImageService, GraphicalImageManager>();
        services.AddScoped<IKitService, KitManager>();
        services.AddScoped<IMagazineService, MagazineManager>();
        services.AddScoped<IMicroformService, MicroformManager>();
        services.AddScoped<IMusicalNoteService, MusicalNoteManager>();
        services.AddScoped<INewsPaperService, NewsPaperManager>();
        services.AddScoped<IObject3DService, Object3DManager>();
        services.AddScoped<IPaintingService, PaintingManager>();
        services.AddScoped<IPosterService, PosterManager>();
        services.AddScoped<IThesisService, ThesisManager>();

        return services;
    }
}
