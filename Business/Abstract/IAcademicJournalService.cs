namespace Business.Abstract
{
    public interface IAcademicJournalService : IMaterialBaseService<AcademicJournal>
    {
        IDataResult<IList<AcademicJournal>> GetAllByAJNumber(ushort aJNumber);
        IDataResult<IList<AcademicJournal>> GetAllByDateOfYear(ushort dateOfYear);
        IDataResult<IList<AcademicJournal>> GetAllByVolume(ushort volume);
        IDataResult<IList<AcademicJournal>> GetAllByPageRange(ushort startPage, ushort endPage);
        IDataResult<IList<AcademicJournal>> GetAllByEditor(Guid editorId);
        IDataResult<IList<AcademicJournal>> GetAllByEditors(Guid[] editorIds);
        IDataResult<IList<AcademicJournal>> GetAllByReferenceId(Guid referenceId);
        IDataResult<IList<AcademicJournal>> GetAllByReferenceOwnerId(Guid[] ids);
        IDataResult<IList<AcademicJournal>> GetAllByReferenceDate(DateTime referenceDate);
        IDataResult<IList<AcademicJournal>> GetAllByResearcher(Guid researcherId);
        IDataResult<IList<AcademicJournal>> GetAllByResearchers(Guid[] researcherIds);
        IDataResult<IList<AcademicJournal>> GetAllByPublisher(Guid publisherId);
        IDataResult<IList<AcademicJournal>> GetAllByPublisherDateOfPublication(DateTime DateOfPublication);
    }
}
