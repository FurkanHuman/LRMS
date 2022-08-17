using Microsoft.EntityFrameworkCore;

namespace DataAccess.Contexts
{
    public class PostgreDbContext : DbContext
    {
        public PostgreDbContext() : base() { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //IJsonReader jsonReader = new JsonReaderMicrosoft()
            //optionsBuilder.UseNpgsql(jsonReader.Reader("PostgreSQLConfig.json", "PostgreConnectionString")).UseSnakeCaseNamingConvention()
            //optionsBuilder.UseNpgsql("Host=localhost;Database=LRMS_DataBase;Username=postgres;Password=12345").UseSnakeCaseNamingConvention()
            optionsBuilder.UseNpgsql("Host=localhost;Database=LRMS_Test_DataBase;Username=postgres;Password=12345").UseSnakeCaseNamingConvention();
        }

        // Infos

        public DbSet<Address> Addresses { get; set; }
        public DbSet<Branch> Branches { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<City> Cities { get; set; }
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

        // Concrete

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
}
