namespace DataAccess.Concrete
{
    public class EfCategoryDal : EfEntityRepositoryBase<Category, CategoryDto, PostgreDbContext>, ICategoryDal
    {
    }
}
