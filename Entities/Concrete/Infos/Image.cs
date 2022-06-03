using Core.Entities.Abstract;
using System.ComponentModel.DataAnnotations;

namespace Entities.Concrete.Infos
{
    public class Image : IEntity
    {
        [Key]
        public Guid Id { get; set; }

        public string ImagePath { get; set; }

        public DateTime Date { get; set; }

        public bool IsDeleted { get; set; }
    }
}
