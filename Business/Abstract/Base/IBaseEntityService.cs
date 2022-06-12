using Core.Entities.Abstract;
using Core.Utilities.Result.Abstract;
using System.Linq.Expressions;

namespace Business.Abstract.Base
{
    public interface IBaseEntityService<T, I> where T : IEntity, new()
                                              where I : struct
    {
        IResult Add(T entity);
        IResult Delete(I id);
        IResult ShadowDelete(I id);
        IResult Update(T entity);
        IDataResult<T> GetById(I id);
        IDataResult<List<T>> GetByNames(string name);
        IDataResult<List<T>> GetByFilterLists(Expression<Func<T, bool>>? filter = null);
        IDataResult<List<T>> GetAllBySecrets();
        IDataResult<List<T>> GetAll();
    }
}
