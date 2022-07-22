using Business.Abstract.Base;
using Core.Utilities.Result.Abstract;
using Entities.Concrete;

namespace Business.Abstract
{
    public interface IAcademicJournalService : IMaterialBaseService<AcademicJournal>
    {
        IDataResult<List<AcademicJournal>> GetAllByAJNumber(ushort aJNumber);
        IDataResult<List<AcademicJournal>> GetAllByDateOfYear(ushort dateOfYear);
        IDataResult<List<AcademicJournal>> GetAllByVolume(ushort volume);
        IDataResult<List<AcademicJournal>> GetAllByPageRange(ushort startPage, ushort endPage);
        IDataResult<List<AcademicJournal>> GetAllByEditor(Guid editorId);
        IDataResult<List<AcademicJournal>> GetAllByEditors(Guid[] editorIds);
        IDataResult<List<AcademicJournal>> GetAllByReferenceId(Guid referenceId);
        IDataResult<List<AcademicJournal>> GetAllByReferenceOwner(string owner);
        IDataResult<List<AcademicJournal>> GetAllByReferenceDate(DateTime referenceDate);
        IDataResult<List<AcademicJournal>> GetAllByResearcher(Guid researcherId);
        IDataResult<List<AcademicJournal>> GetAllByResearchers(Guid[] researcherIds);
        IDataResult<List<AcademicJournal>> GetAllByPublisher(Guid publisherId);
        IDataResult<List<AcademicJournal>> GetAllByPublisherDateOfPublication(DateTime DateOfPublication);
    }
}
