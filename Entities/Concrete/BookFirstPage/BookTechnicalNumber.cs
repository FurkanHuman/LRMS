using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete.BookFirstPage
{
    internal class BookTechnicalNumber:IEntity
    {
        [Key]
        public int Id { get; set; }

        public long? Barcode { get; set; }

        [MaxLength(56)]
        public string? ISBN { get; set; }

        [MaxLength(24)]
        public string? StockCode { get; set; }

        public long? StockNumber { get; set; }

        [MaxLength(64)]
        public string? CertificateCode { get; set; }
    }
}
