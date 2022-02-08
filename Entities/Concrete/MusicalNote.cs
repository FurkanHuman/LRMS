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
    public class MusicalNote:MaterialBase,IEntity
    {
        [Required]
        public Composer Composer { get; set; }

        [Required]
        public DateTime DateOfWriting { get; set; }
    }
}