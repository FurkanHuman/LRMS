using Business.Abstract.Base;
using Core.Utilities.Result.Abstract;
using Entities.Concrete;

namespace Business.Abstract
{
    public interface IPaintingService : IMaterialBaseService<Painting>
    {
        IDataResult<List<Painting>> GetAllByOwnerId(Guid ownerId);
        IDataResult<List<Painting>> GetAllByOwnersId(Guid[] ownerIds);
        IDataResult<List<Painting>> GetAllByDestroyState(bool state);
        IDataResult<Painting> GetByImageId(Guid imageId);
    }
}
