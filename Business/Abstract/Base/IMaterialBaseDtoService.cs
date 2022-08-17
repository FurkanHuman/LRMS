namespace Business.Abstract.Base
{
    public interface IMaterialBaseDtoService<G> : IBaseDtoService<G, Guid> where G : MaterialBaseDto, IDto, new()
    {
        IDataResult<G> DtoGetByStockCode(Guid stockCodeId);
        IDataResult<IList<G>> DtoGetAllByTitle(string title);
        IDataResult<IList<G>> DtoGetAllByDescriptionFinder(string finderString);
        IDataResult<IList<G>> DtoGetAllByCategories(int[] categoriesId);
        IDataResult<IList<G>> DtoGetAllByDimension(Guid dimensionId);
        IDataResult<IList<G>> DtoGetAllByEMFile(Guid eMFilesId);
        IDataResult<IList<G>> DtoGetAllByPrice(decimal minPrice, decimal? maxPrice = null);
    }
}
