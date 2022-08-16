using Core.Entities.Abstract;
using System.Linq.Expressions;

namespace Core.DataAccess
{
    public interface IEntityRepository<T> where T : class, IEntity, new()
    {
        T? Get(Expression<Func<T, bool>> filter);
        IList<T> GetAll(Expression<Func<T, bool>>? filter = null);
        T Add(T entity);
        T Delete(T entity);
        T Update(T entity);
    }
}
