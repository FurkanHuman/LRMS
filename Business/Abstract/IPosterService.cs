using Business.Abstract.Base;
using Core.Utilities.Result.Abstract;
using Entities.Concrete;

namespace Business.Abstract
{
    public interface IPosterService : IMaterialBaseService<Poster>
    {
        IDataResult<List<Poster>> GetAllByOwnerId(Guid ownerId);
        IDataResult<List<Poster>> GetAllByOwnersId(Guid[] ownerIds);
        IDataResult<List<Poster>> GetAllByDestroyState(bool state);
        IDataResult<Poster> GetByImageId(Guid imageId);
    }
}
