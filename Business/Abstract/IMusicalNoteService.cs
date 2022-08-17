namespace Business.Abstract
{
    public interface IMusicalNoteService : IMaterialBaseService<MusicalNote>
    {
        IDataResult<IList<MusicalNote>> GetAllByComposer(Guid composerId);
        IDataResult<IList<MusicalNote>> GetAllByComposers(Guid[] composerIds);
        IDataResult<IList<MusicalNote>> GetAllByDateOfWriting(DateTime dateOfWriting);
    }
}
