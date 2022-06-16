using Business.Abstract.Base;
using Core.Utilities.Result.Abstract;
using Entities.Concrete;

namespace Business.Abstract
{
    public interface IAcademicJournalService : IMaterialBaseService<AcademicJournal>
    {
        IDataResult<List<AcademicJournal>> GetByAJNumber(ushort aJNumber);
        IDataResult<List<AcademicJournal>> GetByDateOfYear(ushort dateOfYear);
        IDataResult<List<AcademicJournal>> GetByVolume(ushort volume);
        IDataResult<List<AcademicJournal>> GetByPageRange(ushort startPage, ushort endPage);
        IDataResult<List<AcademicJournal>> GetByEditor(Guid editorId);
        IDataResult<List<AcademicJournal>> GetByEditor(Guid[] editorIds);
        IDataResult<List<AcademicJournal>> GetByReferenceId(Guid referenceId);
        IDataResult<List<AcademicJournal>> GetByReferenceOwner(string owner);
        IDataResult<List<AcademicJournal>> GetByReferenceDate(DateTime referenceDate);
        IDataResult<List<AcademicJournal>> GetByResearcher(Guid researcherId);
        IDataResult<List<AcademicJournal>> GetByResearcher(Guid[] researcherIds);
        IDataResult<List<AcademicJournal>> GetByPublisher(Guid publisherId);
        IDataResult<List<AcademicJournal>> GetByPublisherDateOfPublication(DateTime DateOfPublication);
    }
}
