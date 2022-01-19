using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete.BookFirstPage
{
    public class Interpreters: BookFirstPagePersonBase, IEntity
    {
        [MaxLength(16)]
        public string? WhichToLanguage { get; set; }
    }
}