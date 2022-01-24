using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Encyclopedia:BasePaper,IEntity
    {
        [Required]
        public int SequenceNumber { get; set; }
    }
}
