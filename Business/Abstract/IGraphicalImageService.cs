using Business.Abstract.Base;
using Core.Utilities.Result.Abstract;
using Entities.Concrete;

namespace Business.Abstract
{
    public interface IGraphicalImageService : IMaterialBaseService<GraphicalImage>
    {
        IDataResult<List<GraphicalImage>> GetByImageCreatedDate(DateTime DateTime);
        IDataResult<List<GraphicalImage>> GetByOtherPeoples(Guid otherPeopleId);
    }
}
