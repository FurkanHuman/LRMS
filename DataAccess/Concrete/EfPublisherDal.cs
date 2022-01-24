using Core.DataAccess.PostgreDb;
using DataAccess.Abstract;
using DataAccess.Context;
using Entities.Concrete.FirstPage;

namespace DataAccess.Concrete
{
    public class EfPublisherDal : EfEntityRepositoryBase<Publisher, PostgreDbContext>, IPublisherDal
    {
    }
}
