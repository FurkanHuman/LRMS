using Core.Utilities.Result.Abstract;
using Entities.Concrete.Infos;

namespace Business.Abstract
{
    public interface IWriterService : IFirstPersonBaseService<Writer>
    {
        IDataResult<List<Writer>> GetNamePreAttachmentList(string NamePreAttachment);
    }
}
