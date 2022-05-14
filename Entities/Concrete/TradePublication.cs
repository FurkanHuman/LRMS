using Core.Entities.Abstract;
using Entities.Concrete.Base;
using Entities.Concrete.Infos;
using System.ComponentModel.DataAnnotations;

namespace Entities.Concrete
{
    public class TradePublication : MaterialBase, IEntity
    {
        [Required]
        public List<Writer> Writers { get; set; }

        [Required]
        public List<string> Audience { get; set; }

        [Required]
        public DateOnly ArticleDate  { get; set; }

        public byte SecretLevel { get; set; }
    }
}
