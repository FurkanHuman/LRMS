using Business.Abstract.Base;
using Core.Utilities.Result.Abstract;
using Entities.Concrete.Infos;

namespace Business.Abstract
{
    public interface IEditionService : IBaseEntityService<Edition>
    {
        IResult Delete(Guid id);
        IResult ShadowDelete(Guid id);
        IDataResult<Edition> GetById(Guid id);
        IDataResult<Edition> GetByPhoneNumber(string phoneNumber);
        IDataResult<List<Edition>> GetByEditionNumber(int editionNumber);
        IDataResult<Edition?> GetByFaxNumber(string faxNumber);
        IDataResult<List<Edition>> GetByWebsites(string webSite);
    }
}
