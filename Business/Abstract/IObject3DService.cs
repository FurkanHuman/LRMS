using Business.Abstract.Base;
using Core.Utilities.Result.Abstract;
using Entities.Concrete;

namespace Business.Abstract
{
    public interface IObject3DService : IMaterialBaseService<Object3D>
    {
        IDataResult<List<Object3D>> GetAllByOwnerId(Guid ownerId);
        IDataResult<List<Object3D>> GetAllByOwnersId(Guid[] ownerIds);
        IDataResult<List<Object3D>> GetAllByDestroyState(bool state);
        IDataResult<Object3D> GetByImageId(Guid imageId);

    }
}
