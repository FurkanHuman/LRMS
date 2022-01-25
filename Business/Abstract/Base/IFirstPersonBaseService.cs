using Core.Utilities.Result.Abstract;
using Entities.Concrete.Base;

namespace Business.Abstract
{
    public interface IFirstPersonBaseService<T> where T : FirstPagePersonBase
    {
        IDataResult<T> GetById(int id);
        IDataResult<T> GetByName(string name);
        IDataResult<T> GetBySurname(string surname);
        IDataResult<List<T>> GetList();
        IDataResult<List<T>> GetByFilterList();
        IResult Add(T Entity);
        IResult Delete(T Entity);
        IResult Update(T Entity);
    }
}