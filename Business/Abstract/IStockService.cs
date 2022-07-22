using Business.Abstract.Base;
using Core.Utilities.Result.Abstract;
using Entities.Concrete.Infos;

namespace Business.Abstract
{
    public interface IStockService : IBaseEntityService<Stock, Guid>
    {
        IDataResult<List<Stock>> GetAllByLibrary(Guid libraryId);
        IDataResult<List<Stock>> GetAllByStockCode(string stockCode);
        IDataResult<List<Stock>> GetAllByQuanty(uint quantity);
    }
}
