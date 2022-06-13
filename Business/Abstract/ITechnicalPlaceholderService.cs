using Business.Abstract.Base;
using Core.Utilities.Result.Abstract;
using Entities.Concrete.Infos;

namespace Business.Abstract
{
    public interface ITechnicalPlaceholderService : IBaseEntityService<TechnicalPlaceholder, Guid>
    {
        IDataResult<List<TechnicalPlaceholder>> GetByStockCode(string stockCode);
        IDataResult<List<TechnicalPlaceholder>> GetByStockNumber(ulong stockNumber);
        IDataResult<List<TechnicalPlaceholder>> GetByWhereIsMaterial(string whereMaterial);
    }
}
