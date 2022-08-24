namespace Business.Abstract
{
    public interface ICategoryService : IBaseEntityService<Category, int>, IBaseDtoService<Category, CategoryDto, CategoryAddDto, CategoryUpdateDto, int>
    {
    }
}
