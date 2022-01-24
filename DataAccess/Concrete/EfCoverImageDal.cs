using Core.DataAccess.PostgreDb;
using DataAccess.Abstract;
using DataAccess.Context;
using Entities.Concrete.Cover;

namespace DataAccess.Concrete
{
    public class EfCoverImageDal : EfEntityRepositoryBase<CoverImage, PostgreDbContext>, ICoverImageDal
    {
    }
}
