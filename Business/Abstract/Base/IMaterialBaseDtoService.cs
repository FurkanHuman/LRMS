using Core.Entities.Abstract;
using Core.Utilities.Result.Abstract;
using Entities.DTOs.Base;

namespace Business.Abstract.Base
{
    public interface IMaterialBaseDtoService<G> : IBaseDtoService<G, Guid> where G : MaterialBaseDto, IDto, new()
    {
        IDataResult<G> DtoGetByStockCode(Guid stockCodeId);

        // list to IEnumrable change after
        IDataResult<List<G>> DtoGetAllByTitle(string title);
        IDataResult<List<G>> DtoGetAllByDescriptionFinder(string finderString);
        IDataResult<List<G>> DtoGetAllByCategories(int[] categoriesId);
        IDataResult<List<G>> DtoGetAllByDimension(Guid dimensionId);
        IDataResult<List<G>> DtoGetAllByEMFile(Guid eMFilesId);
        IDataResult<List<G>> DtoGetAllByPrice(decimal minPrice, decimal? maxPrice = null);
    }
}
