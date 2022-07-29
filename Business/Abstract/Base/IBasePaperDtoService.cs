using Core.Entities.Abstract;
using Core.Utilities.Result.Abstract;
using Entities.DTOs.Base;

namespace Business.Abstract.Base
{
    public interface IBasePaperDtoService<D> : IMaterialBaseDtoService<D> where D : BasePaperDto, IDto, new()
    {
        // list to IEnumrable change after
        IDataResult<D> DtoGetByCoverImage(Guid CImageId);
        IDataResult<List<D>> DtoGetAllByWriter(Guid writerId);
        IDataResult<List<D>> DtoGetAllByEditor(Guid editorId);
        IDataResult<List<D>> DtoGetAllByDirector(Guid directorId);
        IDataResult<List<D>> DtoGetAllByGraphicDirector(Guid graphicDirectorId);
        IDataResult<List<D>> DtoGetAllByGraphicDesign(Guid graphicDesignId);
        IDataResult<List<D>> DtoGetAllByRedaction(Guid redactionId);
        IDataResult<List<D>> DtoGetAllByInterpreter(Guid InterpreterId);
        IDataResult<List<D>> DtoGetAllByTechnicalNumber(Guid technicalNumberId);
        IDataResult<List<D>> DtoGetAllByCommunication(Guid communicationId);
        IDataResult<List<D>> DtoGetAllByEdition(Guid editionNum);
        IDataResult<List<D>> DtoGetAllByPublisher(Guid publisherNum);
        IDataResult<List<D>> DtoGetAllByCoverCap(int CoverCapNum);
    }
}
