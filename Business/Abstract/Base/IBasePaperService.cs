namespace Business.Abstract.Base
{
    public interface IBasePaperService<T> : IMaterialBaseService<T> where T : BasePaper, IEntity, new()
    {
        IDataResult<T> GetByCoverImage(Guid cImageId);
        IDataResult<IList<T>> GetAllByCoverCap(byte coverCapNum);
        IDataResult<IList<T>> GetAllByCommunication(Guid communicationId);
        IDataResult<IList<T>> GetAllByDirector(Guid directorId);
        IDataResult<IList<T>> GetAllByEditor(Guid editorId);
        IDataResult<IList<T>> GetAllByEdition(Guid editionId);
        IDataResult<IList<T>> GetAllByGraphicDirector(Guid graphicDirectorId);
        IDataResult<IList<T>> GetAllByGraphicDesign(Guid graphicDesignId);
        IDataResult<IList<T>> GetAllByInterpreter(Guid interpreterId);
        IDataResult<IList<T>> GetAllByPublisher(Guid publisherId);
        IDataResult<IList<T>> GetAllByTechnicalNumber(Guid technicalNumberId);
        IDataResult<IList<T>> GetAllByRedaction(Guid redactionId);
        IDataResult<IList<T>> GetAllByWriter(Guid writerId);
    }
}
