using Business.Abstract.Base;
using Core.Utilities.Result.Abstract;
using Entities.Concrete;

namespace Business.Abstract
{
    public interface IGraphicalImageService : IMaterialBaseService<GraphicalImage>
    {
        IDataResult<GraphicalImage> GetByImage(Guid imageId);
        IDataResult<List<GraphicalImage>> GetByImageCreatedDate(DateTime dateTime);
        IDataResult<List<GraphicalImage>> GetByOtherPeoples(Guid otherPeopleId);
    }
}
