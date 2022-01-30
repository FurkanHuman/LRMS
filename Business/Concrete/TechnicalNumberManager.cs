using Business.Abstract;
using Business.Constants;
using Core.Utilities.Business;
using Core.Utilities.Result.Abstract;
using Core.Utilities.Result.Concrete;
using DataAccess.Abstract;
using Entities.Concrete.Infos;

namespace Business.Concrete
{
    public class TechnicalNumberManager : ITechnicalNumberService
    {
        private readonly ITechnicalNumberDal _technicalNumberDal;

        public TechnicalNumberManager(ITechnicalNumberDal technicalNumberDal)
        {
            _technicalNumberDal = technicalNumberDal;
        }

        public IResult Add(TechnicalNumber technicalNumber)
        {
            IResult result = BusinessRules.Run(TechnicalNumberControl(technicalNumber));
            if (result != null)
                return result;
            technicalNumber.IsDeleted = false;
            _technicalNumberDal.Add(technicalNumber);
            return new SuccessResult(TechnicalNumberConstants.AddedSuccess);
        }

        public IResult Delete(TechnicalNumber technicalNumber)
        {
            IResult result = BusinessRules.Run(DeleteControl(technicalNumber));
            if (result != null)
                return result;
            _technicalNumberDal.Delete(technicalNumber);
            return new SuccessResult();
        }

        public IResult Update(TechnicalNumber technicalNumber)
        {
            IResult result = BusinessRules.Run(TechnicalNumberControl(technicalNumber));
            if (result != null)
                return result;
            _technicalNumberDal.Update(technicalNumber);
            return new SuccessResult(TechnicalNumberConstants.AddedSuccess);
        }

        public IDataResult<List<TechnicalNumber>> GetByBarcode(long barcode)
        {
            List<TechnicalNumber> technicalNumbers = _technicalNumberDal.GetAll(u => u.Barcode.Equals(barcode) && !u.IsDeleted).ToList();
            return technicalNumbers == null
                ? new ErrorDataResult<List<TechnicalNumber>>(TechnicalNumberConstants.DataNoGet)
                : new ErrorDataResult<List<TechnicalNumber>>(technicalNumbers, TechnicalNumberConstants.DataGet);
        }

        public IDataResult<TechnicalNumber> GetByCertificateNum(string certificateNum)
        {
            TechnicalNumber technicalNumber = _technicalNumberDal.Get(u => u.CertificateCode.Equals(certificateNum) && !u.IsDeleted);
            return technicalNumber == null
                ? new ErrorDataResult<TechnicalNumber>(TechnicalNumberConstants.DataNoGet)
                : new ErrorDataResult<TechnicalNumber>(technicalNumber, TechnicalNumberConstants.DataGet);
        }

        public IDataResult<TechnicalNumber> GetById(int id)
        {
            TechnicalNumber technicalNumber = _technicalNumberDal.Get(u => u.Id.Equals(id) && !u.IsDeleted);
            return technicalNumber == null
                ? new ErrorDataResult<TechnicalNumber>(TechnicalNumberConstants.DataNoGet)
                : new ErrorDataResult<TechnicalNumber>(technicalNumber, TechnicalNumberConstants.DataGet);
        }

        public IDataResult<TechnicalNumber> GetByISBN(ulong ISBNNumber)
        {
            TechnicalNumber technicalNumber = _technicalNumberDal.Get(u => u.ISBN.Equals(ISBNNumber) && !u.IsDeleted);
            return technicalNumber == null
                ? new ErrorDataResult<TechnicalNumber>(TechnicalNumberConstants.ISBNNumberEmpty)
                : new ErrorDataResult<TechnicalNumber>(technicalNumber, TechnicalNumberConstants.ISBNNumberFetched);
        }

        public IDataResult<List<TechnicalNumber>> Getlist()
        {
            return new SuccessDataResult<List<TechnicalNumber>>(_technicalNumberDal.GetAll(u => !u.IsDeleted).ToList(), TechnicalNumberConstants.DataGet);
        }

        public IDataResult<List<TechnicalNumber>> StockCode(string stockCode)
        {
            List<TechnicalNumber> technicalNumbers = _technicalNumberDal.GetAll(u => u.StockCode.Equals(stockCode) && !u.IsDeleted).ToList();
            return technicalNumbers == null
                ? new ErrorDataResult<List<TechnicalNumber>>(TechnicalNumberConstants.StockNumberEmpty)
                : new ErrorDataResult<List<TechnicalNumber>>(technicalNumbers, TechnicalNumberConstants.StockCodeFetched);
        }

        public IDataResult<List<TechnicalNumber>> StockNumber(ulong stockNumber)
        {
            List<TechnicalNumber> technicalNumbers = _technicalNumberDal.GetAll(u => u.StockNumber.Equals(stockNumber) && !u.IsDeleted).ToList();
            return technicalNumbers == null
                ? new ErrorDataResult<List<TechnicalNumber>>(TechnicalNumberConstants.StockNumberEmpty)
                : new ErrorDataResult<List<TechnicalNumber>>(technicalNumbers, TechnicalNumberConstants.StockCodeFetched);
        }

        private static IResult TechnicalNumberControl(TechnicalNumber technicalNumber)
        {
            if (technicalNumber.Barcode.Equals(null))
                return new ErrorResult(TechnicalNumberConstants.BarcodeNull);
            if (technicalNumber.ISBN.Equals(null))
                return new ErrorResult(TechnicalNumberConstants.ISBNNumberEmpty);
            if (technicalNumber.StockCode.Equals(null) || technicalNumber.StockCode.Equals(string.Empty))
                return new ErrorResult(TechnicalNumberConstants.StockCodeEmpty);
            if (technicalNumber.StockNumber.Equals(null))
                return new ErrorResult(TechnicalNumberConstants.StockNumberEmpty);
            if (technicalNumber.CertificateCode.Equals(null) || technicalNumber.CertificateCode.Equals(string.Empty))
                return new ErrorResult(TechnicalNumberConstants.CertificateCodeNull);

            return new SuccessResult();
        }

        private static IResult DeleteControl(TechnicalNumber technicalNumber)
        {
            if (technicalNumber.Id.Equals(null))
                return new ErrorResult(TechnicalNumberConstants.IdNull);
            if (technicalNumber.IsDeleted)
                return new ErrorResult(TechnicalNumberConstants.NotDeleted);

            return new SuccessResult();
        }
    }
}
