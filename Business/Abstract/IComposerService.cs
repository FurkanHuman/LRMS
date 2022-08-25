namespace Business.Abstract
{
    public interface IComposerService : IFirstPersonBaseService<Composer>, IFirstPersonBaseDtoService<Composer, ComposerDto, ComposerAddDto, ComposerUpdateDto>
    {
        IDataResult<IList<Composer>> GetAllByNamePreAttachment(string namePreAttachment);
        IDataResult<IList<ComposerDto>> DtoGetAllByNamePreAttachment(string namePreAttachment);
    }
}
