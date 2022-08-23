namespace Business.Abstract.Base
{
    public interface IBasePaperDtoService<E, D, A, U> : IMaterialBaseDtoService<E, D, A, U> where E : IEntity, new()
                                                                                            where D : BasePaperDto, IDto, new()
                                                                                            where A : IAddDto, new()
                                                                                            where U : IUpdateDto, new()

    {
        IDataResult<D> DtoGetByCoverImage(Guid CImageId);
        IDataResult<IList<D>> DtoGetAllByWriter(Guid writerId);
        IDataResult<IList<D>> DtoGetAllByEditor(Guid editorId);
        IDataResult<IList<D>> DtoGetAllByDirector(Guid directorId);
        IDataResult<IList<D>> DtoGetAllByGraphicDirector(Guid graphicDirectorId);
        IDataResult<IList<D>> DtoGetAllByGraphicDesign(Guid graphicDesignId);
        IDataResult<IList<D>> DtoGetAllByRedaction(Guid redactionId);
        IDataResult<IList<D>> DtoGetAllByInterpreter(Guid InterpreterId);
        IDataResult<IList<D>> DtoGetAllByTechnicalNumber(Guid technicalNumberId);
        IDataResult<IList<D>> DtoGetAllByCommunication(Guid communicationId);
        IDataResult<IList<D>> DtoGetAllByEdition(Guid editionNum);
        IDataResult<IList<D>> DtoGetAllByPublisher(Guid publisherNum);
        IDataResult<IList<D>> DtoGetAllByCoverCap(int CoverCapNum);
    }
}
