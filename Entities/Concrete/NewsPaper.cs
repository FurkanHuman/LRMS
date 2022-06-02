using Core.Entities.Abstract;
using Entities.Concrete.Base;
using System.ComponentModel.DataAnnotations;

namespace Entities.Concrete
{
    public class NewsPaper : BasePaper,IEntity
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public string NewsPaperName { get; set; }

        [Required]
        public int Number { get; set; }

        [Required]
        public DateTime Date { get; set; }

        public bool IsDestroyed { get; set; }
    }
}
