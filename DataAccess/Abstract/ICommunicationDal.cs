namespace DataAccess.Abstract
{
    public interface ICommunicationDal : IEntityRepository<Communication>, IDtoRepository<Communication, CommunicationDto>
    {
    }
}
