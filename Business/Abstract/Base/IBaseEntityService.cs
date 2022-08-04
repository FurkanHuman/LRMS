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
        IDataResult<IList<T>> GetAllByIds(I[] ids);
        IDataResult<IList<T>> GetAllByFilter(Expression<Func<T, bool>>? filter = null);
        IDataResult<IList<T>> GetAllByName(string name);
        IDataResult<IList<T>> GetAllByIsDeleted();
        IDataResult<IList<T>> GetAll();
    }
}
