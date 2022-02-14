using Core.Utilities.Result.Abstract;
using Entities;

namespace Business.Abstract
{
    public interface IComposerService : IFirstPersonBaseService<Composer>
    {

        IDataResult<List<Composer>> GetNamePreAttachmentList(string namePreAttachment);
    }
}
