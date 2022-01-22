using Core.DataAccess;
using Entities.Concrete.BookCover;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface IBookCoverDal: IEntityRepository<BookCoverCap>
    {
    }
}
