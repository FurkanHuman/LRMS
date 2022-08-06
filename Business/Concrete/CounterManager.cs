using Business.Abstract;
using Business.Constants;
using Business.DependencyResolvers.Facade;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Result.Abstract;
using Core.Utilities.Result.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Concrete.Infos;
using System.Linq.Expressions;

namespace Business.Concrete
{
    public class CounterManager : ICounterService
    {
        private readonly ICounterDal _counterDal;
        private readonly IFacadeService _facadeService;

        public CounterManager(ICounterDal counterDal, IFacadeService facadeService)
        {
            _counterDal = counterDal;
            _facadeService = facadeService;
        }

        [ValidationAspect(typeof(CounterValidator), Priority = 1)]
        public IResult Add(Counter counter)
        {
            counter.IsDeleted = false;
            _counterDal.Add(counter);
            return new SuccessResult(CounterConstants.AddSuccess);
        }

        public IResult Delete(Guid id)
        {
            Counter counter = _counterDal.Get(c => c.Id == id);
            if (counter == null)
                return new ErrorResult(CounterConstants.NotMatch);

            _counterDal.Delete(counter);
            return new SuccessResult(CounterConstants.DeleteSuccess);
        }

        public IResult ShadowDelete(Guid id)
        {
            Counter counter = _counterDal.Get(c => c.Id == id && !c.IsDeleted);
            if (counter == null)
                return new ErrorResult(CounterConstants.NotMatch);

            counter.IsDeleted = true;
            _counterDal.Update(counter);
            return new SuccessResult(CounterConstants.EfDeletedSuccsess);
        }

        [ValidationAspect(typeof(CounterValidator), Priority = 1)]
        public IResult Update(Counter counter)
        {
            counter.IsDeleted = true;
            _counterDal.Update(counter);
            return new SuccessResult(CounterConstants.EfDeletedSuccsess);
        }

        public IDataResult<IList<Counter>> GetAll()
        {
            return new SuccessDataResult<IList<Counter>>(_counterDal.GetAll(c => !c.IsDeleted), CounterConstants.DataGet);
        }

        public IDataResult<IList<Counter>> GetAllByFilter(Expression<Func<Counter, bool>>? filter = null)
        {
            return new SuccessDataResult<IList<Counter>>(_counterDal.GetAll(filter), CounterConstants.DataGet);
        }

        public IDataResult<IList<Counter>> GetAllByIds(Guid[] ids)
        {
            IList<Counter> counters = _counterDal.GetAll(c => ids.Contains(c.Id) && !c.IsDeleted);

            return counters == null
                ? new ErrorDataResult<IList<Counter>>(CounterConstants.NotMatch)
                : new SuccessDataResult<IList<Counter>>(counters, CounterConstants.DataGet);
        }

        public IDataResult<IList<Counter>> GetAllByIsDeleted()
        {
            return new SuccessDataResult<IList<Counter>>(_counterDal.GetAll(c => c.IsDeleted), CounterConstants.DataGet);
        }

        public IDataResult<IList<Counter>> GetAllByName(string name)
        {
            return new ErrorDataResult<IList<Counter>>(CounterConstants.Disabled);
        }

        public IDataResult<Counter> GetById(Guid id)
        {
            Counter counter = _counterDal.Get(c => c.Id == id);

            return counter == null
                ? new ErrorDataResult<Counter>(CounterConstants.NotMatch)
                : new SuccessDataResult<Counter>(counter, CounterConstants.DataGet);
        }

        public void GetCountByAcademicJournal(Guid academicJournalId)
        {
            var countObj = _facadeService.AcademicJournalService().GetById(academicJournalId);
            if (!countObj.Success)
                return;
            CountPlus(countObj.Data.Id);
        }

        public void GetCountAllByAcademicJournals(Guid[] academicJournalIds)
        {
            IDataResult<IList<AcademicJournal>> countObjs = _facadeService.AcademicJournalService().GetAllByIds(academicJournalIds);
            if (!countObjs.Success)
                return;

            IList<Guid> guidList = countObjs.Data.Select(g => g.Id).ToList();

            CountPlusAll(guidList);
        }

        public void GetCountByAudioRecord(Guid audioRecordId)
        {
            IDataResult<AudioRecord> countObj = _facadeService.AudioRecordService().GetById(audioRecordId);
            if (!countObj.Success)
                return;
            CountPlus(countObj.Data.Id);
        }

        public void GetCountAllByAudioRecords(Guid[] audioRecordIds)
        {
            IDataResult<IList<AudioRecord>> countObjs = _facadeService.AudioRecordService().GetAllByIds(audioRecordIds);
            if (!countObjs.Success)
                return;

            IList<Guid> guidList = countObjs.Data.Select(g => g.Id).ToList();

            CountPlusAll(guidList);
        }

        public void GetCountByBook(Guid bookId)
        {
            IDataResult<Book> countObj = _facadeService.BookService().GetById(bookId);
            if (!countObj.Success)
                return;
            CountPlus(countObj.Data.Id);
        }

        public void GetCountAllByBooks(Guid[] bookIds)
        {
            IDataResult<IList<Book>> countObjs = _facadeService.BookService().GetAllByIds(bookIds);
            if (!countObjs.Success)
                return;

            IList<Guid> guidList = countObjs.Data.Select(g => g.Id).ToList();

            CountPlusAll(guidList);
        }

        public void GetCountByBookSeries(Guid bookSeriesId)
        {
            IDataResult<BookSeries> countObj = _facadeService.BookSeriesService().GetById(bookSeriesId);
            if (!countObj.Success)
                return;
            CountPlus(countObj.Data.Id);
        }

        public void GetCountAllByBookSeries(Guid[] bookSeriesIds)
        {
            IDataResult<IList<BookSeries>> countObjs = _facadeService.BookSeriesService().GetAllByIds(bookSeriesIds);
            if (!countObjs.Success)
                return;

            IList<Guid> guidList = countObjs.Data.Select(g => g.Id).ToList();

            CountPlusAll(guidList);
        }

        public void GetCountByCartographicMaterial(Guid cartographicMaterialId)
        {
            IDataResult<CartographicMaterial> countObj = _facadeService.CartographicMaterialService().GetById(cartographicMaterialId);
            if (!countObj.Success)
                return;
            CountPlus(countObj.Data.Id);
        }

        public void GetCountAllByCartographicMaterials(Guid[] cartographicMaterialIds)
        {
            IDataResult<IList<CartographicMaterial>> countObjs = _facadeService.CartographicMaterialService().GetAllByIds(cartographicMaterialIds);
            if (!countObjs.Success)
                return;

            IList<Guid> guidList = countObjs.Data.Select(g => g.Id).ToList();

            CountPlusAll(guidList);
        }

        public void GetCountByDepiction(Guid depictionId)
        {
            IDataResult<Depiction> countObj = _facadeService.DepictionService().GetById(depictionId);
            if (!countObj.Success)
                return;
            CountPlus(countObj.Data.Id);
        }

        public void GetCountAllByDepictions(Guid[] depictionIds)
        {
            IDataResult<IList<Depiction>> countObjs = _facadeService.DepictionService().GetAllByIds(depictionIds);
            if (!countObjs.Success)
                return;

            IList<Guid> guidList = countObjs.Data.Select(g => g.Id).ToList();

            CountPlusAll(guidList);
        }

        public void GetCountByDissertation(Guid dissertationId)
        {
            IDataResult<Dissertation> countObj = _facadeService.DissertationService().GetById(dissertationId);
            if (!countObj.Success)
                return;
            CountPlus(countObj.Data.Id);
        }

        public void GetCountAllByDissertations(Guid[] dissertationIds)
        {
            IDataResult<IList<Dissertation>> countObjs = _facadeService.DissertationService().GetAllByIds(dissertationIds);
            if (!countObjs.Success)
                return;

            IList<Guid> guidList = countObjs.Data.Select(g => g.Id).ToList();

            CountPlusAll(guidList);
        }

        public void GetCountByElectronicsResource(Guid electronicsResourceId)
        {
            IDataResult<ElectronicsResource> countObj = _facadeService.ElectronicsResourceService().GetById(electronicsResourceId);
            if (!countObj.Success)
                return;
            CountPlus(countObj.Data.Id);
        }

        public void GetCountAllByElectronicsResources(Guid[] electronicsResourceIds)
        {
            IDataResult<IList<ElectronicsResource>> countObjs = _facadeService.ElectronicsResourceService().GetAllByIds(electronicsResourceIds);
            if (!countObjs.Success)
                return;

            IList<Guid> guidList = countObjs.Data.Select(g => g.Id).ToList();

            CountPlusAll(guidList);
        }

        public void GetCountByEncyclopedia(Guid encyclopediaId)
        {
            IDataResult<Encyclopedia> countObj = _facadeService.EncyclopediaService().GetById(encyclopediaId);
            if (!countObj.Success)
                return;
            CountPlus(countObj.Data.Id);
        }

        public void GetCountAllByEncyclopedias(Guid[] encyclopediaIds)
        {
            IDataResult<IList<Encyclopedia>> countObjs = _facadeService.EncyclopediaService().GetAllByIds(encyclopediaIds);
            if (!countObjs.Success)
                return;

            IList<Guid> guidList = countObjs.Data.Select(g => g.Id).ToList();

            CountPlusAll(guidList);
        }

        public void GetCountByGraphicalImage(Guid graphicalImageId)
        {
            IDataResult<GraphicalImage> countObj = _facadeService.GraphicalImageService().GetById(graphicalImageId);
            if (!countObj.Success)
                return;
            CountPlus(countObj.Data.Id);
        }

        public void GetCountAllByGraphicalImages(Guid[] graphicalImageIds)
        {
            IDataResult<IList<GraphicalImage>> countObjs = _facadeService.GraphicalImageService().GetAllByIds(graphicalImageIds);
            if (!countObjs.Success)
                return;

            IList<Guid> guidList = countObjs.Data.Select(g => g.Id).ToList();

            CountPlusAll(guidList);
        }

        public void GetCountByKit(Guid kitId)
        {
            IDataResult<Kit> countObj = _facadeService.KitService().GetById(kitId);
            if (!countObj.Success)
                return;
            CountPlus(countObj.Data.Id);
        }

        public void GetCountAllByKits(Guid[] kitIds)
        {
            IDataResult<IList<Kit>> countObjs = _facadeService.KitService().GetAllByIds(kitIds);
            if (!countObjs.Success)
                return;

            IList<Guid> guidList = countObjs.Data.Select(g => g.Id).ToList();

            CountPlusAll(guidList);
        }

        public void GetCountByMagazine(Guid magazineId)
        {
            IDataResult<Magazine> countObj = _facadeService.MagazineService().GetById(magazineId);
            if (!countObj.Success)
                return;
            CountPlus(countObj.Data.Id);
        }

        public void GetCountAllByMagazines(Guid[] magazineIds)
        {
            IDataResult<IList<Magazine>> countObjs = _facadeService.MagazineService().GetAllByIds(magazineIds);
            if (!countObjs.Success)
                return;

            IList<Guid> guidList = countObjs.Data.Select(g => g.Id).ToList();

            CountPlusAll(guidList);
        }

        public void GetCountByMicroform(Guid microformId)
        {
            IDataResult<Microform> countObj = _facadeService.MicroformService().GetById(microformId);
            if (!countObj.Success)
                return;
            CountPlus(countObj.Data.Id);
        }

        public void GetCountAllByMicroforms(Guid[] microformIds)
        {
            IDataResult<IList<Microform>> countObjs = _facadeService.MicroformService().GetAllByIds(microformIds);
            if (!countObjs.Success)
                return;

            IList<Guid> guidList = countObjs.Data.Select(g => g.Id).ToList();

            CountPlusAll(guidList);
        }

        public void GetCountByMusicalNote(Guid musicalNoteId)
        {
            IDataResult<MusicalNote> countObj = _facadeService.MusicalNoteService().GetById(musicalNoteId);
            if (!countObj.Success)
                return;
            CountPlus(countObj.Data.Id);
        }

        public void GetCountAllByMusicalNotes(Guid[] musicalNoteIds)
        {
            IDataResult<IList<MusicalNote>> countObjs = _facadeService.MusicalNoteService().GetAllByIds(musicalNoteIds);
            if (!countObjs.Success)
                return;

            IList<Guid> guidList = countObjs.Data.Select(g => g.Id).ToList();

            CountPlusAll(guidList);
        }

        public void GetCountByNewsPaper(Guid newsPaperId)
        {
            IDataResult<NewsPaper> countObj = _facadeService.NewsPaperService().GetById(newsPaperId);
            if (!countObj.Success)
                return;
            CountPlus(countObj.Data.Id);
        }

        public void GetCountAllByNewsPapers(Guid[] newsPaperIds)
        {
            var countObjs = _facadeService.NewsPaperService().GetAllByIds(newsPaperIds);
            if (!countObjs.Success)
                return;

            IList<Guid> guidList = countObjs.Data.Select(g => g.Id).ToList();

            CountPlusAll(guidList);
        }

        public void GetCountByObject3D(Guid object3DId)
        {
            IDataResult<Object3D> countObj = _facadeService.Object3DService().GetById(object3DId);
            if (!countObj.Success)
                return;
            CountPlus(countObj.Data.Id);
        }

        public void GetCountAllByObject3Ds(Guid[] object3DIds)
        {
            IDataResult<IList<Object3D>> countObjs = _facadeService.Object3DService().GetAllByIds(object3DIds);
            if (!countObjs.Success)
                return;

            IList<Guid> guidList = countObjs.Data.Select(g => g.Id).ToList();

            CountPlusAll(guidList);
        }

        public void GetCountByPainting(Guid paintingId)
        {
            IDataResult<Painting> countObj = _facadeService.PaintingService().GetById(paintingId);
            if (!countObj.Success)
                return;
            CountPlus(countObj.Data.Id);
        }

        public void GetCountAllByPaintings(Guid[] paintingIds)
        {
            IDataResult<IList<Painting>> countObjs = _facadeService.PaintingService().GetAllByIds(paintingIds);
            if (!countObjs.Success)
                return;

            IList<Guid> guidList = countObjs.Data.Select(g => g.Id).ToList();

            CountPlusAll(guidList);
        }

        public void GetCountByPoster(Guid posterId)
        {
            IDataResult<Poster> countObj = _facadeService.PosterService().GetById(posterId);
            if (!countObj.Success)
                return;
            CountPlus(countObj.Data.Id);
        }

        public void GetCountAllByPosters(Guid[] posterIds)
        {
            IDataResult<IList<Poster>> countObjs = _facadeService.PosterService().GetAllByIds(posterIds);
            if (!countObjs.Success)
                return;

            IList<Guid> guidList = countObjs.Data.Select(g => g.Id).ToList();

            CountPlusAll(guidList);
        }

        public void GetCountByThesis(Guid thesisId)
        {
            IDataResult<Thesis> countObj = _facadeService.ThesisService().GetById(thesisId);
            if (!countObj.Success)
                return;
            CountPlus(countObj.Data.Id);
        }

        public void GetCountAllByThesis(Guid[] thesisIds)
        {
            IDataResult<IList<Thesis>> countObjs = _facadeService.ThesisService().GetAllByIds(thesisIds);
            if (!countObjs.Success)
                return;

            IList<Guid> guidList = countObjs.Data.Select(g => g.Id).ToList();

            CountPlusAll(guidList);
        }

        private void CountPlus(Guid id)
        {
            Counter counter = _counterDal.Get(c => c.Id == id);
            counter.Count++;
            _counterDal.Update(counter);
        }

        private void CountPlusAll(IList<Guid> ids)
        {
            IList<Counter> counters = _counterDal.GetAll(cs => ids.Contains(cs.Id));
            foreach (Counter counter in counters)
            {
                counter.Count++;
                _counterDal.Update(counter);
            }
        }
    }
}