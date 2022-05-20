using Core.Entities.Abstract;
using Core.Utilities.Result.Abstract;
using Entities.Concrete.Base;

namespace Business.Abstract.Base
{
    public interface IBasePaperService<T> : IMaterialBaseService<T> where T : BasePaper, IEntity, new()
    {
        IDataResult<List<T>> GetByWriters(Guid writerId);
        IDataResult<T> GetByCoverImage(Guid CImageId);
        IDataResult<List<T>> GetByEditors(Guid id);
        IDataResult<List<T>> GetByDirectors(Guid id);
        IDataResult<List<T>> GetByGraphicDirectors(Guid id);
        IDataResult<List<T>> GetByGraphicDesigns(Guid id);
        IDataResult<List<T>> GetByRedactions(Guid id);
        IDataResult<List<T>> GetByInterpreters(Guid id);
        IDataResult<List<T>> GetByTechnicalNumbers(Guid id);
        IDataResult<List<T>> GetByCommunications(Guid id);
        IDataResult<List<T>> GetByEditions(Guid editionNum);
        IDataResult<List<T>> GetByPublishers(Guid publisherNum);
        IDataResult<List<T>> GetByCoverCaps(int CoverCapNum);
    }
}
