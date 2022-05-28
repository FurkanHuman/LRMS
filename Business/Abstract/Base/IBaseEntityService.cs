using Core.Entities.Abstract;
using Core.Utilities.Result.Abstract;
using System.Linq.Expressions;

namespace Business.Abstract.Base
{
    public interface IBaseEntityService<T> where T : IEntity, new()
    {
        IResult Add(T entity);
        IResult Update(T entity);
        IDataResult<List<T>> GetByNames(string name);
        IDataResult<List<T>> GetByFilterLists(Expression<Func<T, bool>>? filter = null);
        IDataResult<List<T>> GetAll();
        IDataResult<List<T>> GetAllBySecrets();
    }
}
