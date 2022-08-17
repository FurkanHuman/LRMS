using Core.Entities.Abstract;
using System.ComponentModel.DataAnnotations;

namespace Entities.Concrete.Entities.Infos
{
    public class Branch : IEntity
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public bool IsDeleted { get; set; }
    }
}
