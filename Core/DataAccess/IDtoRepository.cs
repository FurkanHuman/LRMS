using Core.Entities.Abstract;
using System.Linq.Expressions;

namespace Core.DataAccess
{
    public interface IDtoRepository<E, D> where E : class, IEntity, new()
                                          where D : class, IDto, new()

    {
        D? DtoGet(Expression<Func<E, bool>> filter);

        IList<D> DtoGetAll(Expression<Func<E, bool>>? filter = null);
    }

    public interface IDtoRepository<E> where E : class, IEntity, new()
    {
        // custom IDto type. C is special. if more dto is needed it can be used with the help of methot
        C? CDtoGet<C>(Expression<Func<E, bool>> filter) where C : class, IDto, new();

        IList<C> CDtoGetAll<C>(Expression<Func<E, bool>>? filter = null) where C : class, IDto, new();
    }
}
