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
        IDataResult<List<EMaterialFile>> GetAllByIds(Guid[] ids);
        IDataResult<List<EMaterialFile>> GetAllByName(string name);
        IDataResult<List<EMaterialFile>> GetAllByFilter(Expression<Func<EMaterialFile, bool>>? filter = null);
        IDataResult<List<EMaterialFile>> GetAllBySecret();
        IDataResult<List<EMaterialFile>> GetAll();
    }
}
