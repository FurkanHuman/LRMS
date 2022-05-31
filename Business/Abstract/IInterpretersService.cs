using Business.Abstract.Base;
using Core.Utilities.Result.Abstract;
using Entities.Concrete.Infos;

namespace Business.Abstract
{
    public interface IInterpretersService : IFirstPersonBaseService<Interpreters>
    {
        IDataResult<List<Interpreters>> GetByWhichToLanguageList(string langName);
    }
}
