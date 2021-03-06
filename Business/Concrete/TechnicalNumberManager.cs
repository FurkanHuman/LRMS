using Business.Abstract;
using Business.Constants;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Result.Abstract;
using Core.Utilities.Result.Concrete;
using DataAccess.Abstract;
using Entities.Concrete.Infos;
using System.Linq.Expressions;

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

        public IResult Delete(Guid id)
        {
            TechnicalNumber technicalNumber = _technicalNumberDal.Get(tn => tn.Id == id);
            if (technicalNumber == null)
                return new ErrorResult(TechnicalNumberConstants.DataNoGet);

            _technicalNumberDal.Delete(technicalNumber);
            return new SuccessResult();
        }

        public IResult ShadowDelete(Guid id)
        {
            TechnicalNumber technicalNumber = _technicalNumberDal.Get(tn => tn.Id == id);
            if (technicalNumber == null)
                return new ErrorResult(TechnicalNumberConstants.DataNoGet);

            technicalNumber.IsDeleted = true;
            _technicalNumberDal.Update(technicalNumber);
            return new SuccessResult();
        }

        [ValidationAspect(typeof(TechnicalNumberValidator), Priority = 1)]
        public IResult Update(TechnicalNumber technicalNumber)
        {
            _technicalNumberDal.Update(technicalNumber);
            return new SuccessResult(TechnicalNumberConstants.UpdateSuccess);
        }

        public IDataResult<List<TechnicalNumber>> GetAllByBarcode(long barcode)
        {
            List<TechnicalNumber> technicalNumbers = _technicalNumberDal.GetAll(u => u.Barcode == barcode && !u.IsDeleted).ToList();
            return technicalNumbers == null
                ? new ErrorDataResult<List<TechnicalNumber>>(TechnicalNumberConstants.DataNoGet)
                : new ErrorDataResult<List<TechnicalNumber>>(technicalNumbers, TechnicalNumberConstants.DataGet);
        }

        public IDataResult<TechnicalNumber> GetByCertificateNum(string certificateNum)
        {
            TechnicalNumber technicalNumber = _technicalNumberDal.Get(u => u.CertificateCode == certificateNum && !u.IsDeleted);
            return technicalNumber == null
                ? new ErrorDataResult<TechnicalNumber>(TechnicalNumberConstants.DataNoGet)
                : new ErrorDataResult<TechnicalNumber>(technicalNumber, TechnicalNumberConstants.DataGet);
        }

        public IDataResult<TechnicalNumber> GetById(Guid id)
        {
            TechnicalNumber technicalNumber = _technicalNumberDal.Get(u => u.Id == id);
            return technicalNumber == null
                ? new ErrorDataResult<TechnicalNumber>(TechnicalNumberConstants.DataNoGet)
                : new ErrorDataResult<TechnicalNumber>(technicalNumber, TechnicalNumberConstants.DataGet);
        }

        public IDataResult<List<TechnicalNumber>> GetAllByIds(Guid[] ids)
        {
            List<TechnicalNumber> technicalNumbers = _technicalNumberDal.GetAll(u => ids.Contains(u.Id) && !u.IsDeleted).ToList();
            return technicalNumbers == null
                ? new ErrorDataResult<List<TechnicalNumber>>(TechnicalNumberConstants.DataNoGet)
                : new ErrorDataResult<List<TechnicalNumber>>(technicalNumbers, TechnicalNumberConstants.DataGet);
        }

        public IDataResult<TechnicalNumber> GetByISBN(ulong ISBNNumber)
        {
            TechnicalNumber technicalNumber = _technicalNumberDal.Get(u => u.ISBN == ISBNNumber && !u.IsDeleted);
            return technicalNumber == null
                ? new ErrorDataResult<TechnicalNumber>(TechnicalNumberConstants.ISBNNumberEmpty)
                : new ErrorDataResult<TechnicalNumber>(technicalNumber, TechnicalNumberConstants.ISBNNumberFetched);
        }

        public IDataResult<List<TechnicalNumber>> GetAllByName(string name)
        {
            return new ErrorDataResult<List<TechnicalNumber>>(TechnicalNumberConstants.Disabled);
        }

        public IDataResult<List<TechnicalNumber>> GetAllByFilter(Expression<Func<TechnicalNumber, bool>>? filter = null)
        {
            return new SuccessDataResult<List<TechnicalNumber>>(_technicalNumberDal.GetAll(filter).ToList(), TechnicalNumberConstants.DataGet);
        }

        public IDataResult<List<TechnicalNumber>> GetAllBySecret()
        {
            return new SuccessDataResult<List<TechnicalNumber>>(_technicalNumberDal.GetAll(u => u.IsDeleted).ToList(), TechnicalNumberConstants.DataGet);
        }
        public IDataResult<List<TechnicalNumber>> GetAll()
        {
            return new SuccessDataResult<List<TechnicalNumber>>(_technicalNumberDal.GetAll(u => !u.IsDeleted).ToList(), TechnicalNumberConstants.DataGet);
        }
    }
}
