using Business.Abstract.Base;
using Core.Utilities.Result.Abstract;
using Entities.Concrete;

namespace Business.Abstract
{
    public interface IGraphicalImageService : IMaterialBaseService<GraphicalImage>
    {
        IDataResult<GraphicalImage> GetByImage(Guid imageId);
        IDataResult<List<GraphicalImage>> GetAllByImageCreatedDate(DateTime dateTime);
        IDataResult<List<GraphicalImage>> GetAllByOtherPeople(Guid otherPeopleId);
    }
}
