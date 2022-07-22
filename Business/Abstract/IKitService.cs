using Business.Abstract.Base;
using Core.Utilities.Result.Abstract;
using Entities.Concrete;

namespace Business.Abstract
{
    public interface IKitService : IMaterialBaseService<Kit>
    {
        IDataResult<Kit> GetByAcademicJournal(Guid academicJournalId);
        IDataResult<List<Kit>> GetAllByAcademicJournals(Guid[] academicJournalIds);
        IDataResult<Kit> GetByAudioRecord(Guid audioRecordId);
        IDataResult<List<Kit>> GetAllByAudioRecords(Guid[] audioRecordIds);
        IDataResult<Kit> GetByBook(Guid bookId);
        IDataResult<List<Kit>> GetAllByBooks(Guid[] bookIds);
        IDataResult<Kit> GetByBookSeries(Guid bookSeriesId);
        IDataResult<List<Kit>> GetAllByBookSeries(Guid[] bookSeriesIds);
        IDataResult<Kit> GetByCartographicMaterial(Guid cartographicMaterialId);
        IDataResult<List<Kit>> GetAllByCartographicMaterials(Guid[] cartographicMaterialIds);
        IDataResult<Kit> GetByDepiction(Guid depictionId);
        IDataResult<List<Kit>> GetAllByDepictions(Guid[] depictionIds);
        IDataResult<Kit> GetByDissertation(Guid dissertationId);
        IDataResult<List<Kit>> GetAllByDissertations(Guid[] dissertationIds);
        IDataResult<Kit> GetByElectronicsResource(Guid electronicsResourceId);
        IDataResult<List<Kit>> GetAllByElectronicsResources(Guid[] electronicsResourceIds);
        IDataResult<Kit> GetByEncyclopedia(Guid encyclopediaId);
        IDataResult<List<Kit>> GetAllByEncyclopedias(Guid[] encyclopediaIds);
        IDataResult<Kit> GetByGraphicalImage(Guid graphicalImageId);
        IDataResult<List<Kit>> GetAllByGraphicalImages(Guid[] graphicalImageIds);
        IDataResult<List<Kit>> GetAllByImage(Guid imageId);
        IDataResult<Kit> GetByMagazine(Guid magazineId);
        IDataResult<List<Kit>> GetAllByMagazines(Guid[] magazineIds);
        IDataResult<Kit> GetByMicroform(Guid microformId);
        IDataResult<List<Kit>> GetAllByMicroforms(Guid[] microformIds);
        IDataResult<Kit> GetByMusicalNote(Guid musicalNoteId);
        IDataResult<List<Kit>> GetAllByMusicalNotes(Guid[] musicalNoteIds);
        IDataResult<Kit> GetByNewsPaper(Guid newsPaperId);
        IDataResult<List<Kit>> GetAllByNewsPapers(Guid[] newsPaperIds);
        IDataResult<Kit> GetByObject3D(Guid object3DId);
        IDataResult<List<Kit>> GetAllByObject3Ds(Guid[] object3DIds);
        IDataResult<Kit> GetByPainting(Guid paintingId);
        IDataResult<List<Kit>> GetAllByPaintings(Guid[] paintingIds);
        IDataResult<Kit> GetByPoster(Guid posterId);
        IDataResult<List<Kit>> GetAllByPosters(Guid[] posterIds);
        IDataResult<Kit> GetByThesis(Guid thesisId);
        IDataResult<List<Kit>> GetAllByThesis(Guid[] thesisIds);
    }
}
