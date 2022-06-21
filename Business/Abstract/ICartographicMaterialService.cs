using Business.Abstract.Base;
using Core.Utilities.Result.Abstract;
using Entities.Concrete;

namespace Business.Abstract
{
    public interface ICartographicMaterialService : IMaterialBaseService<CartographicMaterial>
    {
        IDataResult<CartographicMaterial> GetByImageId(Guid imageId);
        IDataResult<List<CartographicMaterial>> GetByImageIds(Guid[] imageIds);
        IDataResult<List<CartographicMaterial>> GetByDate(DateTime dateTimeMin, DateTime? dateTimeMax);
    }
}
