namespace Business.Abstract.Base
{
    public interface IFirstPersonBaseDtoService<E, D> : IBaseDtoService<E, D, Guid> where E : IEntity, new()
                                                                                    where D : FirstPagePersonBaseDto, IDto, new()
    {
        IDataResult<IList<D>> DtoGetAllBySurname(string surname);
    }
}
