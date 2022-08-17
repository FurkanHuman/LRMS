namespace Business.Abstract
{
    public interface IComposerService : IFirstPersonBaseService<Composer>
    {
        IDataResult<IList<Composer>> GetAllByNamePreAttachment(string namePreAttachment);
    }
}
