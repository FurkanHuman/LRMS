using Core.DataAccess.PostgreDb;
using DataAccess.Abstract;
using DataAccess.Context;
using Entities.Concrete;

namespace DataAccess.Concrete
{
    public class EfBookDal : EfEntityRepositoryBase<Book, PostgreDbContext>, IBookDal
    {
    }
}
