using Core.Entities.Abstract;
using Core.Utilities.Result.Abstract;
using Entities.Concrete.Base;

namespace Business.Abstract.Base
{
    public interface IMaterialBaseService<T> : IBaseEntityService<T, Guid> where T : MaterialBase, IEntity, new()
    {
        IDataResult<List<T>> GetByTitles(string title);
        IDataResult<List<T>> GetByDescriptionFinder(string finderString);
        IDataResult<List<T>> GetByCategories(int[] categoriesId);
        IDataResult<List<T>> GetByWhereIsItLocated(Guid Id);
        IDataResult<List<T?>> GetByPrice(Guid Id);
        IDataResult<List<T?>> GetByDimension(Guid dimensionId);
        IDataResult<List<T?>> GetByEMFiles(Guid dimensionId);
        IDataResult<T> GetState(Guid id);
        IDataResult<T?> GetSecretLevel(Guid id);
    }
}
