using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Result.Abstract;
using Core.Utilities.Result.Concrete;
using DataAccess.Abstract;
using Entities.Concrete.Infos;

namespace Business.Concrete
{
    public class TechnicalPlaceholderManager : ITechnicalPlaceholder
    {
        private readonly ITechnicalPlaceholderDal _placeholderDal;

        public TechnicalPlaceholderManager(ITechnicalPlaceholderDal placeholderDal)
        {
            _placeholderDal = placeholderDal;
        }


        [ValidationAspect(typeof(TechnicalPlaceholderValidator), Priority = 1)]
        public IResult Add(TechnicalPlaceholder technicalPlaceholder)
        {
            technicalPlaceholder.IsDeleted = false;
            _placeholderDal.Add(technicalPlaceholder);
            return new SuccessResult(TechnicalPlaceholderConstants.AddSuccess);
        }

        public IResult Delete(TechnicalPlaceholder technicalPlaceholder)
        {
            _placeholderDal.Delete(technicalPlaceholder);
            return new SuccessResult(TechnicalPlaceholderConstants.DeleteSuccess);
        }

        public IResult Update(TechnicalPlaceholder technicalPlaceholder)
        {
            _placeholderDal.Update(technicalPlaceholder);
            return new SuccessResult(TechnicalPlaceholderConstants.UpdateSuccess);
        }

        public IDataResult<TechnicalPlaceholder> GetById(int id)
        {
            TechnicalPlaceholder technicalPlaceholder = _placeholderDal.Get(T => T.Id == id && !T.IsDeleted);
            return technicalPlaceholder == null
                ? new ErrorDataResult<TechnicalPlaceholder>(TechnicalPlaceholderConstants.DataNotGet)
                : new SuccessDataResult<TechnicalPlaceholder>(technicalPlaceholder, TechnicalPlaceholderConstants.DataGet);
        }

        public IDataResult<List<TechnicalPlaceholder>> Getlist()
        {
            return new SuccessDataResult<List<TechnicalPlaceholder>>(_placeholderDal.GetAll().ToList());
        }

        public IDataResult<List<TechnicalPlaceholder>> StockCode(string stockCode)
        {
            List<TechnicalPlaceholder> technicalPlaceholder = _placeholderDal.GetAll(T => T.StockCode.ToLowerInvariant().Equals(stockCode.ToLowerInvariant()) && !T.IsDeleted).ToList();
            return technicalPlaceholder == null
                ? new ErrorDataResult<List<TechnicalPlaceholder>>(TechnicalPlaceholderConstants.DataNotGet)
                : new SuccessDataResult<List<TechnicalPlaceholder>>(technicalPlaceholder, TechnicalPlaceholderConstants.DataGet);
        }

        public IDataResult<List<TechnicalPlaceholder>> StockNumber(ulong stockNumber)
        {
            List<TechnicalPlaceholder> technicalPlaceholder = _placeholderDal.GetAll(T => T.StockNumber == stockNumber && !T.IsDeleted).ToList();
            return technicalPlaceholder == null
                ? new ErrorDataResult<List<TechnicalPlaceholder>>(TechnicalPlaceholderConstants.DataNotGet)
                : new SuccessDataResult<List<TechnicalPlaceholder>>(technicalPlaceholder, TechnicalPlaceholderConstants.DataGet);
        }

        public IDataResult<List<TechnicalPlaceholder>> WhereIsMaterial(string whereMaterial)
        {
            List<TechnicalPlaceholder> technicalPlaceholder = _placeholderDal.GetAll(T => T.WhereIsMaterial.ToLowerInvariant().Contains(whereMaterial.ToLowerInvariant()) && !T.IsDeleted).ToList();
            return technicalPlaceholder == null
                ? new ErrorDataResult<List<TechnicalPlaceholder>>(TechnicalPlaceholderConstants.DataNotGet)
                : new SuccessDataResult<List<TechnicalPlaceholder>>(technicalPlaceholder, TechnicalPlaceholderConstants.DataGet);
        }
    }
}
