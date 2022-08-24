namespace DataAccess.Concrete
{
    public class EfCommunicationDal : EfEntityRepositoryBase<Communication, CommunicationDto, PostgreDbContext>, ICommunicationDal
    {
    }
}
