using Core.Entities.Abstract;
using Core.Utilities.Result.Abstract;
using Entities.Concrete.Base;

namespace Business.Abstract.Base
{
    public interface IMaterialBaseService<T> : IBaseEntityService<T, Guid> where T : MaterialBase, IEntity, new()
    {
        IDataResult<byte?> GetSecretLevel(Guid id);
        IDataResult<byte> GetState(Guid id);
        IDataResult<T> GetByStock(Guid stockId);
        IDataResult<List<T>> GetAllByCategories(int[] categoriesId);
        IDataResult<List<T>> GetAllByDescriptionFinder(string finderString);
        IDataResult<List<T>> GetAllByDimension(Guid dimensionId);
        IDataResult<List<T>> GetAllByEMFile(Guid eMFileId);
        IDataResult<List<T>> GetAllByPrice(decimal minPrice, decimal? maxPrice = null);
        IDataResult<List<T>> GetAllByTechnicalPlaceholder(Guid technicalPlaceholderId);
        IDataResult<List<T>> GetAllByTitle(string title);
    }
}
