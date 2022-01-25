using Core.Entities.Abstract;
using System.ComponentModel.DataAnnotations;

namespace Entities.Concrete.Infos
{
    public class TechnicalNumber : IEntity
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public long Barcode { get; set; }

        [Required]
        public ulong ISBN { get; set; }

        [MaxLength(24)]
        public string StockCode { get; set; }

        [Required]
        public ulong StockNumber { get; set; }

        [MaxLength(64)]
        public string CertificateCode { get; set; }

        public bool IsDeleted { get; set; }
    }
}
