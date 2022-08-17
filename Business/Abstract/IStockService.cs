namespace Business.Abstract
{
    public interface IStockService : IBaseEntityService<Stock, Guid>
    {
        IDataResult<IList<Stock>> GetAllByLibrary(Guid libraryId);
        IDataResult<IList<Stock>> GetAllByStockCode(string stockCode);
        IDataResult<IList<Stock>> GetAllByQuanty(uint quantity);
    }
}
