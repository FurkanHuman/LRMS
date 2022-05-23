using Core.Utilities.Result.Abstract;
using Entities.Concrete.Infos;
using System.Linq.Expressions;

namespace Business.Abstract
{
    public interface ICommunicationService
    {
        IResult Add(Communication communication);
        IResult Delete(Guid gId);
        IResult ShadowDelete(Guid gId);
        IResult Update(Communication communication);
        IDataResult<Communication> Get(Guid gId);
        IDataResult<List<Communication>> GetByCName(string CName);
        IDataResult<Communication> GetByAddressGId(Guid addressgId);
        IDataResult<Communication> GetByPhoneNumber(string phoneNumber);
        IDataResult<Communication>? GetbyFaxNumber(string faxNumber);
        IDataResult<Communication> GetByEmail(string eMail);
        IDataResult<Communication> GetByWebSite(string webSite);
        IDataResult<List<Communication>> GetAllByFilterLists(Expression<Func<Communication, bool>>? filter = null);
        IDataResult<List<Communication>> GetAll();
    }
}
