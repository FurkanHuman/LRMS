using Business.Abstract.Base;
using Core.Utilities.Result.Abstract;
using Entities.Concrete.Infos;
using Entities.DTOs.Infos;

namespace Business.Abstract
{
    public interface IWriterService : IFirstPersonBaseService<Writer>, IFirstPersonBaseDtoService<WriterDto>
    {
        IDataResult<List<Writer>> GetAllNamePreAttachment(string namePreAttachment);
        IDataResult<List<WriterDto>> DtoGetAllNamePreAttachment(string namePreAttachment);
    }
}
