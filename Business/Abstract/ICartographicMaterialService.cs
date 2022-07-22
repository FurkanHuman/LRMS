using Business.Abstract.Base;
using Core.Utilities.Result.Abstract;
using Entities.Concrete;

namespace Business.Abstract
{
    public interface ICartographicMaterialService : IMaterialBaseService<CartographicMaterial>
    {
        IDataResult<CartographicMaterial> GetAllByImageId(Guid imageId);
        IDataResult<List<CartographicMaterial>> GetAllByImageIds(Guid[] imageIds);
        IDataResult<List<CartographicMaterial>> GetAllByDate(DateTime dateTimeMin, DateTime? dateTimeMax);
    }
}
