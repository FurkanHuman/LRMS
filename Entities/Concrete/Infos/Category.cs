using Core.Entities.Abstract;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Entities.Concrete.Infos
{
    public class Category : IEntity
    {// category
        [Key, JsonIgnore]
        public int Id { get; set; }

        [MinLength(2),Required]
        public string CategoryName { get; set; }
    }
}
