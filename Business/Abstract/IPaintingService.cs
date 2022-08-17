namespace Business.Abstract
{
    public interface IPaintingService : IMaterialBaseService<Painting>
    {
        IDataResult<IList<Painting>> GetAllByOwnerId(Guid ownerId);
        IDataResult<IList<Painting>> GetAllByOwnersId(Guid[] ownerIds);
        IDataResult<IList<Painting>> GetAllByDestroyState(bool state);
        IDataResult<Painting> GetByImageId(Guid imageId);
    }
}
