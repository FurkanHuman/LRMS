using Business.Abstract.Base;
using Core.Utilities.Result.Abstract;
using Entities.Concrete;

namespace Business.Abstract
{
    public interface IBookService : IBasePaperService<Book>
    {
        IDataResult<List<Book>> GetByOriginalBookName(string originalBookName);
        IDataResult<List<Book>> GetByReferences(Guid referenceId);
    }
}
