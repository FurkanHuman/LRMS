using Business.Abstract.Base;
using Core.Utilities.Result.Abstract;
using Entities.Concrete.Infos;

namespace Business.Abstract
{
    public interface IOtherPeopleService : IFirstPersonBaseService<OtherPeople>
    {
        IDataResult<List<OtherPeople>> GetByTitles(string title);
        IDataResult<List<OtherPeople>> GetByNamePreAttch(string preAttch);
    }
}
