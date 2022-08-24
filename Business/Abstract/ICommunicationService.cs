namespace Business.Abstract
{
    public interface ICommunicationService : IBaseEntityService<Communication, Guid>, IBaseDtoService<Communication, CommunicationDto, CommunicationAddDto, CommunicationUpdateDto, Guid>
    {
        IDataResult<Communication> GetByPhoneNumber(string phoneNumber);
        IDataResult<CommunicationDto> DtoGetByPhoneNumber(string phoneNumber);
        IDataResult<Communication> GetByFaxNumber(string faxNumber); 
        IDataResult<CommunicationDto> DtoGetByFaxNumber(string faxNumber);
        IDataResult<Communication> GetByEmail(string eMail);
        IDataResult<CommunicationDto> DtoGetByEmail(string eMail);
        IDataResult<Communication> GetByWebSite(string webSite);
        IDataResult<CommunicationDto> DtoGetByWebSite(string webSite);
    }
}
