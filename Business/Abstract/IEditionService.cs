using Core.Utilities.Result.Abstract;
using Entities.Concrete.Infos;

namespace Business.Abstract
{
    public interface IEditionService
    {
        IDataResult<Edition> GetById(int id);
        IDataResult<Edition> GetByPhoneNumber(ulong phoneNumber);
        IDataResult<List<Edition>> GetByAdress(string address);
        IDataResult<Edition> GetByName(string name);
        IDataResult<List<Edition>> GetByEditionNumber(int editionNumber);
        IDataResult<Edition?> GetByFaxNumber(ulong faxNumber);
        IDataResult<List<Edition>> GetByWebsites(string webSite);
        IDataResult<List<Edition>> GetList();
        IResult Add(Edition  edition);
        IResult Delete(Edition edition);
        IResult Update(Edition oldEdition, Edition newEdition);
    }
}
