using Entities.Abstract;

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

        [ValidationAspect(typeof(CategoryValidator), Priority = 1)]
        public IDataResult<CategoryAddDto> DtoAdd(CategoryAddDto addDto)
        {
            Category category = new MapperConfiguration(cfg => cfg.CreateMap<CategoryAddDto, Category>()).CreateMapper().Map<Category>(addDto);

            IResult result = BusinessRules.Run(CategoryNameChecker(category));
            if (result != null)
                return new ErrorDataResult<CategoryAddDto>(result.Message);

            category.IsDeleted = false;

            Category returnCategory = _categoryDal.Add(category);

            return returnCategory != null
                ? new SuccessDataResult<CategoryAddDto>(addDto, CategoryConstants.AddSuccess)
                : new ErrorDataResult<CategoryAddDto>(addDto, CategoryConstants.AddFailed);
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

        [ValidationAspect(typeof(CategoryValidator), Priority = 1)]
        public IDataResult<CategoryUpdateDto> DtoUpdate(CategoryUpdateDto updateDto)
        {
            Category category = new MapperConfiguration(cfg => cfg.CreateMap<CategoryUpdateDto, Category>()).CreateMapper().Map<Category>(updateDto);

            IResult result = BusinessRules.Run(CategoryNameChecker(category));
            if (result != null)
                return new ErrorDataResult<CategoryUpdateDto>(result.Message);

            Category returnCategory = _categoryDal.Update(category);

            return returnCategory != null
                ? new SuccessDataResult<CategoryUpdateDto>(updateDto, CategoryConstants.AddSuccess)
                : new ErrorDataResult<CategoryUpdateDto>(updateDto, CategoryConstants.AddFailed);
        }

        public IDataResult<Category> GetById(int id)
        {
            Category? category = _categoryDal.Get(Z => Z.Id == id);

            return category == null
                ? new ErrorDataResult<Category>(CategoryConstants.DataNotGet)
                : new SuccessDataResult<Category>(category, CategoryConstants.DataGet);
        }

        public IDataResult<CategoryDto> DtoGetById(int id)
        {
            CategoryDto? categoryDto = _categoryDal.DtoGet(Z => Z.Id == id);

            return categoryDto == null
                ? new ErrorDataResult<CategoryDto>(CategoryConstants.DataNotGet)
                : new SuccessDataResult<CategoryDto>(categoryDto, CategoryConstants.DataGet);
        }

        public IDataResult<IList<Category>> GetAllByIds(int[] ids)
        {
            IList<Category> categorys = _categoryDal.GetAll(Z => ids.Contains(Z.Id));
            return categorys == null
                ? new ErrorDataResult<IList<Category>>(CategoryConstants.DataNotGet)
                : new SuccessDataResult<IList<Category>>(categorys, CategoryConstants.DataGet);
        }

        public IDataResult<IList<CategoryDto>> DtoGetAllByIds(int[] ids)
        {
            IList<CategoryDto> categoryDtos = _categoryDal.DtoGetAll(Z => ids.Contains(Z.Id));
            return categoryDtos == null
                ? new ErrorDataResult<IList<CategoryDto>>(CategoryConstants.DataNotGet)
                : new SuccessDataResult<IList<CategoryDto>>(categoryDtos, CategoryConstants.DataGet);
        }

        public IDataResult<IList<Category>> GetAllByName(string name)
        {
            IList<Category> categorys = _categoryDal.GetAll(Z => Z.Name.Contains(name));
            return categorys == null
                ? new ErrorDataResult<IList<Category>>(CategoryConstants.DataNotGet)
                : new SuccessDataResult<IList<Category>>(categorys, CategoryConstants.DataGet);
        }

        public IDataResult<IList<CategoryDto>> DtoGetAllByName(string name)
        {
            IList<CategoryDto> categoryDtos = _categoryDal.DtoGetAll(Z => Z.Name.Contains(name));
            return categoryDtos == null
                ? new ErrorDataResult<IList<CategoryDto>>(CategoryConstants.DataNotGet)
                : new SuccessDataResult<IList<CategoryDto>>(categoryDtos, CategoryConstants.DataGet);
        }

        public IDataResult<IList<Category>> GetAllByFilter(Expression<Func<Category, bool>>? filter = null)
        {
            return new SuccessDataResult<IList<Category>>(_categoryDal.GetAll(filter), CategoryConstants.DataGet);
        }

        public IDataResult<IList<CategoryDto>> DtoGetAllByFilter(Expression<Func<Category, bool>>? filter = null)
        {
            return new SuccessDataResult<IList<CategoryDto>>(_categoryDal.DtoGetAll(filter), CategoryConstants.DataGet);
        }

        public IDataResult<IList<Category>> GetAllByIsDeleted()
        {
            return new SuccessDataResult<IList<Category>>(_categoryDal.GetAll(c => c.IsDeleted), CategoryConstants.DataGet);
        }

        public IDataResult<IList<CategoryDto>> DtoGetAllByIsDeleted()
        {
            return new SuccessDataResult<IList<CategoryDto>>(_categoryDal.DtoGetAll(c => c.IsDeleted), CategoryConstants.DataGet);
        }

        public IDataResult<IList<Category>> GetAll()
        {
            return new SuccessDataResult<IList<Category>>(_categoryDal.GetAll(c => !c.IsDeleted), CategoryConstants.DataGet);
        }
        public IDataResult<IList<CategoryDto>> DtoGetAll()
        {
            return new SuccessDataResult<IList<CategoryDto>>(_categoryDal.DtoGetAll(c=>!c.IsDeleted), CategoryConstants.DataGet);
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
