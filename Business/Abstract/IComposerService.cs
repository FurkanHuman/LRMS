using Business.Abstract.Base;
using Core.Utilities.Result.Abstract;
using Entities.Concrete.Infos;

namespace Business.Abstract
{
    public interface IComposerService : IFirstPersonBaseService<Composer>
    {

        IDataResult<List<Composer>> GetNamePreAttachmentList(string namePreAttachment);
    }
}
