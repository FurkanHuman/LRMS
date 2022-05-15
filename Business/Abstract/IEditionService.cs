using Core.Utilities.Result.Abstract;
using Entities.Concrete.Infos;

namespace Business.Abstract
{
    public interface IEditionService
    {
        IDataResult<Edition> GetById(Guid id);
        IDataResult<Edition> GetByPhoneNumber(string phoneNumber);
        IDataResult<Edition> GetByName(string name);
        IDataResult<List<Edition>> GetByEditionNumber(int editionNumber);
        IDataResult<Edition?> GetByFaxNumber(string faxNumber);
        IDataResult<List<Edition>> GetByWebsites(string webSite);
        IDataResult<List<Edition>> GetList();
        IResult Add(Edition edition);
        IResult Delete(Edition edition);
        IResult Update(Edition edition);
    }
}
