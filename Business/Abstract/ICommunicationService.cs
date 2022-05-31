using Business.Abstract.Base;
using Core.Utilities.Result.Abstract;
using Entities.Concrete.Infos;

namespace Business.Abstract
{
    public interface ICommunicationService : IBaseEntityService<Communication>
    {
        IResult Delete(Guid id);
        IResult ShadowDelete(Guid id);
        IDataResult<Communication> GetById(Guid id);
        IDataResult<Communication> GetByPhoneNumber(string phoneNumber);
        IDataResult<Communication>? GetbyFaxNumber(string faxNumber);
        IDataResult<Communication> GetByEmail(string eMail);
        IDataResult<Communication> GetByWebSite(string webSite);
    }
}
