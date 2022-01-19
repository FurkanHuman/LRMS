using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class BookType
    {
        [Key]
        [JsonIgnore]
        public int Id { get; set; }

        [Required]
        public string BookTypeName { get; set; }
    }
}
