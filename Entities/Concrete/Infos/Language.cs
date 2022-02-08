using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Entities.Concrete.Infos
{
    public class Language : IEntity
    {
        [Key, JsonIgnore]
        public int Id { get; set; }

        [Required, MaxLength()]
        public string LanguageName { get; set; }

        public bool IsDeleted { get; set; }
    }
}
