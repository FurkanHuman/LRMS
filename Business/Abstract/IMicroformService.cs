namespace Business.Abstract
{
    public interface IMicroformService : IMaterialBaseService<Microform>
    {
        IDataResult<IList<Microform>> GetAllByScale(string scale);
    }
}
