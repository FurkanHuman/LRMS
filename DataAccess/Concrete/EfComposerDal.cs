using Core.DataAccess.PostgreDb;
using DataAccess.Abstract;
using DataAccess.Context;
using Entities;

namespace DataAccess.Concrete
{
    public class EfComposerDal : EfEntityRepositoryBase<Composer, PostgreDbContext>, IComposerDal
    {
    }
}
