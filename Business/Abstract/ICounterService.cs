using Business.Abstract.Base;
using Entities.Concrete.Infos;

namespace Business.Abstract
{
    public interface ICounterService : IBaseEntityService<Counter, Guid>
    {
        void GetCountByAcademicJournal(Guid academicJournalId);
        void GetCountAllByAcademicJournals(Guid[] academicJournalIds);
        void GetCountByAudioRecord(Guid audioRecordId);
        void GetCountAllByAudioRecords(Guid[] audioRecordIds);
        void GetCountByBook(Guid bookId);
        void GetCountAllByBooks(Guid[] bookIds);
        void GetCountByBookSeries(Guid bookSeriesId);
        void GetCountAllByBookSeries(Guid[] bookSeriesIds);
        void GetCountByCartographicMaterial(Guid cartographicMaterialId);
        void GetCountAllByCartographicMaterials(Guid[] cartographicMaterialIds);
        void GetCountByDepiction(Guid depictionId);
        void GetCountAllByDepictions(Guid[] depictionIds);
        void GetCountByDissertation(Guid dissertationId);
        void GetCountAllByDissertations(Guid[] dissertationIds);
        void GetCountByElectronicsResource(Guid electronicsResourceId);
        void GetCountAllByElectronicsResources(Guid[] electronicsResourceIds);
        void GetCountByEncyclopedia(Guid encyclopediaId);
        void GetCountAllByEncyclopedias(Guid[] encyclopediaIds);
        void GetCountByGraphicalImage(Guid graphicalImageId);
        void GetCountAllByGraphicalImages(Guid[] graphicalImageIds);
        void GetCountByKit(Guid kitId);
        void GetCountAllByKits(Guid[] kitIds);
        void GetCountByMagazine(Guid magazineId);
        void GetCountAllByMagazines(Guid[] magazineIds);
        void GetCountByMicroform(Guid microformId);
        void GetCountAllByMicroforms(Guid[] microformIds);
        void GetCountByMusicalNote(Guid musicalNoteId);
        void GetCountAllByMusicalNotes(Guid[] musicalNoteIds);
        void GetCountByNewsPaper(Guid newsPaperId);
        void GetCountAllByNewsPapers(Guid[] newsPaperIds);
        void GetCountByObject3D(Guid object3DId);
        void GetCountAllByObject3Ds(Guid[] object3DIds);
        void GetCountByPainting(Guid paintingId);
        void GetCountAllByPaintings(Guid[] paintingIds);
        void GetCountByPoster(Guid posterId);
        void GetCountAllByPosters(Guid[] posterIds);
        void GetCountByThesis(Guid thesisId);
        void GetCountAllByThesis(Guid[] thesisIds);
    }
}
