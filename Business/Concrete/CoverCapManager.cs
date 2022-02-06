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
    public class CoverCapManager : ICoverCapService
    {
        private readonly ICoverCapDal _coverCapDal;

        public CoverCapManager(ICoverCapDal coverCapDal)
        {
            _coverCapDal = coverCapDal;
        }

        [ValidationAspect(typeof(CoverCapValidator), Priority = 1)]
        public IResult Add(CoverCap coverCap)
        {
            IResult result = BusinessRules.Run(CoverCapChecker(coverCap));
            if (result != null)
                return result;

            _coverCapDal.Add(coverCap);
            return new SuccessResult(CoverCapConstants.AddSuccess);
        }

        public IResult Delete(CoverCap coverCap)
        {
            _coverCapDal.Delete(coverCap);
            return new SuccessResult(CoverCapConstants.DeleteSuccess);
        }

        public IResult Update(CoverCap coverCap)
        {
            _coverCapDal.Update(coverCap);
            return new SuccessResult(CoverCapConstants.UpdateSuccess);
        }

        public IDataResult<CoverCap> GetById(int id)
        {
            CoverCap? coverCap = _coverCapDal.Get(u => u.Id == id);
            return coverCap == null
                ? new ErrorDataResult<CoverCap>(CoverCapConstants.DataNotGet)
                : new SuccessDataResult<CoverCap>(coverCap, CategoryConstants.DataGet);
        }

        public IDataResult<CoverCap> GetByName(string name)
        {
            CoverCap? coverCap = _coverCapDal.Get(u => u.BookSkinType.ToUpperInvariant().Contains(name.ToUpperInvariant()));
            return coverCap == null
                ? new ErrorDataResult<CoverCap>(CoverCapConstants.DataNotGet)
                : new SuccessDataResult<CoverCap>(coverCap, CategoryConstants.DataGet);
        }

        public IDataResult<List<CoverCap>> GetList()
        {
            return new SuccessDataResult<List<CoverCap>>((List<CoverCap>)_coverCapDal.GetAll());
        }

        private IResult CoverCapChecker(CoverCap coverCap)
        {
            bool r = _coverCapDal.GetAll(cc => cc.BookSkinType.ToLowerInvariant().Contains(coverCap.BookSkinType.ToLowerInvariant())).Any();
            return r
                ? new ErrorResult(CoverCapConstants.CoverCapNameExist)
                : new SuccessResult();
        }
    }
}
