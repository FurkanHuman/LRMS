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
            if (technicalPlaceholder == null)
                return new ErrorResult(TechnicalNumberConstants.DataNoGet);

            _placeholderDal.Delete(technicalPlaceholder);
            return new SuccessResult(TechnicalPlaceholderConstants.DeleteSuccess);
        }

        public IResult ShadowDelete(Guid id)
        {
            TechnicalPlaceholder technicalPlaceholder = _placeholderDal.Get(tph => tph.Id == id);
            if (technicalPlaceholder == null)
                return new ErrorResult(TechnicalNumberConstants.DataNoGet);

            _placeholderDal.Update(technicalPlaceholder);
            return new SuccessResult(TechnicalPlaceholderConstants.DeleteSuccess);
        }

        [ValidationAspect(typeof(TechnicalPlaceholderValidator), Priority = 1)]
        public IResult Update(TechnicalPlaceholder technicalPlaceholder)
        {
            _placeholderDal.Update(technicalPlaceholder);
            return new SuccessResult(TechnicalPlaceholderConstants.UpdateSuccess);
        }

        public IDataResult<TechnicalPlaceholder> GetById(Guid id)
        {
            TechnicalPlaceholder technicalPlaceholder = _placeholderDal.Get(T => T.Id == id);
            return technicalPlaceholder == null
                ? new ErrorDataResult<TechnicalPlaceholder>(TechnicalPlaceholderConstants.DataNotGet)
                : new SuccessDataResult<TechnicalPlaceholder>(technicalPlaceholder, TechnicalPlaceholderConstants.DataGet);
        }

        public IDataResult<List<TechnicalPlaceholder>> GetAllByIds(Guid[] ids)
        {
            List<TechnicalPlaceholder> technicalPlaceholder = _placeholderDal.GetAll(t => ids.Contains(t.Id) && !t.IsDeleted).ToList();
            return technicalPlaceholder == null
                ? new ErrorDataResult<List<TechnicalPlaceholder>>(TechnicalPlaceholderConstants.DataNotGet)
                : new SuccessDataResult<List<TechnicalPlaceholder>>(technicalPlaceholder, TechnicalPlaceholderConstants.DataGet);
        }

        public IDataResult<List<TechnicalPlaceholder>> GetAllByColumnCode(string columnCode)
        {
            List<TechnicalPlaceholder> technicalPlaceholder = _placeholderDal.GetAll(t => t.ColumnCode.Contains(columnCode) && !t.IsDeleted).ToList();
            return technicalPlaceholder == null
                ? new ErrorDataResult<List<TechnicalPlaceholder>>(TechnicalPlaceholderConstants.DataNotGet)
                : new SuccessDataResult<List<TechnicalPlaceholder>>(technicalPlaceholder, TechnicalPlaceholderConstants.DataGet);
        }

        public IDataResult<List<TechnicalPlaceholder>> GetAllByRowCode(string rowCode)
        {
            List<TechnicalPlaceholder> technicalPlaceholder = _placeholderDal.GetAll(t => t.RowCode.Contains(rowCode) && !t.IsDeleted).ToList();
            return technicalPlaceholder == null
                ? new ErrorDataResult<List<TechnicalPlaceholder>>(TechnicalPlaceholderConstants.DataNotGet)
                : new SuccessDataResult<List<TechnicalPlaceholder>>(technicalPlaceholder, TechnicalPlaceholderConstants.DataGet);
        }

        public IDataResult<List<TechnicalPlaceholder>> GetAllBySpecialLocation(string specialLocation)
        {
            List<TechnicalPlaceholder> technicalPlaceholder = _placeholderDal.GetAll(t => t.SpecialLocation.Contains(specialLocation) && !t.IsDeleted).ToList();
            return technicalPlaceholder == null
                ? new ErrorDataResult<List<TechnicalPlaceholder>>(TechnicalPlaceholderConstants.DataNotGet)
                : new SuccessDataResult<List<TechnicalPlaceholder>>(technicalPlaceholder, TechnicalPlaceholderConstants.DataGet);
        }

        public IDataResult<List<TechnicalPlaceholder>> GetAllByName(string name)
        {
            return new ErrorDataResult<List<TechnicalPlaceholder>>(TechnicalPlaceholderConstants.Disabled);
        }

        public IDataResult<List<TechnicalPlaceholder>> GetAllByFilter(Expression<Func<TechnicalPlaceholder, bool>>? filter = null)
        {
            return new SuccessDataResult<List<TechnicalPlaceholder>>(_placeholderDal.GetAll(filter).ToList());
        }

        public IDataResult<List<TechnicalPlaceholder>> GetAllBySecret()
        {
            return new SuccessDataResult<List<TechnicalPlaceholder>>(_placeholderDal.GetAll(ph => ph.IsDeleted).ToList());
        }

        public IDataResult<List<TechnicalPlaceholder>> GetAll()
        {
            return new SuccessDataResult<List<TechnicalPlaceholder>>(_placeholderDal.GetAll(ph => !ph.IsDeleted).ToList());
        }
    }
}
