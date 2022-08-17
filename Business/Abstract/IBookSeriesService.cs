namespace Business.Abstract
{
    public interface IBookSeriesService : IBasePaperService<BookSeries>
    {
        IDataResult<BookSeries> GetByBookId(Guid bookId);
    }
}
