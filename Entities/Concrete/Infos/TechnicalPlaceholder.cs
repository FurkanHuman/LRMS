using Core.Entities.Abstract;
using System.ComponentModel.DataAnnotations;

namespace Entities.Concrete.Infos
{
    public class TechnicalPlaceholder : IEntity
    {
        [Key]
        public Guid Id { get; set; }

        public Library Library { get; set; }

        [MaxLength(24)]
        public string? StockCode { get; set; }

        [Required]
        public ulong StockNumber { get; set; }

        [Required]
        public string WhereIsMaterial { get; set; }

        public bool IsDeleted { get; set; }

    }
}
