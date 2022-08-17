namespace Business.Abstract
{
    public interface IBookService : IBasePaperService<Book>
    {
        IDataResult<IList<Book>> GetAllByOriginalBookName(string originalBookName);
        IDataResult<IList<Book>> GetAllByReference(Guid referenceId);
    }
}
