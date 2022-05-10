using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Entities.Concrete.Base
{
    public class FirstPagePersonBase
    {
        [Key, JsonIgnore]
        public int Id { get; set; }

        public string Name { get; set; }

        public string SurName { get; set; }

        public bool IsDeleted { get; set; }
    }
}
