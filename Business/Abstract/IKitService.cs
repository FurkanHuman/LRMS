namespace Business.Abstract
{
    public interface IKitService : IMaterialBaseService<Kit>
    {
        IDataResult<Kit> GetByAcademicJournal(Guid academicJournalId);
        IDataResult<IList<Kit>> GetAllByAcademicJournals(Guid[] academicJournalIds);
        IDataResult<Kit> GetByAudioRecord(Guid audioRecordId);
        IDataResult<IList<Kit>> GetAllByAudioRecords(Guid[] audioRecordIds);
        IDataResult<Kit> GetByBook(Guid bookId);
        IDataResult<IList<Kit>> GetAllByBooks(Guid[] bookIds);
        IDataResult<Kit> GetByBookSeries(Guid bookSeriesId);
        IDataResult<IList<Kit>> GetAllByBookSeries(Guid[] bookSeriesIds);
        IDataResult<Kit> GetByCartographicMaterial(Guid cartographicMaterialId);
        IDataResult<IList<Kit>> GetAllByCartographicMaterials(Guid[] cartographicMaterialIds);
        IDataResult<Kit> GetByDepiction(Guid depictionId);
        IDataResult<IList<Kit>> GetAllByDepictions(Guid[] depictionIds);
        IDataResult<Kit> GetByDissertation(Guid dissertationId);
        IDataResult<IList<Kit>> GetAllByDissertations(Guid[] dissertationIds);
        IDataResult<Kit> GetByElectronicsResource(Guid electronicsResourceId);
        IDataResult<IList<Kit>> GetAllByElectronicsResources(Guid[] electronicsResourceIds);
        IDataResult<Kit> GetByEncyclopedia(Guid encyclopediaId);
        IDataResult<IList<Kit>> GetAllByEncyclopedias(Guid[] encyclopediaIds);
        IDataResult<Kit> GetByGraphicalImage(Guid graphicalImageId);
        IDataResult<IList<Kit>> GetAllByGraphicalImages(Guid[] graphicalImageIds);
        IDataResult<IList<Kit>> GetAllByImage(Guid imageId);
        IDataResult<Kit> GetByMagazine(Guid magazineId);
        IDataResult<IList<Kit>> GetAllByMagazines(Guid[] magazineIds);
        IDataResult<Kit> GetByMicroform(Guid microformId);
        IDataResult<IList<Kit>> GetAllByMicroforms(Guid[] microformIds);
        IDataResult<Kit> GetByMusicalNote(Guid musicalNoteId);
        IDataResult<IList<Kit>> GetAllByMusicalNotes(Guid[] musicalNoteIds);
        IDataResult<Kit> GetByNewsPaper(Guid newsPaperId);
        IDataResult<IList<Kit>> GetAllByNewsPapers(Guid[] newsPaperIds);
        IDataResult<Kit> GetByObject3D(Guid object3DId);
        IDataResult<IList<Kit>> GetAllByObject3Ds(Guid[] object3DIds);
        IDataResult<Kit> GetByPainting(Guid paintingId);
        IDataResult<IList<Kit>> GetAllByPaintings(Guid[] paintingIds);
        IDataResult<Kit> GetByPoster(Guid posterId);
        IDataResult<IList<Kit>> GetAllByPosters(Guid[] posterIds);
        IDataResult<Kit> GetByThesis(Guid thesisId);
        IDataResult<IList<Kit>> GetAllByThesis(Guid[] thesisIds);
    }
}
