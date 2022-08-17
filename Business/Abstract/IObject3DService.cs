namespace Business.Abstract
{
    public interface IObject3DService : IMaterialBaseService<Object3D>
    {
        IDataResult<IList<Object3D>> GetAllByOwnerId(Guid ownerId);
        IDataResult<IList<Object3D>> GetAllByOwnersId(Guid[] ownerIds);
        IDataResult<IList<Object3D>> GetAllByDestroyState(bool state);
        IDataResult<Object3D> GetByImageId(Guid imageId);

    }
}
