using Business.Abstract.Base;
using Core.Utilities.Result.Abstract;
using Entities.Concrete;

namespace Business.Abstract
{
    public interface IMusicalNoteService : IMaterialBaseService<MusicalNote>
    {
        IDataResult<List<MusicalNote>> GetAllByComposer(Guid composerId);
        IDataResult<List<MusicalNote>> GetAllByComposers(Guid[] composerIds);
        IDataResult<List<MusicalNote>> GetAllByDateOfWriting(DateTime dateOfWriting);
    }
}
