using Business.Abstract.Base;
using Core.Utilities.Result.Abstract;
using Entities.Concrete.Infos;

namespace Business.Abstract
{
    public interface IOtherPeopleService : IFirstPersonBaseService<OtherPeople>
    {
        IDataResult<IList<OtherPeople>> GetAllByTitle(string title);
        IDataResult<IList<OtherPeople>> GetAllByNamePreAttach(string preAttch);
    }
}
