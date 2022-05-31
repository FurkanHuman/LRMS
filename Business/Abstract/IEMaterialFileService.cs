using Core.Utilities.Result.Abstract;
using Entities.Concrete.Infos;
using Microsoft.AspNetCore.Http;
using System.Linq.Expressions;

namespace Business.Abstract
{
    public interface IEMaterialFileService
    {
        IResult Add(IFormFile file, EMaterialFile eMaterialFile);
        IResult Delete(Guid id);
        IResult ShadowDelete(Guid id);
        IResult Update(IFormFile file, EMaterialFile eMaterialFile);
        IDataResult<EMaterialFile> GetById(Guid id);
        IDataResult<List<EMaterialFile>> GetByNames(string name);
        IDataResult<List<EMaterialFile>> GetByFilterLists(Expression<Func<EMaterialFile, bool>>? filter = null);
        IDataResult<List<EMaterialFile>> GetAll();
        IDataResult<List<EMaterialFile>> GetAllBySecrets();
    }
}
