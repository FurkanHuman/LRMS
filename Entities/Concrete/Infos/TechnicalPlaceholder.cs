using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete.Infos
{
    public class TechnicalPlaceholder:IEntity
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
