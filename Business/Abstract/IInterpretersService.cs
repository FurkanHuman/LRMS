namespace Business.Abstract
{
    public interface IInterpretersService : IFirstPersonBaseService<Interpreters>
    {
        IDataResult<IList<Interpreters>> GetAllByWhichToLanguage(string langName);
    }
}
