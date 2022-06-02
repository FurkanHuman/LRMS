using Core.Entities.Abstract;
using Entities.Concrete.Base;
using Entities.Concrete.Infos;
using System.ComponentModel.DataAnnotations;

namespace Entities.Concrete
{
    public class TradePublication : MaterialBase,IEntity
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public List<Writer> Writers { get; set; }

        [Required]
        public List<string> Audience { get; set; }

        [Required]
        public DateOnly ArticleDate { get; set; }

        public float Price { get; set; }
    }
}
