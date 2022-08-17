namespace DataAccess.Concrete
{
    public class EfBookDal : EfEntityRepositoryBase<Book, PostgreDbContext>, IBookDal
    {
    }
}
