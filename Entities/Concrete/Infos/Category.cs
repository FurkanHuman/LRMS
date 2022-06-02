using Core.Entities.Abstract;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Entities.Concrete.Infos
{
    public class Category : IEntity
    {
        [Key]
        public int Id { get; set; }

        public string CategoryName { get; set; }

        public bool IsDeleted { get; set; }
    }
}
