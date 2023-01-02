using Application.Repositories;
using Microsoft.Extensions.DependencyInjection;
using Persistence.Repositories;

namespace Persistence.ServiceRegistrations;

public static class LrmsMainRegistration
{
    public static IServiceCollection AddLRMSMainRegistration(this IServiceCollection services)
    {
        // LRMS Main

        services.AddScoped<IAcademicJournalRepository, AcademicJournalRepository>();
        services.AddScoped<IAudioRecordRepository, AudioRecordRepository>();
        services.AddScoped<IBookRepository, BookRepository>();
        services.AddScoped<IBookSeriesRepository, BookSeriesRepository>();
        services.AddScoped<ICartographicMaterialRepository, CartographicMaterialRepository>();
        services.AddScoped<IDepictionRepository, DepictionRepository>();
        services.AddScoped<IDissertationRepository, DissertationRepository>();
        services.AddScoped<IElectronicsResourceRepository, ElectronicsResourceRepository>();
        services.AddScoped<IEncyclopediaRepository, EncyclopediaRepository>();
        services.AddScoped<IGraphicalImageRepository, GraphicalImageRepository>();
        services.AddScoped<IKitRepository, KitRepository>();
        services.AddScoped<IMagazineRepository, MagazineRepository>();
        services.AddScoped<IMicroformRepository, MicroformRepository>();
        services.AddScoped<IMusicalNoteRepository, MusicalNoteRepository>();
        services.AddScoped<INewsPaperRepository, NewsPaperRepository>();
        services.AddScoped<IObject3DRepository, Object3DRepository>();
        services.AddScoped<IPaintingRepository, PaintingRepository>();
        services.AddScoped<IPosterRepository, PosterRepository>();
        services.AddScoped<IThesisRepository, ThesisRepository>();

        return services;
    }
}
