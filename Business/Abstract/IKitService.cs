using Business.Abstract.Base;
using Core.Utilities.Result.Abstract;
using Entities.Concrete;
using Entities.Concrete.Base;

namespace Business.Abstract
{
    public interface IKitService : IMaterialBaseService<Kit>
    {
        IDataResult<Kit> GetByAcademicJournal(Guid AcademicJournalId);
        IDataResult<List<Kit>> GetByAcademicJournals(Guid[] AcademicJournalIds);
        IDataResult<Kit> GetByAudioRecord(Guid AudioRecordId);
        IDataResult<List<Kit>> GetByAudioRecords(Guid[] AudioRecordIds);
        IDataResult<Kit> GetByBook(Guid bookId);
        IDataResult<List<Kit>> GetByBooks(Guid[] bookIds);
        IDataResult<Kit> GetByBookSeries(Guid bookSeriesId);
        IDataResult<List<Kit>> GetByBookSeries(Guid[] bookSeriesIds);
        IDataResult<Kit> GetByCartographicMaterial(Guid cartographicMaterialId);
        IDataResult<List<Kit>> GetByCartographicMaterials(Guid[] cartographicMaterialIds);
        IDataResult<Kit> GetByDepiction(Guid depictionId);
        IDataResult<List<Kit>> GetByDepictions(Guid[] depictionIds);
        IDataResult<Kit> GetByDissertation(Guid dissertationId);
        IDataResult<List<Kit>> GetByDissertations(Guid[] dissertationIds);
        IDataResult<Kit> GetByElectronicsResource(Guid electronicsResourceId);
        IDataResult<List<Kit>> GetByElectronicsResources(Guid[] electronicsResourceIds);
        IDataResult<Kit> GetByEncyclopedia(Guid encyclopediaId);
        IDataResult<List<Kit>> GetByEncyclopedias(Guid[] encyclopediaIds);
        IDataResult<Kit> GetByGraphicalImage(Guid graphicalImageId);
        IDataResult<List<Kit>> GetByGraphicalImages(Guid[] graphicalImageIds);
        IDataResult<Kit> GetByMagazine(Guid magazineId);
        IDataResult<List<Kit>> GetByMagazines(Guid[] magazineIds);
        IDataResult<Kit> GetByMicroform(Guid microformId);
        IDataResult<List<Kit>> GetByMicroforms(Guid[] microformIds);
        IDataResult<Kit> GetByMusicalNote(Guid musicalNoteId);
        IDataResult<List<Kit>> GetByMusicalNotes(Guid[] musicalNoteIds);
        IDataResult<Kit> GetByNewsPaper(Guid newsPaperId);
        IDataResult<List<Kit>> GetByNewsPapers(Guid[] newsPaperIds);
        IDataResult<Kit> GetByObject3D(Guid object3DId);
        IDataResult<List<Kit>> GetByObject3Ds(Guid[] object3DIds);
        IDataResult<Kit> GetByPainting(Guid paintingId);
        IDataResult<List<Kit>> GetByPaintings(Guid[] paintingIds);
        IDataResult<Kit> GetByPoster(Guid posterId);
        IDataResult<List<Kit>> GetByPosters(Guid[] posterIds);
        IDataResult<Kit> GetByThesis(Guid thesisId);
        IDataResult<List<Kit>> GetByThesis(Guid[] thesisIds);
    }
}
