namespace Business.Abstract.Base
{
    public interface IBaseDtoService<E, D, A, U, I> where E : IEntity, new()
                                                    where D : IDto, new()
                                                    where A : IAddDto, new()
                                                    where U : IUpdateDto, new()
                                                    where I : struct
    {
        IDataResult<A> DtoAdd(A addDto);
        IDataResult<U> DtoUpdate(U updateDto);
        IDataResult<D> DtoGetById(I id);
        IDataResult<IList<D>> DtoGetAllByIds(I[] ids);
        IDataResult<IList<D>> DtoGetAllByName(string name);
        IDataResult<IList<D>> DtoGetAllByFilter(Expression<Func<E, bool>>? filter = null);
        IDataResult<IList<D>> DtoGetAllByIsDeleted();
        IDataResult<IList<D>> DtoGetAll();
    }
}
