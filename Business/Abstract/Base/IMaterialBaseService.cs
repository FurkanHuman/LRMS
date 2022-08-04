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
        IDataResult<IList<T>> GetAllByCategories(int[] categoriesId);
        IDataResult<IList<T>> GetAllByDescriptionFinder(string finderString);
        IDataResult<IList<T>> GetAllByDimension(Guid dimensionId);
        IDataResult<IList<T>> GetAllByEMFile(Guid eMFileId);
        IDataResult<IList<T>> GetAllByPrice(decimal minPrice, decimal? maxPrice = null);
        IDataResult<IList<T>> GetAllByTechnicalPlaceholder(Guid technicalPlaceholderId);
        IDataResult<IList<T>> GetAllByTitle(string title);
    }
}
