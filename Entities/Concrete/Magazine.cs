using Core.Entities.Abstract;
using Entities.Concrete.Cover;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Magazine:BasePaper,IEntity
    {

        [Required, MaxLength(512)]
        public string Title { get; set; }
    }
}
