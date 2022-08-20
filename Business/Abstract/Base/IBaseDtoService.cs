namespace Business.Abstract.Base
{
    public interface IBaseDtoService<E, D, I> where E : IEntity, new()
                                              where D : IDto, new()
                                              where I : struct
    {
        IDataResult<D> DtoGetById(I id);
        IDataResult<IList<D>> DtoGetAllByIds(I[] ids);
        IDataResult<IList<D>> DtoGetAllByName(string name);
        IDataResult<IList<D>> DtoGetAllByFilter(Expression<Func<E, bool>>? filter = null);
        IDataResult<IList<D>> DtoGetAllByIsDeleted();
        IDataResult<IList<D>> DtoGetAll();
    }
}
