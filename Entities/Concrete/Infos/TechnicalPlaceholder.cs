using Core.Entities.Abstract;
using System.ComponentModel.DataAnnotations;

namespace Entities.Concrete.Infos
{
    public class TechnicalPlaceholder : IEntity
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(24)]
        public string? StockCode { get; set; }

        [Required]
        public ulong StockNumber { get; set; }

        [Required]
        public string WhereMaterial { get; set; }

        public bool IsDeleted { get; set; }

    }
}
