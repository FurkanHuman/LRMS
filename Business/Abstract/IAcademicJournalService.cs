using Business.Abstract.Base;
using Core.Utilities.Result.Abstract;
using Entities.Concrete;

namespace Business.Abstract
{
    public interface IAcademicJournalService : IMaterialBaseService<AcademicJournal>
    {
        IDataResult<List<AcademicJournal>> GetByResearcher(Guid researcherId);
        IDataResult<List<AcademicJournal>> GetByResearcherLists(Guid[] researcherIds);

        IDataResult<List<AcademicJournal>> GetByEditor(Guid id);
        IDataResult<List<AcademicJournal>> GetByEditorLists(Guid[] id);
    }
}
