using Core.Entities.Abstract;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Entities.Concrete.BookFirstPage
{
    public class BookFirstPagePersonBase : IEntity
    {
        [Key, JsonIgnore]
        public int Id { get; set; }

        [MaxLength(32), Required]
        public string Name { get; set; }


        [MaxLength(32), Required]
        public string SurName { get; set; }
    }
}
