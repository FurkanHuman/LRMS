using Business.Abstract.Base;
using Core.Utilities.Result.Abstract;
using Entities.Concrete.Infos;

namespace Business.Abstract
{
    public interface ITechnicalPlaceholderService : IBaseEntityService<TechnicalPlaceholder, Guid>
    {
        IDataResult<List<TechnicalPlaceholder>> StockCode(string stockCode);
        IDataResult<List<TechnicalPlaceholder>> StockNumber(ulong stockNumber);
        IDataResult<List<TechnicalPlaceholder>> WhereIsMaterial(string whereMaterial);
    }
}
