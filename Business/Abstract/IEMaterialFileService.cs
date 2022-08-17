using Microsoft.AspNetCore.Http;

namespace Business.Abstract
{
    public interface IEMaterialFileService
    {
        IResult Add(IFormFile file, EMaterialFile eMaterialFile);
        IResult Delete(Guid id);
        IResult ShadowDelete(Guid id);
        IResult Update(IFormFile file, EMaterialFile eMaterialFile);
        IDataResult<EMaterialFile> GetById(Guid id);
        IDataResult<IList<EMaterialFile>> GetAllByIds(Guid[] ids);
        IDataResult<IList<EMaterialFile>> GetAllByName(string name);
        IDataResult<IList<EMaterialFile>> GetAllByFilter(Expression<Func<EMaterialFile, bool>>? filter = null);
        IDataResult<IList<EMaterialFile>> GetAllByIsDeleted();
        IDataResult<IList<EMaterialFile>> GetAll();
    }
}
