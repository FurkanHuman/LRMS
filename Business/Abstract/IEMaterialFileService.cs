using Core.Utilities.Result.Abstract;
using Entities.Concrete.Infos;
using Microsoft.AspNetCore.Http;
using System.Linq.Expressions;

namespace Business.Abstract
{
    public interface IEMaterialFileService
    {
        IResult Add(IFormFile file, EMaterialFile eMaterialFile);
        IResult Delete(Guid eMFgId);
        IResult HideFile(Guid eMFgId, bool state = true);
        IResult Update(IFormFile file, EMaterialFile eMaterialFile);
        IDataResult<EMaterialFile> GetByGuid(Guid guid);
        IDataResult<List<EMaterialFile>> GetAllByFilter(Expression<Func<EMaterialFile, bool>>? filter = null);
        IDataResult<List<EMaterialFile>> GetAll();
    }
}
