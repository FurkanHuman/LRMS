using Core.Entities.Abstract;
using Entities.Concrete.Infos;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Entities.Concrete.Base
{
    public class MaterialBase
    {
        [Key, JsonIgnore]
        public ulong Id { get; set; }

        [Required, MaxLength(512)]
        public string Name { get; set; }

        [Required, MaxLength(512)]
        public string Title { get; set; }

        [Required, MaxLength(512)]
        public string Description { get; set; }

        [Required, MaxLength(512)]
        public string State { get; set; }

        [Required]
        public List<Category> Categories { get; set; }

        [Required]
        public List<TechnicalPlaceholder> TechnicalPlaceholders { get; set; }
    }
}
