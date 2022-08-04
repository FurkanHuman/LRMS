using Business.Abstract.Base;
using Core.Utilities.Result.Abstract;
using Entities.Concrete;

namespace Business.Abstract
{
    public interface ICartographicMaterialService : IMaterialBaseService<CartographicMaterial>
    {
        IDataResult<CartographicMaterial> GetAllByImageId(Guid imageId);
        IDataResult<IList<CartographicMaterial>> GetAllByImageIds(Guid[] imageIds);
        IDataResult<IList<CartographicMaterial>> GetAllByDate(DateTime dateTimeMin, DateTime? dateTimeMax);
    }
}
