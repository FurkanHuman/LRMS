using Core.Entities.Abstract;
using Entities.Concrete.Entities.Bases;
using System.ComponentModel.DataAnnotations;

namespace Entities.Concrete.Entities.Mains
{
    public class NewsPaper : BasePaper, IEntity
    {
        [Required]
        public string NewsPaperName { get; set; }

        [Required]
        public uint Number { get; set; }

        [Required]
        public DateTime Date { get; set; }

        public bool IsDestroyed { get; set; }

        public IList<Kit> Kits { get; set; }
    }
}
