using Core.DataAccess.PostgreDb;
using DataAccess.Abstract;
using DataAccess.Context;
using Entities.Concrete.FirstPage;

namespace DataAccess.Concrete
{
    public class EfInterpretersDal : EfEntityRepositoryBase<Interpreters, PostgreDbContext>, IInterpretersDal
    {
    }
}
