using Business.Abstract.Base;
using Core.Utilities.Result.Abstract;
using Entities.Concrete.Infos;

namespace Business.Abstract
{
    public interface ILibraryService : IBaseEntityService<Library>
    {
        IResult Delete(int id);
        IResult ShadowDelete(int id);
        IDataResult<Library> GetById(int id);
    }
}
