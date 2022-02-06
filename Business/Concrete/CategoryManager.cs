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
            IResult result = BusinessRules.Run(CategoryNameChecker(category));
            if (result != null)
                return result;

            _categoryDal.Add(category);
            return new SuccessResult(CategoryConstants.AddSuccess);
        }

        public IResult Delete(Category category)
        {
            _categoryDal.Delete(category);
            return new SuccessResult(CategoryConstants.DeleteSuccess);
        }

        public IResult Update(Category category)
        {
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

        private IResult CategoryNameChecker(Category category)
        {
            bool res = _categoryDal.GetAll(c => c.CategoryName.ToLowerInvariant().Contains(category.CategoryName.ToLowerInvariant())).Any();

            return res
                ? new ErrorResult(CategoryConstants.DataNotGet)
                : new SuccessResult(CategoryConstants.DataGet);

        }
    }
}
