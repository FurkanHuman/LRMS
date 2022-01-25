using Core.Entities.Abstract;
using Entities.Concrete.Base;
using System.ComponentModel.DataAnnotations;

namespace Entities.Concrete.Infos
{
    public class Interpreters : FirstPagePersonBase, IEntity
    {// çevirenler hangi dilden cevirdi
        [MaxLength(16)]
        public string WhichToLanguage { get; set; }
    }
}