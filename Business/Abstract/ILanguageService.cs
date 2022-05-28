using Business.Abstract.Base;
using Core.Utilities.Result.Abstract;
using Entities.Concrete.Infos;

namespace Business.Abstract
{
    public interface ILanguageService : IBaseEntityService<Language>
    {
        IResult Delete(int id);
        IResult ShadowDelete(int id);
        IDataResult<Language> GetById(int id);
    }
}
