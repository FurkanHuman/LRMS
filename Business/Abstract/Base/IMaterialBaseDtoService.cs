namespace Business.Abstract.Base
{
    public interface IMaterialBaseDtoService<E, D, A, U> : IBaseDtoService<E, D, A, U, Guid> where E : IEntity, new()
                                                                                             where D : MaterialBaseDto, IDto, new()
                                                                                             where A : IAddDto, new()
                                                                                             where U : IUpdateDto, new()

    {
        IDataResult<D> DtoGetByStockCode(Guid stockCodeId);
        IDataResult<IList<D>> DtoGetAllByTitle(string title);
        IDataResult<IList<D>> DtoGetAllByDescriptionFinder(string finderString);
        IDataResult<IList<D>> DtoGetAllByCategories(int[] categoriesId);
        IDataResult<IList<D>> DtoGetAllByDimension(Guid dimensionId);
        IDataResult<IList<D>> DtoGetAllByEMFile(Guid eMFilesId);
        IDataResult<IList<D>> DtoGetAllByPrice(decimal minPrice, decimal? maxPrice = null);
    }
}
