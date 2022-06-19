using Business.Abstract.Base;
using Core.Utilities.Result.Abstract;
using Entities.Concrete;

namespace Business.Abstract
{
    public interface IBookSeriesService : IBasePaperService<BookSeries>
    {
        IDataResult<BookSeries> GetByBookId(Guid bookId);
    }
}
