namespace Business.Abstract
{
    public interface ICommunicationService : IBaseEntityService<Communication, Guid>
    {
        IDataResult<Communication> GetByPhoneNumber(string phoneNumber);
        IDataResult<Communication> GetByFaxNumber(string faxNumber);
        IDataResult<Communication> GetByEmail(string eMail);
        IDataResult<Communication> GetByWebSite(string webSite);
    }
}
