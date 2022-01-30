using Core.Utilities.Result.Abstract;
using Entities.Concrete.Infos;

namespace Business.Abstract
{
    public interface ITechnicalNumberService
    {
        IDataResult<TechnicalNumber> GetById(int id);
        IDataResult<List<TechnicalNumber>> GetByBarcode(long barcode);
        IDataResult<TechnicalNumber> GetByISBN(ulong ISBNNumber);
        IDataResult<TechnicalNumber> GetByCertificateNum(string certificateNum);
        IDataResult<List<TechnicalNumber>> StockCode(string stockCode);
        IDataResult<List<TechnicalNumber>> StockNumber(ulong stockNumber);
        IDataResult<List<TechnicalNumber>> Getlist();
        IResult Add(TechnicalNumber technicalNumber);
        IResult Delete(TechnicalNumber technicalNumber);
        IResult Update(TechnicalNumber technicalNumber);
    }
}
