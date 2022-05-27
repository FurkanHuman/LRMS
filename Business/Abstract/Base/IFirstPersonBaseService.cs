using Core.Entities.Abstract;
using Core.Utilities.Result.Abstract;
using Entities.Concrete.Base;
using System.Linq.Expressions;

namespace Business.Abstract.Base
{
    public interface IFirstPersonBaseService<T> where T : FirstPagePersonBase, IEntity, new()
    {
        IDataResult<T> GetById(Guid guid);
        IDataResult<List<T>> GetByNames(string name);
        IDataResult<List<T>> GetBySurnames(string surname);
        IDataResult<List<T>> GetList();
        IDataResult<List<T>> GetByFilterList(Expression<Func<T, bool>>? filter = null);
        IResult Add(T entity);
        IResult Delete(T entity);
        IResult ShadowDelete(Guid guid);
        IResult Update(T entity);
    }
}