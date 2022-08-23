namespace Business.Abstract.Base
{
    public interface IFirstPersonBaseDtoService<E, D, A, U> : IBaseDtoService<E, D, A, U, Guid> where E : IEntity, new()
                                                                                          where D : FirstPagePersonBaseDto, IDto, new()
                                                                                          where A : IAddDto, new()
                                                                                          where U : IUpdateDto, new()
    {

        IDataResult<IList<D>> DtoGetAllBySurname(string surname);
    }
}
