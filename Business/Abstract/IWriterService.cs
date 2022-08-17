namespace Business.Abstract
{
    public interface IWriterService : IFirstPersonBaseService<Writer>, IFirstPersonBaseDtoService<WriterDto>
    {
        IDataResult<IList<Writer>> GetAllNamePreAttachment(string namePreAttachment);
        IDataResult<IList<WriterDto>> DtoGetAllNamePreAttachment(string namePreAttachment);
    }
}
