using Business.Abstract.Base;
using Core.Utilities.Result.Abstract;
using Entities.Concrete.Infos;
using Entities.DTOs.Infos;

namespace Business.Abstract
{
    public interface IWriterService : IFirstPersonBaseService<Writer>, IFirstPersonBaseDtoService<WriterDto>
    {
        IDataResult<IList<Writer>> GetAllNamePreAttachment(string namePreAttachment);
        IDataResult<IList<WriterDto>> DtoGetAllNamePreAttachment(string namePreAttachment);
    }
}
