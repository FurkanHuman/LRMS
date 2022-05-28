using Business.Abstract.Base;
using Core.Utilities.Result.Abstract;
using Entities.Concrete.Infos;

namespace Business.Abstract
{
    public interface ITechnicalPlaceholderService : IBaseEntityService<TechnicalPlaceholder>
    {
        IResult Delete(Guid id);
        IResult ShadowDelete(Guid id);
        IDataResult<TechnicalPlaceholder> GetById(Guid id);
        IDataResult<List<TechnicalPlaceholder>> StockCode(string stockCode);
        IDataResult<List<TechnicalPlaceholder>> StockNumber(ulong stockNumber);
        IDataResult<List<TechnicalPlaceholder>> WhereIsMaterial(string whereMaterial);
    }
}
