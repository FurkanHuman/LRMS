using Core.Entities.Abstract;
using System.ComponentModel.DataAnnotations;

namespace Entities.Concrete.FirstPage
{
    public class Interpreters : FirstPagePersonBase, IEntity
    {// çevirenler hangi dilden cevirdi
        [MaxLength(16)]
        public string WhichToLanguage { get; set; }
    }
}