using Core.Entities.Abstract;
using Core.Utilities.Result.Abstract;
using Entities.Concrete.Base;

namespace Business.Abstract.Base
{
    public interface IBasePaperService<T> : IMaterialBaseService<T> where T : BasePaper, IEntity, new()
    {
        IDataResult<T> GetByCoverImage(Guid cImageId);
        IDataResult<List<T>> GetAllByCoverCap(byte coverCapNum);
        IDataResult<List<T>> GetAllByCommunication(Guid communicationId);
        IDataResult<List<T>> GetAllByDirector(Guid directorId);
        IDataResult<List<T>> GetAllByEditor(Guid editorId);
        IDataResult<List<T>> GetAllByEdition(Guid editionId);
        IDataResult<List<T>> GetAllByGraphicDirector(Guid graphicDirectorId);
        IDataResult<List<T>> GetAllByGraphicDesign(Guid graphicDesignId);
        IDataResult<List<T>> GetAllByInterpreter(Guid interpreterId);
        IDataResult<List<T>> GetAllByPublisher(Guid publisherId);
        IDataResult<List<T>> GetAllByTechnicalNumber(Guid technicalNumberId);
        IDataResult<List<T>> GetAllByRedaction(Guid redactionId);
        IDataResult<List<T>> GetAllByWriter(Guid writerId);
    }
}
