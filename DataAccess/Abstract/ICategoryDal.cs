using Core.DataAccess;
using Entities.Concrete.Cover;

namespace DataAccess.Abstract
{
    public interface ICategoryDal : IEntityRepository<Category>
    {
    }
}
