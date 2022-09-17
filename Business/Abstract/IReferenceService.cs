namespace Business.Abstract
{
    public interface IReferenceService : IBaseEntityService<Reference, Guid>
    {
        IDataResult<IList<Reference>> GetAllByOwnerId(Guid[] ids);
        IDataResult<IList<Reference>> GetAllByReferenceDate(DateTime date);
        IDataResult<IList<Reference>> GetAllBySubText(string subText);
    }
}
