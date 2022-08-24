namespace DataAccess.Abstract
{
    public interface ICategoryDal : IEntityRepository<Category>, IDtoRepository<Category, CategoryDto>
    {
    }
}
