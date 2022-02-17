using Core.Entities.Abstract;
using Entities.Concrete.Base;
using System.ComponentModel.DataAnnotations;

namespace Entities.Concrete
{
    public class GraphicalImage : MaterialBase, IEntity
    {
        [Required]
        public DateTime ImageCreatedDate { get; set; }
    }
}
