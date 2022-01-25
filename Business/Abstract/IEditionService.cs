using Core.Utilities.Result.Abstract;
using Entities.Concrete.Infos;

namespace Business.Abstract
{
    public interface IEditionService
    {
        IDataResult<Edition> GetById(int id);
        IDataResult<Edition> GetByPhoneNumber(ulong phoneNumber);
        IDataResult<Edition> GetByAdress(string address);
        IDataResult<Edition> GetByName(string name);
        IDataResult<Edition> GetByEditionNumber(int editionNumber);
        IDataResult<Edition?> GetByFaxNumber(ulong faxNumber);
        IDataResult<Edition> GetByWebsites(string webSite);
        IDataResult<List<Edition>> GetList();
        IResult Add(Edition Edition);
        IResult Delete(Edition Edition);
        IResult Update(Edition Edition);
    }
}
