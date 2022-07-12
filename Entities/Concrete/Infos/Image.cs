using Core.Entities.Abstract;
using System.ComponentModel.DataAnnotations;

namespace Entities.Concrete.Infos
{
    public class Image : IEntity
    {
        [Key]
        public Guid Id { get; set; }

        public string ImagePath { get; set; }

        public DateTime Date { get; set; }

        public bool IsDeleted { get; set; }

        public IList<Book> Books { get; set; }
        public IList<BookSeries> BookSeries { get; set; }
        public IList<CartographicMaterial> CartographicMaterials { get; set; }
        public IList<Encyclopedia> Encyclopedias { get; set; }
        public IList<Kit> kits { get; set; }
        public IList<Magazine> Magazines { get; set; }
        public IList<NewsPaper> NewsPapers { get; set; }
        public IList<Object3D> Object3Ds { get; set; }
        public IList<Poster> Posters { get; set; }

    }
}
