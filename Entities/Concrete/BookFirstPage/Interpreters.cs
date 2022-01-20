using Core.Entities.Abstract;
using System.ComponentModel.DataAnnotations;

namespace Entities.Concrete.BookFirstPage
{
    public class Interpreters : BookFirstPagePersonBase, IEntity
    {
        [MaxLength(16)]
        public string? WhichToLanguage { get; set; }
    }
}