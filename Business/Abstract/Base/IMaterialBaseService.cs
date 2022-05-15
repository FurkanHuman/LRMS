using Core.Entities.Abstract;
using Core.Utilities.Result.Abstract;
using Entities.Concrete.Base;
using System.Linq.Expressions;

namespace Business.Abstract.Base
{
    public interface IMaterialBaseService<T> where T : MaterialBase,IEntity,new()
    {
        IDataResult<T> GetById(Guid id);
        IDataResult<T> GetByName(string name);
        IDataResult<T> GetByDescriptionFinder(string finderString);
        IDataResult<T> GetByCategory(int categoryId);
        IDataResult<List<T>> GetByWhereIsItLocateds(Guid placeHolderId);
        IDataResult<T> GetByDimension(Guid dimensionId);
        IDataResult<List<T>> GetByEMFiles(Guid dimensionId);
        IDataResult<T> GetState(int stateId);
        IDataResult<T> GetSecretLevel();
        IDataResult<List<T>> GetLists();
        IDataResult<List<T>> GetByFilterLists(Expression<Func<T, bool>>? filter = null);
        IResult Add(T entity);
        IResult Delete(T entity);
        IResult Update(T entity);
    }
}
