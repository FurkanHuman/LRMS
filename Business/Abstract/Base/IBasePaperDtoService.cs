using Core.Entities.Abstract;
using Core.Utilities.Result.Abstract;
using Entities.DTOs.Base;

namespace Business.Abstract.Base
{
    public interface IBasePaperDtoService<D> : IMaterialBaseDtoService<D> where D : BasePaperDto, IDto, new()
    {
        IDataResult<List<D>> DtoGetByWriters(Guid writerId);
        IDataResult<D> DtoGetByCoverImage(Guid CImageId);
        IDataResult<List<D>> DtoGetByEditors(Guid id);
        IDataResult<List<D>> DtoGetByDirectors(Guid id);
        IDataResult<List<D>> DtoGetByGraphicDirectors(Guid id);
        IDataResult<List<D>> DtoGetByGraphicDesigns(Guid id);
        IDataResult<List<D>> DtoGetByRedactions(Guid id);
        IDataResult<List<D>> DtoGetByInterpreters(Guid id);
        IDataResult<List<D>> DtoGetByTechnicalNumbers(Guid id);
        IDataResult<List<D>> DtoGetByCommunications(Guid id);
        IDataResult<List<D>> DtoGetByEditions(Guid editionNum);
        IDataResult<List<D>> DtoGetByPublishers(Guid publisherNum);
        IDataResult<List<D>> DtoGetByCoverCaps(int CoverCapNum);
    }
}
