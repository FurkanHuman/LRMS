using Business.Abstract.Base;
using Core.Utilities.Result.Abstract;
using Entities.Concrete.Infos;

namespace Business.Abstract
{
    public interface IOtherPeopleService : IFirstPersonBaseService<OtherPeople>
    {
        IDataResult<List<OtherPeople>> GetAllByTitle(string title);
        IDataResult<List<OtherPeople>> GetAllByNamePreAttach(string preAttch);
    }
}
