using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class BookSeries : Book, IEntity
    {
        public int BookNumber { get; set; }
        
        public List<Book> Books { get; set; }
    }
}
