using Core.Entities.Abstract;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Entities.Concrete.Infos
{
    public class CoverCap : IEntity
    {   // kitap kapağı tipikartonderi vs vs
        [Key]
        public int Id { get; set; }

        public string BookSkinType { get; set; }

        public bool IsDeleted { get; set; }
    }
}
