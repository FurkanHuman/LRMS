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

        public IDataResult<List<CoverCap>> GetByIds(byte[] ids)
        {
            List<CoverCap> coverCaps = _coverCapDal.GetAll(c => ids.Contains(c.Id)).ToList();
            return coverCaps == null
                ? new ErrorDataResult<List<CoverCap>>(CoverCapConstants.DataNotGet)
                : new SuccessDataResult<List<CoverCap>>(coverCaps, CategoryConstants.DataGet);
        }

        public IDataResult<List<CoverCap>> GetByNames(string name)
        {
            List<CoverCap> coverCaps = _coverCapDal.GetAll(u => u.BookSkinType.Contains(name)).ToList();
            return coverCaps == null
                ? new ErrorDataResult<List<CoverCap>>(CoverCapConstants.DataNotGet)
                : new SuccessDataResult<List<CoverCap>>(coverCaps, CategoryConstants.DataGet);
        }

        public IDataResult<List<CoverCap>> GetAllByFilter(Expression<Func<CoverCap, bool>>? filter = null)
        {
            return new SuccessDataResult<List<CoverCap>>(_coverCapDal.GetAll(filter).ToList());
        }

        public IDataResult<List<CoverCap>> GetAllBySecrets()
        {
            return new SuccessDataResult<List<CoverCap>>(_coverCapDal.GetAll(c => c.IsDeleted).ToList());
        }

        public IDataResult<List<CoverCap>> GetAll()
        {
            return new SuccessDataResult<List<CoverCap>>(_coverCapDal.GetAll(c => !c.IsDeleted).ToList());
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
