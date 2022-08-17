namespace DataAccess.Abstract
{
    public interface IWriterDal : IEntityRepository<Writer>, IDtoRepository<Writer>, IDtoRepository<Writer, WriterDto>
    {
    }
}
