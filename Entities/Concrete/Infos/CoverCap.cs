using Core.Entities.Abstract;
using System.ComponentModel.DataAnnotations;

namespace Entities.Concrete.Infos
{
    public class CoverCap : IEntity
    {   // kitap kapağı tipi, karton, deri,  vs vs
        [Key]
        public int Id { get; set; }

        public string BookSkinType { get; set; }

        public bool IsDeleted { get; set; }
    }
}
