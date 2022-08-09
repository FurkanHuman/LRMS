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
    public class CategoryManager : ICategoryService
    {
        private readonly ICategoryDal _categoryDal;

        public CategoryManager(ICategoryDal categoryDal)
        {
            _categoryDal = categoryDal;
        }

        [ValidationAspect(typeof(CategoryValidator), Priority = 1)]
        public IResult Add(Category category)
        {
            IResult result = BusinessRules.Run(CategoryNameChecker(category));
            if (result != null)
                return result;

            _categoryDal.Add(category);
            return new SuccessResult(CategoryConstants.AddSuccess);
        }

        public IResult ShadowDelete(int id)
        {
            Category category = _categoryDal.Get(c => c.Id == id && !c.IsDeleted);
            if (category == null)
                return new ErrorResult(CategoryConstants.NotMatch);

            category.IsDeleted = true;
            _categoryDal.Update(category);
            return new SuccessResult(CategoryConstants.DeleteSuccess);
        }

        public IResult Delete(int id)
        {
            Category category = _categoryDal.Get(c => c.Id == id && !c.IsDeleted);
            if (category == null)
                return new ErrorResult(CategoryConstants.NotMatch);

            _categoryDal.Delete(category);
            return new SuccessResult(CategoryConstants.DeleteSuccess);
        }

        [ValidationAspect(typeof(CategoryValidator), Priority = 1)]
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

        public IDataResult<IList<Category>> GetAllByIds(int[] ids)
        {
            IList<Category> categorys = _categoryDal.GetAll(Z => ids.Contains(Z.Id));
            return categorys == null
                ? new ErrorDataResult<IList<Category>>(CategoryConstants.DataNotGet)
                : new SuccessDataResult<IList<Category>>(categorys, CategoryConstants.DataGet);
        }

        public IDataResult<IList<Category>> GetAllByName(string name)
        {
            IList<Category> categorys = _categoryDal.GetAll(Z => Z.Name.Contains(name));
            return categorys == null
                ? new ErrorDataResult<IList<Category>>(CategoryConstants.DataNotGet)
                : new SuccessDataResult<IList<Category>>(categorys, CategoryConstants.DataGet);
        }

        public IDataResult<IList<Category>> GetAllByFilter(Expression<Func<Category, bool>>? filter = null)
        {
            return new SuccessDataResult<IList<Category>>(_categoryDal.GetAll(filter), CategoryConstants.DataGet);
        }

        public IDataResult<IList<Category>> GetAllByIsDeleted()
        {
            return new SuccessDataResult<IList<Category>>(_categoryDal.GetAll(c => c.IsDeleted), CategoryConstants.DataGet);
        }

        public IDataResult<IList<Category>> GetAll()
        {
            return new SuccessDataResult<IList<Category>>(_categoryDal.GetAll(c => !c.IsDeleted), CategoryConstants.DataGet);
        }

        private IResult CategoryNameChecker(Category category)
        {
            bool res = _categoryDal.GetAll(c => c.Name.Contains(category.Name)).Any();
            return res
                ? new ErrorResult(CategoryConstants.DataNotGet)
                : new SuccessResult(CategoryConstants.DataGet);
        }
    }
}
