using Business.Abstract.Base;
using Core.Utilities.Result.Abstract;
using Entities.Concrete.Infos;

namespace Business.Abstract
{
    public interface IPublisherService : IBaseEntityService<Publisher>
    {
        IResult Delete(Guid id);
        IResult ShadowDelete(Guid id);
        IDataResult<Publisher> GetById(Guid id);
        IDataResult<Publisher> GetByPhoneNumber(string phoneNumber);
        IDataResult<Publisher> GetByName(string name);
        IDataResult<Publisher?> GetByFaxNumber(string faxNumber);
        IDataResult<List<Publisher>> GetByWebsitess(string webSite);
    }
}
