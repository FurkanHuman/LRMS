namespace Business.Abstract
{
    public interface IResearcherService : IFirstPersonBaseService<Researcher>
    {
        IDataResult<IList<Researcher>> GetAllNamePreAttachment(string namePreAttachment);
        IDataResult<IList<Researcher>> GetAllSpecialty(string Specialty);
    }
}
