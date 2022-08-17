namespace Business.Abstract
{
    public interface IOtherPeopleService : IFirstPersonBaseService<OtherPeople>
    {
        IDataResult<IList<OtherPeople>> GetAllByTitle(string title);
        IDataResult<IList<OtherPeople>> GetAllByNamePreAttach(string preAttch);
    }
}
