using Core.Domain.Abstract;
using Domain.Entities.Bases;
using Domain.Entities.Infos;

namespace Domain.Entities.Mains;

public class Kit : MaterialBase, IEntity
{
    public Guid ImageId { get; set; }

    public Guid? AcademicJournalsId { get; set; }

    public Guid? AudioRecordsId { get; set; }

    public Guid? BooksId { get; set; }

    public Guid? BookSeriesId { get; set; }

    public Guid? CartographicMaterialsId { get; set; }

    public Guid? DepictionsId { get; set; }

    public Guid? DissertationsId { get; set; }

    public Guid? ElectronicsResourcesId { get; set; }

    public Guid? EncyclopediasId { get; set; }

    public Guid? GraphicalImagesId { get; set; }

    public Guid? MagazinesId { get; set; }

    public Guid? MicroformsId { get; set; }

    public Guid? MusicalNotesId { get; set; }

    public Guid? NewsPapersId { get; set; }

    public Guid? Object3DsId { get; set; }

    public Guid? PaintingsId { get; set; }

    public Guid? PostersId { get; set; }

    public Guid? ThesesId { get; set; }

    public bool IsKitBroken { get; set; }

    public IList<Image> Images { get; set; }

    public IList<AcademicJournal>? AcademicJournals { get; set; }

    public IList<AudioRecord>? AudioRecords { get; set; }

    public IList<Book>? Books { get; set; }

    public IList<BookSeries>? BookSeries { get; set; }

    public IList<CartographicMaterial>? CartographicMaterials { get; set; }

    public IList<Depiction>? Depictions { get; set; }

    public IList<Dissertation>? Dissertations { get; set; }

    public IList<ElectronicsResource>? ElectronicsResources { get; set; }

    public IList<Encyclopedia>? Encyclopedias { get; set; }

    public IList<GraphicalImage>? GraphicalImages { get; set; }

    public IList<Magazine>? Magazines { get; set; }

    public IList<Microform>? Microforms { get; set; }

    public IList<MusicalNote>? MusicalNotes { get; set; }

    public IList<NewsPaper>? NewsPapers { get; set; }

    public IList<Object3D>? Object3Ds { get; set; }

    public IList<Painting>? Paintings { get; set; }

    public IList<Poster>? Posters { get; set; }

    public IList<Thesis>? Theses { get; set; }
}
