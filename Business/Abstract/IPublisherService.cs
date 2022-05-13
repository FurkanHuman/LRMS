using Core.Utilities.Result.Abstract;
using Entities.Concrete.Infos;

namespace Business.Abstract
{
    public interface IPublisherService
    {
        IDataResult<Publisher> GetById(int id);
        IDataResult<Publisher> GetByPhoneNumber(string phoneNumber);
        IDataResult<Publisher> GetByName(string name);
        IDataResult<Publisher?> GetByFaxNumber(string faxNumber);
        IDataResult<List<Publisher>> GetByWebsitess(string webSite);
        IDataResult<List<Publisher>> GetList();
        IResult Add(Publisher publisher);
        IResult Delete(Publisher publisher);
        IResult Update(Publisher publisher);
    }
}
