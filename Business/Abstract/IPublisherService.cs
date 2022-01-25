using Core.Utilities.Result.Abstract;
using Entities.Concrete.Infos;

namespace Business.Abstract
{
    public interface IPublisherService
    {
        IDataResult<Publisher> GetById(int id);
        IDataResult<Publisher> GetByPhoneNumber(ulong phoneNumber);
        IDataResult<Publisher> GetByAdress(string address);
        IDataResult<Publisher> GetByName(string name);
        IDataResult<Publisher?> GetByFaxNumber(ulong faxNumber);
        IDataResult<Publisher> GetByWebsites(string webSite);
        IDataResult<List<Publisher>> GetList();
        IResult Add(Publisher publisher);
        IResult Delete(Publisher publisher);
        IResult Update(Publisher publisher);
    }
}
