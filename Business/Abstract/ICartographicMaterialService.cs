namespace Business.Abstract
{
    public interface ICartographicMaterialService : IMaterialBaseService<CartographicMaterial>
    {
        IDataResult<CartographicMaterial> GetAllByImageId(Guid imageId);
        IDataResult<IList<CartographicMaterial>> GetAllByImageIds(Guid[] imageIds);
        IDataResult<IList<CartographicMaterial>> GetAllByDate(DateTime dateTimeMin, DateTime? dateTimeMax);
    }
}
