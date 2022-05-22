using Core.DataAccess.PostgreDb;
using DataAccess.Abstract;
using DataAccess.Contexts;
using Entities.Concrete;

namespace DataAccess.Concrete
{
    public class EfMusicalNoteDal : EfEntityRepositoryBase<MusicalNote, PostgreDbContext>, IMusicalNoteDal
    {
    }
}
