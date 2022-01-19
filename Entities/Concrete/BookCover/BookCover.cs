using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Entities.Concrete.BookCover
{
    public class BookCover:IEntity
    {
        [Key]
        [JsonIgnore]
        public int Id { get; set; }
    }
}
