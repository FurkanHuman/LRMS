using Core.Entities.Abstract;
using System.ComponentModel.DataAnnotations;

namespace Entities.Concrete.BookFirstPage
{
    public class BookTechnicalNumber : IEntity
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public long Barcode { get; set; }

        [MaxLength(56)]
        public string ISBN { get; set; }

        [MaxLength(24)]
        public string StockCode { get; set; }

        [Required]
        public long StockNumber { get; set; }

        [MaxLength(64)]
        public string CertificateCode { get; set; }
    }
}
