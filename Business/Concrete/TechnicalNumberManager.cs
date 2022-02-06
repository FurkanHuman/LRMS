using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
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


        [ValidationAspect(typeof(TechnicalNumberValidator), Priority = 1)]
        public IResult Add(TechnicalNumber technicalNumber)
        {
            technicalNumber.IsDeleted = false;
            _technicalNumberDal.Add(technicalNumber);
            return new SuccessResult(TechnicalNumberConstants.AddedSuccess);
        }

        public IResult Delete(TechnicalNumber technicalNumber)
        {
            _technicalNumberDal.Delete(technicalNumber);
            return new SuccessResult();
        }

        public IResult Update(TechnicalNumber technicalNumber)
        {
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
    }
}
