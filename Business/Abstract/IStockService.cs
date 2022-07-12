using Business.Abstract.Base;
using Core.Utilities.Result.Abstract;
using Entities.Concrete.Infos;

namespace Business.Abstract
{
    public interface IStockService : IBaseEntityService<Stock, Guid>
    {
        IDataResult<List<Stock>> GetByLibraries(Guid libraryId);
        IDataResult<List<Stock>> GetByStockCodes(string stockCode);
        IDataResult<List<Stock>> GetByQuantites(uint quantity);
    }
}
