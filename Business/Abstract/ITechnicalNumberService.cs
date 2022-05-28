using Business.Abstract.Base;
using Core.Utilities.Result.Abstract;
using Entities.Concrete.Infos;

namespace Business.Abstract
{
    public interface ITechnicalNumberService : IBaseEntityService<TechnicalNumber>
    {
        IResult Delete(Guid id);
        IResult ShadowDelete(Guid id);
        IDataResult<TechnicalNumber> GetById(Guid id);
        IDataResult<List<TechnicalNumber>> GetByBarcode(long barcode);
        IDataResult<TechnicalNumber> GetByISBN(ulong ISBNNumber);
        IDataResult<TechnicalNumber> GetByCertificateNum(string certificateNum);
    }
}
