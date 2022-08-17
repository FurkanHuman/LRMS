namespace Business.Abstract
{
    public interface IConsultantService : IFirstPersonBaseService<Consultant>
    {
        IDataResult<IList<Consultant>> GetAllByNamePreAttachment(string namePreAttachment);
    }
}
