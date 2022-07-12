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
        IDataResult<List<T>> GetByCategories(int[] categoriesId);
        IDataResult<List<T>> GetByDescriptionFinder(string finderString);
        IDataResult<List<T>> GetByDimension(Guid dimensionId);
        IDataResult<List<T>> GetByEMFiles(Guid eMFilesId);
        IDataResult<List<T>> GetByPrice(decimal minPrice, decimal? maxPrice = null);
        IDataResult<List<T>> GetByTechnicalPlaceholders(Guid technicalPlaceholderId);
        IDataResult<List<T>> GetByTitles(string title);
    }
}
