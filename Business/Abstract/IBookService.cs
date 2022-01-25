using Business.Abstract.Base;
using Entities.Concrete;

namespace Business.Abstract
{
    public interface IBookService : IBasePaperService<Book>
    {
    }
}
