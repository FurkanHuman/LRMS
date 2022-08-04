using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Business;
using Core.Utilities.Result.Abstract;
using Core.Utilities.Result.Concrete;
using DataAccess.Abstract;
using Entities.Concrete.Infos;
using System.Linq.Expressions;

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

            coverCap.IsDeleted = false;
            _coverCapDal.Add(coverCap);
            return new SuccessResult(CoverCapConstants.AddSuccess);
        }

        public IResult Delete(byte id)
        {
            CoverCap coverCap = _coverCapDal.Get(ccp => ccp.Id == id);
            if (coverCap == null)
                return new ErrorResult(CoverCapConstants.NotMatch);

            _coverCapDal.Delete(coverCap);
            return new SuccessResult(CoverCapConstants.DeleteSuccess);
        }

        public IResult ShadowDelete(byte id)
        {
            CoverCap coverCap = _coverCapDal.Get(ccp => ccp.Id == id && !ccp.IsDeleted);
            if (coverCap == null)
                return new ErrorResult(CoverCapConstants.NotMatch);
            coverCap.IsDeleted = true;

            _coverCapDal.Update(coverCap);
            return new SuccessResult(CoverCapConstants.DeleteSuccess);
        }

        [ValidationAspect(typeof(CoverCapValidator), Priority = 1)]
        public IResult Update(CoverCap coverCap)
        {
            _coverCapDal.Update(coverCap);
            return new SuccessResult(CoverCapConstants.UpdateSuccess);
        }

        public IDataResult<CoverCap> GetById(byte id)
        {
            CoverCap coverCap = _coverCapDal.Get(u => u.Id == id);
            return coverCap == null
                ? new ErrorDataResult<CoverCap>(CoverCapConstants.DataNotGet)
                : new SuccessDataResult<CoverCap>(coverCap, CategoryConstants.DataGet);
        }

        public IDataResult<IList<CoverCap>> GetAllByIds(byte[] ids)
        {
            IList<CoverCap> coverCaps = _coverCapDal.GetAll(c => ids.Contains(c.Id));
            return coverCaps == null
                ? new ErrorDataResult<IList<CoverCap>>(CoverCapConstants.DataNotGet)
                : new SuccessDataResult<IList<CoverCap>>(coverCaps, CategoryConstants.DataGet);
        }

        public IDataResult<IList<CoverCap>> GetAllByName(string name)
        {
            IList<CoverCap> coverCaps = _coverCapDal.GetAll(u => u.BookSkinType.Contains(name));
            return coverCaps == null
                ? new ErrorDataResult<IList<CoverCap>>(CoverCapConstants.DataNotGet)
                : new SuccessDataResult<IList<CoverCap>>(coverCaps, CategoryConstants.DataGet);
        }

        public IDataResult<IList<CoverCap>> GetAllByFilter(Expression<Func<CoverCap, bool>>? filter = null)
        {
            return new SuccessDataResult<IList<CoverCap>>(_coverCapDal.GetAll(filter));
        }

        public IDataResult<IList<CoverCap>> GetAllByIsDeleted()
        {
            return new SuccessDataResult<IList<CoverCap>>(_coverCapDal.GetAll(c => c.IsDeleted));
        }

        public IDataResult<IList<CoverCap>> GetAll()
        {
            return new SuccessDataResult<IList<CoverCap>>(_coverCapDal.GetAll(c => !c.IsDeleted));
        }

        private IResult CoverCapChecker(CoverCap coverCap)
        {
            bool r = _coverCapDal.GetAll(cc => cc.BookSkinType.Contains(coverCap.BookSkinType)).Any();
            return r
                ? new ErrorResult(CoverCapConstants.CoverCapNameExist)
                : new SuccessResult();
        }
    }
}
