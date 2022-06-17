using Core.Entities.Abstract;
using Core.Utilities.Result.Abstract;
using Entities.Concrete.Base;

namespace Business.Abstract.Base
{
    public interface IBasePaperService<T> : IMaterialBaseService<T> where T : BasePaper, IEntity, new()
    {
        IDataResult<T> GetByCoverImage(Guid cImageId);
        IDataResult<List<T>> GetByCoverCaps(byte CoverCapNum);
        IDataResult<List<T>> GetByCommunications(Guid communicationId);
        IDataResult<List<T>> GetByDirectors(Guid directorId);
        IDataResult<List<T>> GetByEditors(Guid editorId);
        IDataResult<List<T>> GetByEditions(Guid editionNum);
        IDataResult<List<T>> GetByGraphicDirectors(Guid graphicDirectorId);
        IDataResult<List<T>> GetByGraphicDesigns(Guid graphicDesignId);
        IDataResult<List<T>> GetByInterpreters(Guid interpreterId);
        IDataResult<List<T>> GetByPublishers(Guid publisherNum);
        IDataResult<List<T>> GetByTechnicalNumbers(Guid technicalNumberId);
        IDataResult<List<T>> GetByRedactions(Guid redactionId);
        IDataResult<List<T>> GetByWriters(Guid writerId);
    }
}
