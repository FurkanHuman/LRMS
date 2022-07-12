using Core.Entities.Abstract;
using Core.Utilities.Result.Abstract;
using Entities.DTOs.Base;

namespace Business.Abstract.Base
{
    public interface IMaterialBaseDtoService<G> : IBaseDtoService<G, Guid> where G : MaterialBaseDto, IDto, new()
    {
        IDataResult<G> DtoGetByStockCode(Guid stockCodeId);
        IDataResult<List<G>> DtoGetByTitles(string title);
        IDataResult<List<G>> DtoGetByDescriptionFinder(string finderString);
        IDataResult<List<G>> DtoGetByCategories(int[] categoriesId);
        IDataResult<List<G>> DtoGetByDimension(Guid dimensionId);
        IDataResult<List<G>> DtoGetByEMFiles(Guid eMFilesId);
        IDataResult<List<G>> DtoGetByPrice(decimal minPrice, decimal? maxPrice = null);
    }
}
