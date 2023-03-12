using Core.Domain.Abstract;
using Domain.Entities.Infos;
using Domain.Entities.Mains;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Reflection;

namespace Persistence.Contexts.BaseContext;

public class BaseLrmsContext : DbContext
{
    public BaseLrmsContext(DbContextOptions dbContextOptions) : base(dbContextOptions) { }

    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = new())
    {
        IEnumerable<EntityEntry<IEntity>> entries = ChangeTracker
            .Entries<IEntity>()
            .Where(ie => ie.State == EntityState.Added || ie.State == EntityState.Modified);

        foreach (EntityEntry<IEntity> entry in entries)
            _ = entry.State switch
            {
                EntityState.Added => entry.Entity.CreatedDate = DateTime.UtcNow,
                EntityState.Modified => entry.Entity.UpdatedDate = DateTime.UtcNow
            };
        return await base.SaveChangesAsync(cancellationToken);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly(), e => e.Namespace == "Persistence.EntityConfigurations.Lrms");
    }


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

    // IntermediateTables

    //public DbSet<AcademicJournalCategory> AcademicJournalCategories { get; set; }
    //public DbSet<AcademicJournalDimension> AcademicJournalDimensions { get; set; }
    //public DbSet<AcademicJournalEditor> AcademicJournalEditors { get; set; }
    //public DbSet<AcademicJournalEMaterialFile> AcademicJournalEMaterialFiles { get; set; }
    //public DbSet<AcademicJournalKit> AcademicJournalKits { get; set; }
    //public DbSet<AcademicJournalPublisher> AcademicJournalPublishers { get; set; }
    //public DbSet<AcademicJournalReference> AcademicJournalReferences { get; set; }
    //public DbSet<AcademicJournalResearcher> AcademicJournalResearchers { get; set; }
    //public DbSet<AcademicJournalTechnicalPlaceholder> AcademicJournalTechnicalPlaceholders { get; set; }
    //public DbSet<AudioRecordCategory> AudioRecordCategories { get; set; }
    //public DbSet<AudioRecordDimension> AudioRecordDimensions { get; set; }
    //public DbSet<AudioRecordEMaterialFile> AudioRecordEMaterialFiles { get; set; }
    //public DbSet<AudioRecordKit> AudioRecordKits { get; set; }
    //public DbSet<AudioRecordTechnicalPlaceholder> AudioRecordTechnicalPlaceholders { get; set; }
    //public DbSet<BookBookSeries> BookBookSeries { get; set; }
    //public DbSet<BookCategory> BookCategories { get; set; }
    //public DbSet<BookCoverCap> BookCoverCaps { get; set; }
    //public DbSet<BookDimension> BookDimensions { get; set; }
    //public DbSet<BookDirector> BookDirectors { get; set; }
    //public DbSet<BookEdition> BookEditions { get; set; }
    //public DbSet<BookEditor> BookEditors { get; set; }
    //public DbSet<BookEMaterialFile> BookEMaterialFiles { get; set; }
    //public DbSet<BookGraphicDesigner> BookGraphicDesigners { get; set; }
    //public DbSet<BookGraphicDirector> BookGraphicDirectors { get; set; }
    //public DbSet<BookImage> BookImages { get; set; }
    //public DbSet<BookInterpreters> BookInterpreters { get; set; }
    //public DbSet<BookKit> BookKits { get; set; }
    //public DbSet<BookOtherPeople> BookOtherPeoples { get; set; }
    //public DbSet<BookRedaction> BookRedactions { get; set; }
    //public DbSet<BookReference> BookReferences { get; set; }
    //public DbSet<BookSeriesCategory> BookSeriesCategories { get; set; }
    //public DbSet<BookSeriesCoverCap> BookSeriesCoverCaps { get; set; }
    //public DbSet<BookSeriesDimension> BookSeriesDimensions { get; set; }
    //public DbSet<BookSeriesDirector> BookSeriesDirectors { get; set; }
    //public DbSet<BookSeriesEdition> BookSeriesEditions { get; set; }
    //public DbSet<BookSeriesEditor> BookSeriesEditors { get; set; }
    //public DbSet<BookSeriesEMaterialFile> BookSeriesEMaterialFiles { get; set; }
    //public DbSet<BookSeriesGraphicDesigner> BookSeriesGraphicDesigners { get; set; }
    //public DbSet<BookSeriesGraphicDirector> BookSeriesGraphicDirectors { get; set; }
    //public DbSet<BookSeriesImage> BookSeriesImages { get; set; }
    //public DbSet<BookSeriesInterpreters> BookSeriesInterpreters { get; set; }
    //public DbSet<BookSeriesKit> BookSeriesKits { get; set; }
    //public DbSet<BookSeriesOtherPeople> BookSeriesOtherPeoples { get; set; }
    //public DbSet<BookSeriesRedaction> BookSeriesRedactions { get; set; }
    //public DbSet<BookSeriesTechnicalNumber> BookSeriesTechnicalNumbers { get; set; }
    //public DbSet<BookSeriesTechnicalPlaceholder> BookSeriesTechnicalPlaceholders { get; set; }
    //public DbSet<BookSeriesWriter> BookSeriesWriters { get; set; }
    //public DbSet<BookTechnicalNumber> BookTechnicalNumbers { get; set; }
    //public DbSet<BookTechnicalPlaceholder> BookTechnicalPlaceholders { get; set; }
    //public DbSet<BookWriter> BookWriters { get; set; }
    //public DbSet<CartographicMaterialCategory> CartographicMaterialCategories { get; set; }
    //public DbSet<CartographicMaterialDimension> CartographicMaterialDimensions { get; set; }
    //public DbSet<CartographicMaterialEMaterialFile> CartographicMaterialEMaterialFiles { get; set; }
    //public DbSet<CartographicMaterialImage> CartographicMaterialImages { get; set; }
    //public DbSet<CartographicMaterialKit> CartographicMaterialKits { get; set; }
    //public DbSet<CartographicMaterialTechnicalPlaceholder> CartographicMaterialTechnicalPlaceholders { get; set; }
    //public DbSet<CategoryDepiction> CategoryDepictions { get; set; }
    //public DbSet<CategoryDissertation> CategoryDissertations { get; set; }
    //public DbSet<CategoryElectronicsResource> CategoryElectronicsResources { get; set; }
    //public DbSet<CategoryEncyclopedia> CategoryEncyclopedias { get; set; }
    //public DbSet<CategoryGraphicalImage> CategoryGraphicalImages { get; set; }
    //public DbSet<CategoryKit> CategoryKits { get; set; }
    //public DbSet<CategoryMagazine> CategoryMagazines { get; set; }
    //public DbSet<CategoryMicroform> CategoryMicroforms { get; set; }
    //public DbSet<CategoryMusicalNote> CategoryMusicalNotes { get; set; }
    //public DbSet<CategoryNewsPaper> CategoryNewsPapers { get; set; }
    //public DbSet<CategoryObject3d> CategoryObject3d { get; set; }
    //public DbSet<CategoryPainting> CategoryPaintings { get; set; }
    //public DbSet<CategoryPoster> CategoryPosters { get; set; }
    //public DbSet<CategoryThesis> CategoryThesis { get; set; }
    //public DbSet<CloudStorageElectronicsResource> CloudStorageElectronicsResources { get; set; }
    //public DbSet<CloudStorageEMaterialFile> CloudStorageEMaterialFiles { get; set; }
    //public DbSet<CloudStorageImage> CloudStorageImages { get; set; }
    //public DbSet<CoverCapEncyclopedia> CoverCapEncyclopedias { get; set; }
    //public DbSet<CoverCapMagazine> CoverCapMagazines { get; set; }
    //public DbSet<CoverCapNewsPaper> CoverCapNewsPapers { get; set; }
    //public DbSet<DepictionDimension> DepictionDimensions { get; set; }
    //public DbSet<DepictionEMaterialFile> DepictionEMaterialFiles { get; set; }
    //public DbSet<DepictionKit> DepictionKits { get; set; }
    //public DbSet<DepictionTechnicalPlaceholder> DepictionTechnicalPlaceholders { get; set; }
    //public DbSet<DimensionDissertation> DimensionDissertations { get; set; }
    //public DbSet<DimensionElectronicsResource> DimensionElectronicsResources { get; set; }
    //public DbSet<DimensionEncyclopedia> DimensionEncyclopedias { get; set; }
    //public DbSet<DimensionGraphicalImage> DimensionGraphicalImages { get; set; }
    //public DbSet<DimensionMagazine> DimensionMagazines { get; set; }
    //public DbSet<DimensionMicroform> DimensionMicroforms { get; set; }
    //public DbSet<DimensionMusicalNote> DimensionMusicalNotes { get; set; }
    //public DbSet<DimensionNewsPaper> DimensionNewsPapers { get; set; }
    //public DbSet<DimensionObject3d> DimensionObject3d { get; set; }
    //public DbSet<DimensionPainting> DimensionPaintings { get; set; }
    //public DbSet<DimensionPoster> DimensionPosters { get; set; }
    //public DbSet<DimensionThesis> DimensionThesis { get; set; }
    //public DbSet<DirectorEncyclopedia> DirectorEncyclopedias { get; set; }
    //public DbSet<DirectorMagazine> DirectorMagazines { get; set; }
    //public DbSet<DirectorNewsPaper> DirectorNewsPapers { get; set; }
    //public DbSet<DissertationEMaterialFile> DissertationEMaterialFiles { get; set; }
    //public DbSet<DissertationKit> DissertationKits { get; set; }
    //public DbSet<DissertationResearcher> DissertationResearchers { get; set; }
    //public DbSet<DissertationTechnicalPlaceholder> DissertationTechnicalPlaceholders { get; set; }
    //public DbSet<DissertationUniversity> DissertationUniversities { get; set; }
    //public DbSet<EditionEncyclopedia> EditionEncyclopedias { get; set; }
    //public DbSet<EditionMagazine> EditionMagazines { get; set; }
    //public DbSet<EditionNewsPaper> EditionNewsPapers { get; set; }
    //public DbSet<EditorEncyclopedia> EditorEncyclopedias { get; set; }
    //public DbSet<EditorMagazine> EditorMagazines { get; set; }
    //public DbSet<EditorNewsPaper> EditorNewsPapers { get; set; }
    //public DbSet<ElectronicsResourceKit> ElectronicsResourceKits { get; set; }
    //public DbSet<ElectronicsResourceTechnicalPlaceholder> ElectronicsResourceTechnicalPlaceholders { get; set; }
    //public DbSet<EMaterialFileElectronicsResource> EMaterialFileElectronicsResources { get; set; }
    //public DbSet<EMaterialFileEncyclopedia> EMaterialFileEncyclopedias { get; set; }
    //public DbSet<EMaterialFileGraphicalImage> EMaterialFileGraphicalImages { get; set; }
    //public DbSet<EMaterialFileMagazine> EMaterialFileMagazines { get; set; }
    //public DbSet<EMaterialFileMicroform> EMaterialFileMicroforms { get; set; }
    //public DbSet<EMaterialFileMusicalNote> EMaterialFileMusicalNotes { get; set; }
    //public DbSet<EMaterialFileNewsPaper> EMaterialFileNewsPapers { get; set; }
    //public DbSet<EMaterialFileObject3d> EMaterialFileObject3d { get; set; }
    //public DbSet<EMaterialFilePainting> EMaterialFilePaintings { get; set; }
    //public DbSet<EMaterialFilePoster> EMaterialFilePosters { get; set; }
    //public DbSet<EMaterialFileThesis> EMaterialFileThesis { get; set; }
    //public DbSet<EncyclopediaGraphicDesigner> EncyclopediaGraphicDesigners { get; set; }
    //public DbSet<EncyclopediaGraphicDirector> EncyclopediaGraphicDirectors { get; set; }
    //public DbSet<EncyclopediaImage> EncyclopediaImages { get; set; }
    //public DbSet<EncyclopediaInterpreters> EncyclopediaInterpreters { get; set; }
    //public DbSet<EncyclopediaKit> EncyclopediaKits { get; set; }
    //public DbSet<EncyclopediaOtherPeople> EncyclopediaOtherPeoples { get; set; }
    //public DbSet<EncyclopediaRedaction> EncyclopediaRedactions { get; set; }
    //public DbSet<EncyclopediaReference> EncyclopediaReferences { get; set; }
    //public DbSet<EncyclopediaTechnicalNumber> EncyclopediaTechnicalNumbers { get; set; }
    //public DbSet<EncyclopediaTechnicalPlaceholder> EncyclopediaTechnicalPlaceholders { get; set; }
    //public DbSet<EncyclopediaWriter> EncyclopediaWriters { get; set; }
    //public DbSet<GraphicalImageKit> GraphicalImageKits { get; set; }
    //public DbSet<GraphicalImageTechnicalPlaceholder> GraphicalImageTechnicalPlaceholders { get; set; }
    //public DbSet<GraphicDesignerMagazine> GraphicDesignerMagazines { get; set; }
    //public DbSet<GraphicDesignerNewsPaper> GraphicDesignerNewsPapers { get; set; }
    //public DbSet<GraphicDirectorMagazine> GraphicDirectorMagazines { get; set; }
    //public DbSet<GraphicDirectorNewsPaper> GraphicDirectorNewsPapers { get; set; }
    //public DbSet<ImageKit> ImageKits { get; set; }
    //public DbSet<ImageMagazine> ImageMagazines { get; set; }
    //public DbSet<ImageNewsPaper> ImageNewsPapers { get; set; }
    //public DbSet<ImageObject3d> ImageObject3d { get; set; }
    //public DbSet<ImagePainting> ImagePaintings { get; set; }
    //public DbSet<İnterpretersMagazine> İnterpretersMagazine { get; set; }
    //public DbSet<İnterpretersNewsPaper> İnterpretersNewsPaper { get; set; }
    //public DbSet<KitMagazine> KitMagazines { get; set; }
    //public DbSet<KitMicroform> KitMicroforms { get; set; }
    //public DbSet<KitMusicalNote> KitMusicalNotes { get; set; }
    //public DbSet<KitNewsPaper> KitNewsPapers { get; set; }
    //public DbSet<KitObject3d> KitObject3d { get; set; }
    //public DbSet<KitPainting> KitPaintings { get; set; }
    //public DbSet<KitPoster> KitPosters { get; set; }
    //public DbSet<KitThesis> KitThesis { get; set; }
    //public DbSet<MagazineOtherPeople> MagazineOtherPeoples { get; set; }
    //public DbSet<MagazineRedaction> MagazineRedactions { get; set; }
    //public DbSet<MagazineTechnicalNumber> MagazineTechnicalNumbers { get; set; }
    //public DbSet<MagazineTechnicalPlaceholder> MagazineTechnicalPlaceholders { get; set; }
    //public DbSet<MagazineWriter> MagazineWriters { get; set; }
    //public DbSet<MicroformTechnicalPlaceholder> MicroformTechnicalPlaceholders { get; set; }
    //public DbSet<MusicalNoteTechnicalPlaceholder> MusicalNoteTechnicalPlaceholders { get; set; }
    //public DbSet<NewsPaperOtherPeople> NewsPaperOtherPeoples { get; set; }
    //public DbSet<NewsPaperRedaction> NewsPaperRedactions { get; set; }
    //public DbSet<NewsPaperTechnicalNumber> NewsPaperTechnicalNumbers { get; set; }
    //public DbSet<NewsPaperTechnicalPlaceholder> NewsPaperTechnicalPlaceholders { get; set; }
    //public DbSet<NewsPaperWriter> NewsPaperWriters { get; set; }
    //public DbSet<Object3dTechnicalPlaceholder> Object3dTechnicalPlaceholder { get; set; }
    //public DbSet<PaintingTechnicalPlaceholder> PaintingTechnicalPlaceholders { get; set; }
    //public DbSet<PosterTechnicalPlaceholder> PosterTechnicalPlaceholders { get; set; }
    //public DbSet<TechnicalPlaceholderThesis> TechnicalPlaceholderThesis { get; set; }
}
