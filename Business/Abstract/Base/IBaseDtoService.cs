namespace Business.Abstract.Base
{
    public interface IBaseDtoService<D, I> where D : IDto, new()
                                           where I : struct
    {
        IResult DtoAdd(D entity);
        IResult DtoUpdate(D entity);
        IDataResult<D> DtoGetById(I id);
        IDataResult<IList<D>> DtoGetAllByIds(I[] ids);
        IDataResult<IList<D>> DtoGetAllByName(string name);
        IDataResult<IList<D>> DtoGetAllByIsDeleted();
        IDataResult<IList<D>> DtoGetAll();
    }
}
