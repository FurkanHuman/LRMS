namespace Business.Abstract
{
    public interface ITechnicalNumberService : IBaseEntityService<TechnicalNumber, Guid>
    {
        IDataResult<IList<TechnicalNumber>> GetAllByBarcode(long barcode);
        IDataResult<TechnicalNumber> GetByISBN(ulong ISBNNumber);
        IDataResult<TechnicalNumber> GetByCertificateNum(string certificateNum);
    }
}
