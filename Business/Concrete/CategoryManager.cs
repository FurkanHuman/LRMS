using Business.Abstract;
using Business.Constants;
using Core.Utilities.Business;
using Core.Utilities.Result.Abstract;
using Core.Utilities.Result.Concrete;
using DataAccess.Abstract;
using Entities.Concrete.Infos;

namespace Business.Concrete
{
    public class CategoryManager : ICategoryService
    {
        private readonly ICategoryDal _categoryDal;

        public CategoryManager(ICategoryDal categoryDal)
        {
            _categoryDal = categoryDal;
        }

        public IResult Add(Category category)
        {
            IResult result = BusinessRules.Run(CategoryChecker(category));
            if (result != null)
                return result;

            _categoryDal.Add(category);
            return new SuccessResult(CategoryConstants.AddSucces);
        }

        public IResult Update(Category category, string changedName)
        {
            IResult result = BusinessRules.Run(CategoryChecker(category), ChangedNameChecker(changedName));
            if (result != null)
                return result;

            category.CategoryName = changedName;
            _categoryDal.Update(category);

            return new SuccessResult(CategoryConstants.UpdateSuccess);
        }

        public IDataResult<Category> GetById(int id)
        {
            Category? category = _categoryDal.Get(Z => Z.Id == id);

            return category == null
                ? new ErrorDataResult<Category>(CategoryConstants.DataNotGet)
                : new SuccessDataResult<Category>(category, CategoryConstants.DataGet);
        }

        public IDataResult<Category> GetByName(string name)
        {
            Category? category = _categoryDal.Get(Z => Z.CategoryName == name);

            return category == null
                ? new ErrorDataResult<Category>(CategoryConstants.DataNotGet)
                : new SuccessDataResult<Category>(category, CategoryConstants.DataGet);
        }

        public IDataResult<List<Category>> GetList()
        {
            return new SuccessDataResult<List<Category>>((List<Category>)_categoryDal.GetAll(), CategoryConstants.DataGet);
        }

        private static IResult ChangedNameChecker(string changedName)
        {
            if (changedName.Length <= 2)
                return new ErrorResult(CategoryConstants.KeywordNumberCounter);
            if (changedName == string.Empty)
                return new ErrorResult(CategoryConstants.CategoryNameNull);
            return new SuccessResult();
        }

        private IResult CategoryChecker(Category category)
        {
            if (category == null)
                return new ErrorResult(CategoryConstants.CategoryNameNull);
            if (category.CategoryName == null || category.CategoryName == string.Empty)
                return new ErrorResult(CategoryConstants.CategoryNameNull);
            if (_categoryDal.Get(x => x.CategoryName.ToLower() == category.CategoryName.ToLower()) != null)
                return new ErrorResult(CategoryConstants.CategoryNameExist);
            return new SuccessResult();
        }
    }
}
