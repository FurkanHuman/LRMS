using Business.Abstract.Base;
using Core.Utilities.Result.Abstract;
using Entities.Concrete.Infos;
using Microsoft.AspNetCore.Http;

namespace Business.Abstract
{
    public interface IEMaterialFileService : IBaseEntityService<EMaterialFile>
    {
        IResult Add(IFormFile file, EMaterialFile eMaterialFile);
        IResult Delete(Guid id);
        IResult ShadowDelete(Guid id);
        IResult Update(IFormFile file, EMaterialFile eMaterialFile);
        IDataResult<EMaterialFile> GetById(Guid id);
    }
}
