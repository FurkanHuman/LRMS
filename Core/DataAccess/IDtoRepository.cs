using Core.Entities.Abstract;
using System.Linq.Expressions;

namespace Core.DataAccess
{
    public interface IDtoRepository<D, T> where D : class, IDto, new()
                                          where T : class, IEntity, new()
    {
        D? DtoGet(Expression<Func<T, bool>> filter);
        IList<D> DtoGetAll(Expression<Func<T, bool>>? filter = null);
    }
}
