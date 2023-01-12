using Core.Domain.Abstract;
using Domain.Entities.Infos;
using Domain.Entities.Mains;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.Extensions.Configuration;
using System.Reflection;

namespace Persistence.Contexts;

public class PostgreLrmsDbContext : DbContext
{
    public PostgreLrmsDbContext(DbContextOptions dbContextOptions, IConfiguration configuration) : base(dbContextOptions)
    {
        Configuration = configuration;
    }
        

    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
    {
        IEnumerable<EntityEntry<IEntity>> datas = ChangeTracker
            .Entries<IEntity>();

        foreach (var data in datas)
        {
#pragma warning disable CS8509 // The switch expression does not handle all possible values of its input type (it is not exhaustive).
            _ = data.State switch
            {
                EntityState.Added => data.Entity.CreatedDate = DateTime.UtcNow,
                EntityState.Modified => data.Entity.UpdatedDate = DateTime.UtcNow
            };
#pragma warning restore CS8509 // The switch expression does not handle all possible values of its input type (it is not exhaustive).
        }
        return await base.SaveChangesAsync(cancellationToken);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }

    protected IConfiguration Configuration { get; set; }

    // Infos

    public DbSet<Address> Addresses { get; set; }
    public DbSet<Branch> Branches { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<City> Cities { get; set; }
    public DbSet<CloudStorage> CloudStorages { get; set; }
    public DbSet<Communication> Communications { get; set; }
    public DbSet<Composer> Composers { get; set; }
    public DbSet<Consultant> Consultants { get; set; }
    public DbSet<Counter> Counters { get; set; }
    public DbSet<Country> Countries { get; set; }
    public DbSet<CoverCap> CoverCaps { get; set; }
    public DbSet<Dimension> Dimensions { get; set; }
    public DbSet<Director> Directors { get; set; }
    public DbSet<Edition> Editions { get; set; }
    public DbSet<Editor> Editors { get; set; }
    public DbSet<EMaterialFile> EMaterialFiles { get; set; }
    public DbSet<GraphicDesigner> GraphicDesigners { get; set; }
    public DbSet<GraphicDirector> GraphicDirectors { get; set; }
    public DbSet<Image> Images { get; set; }
    public DbSet<Interpreters> Interpreters { get; set; }
    public DbSet<Language> Languages { get; set; }
    public DbSet<Library> Libraries { get; set; }
    public DbSet<OtherPeople> OtherPeoples { get; set; }
    public DbSet<Publisher> Publishers { get; set; }
    public DbSet<Redaction> Redactions { get; set; }
    public DbSet<Reference> References { get; set; }
    public DbSet<Researcher> Researchers { get; set; }
    public DbSet<Stock> Stocks { get; set; }
    public DbSet<TechnicalNumber> TechnicalNumbers { get; set; }
    public DbSet<TechnicalPlaceholder> TechnicalPlaceholders { get; set; }
    public DbSet<University> Universities { get; set; }
    public DbSet<Writer> Writers { get; set; }

    // Main

    public DbSet<AcademicJournal> AcademicJournals { get; set; }
    public DbSet<AudioRecord> AudioRecords { get; set; }
    public DbSet<Book> Books { get; set; }
    public DbSet<BookSeries> BookSeries { get; set; }
    public DbSet<CartographicMaterial> CartographicMaterials { get; set; }
    public DbSet<Depiction> Depictions { get; set; }
    public DbSet<Dissertation> Dissertations { get; set; }
    public DbSet<ElectronicsResource> ElectronicsResources { get; set; }
    public DbSet<Encyclopedia> Encyclopedias { get; set; }
    public DbSet<GraphicalImage> GraphicalImages { get; set; }
    public DbSet<Kit> Kits { get; set; }
    public DbSet<Magazine> Magazines { get; set; }
    public DbSet<Microform> Microforms { get; set; }
    public DbSet<MusicalNote> MusicalNotes { get; set; }
    public DbSet<NewsPaper> NewsPapers { get; set; }
    public DbSet<Object3D> Object3Ds { get; set; }
    public DbSet<Painting> Paintings { get; set; }
    public DbSet<Poster> Posters { get; set; }
    public DbSet<Thesis> Theses { get; set; }
}
