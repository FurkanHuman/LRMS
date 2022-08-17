namespace Business.Abstract
{
    public interface IElectronicsResourceService : IMaterialBaseService<ElectronicsResource>
    {
        IDataResult<IList<ElectronicsResource>> GetAllByResourceUrlFinderString(string finderStr);
    }
}
