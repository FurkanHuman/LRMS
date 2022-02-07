using Core.Entities.Abstract;
using Entities.Concrete.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete.Infos
{
    public class Researcher : FirstPagePersonBase, IEntity
    {
        public string? NamePreAttachment { get; set; }

        [Required]
        public string Specialty { get; set; }
    }
}
