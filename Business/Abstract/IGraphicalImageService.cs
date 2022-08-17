namespace Business.Abstract
{
    public interface IGraphicalImageService : IMaterialBaseService<GraphicalImage>
    {
        IDataResult<GraphicalImage> GetByImage(Guid imageId);
        IDataResult<IList<GraphicalImage>> GetAllByImageCreatedDate(DateTime dateTime);
        IDataResult<IList<GraphicalImage>> GetAllByOtherPeople(Guid otherPeopleId);
    }
}
