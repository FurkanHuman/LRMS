using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Result.Abstract;
using Core.Utilities.Result.Concrete;
using DataAccess.Abstract;
using Entities.Concrete.Infos;
using System.Linq.Expressions;

namespace Business.Concrete
{
    public class TechnicalPlaceholderManager : ITechnicalPlaceholderService
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

        public IResult Delete(Guid id)
        {
            TechnicalPlaceholder technicalPlaceholder = _placeholderDal.Get(tph => tph.Id == id);
            if (technicalPlaceholder != null)
                return new ErrorResult(TechnicalNumberConstants.DataNoGet);

            _placeholderDal.Delete(technicalPlaceholder);
            return new SuccessResult(TechnicalPlaceholderConstants.DeleteSuccess);
        }

        public IResult ShadowDelete(Guid id)
        {
            TechnicalPlaceholder technicalPlaceholder = _placeholderDal.Get(tph => tph.Id == id);
            if (technicalPlaceholder != null)
                return new ErrorResult(TechnicalNumberConstants.DataNoGet);

            _placeholderDal.Update(technicalPlaceholder);
            return new SuccessResult(TechnicalPlaceholderConstants.DeleteSuccess);
        }

        public IResult Update(TechnicalPlaceholder technicalPlaceholder)
        {
            _placeholderDal.Update(technicalPlaceholder);
            return new SuccessResult(TechnicalPlaceholderConstants.UpdateSuccess);
        }

        public IDataResult<TechnicalPlaceholder> GetById(Guid id)
        {
            TechnicalPlaceholder technicalPlaceholder = _placeholderDal.Get(T => T.Id == id && !T.IsDeleted);
            return technicalPlaceholder == null
                ? new ErrorDataResult<TechnicalPlaceholder>(TechnicalPlaceholderConstants.DataNotGet)
                : new SuccessDataResult<TechnicalPlaceholder>(technicalPlaceholder, TechnicalPlaceholderConstants.DataGet);
        }

        public IDataResult<List<TechnicalPlaceholder>> StockCode(string stockCode)
        {
            List<TechnicalPlaceholder> technicalPlaceholder = _placeholderDal.GetAll(T => T.StockCode.Contains(stockCode ) && !T.IsDeleted).ToList();
            return technicalPlaceholder == null
                ? new ErrorDataResult<List<TechnicalPlaceholder>>(TechnicalPlaceholderConstants.DataNotGet)
                : new SuccessDataResult<List<TechnicalPlaceholder>>(technicalPlaceholder, TechnicalPlaceholderConstants.DataGet);
        }

        public IDataResult<List<TechnicalPlaceholder>> GetByNames(string name)
        {
            return new ErrorDataResult<List<TechnicalPlaceholder>>(TechnicalPlaceholderConstants.Disabled);
        }

        public IDataResult<List<TechnicalPlaceholder>> GetByFilterLists(Expression<Func<TechnicalPlaceholder, bool>>? filter = null)
        {
            return new SuccessDataResult<List<TechnicalPlaceholder>>(_placeholderDal.GetAll(filter).ToList());
        }

        public IDataResult<List<TechnicalPlaceholder>> GetAllBySecrets()
        {
            return new SuccessDataResult<List<TechnicalPlaceholder>>(_placeholderDal.GetAll(ph => ph.IsDeleted).ToList());
        }

        public IDataResult<List<TechnicalPlaceholder>> GetAll()
        {
            return new SuccessDataResult<List<TechnicalPlaceholder>>(_placeholderDal.GetAll(ph => !ph.IsDeleted).ToList());
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
            List<TechnicalPlaceholder> technicalPlaceholder = _placeholderDal.GetAll(T => T.WhereIsMaterial.Contains(whereMaterial) && !T.IsDeleted).ToList();
            return technicalPlaceholder == null
                ? new ErrorDataResult<List<TechnicalPlaceholder>>(TechnicalPlaceholderConstants.DataNotGet)
                : new SuccessDataResult<List<TechnicalPlaceholder>>(technicalPlaceholder, TechnicalPlaceholderConstants.DataGet);
        }
    }
}
