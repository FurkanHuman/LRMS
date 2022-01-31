using Core.Utilities.Result.Abstract;
using Entities.Concrete.Base;
using System.Linq.Expressions;

namespace Business.Abstract
{
    public interface IFirstPersonBaseService<T> where T : FirstPagePersonBase
    {
        IDataResult<T> GetById(int id);
        IDataResult<T> GetByName(string name);
        IDataResult<T> GetBySurname(string surname);
        IDataResult<List<T>> GetList();
        IDataResult<List<T>> GetByFilterList(Expression<Func<T, bool>>? filter = null);
        IResult Add(T entity);
        IResult Delete(T entity);
        IResult Update(T entity);
    }
}