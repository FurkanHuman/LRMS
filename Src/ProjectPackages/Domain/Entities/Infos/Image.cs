using Core.Domain.Abstract;
using Core.Domain.Bases;
using Domain.Entities.Mains;

namespace Domain.Entities.Infos;

public class Image : BaseEntity<Guid>, IEntity
{
    public string Url { get; set; }
    public uint CloudStorageServiceId { get; set; }
    public DateTime Date { get; set; }
    public IList<CloudStorage> CloudStorageService { get; set; }
    public IList<Book> Books { get; set; }
    public IList<BookSeries> BookSeries { get; set; }
    public IList<CartographicMaterial> CartographicMaterials { get; set; }
    public IList<Encyclopedia> Encyclopedias { get; set; }
    public IList<Kit> Kits { get; set; }
    public IList<Magazine> Magazines { get; set; }
    public IList<NewsPaper> NewsPapers { get; set; }
    public IList<Object3D> Object3Ds { get; set; }
    public IList<Painting> Paintings { get; set; }
    public IList<Poster> Posters { get; set; }
}
