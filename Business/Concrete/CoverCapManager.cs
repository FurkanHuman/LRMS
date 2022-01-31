using Business.Abstract;
using Business.Constants;
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

        public IResult Add(CoverCap coverCap)
        {
            IResult result = BusinessRules.Run(CoverCapChecker(coverCap));
            if (result != null)
                return result;

            _coverCapDal.Add(coverCap);
            return new SuccessResult(CoverCapConstants.AddSucces);
        }

        public IResult Update(CoverCap coverCap, string changedName)
        {
            IResult result = BusinessRules.Run(CoverCapChecker(coverCap), ChangedNameChecker(changedName));
            if (result != null)
                return result;

            coverCap.BookSkinType = changedName;
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
            CoverCap? coverCap = _coverCapDal.Get(u => u.BookSkinType == name);
            return coverCap == null
                ? new ErrorDataResult<CoverCap>(CoverCapConstants.DataNotGet)
                : new SuccessDataResult<CoverCap>(coverCap, CategoryConstants.DataGet);
        }

        public IDataResult<List<CoverCap>> GetList()
        {
            return new SuccessDataResult<List<CoverCap>>((List<CoverCap>)_coverCapDal.GetAll());
        }

        private static IResult ChangedNameChecker(string changedName)
        {
            if (changedName.Length <= 2)
                return new ErrorResult(CoverCapConstants.KeywordNumberCounter);
            if (changedName == string.Empty)
                return new ErrorResult(CoverCapConstants.CoverCapNameNull);
            return new SuccessResult();
        }

        private IResult CoverCapChecker(CoverCap coverCap)
        {
            if (coverCap == null)
                return new ErrorResult(CoverCapConstants.CoverCapNameNull);
            if (coverCap.BookSkinType == null || coverCap.BookSkinType == string.Empty)
                return new ErrorResult(CoverCapConstants.CoverCapNameNull);
            if (_coverCapDal.Get(x => x.BookSkinType.ToLower() == coverCap.BookSkinType.ToLower()) != null)
                return new ErrorResult(CoverCapConstants.CoverCapNameExist);
            return new SuccessResult();
        }
    }
}
