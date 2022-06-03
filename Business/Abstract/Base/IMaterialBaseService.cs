using Core.Entities.Abstract;
using Core.Utilities.Result.Abstract;
using Entities.Concrete.Base;

namespace Business.Abstract.Base
{
    public interface IMaterialBaseService<T> : IBaseEntityService<T, Guid> where T : MaterialBase, IEntity, new()
    {
        IDataResult<T> GetByName(string name);
        IDataResult<T> GetByDescriptionFinder(string finderString);
        IDataResult<T> GetByCategory(int categoryId);
        IDataResult<List<T>> GetByWhereIsItLocateds(Guid placeHolderId);
        IDataResult<T> GetByDimension(Guid dimensionId);
        IDataResult<List<T>> GetByEMFiles(Guid dimensionId);
        IDataResult<T> GetState(int stateId);
        IDataResult<T> GetSecretLevel();
        IDataResult<List<T>> GetLists();
        IResult Delete(T entity);
    }
}
