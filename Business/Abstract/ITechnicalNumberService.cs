using Business.Abstract.Base;
using Core.Utilities.Result.Abstract;
using Entities.Concrete.Infos;

namespace Business.Abstract
{
    public interface ITechnicalNumberService : IBaseEntityService<TechnicalNumber, Guid>
    {
        IDataResult<List<TechnicalNumber>> GetByBarcode(long barcode);
        IDataResult<TechnicalNumber> GetByISBN(ulong ISBNNumber);
        IDataResult<TechnicalNumber> GetByCertificateNum(string certificateNum);
    }
}
