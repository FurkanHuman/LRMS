namespace Business.Abstract
{
    public interface IEncyclopediaService : IBasePaperService<Encyclopedia>
    {
        IDataResult<IList<Encyclopedia>> GetAllBySequenceNumber(uint sequenceNumber);
    }
}
