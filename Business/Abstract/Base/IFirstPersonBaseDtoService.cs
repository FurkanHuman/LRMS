namespace Business.Abstract.Base
{
    public interface IFirstPersonBaseDtoService<D> : IBaseDtoService<D, Guid> where D : FirstPagePersonBaseDto, IDto, new()
    {
        IDataResult<IList<D>> DtoGetAllBySurname(string surname);
    }
}
