using Core.Entities.Abstract;
using Entities.Concrete.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class GraphicalImage:MaterialBase,IEntity
    {
        [Required]
        public DateTime ImageCreatedDate { get; set; }
    }
}
