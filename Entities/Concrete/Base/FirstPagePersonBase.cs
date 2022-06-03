using System.ComponentModel.DataAnnotations;

namespace Entities.Concrete.Base
{
    public class FirstPagePersonBase
    {
        [Key]
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string SurName { get; set; }

        public bool IsDeleted { get; set; }
    }
}
