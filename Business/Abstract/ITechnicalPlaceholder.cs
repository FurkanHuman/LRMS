using Core.Utilities.Result.Abstract;
using Entities.Concrete.Infos;

namespace Business.Abstract
{
    public interface ITechnicalPlaceholder
    {
        IDataResult<TechnicalPlaceholder> GetById(int id);
        IDataResult<List<TechnicalPlaceholder>> StockCode(string stockCode);
        IDataResult<List<TechnicalPlaceholder>> StockNumber(ulong stockNumber);
        IDataResult<List<TechnicalPlaceholder>> WhereIsMaterial(string whereMaterial);
        IDataResult<List<TechnicalPlaceholder>> Getlist();
        IResult Add(TechnicalPlaceholder technicalPlaceholder);
        IResult Delete(TechnicalPlaceholder technicalPlaceholder);
        IResult Update(TechnicalPlaceholder technicalPlaceholder);
    }
}
