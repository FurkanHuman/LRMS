﻿using Business.Abstract;
using Business.Constants;
using Business.DependencyResolvers.Facade;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Business;
using Core.Utilities.Result.Abstract;
using Core.Utilities.Result.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Concrete.Infos;
using System.Linq.Expressions;

namespace Business.Concrete
{
    public class KitManager : IKitService
    {
        private readonly IKitDal _kitDal;
        private readonly IFacadeService _facadeService;

        public KitManager(IKitDal kitDal, IFacadeService facadeService)
        {
            _kitDal = kitDal;
            _facadeService = facadeService;
        }

        [ValidationAspect(typeof(KitValidator))]
        public IResult Add(Kit entity)
        {
            IResult result = BusinessRules.Run(KitControl(entity));
            if (result != null)
                return result;

            entity.IsDeleted = false;
            _kitDal.Add(entity);
            return new SuccessResult(KitConstants.AddSuccess);
        }

        public IResult Delete(Guid id)
        {
            Kit kit = _kitDal.Get(k => k.Id == id);
            if (kit == null)
                return new ErrorResult(KitConstants.NotMatch);

            _kitDal.Delete(kit);
            return new SuccessResult(KitConstants.DeleteSuccess);
        }

        public IResult ShadowDelete(Guid id)
        {
            Kit kit = _kitDal.Get(k => k.Id == id && !k.IsDeleted);
            if (kit == null)
                return new ErrorResult(KitConstants.NotMatch);

            kit.IsDeleted = true;
            _kitDal.Update(kit);
            return new SuccessResult(KitConstants.EfDeletedSuccsess);
        }

        [ValidationAspect(typeof(KitValidator))]
        public IResult Update(Kit entity)
        {
            IResult result = BusinessRules.Run(KitControl(entity));
            if (result != null)
                return result;

            entity.IsDeleted = false;
            _kitDal.Update(entity);
            return new SuccessResult(KitConstants.AddSuccess);
        }

        public IDataResult<IList<Kit>> GetAll()
        {
            return new SuccessDataResult<IList<Kit>>(_kitDal.GetAll(k => !k.IsDeleted), KitConstants.DataGet);
        }

        public IDataResult<IList<Kit>> GetAllByFilter(Expression<Func<Kit, bool>>? filter = null)
        {
            return new SuccessDataResult<IList<Kit>>(_kitDal.GetAll(filter), KitConstants.DataGet);
        }

        public IDataResult<IList<Kit>> GetAllByIsDeleted()
        {
            return new SuccessDataResult<IList<Kit>>(_kitDal.GetAll(k => k.IsDeleted), KitConstants.DataGet);
        }

        public IDataResult<Kit> GetByAcademicJournal(Guid academicJournalId)
        {
            IDataResult<AcademicJournal> aJ = _facadeService.AcademicJournalService().GetById(academicJournalId);
            if (!aJ.Success)
                return new ErrorDataResult<Kit>(aJ.Message);

            Kit kit = _kitDal.Get(k => k.AcademicJournalsId == academicJournalId && !k.IsDeleted);
            return kit == null
                ? new ErrorDataResult<Kit>(KitConstants.DataNotGet)
                : new SuccessDataResult<Kit>(kit, KitConstants.DataGet);
        }

        public IDataResult<IList<Kit>> GetAllByAcademicJournals(Guid[] academicJournalIds)
        {
            IDataResult<IList<AcademicJournal>> aJs = _facadeService.AcademicJournalService().GetAllByIds(academicJournalIds);
            if (!aJs.Success)
                return new ErrorDataResult<IList<Kit>>(aJs.Message);

            IList<Kit> kits = _kitDal.GetAll(k => k.AcademicJournals == aJs.Data && !k.IsDeleted);
            return kits == null
                ? new ErrorDataResult<IList<Kit>>(KitConstants.DataNotGet)
                : new SuccessDataResult<IList<Kit>>(kits, KitConstants.DataGet);
        }

        public IDataResult<Kit> GetByAudioRecord(Guid audioRecordId)
        {
            IDataResult<AudioRecord> aR = _facadeService.AudioRecordService().GetById(audioRecordId);
            if (!aR.Success)
                return new ErrorDataResult<Kit>(aR.Message);

            Kit kit = _kitDal.Get(k => k.AudioRecordsId == audioRecordId && !k.IsDeleted);
            return kit == null
                ? new ErrorDataResult<Kit>(KitConstants.DataNotGet)
                : new SuccessDataResult<Kit>(kit, KitConstants.DataGet);
        }

        public IDataResult<IList<Kit>> GetAllByAudioRecords(Guid[] audioRecordIds)
        {
            IDataResult<IList<AudioRecord>> aR = _facadeService.AudioRecordService().GetAllByIds(audioRecordIds);
            if (!aR.Success)
                return new ErrorDataResult<IList<Kit>>(aR.Message);

            IList<Kit> kits = _kitDal.GetAll(k => k.AudioRecords == aR.Data && !k.IsDeleted);
            return kits == null
                ? new ErrorDataResult<IList<Kit>>(KitConstants.DataNotGet)
                : new SuccessDataResult<IList<Kit>>(kits, KitConstants.DataGet);
        }

        public IDataResult<Kit> GetByBook(Guid bookId)
        {
            IDataResult<Book> b = _facadeService.BookService().GetById(bookId);
            if (!b.Success)
                return new ErrorDataResult<Kit>(b.Message);

            Kit kit = _kitDal.Get(k => k.BooksId == bookId && !k.IsDeleted);
            return kit == null
                ? new ErrorDataResult<Kit>(KitConstants.DataNotGet)
                : new SuccessDataResult<Kit>(kit, KitConstants.DataGet);
        }

        public IDataResult<IList<Kit>> GetAllByBooks(Guid[] bookIds)
        {
            IDataResult<IList<Book>> bs = _facadeService.BookService().GetAllByIds(bookIds);
            if (!bs.Success)
                return new ErrorDataResult<IList<Kit>>(bs.Message);

            IList<Kit> kits = _kitDal.GetAll(k => k.Books == bs.Data && !k.IsDeleted);
            return kits == null
                ? new ErrorDataResult<IList<Kit>>(KitConstants.DataNotGet)
                : new SuccessDataResult<IList<Kit>>(kits, KitConstants.DataGet);
        }

        public IDataResult<Kit> GetByBookSeries(Guid bookSeriesId)
        {
            IDataResult<BookSeries> bS = _facadeService.BookSeriesService().GetById(bookSeriesId);
            if (!bS.Success)
                return new ErrorDataResult<Kit>(bS.Message);

            Kit kit = _kitDal.Get(k => k.BookSeriesId == bookSeriesId && !k.IsDeleted);
            return kit == null
                ? new ErrorDataResult<Kit>(KitConstants.DataNotGet)
                : new SuccessDataResult<Kit>(kit, KitConstants.DataGet);
        }

        public IDataResult<IList<Kit>> GetAllByBookSeries(Guid[] bookSeriesIds)
        {
            IDataResult<IList<BookSeries>> bss = _facadeService.BookSeriesService().GetAllByIds(bookSeriesIds);
            if (!bss.Success)
                return new ErrorDataResult<IList<Kit>>(bss.Message);

            IList<Kit> kits = _kitDal.GetAll(k => k.BookSeries == bss.Data && !k.IsDeleted);
            return kits == null
                ? new ErrorDataResult<IList<Kit>>(KitConstants.DataNotGet)
                : new SuccessDataResult<IList<Kit>>(kits, KitConstants.DataGet);
        }

        public IDataResult<Kit> GetByCartographicMaterial(Guid cartographicMaterialId)
        {
            IDataResult<CartographicMaterial> cM = _facadeService.CartographicMaterialService().GetById(cartographicMaterialId);
            if (!cM.Success)
                return new ErrorDataResult<Kit>(cM.Message);

            Kit kit = _kitDal.Get(k => k.CartographicMaterialsId == cartographicMaterialId && !k.IsDeleted);
            return kit == null
                ? new ErrorDataResult<Kit>(KitConstants.DataNotGet)
                : new SuccessDataResult<Kit>(kit, KitConstants.DataGet);
        }

        public IDataResult<IList<Kit>> GetAllByCartographicMaterials(Guid[] cartographicMaterialIds)
        {
            IDataResult<IList<CartographicMaterial>>? cMs = _facadeService.CartographicMaterialService().GetAllByIds(cartographicMaterialIds);
            if (!cMs.Success)
                return new ErrorDataResult<IList<Kit>>(cMs.Message);

            IList<Kit> kits = _kitDal.GetAll(k => k.CartographicMaterials == cMs.Data && !k.IsDeleted);
            return kits == null
                ? new ErrorDataResult<IList<Kit>>(KitConstants.DataNotGet)
                : new SuccessDataResult<IList<Kit>>(kits, KitConstants.DataGet);
        }

        public IDataResult<IList<Kit>> GetAllByCategories(int[] categoriesId)
        {
            IDataResult<IList<Category>> c = _facadeService.CategoryService().GetAllByIds(categoriesId);
            if (!c.Success)
                return new ErrorDataResult<IList<Kit>>(c.Message);

            IList<Kit> kits = _kitDal.GetAll(k => k.Categories.Any(c => categoriesId.Contains(c.Id)) && !k.IsDeleted);
            return kits == null
                ? new ErrorDataResult<IList<Kit>>(KitConstants.DataNotGet)
                : new SuccessDataResult<IList<Kit>>(kits, KitConstants.DataGet);
        }

        public IDataResult<Kit> GetByDepiction(Guid depictionId)
        {
            IDataResult<Depiction> d = _facadeService.DepictionService().GetById(depictionId);
            if (!d.Success)
                return new ErrorDataResult<Kit>(d.Message);

            Kit kit = _kitDal.Get(k => k.DepictionsId == depictionId && !k.IsDeleted);
            return kit == null
                ? new ErrorDataResult<Kit>(KitConstants.DataNotGet)
                : new SuccessDataResult<Kit>(kit, KitConstants.DataGet);
        }

        public IDataResult<IList<Kit>> GetAllByDepictions(Guid[] depictionIds)
        {
            IDataResult<IList<Depiction>> ds = _facadeService.DepictionService().GetAllByIds(depictionIds);
            if (!ds.Success)
                return new ErrorDataResult<IList<Kit>>(ds.Message);

            IList<Kit> kits = _kitDal.GetAll(k => k.Depictions == ds.Data && !k.IsDeleted);
            return kits == null
                ? new ErrorDataResult<IList<Kit>>(KitConstants.DataNotGet)
                : new SuccessDataResult<IList<Kit>>(kits, KitConstants.DataGet);
        }

        public IDataResult<IList<Kit>> GetAllByDescriptionFinder(string finderString)
        {
            IList<Kit> kits = _kitDal.GetAll(k => k.Description.Contains(finderString) && !k.IsDeleted);
            return kits == null
                ? new ErrorDataResult<IList<Kit>>(KitConstants.DataNotGet)
                : new SuccessDataResult<IList<Kit>>(kits, KitConstants.DataGet);
        }

        public IDataResult<IList<Kit>> GetAllByDimension(Guid dimensionId)
        {
            IDataResult<Dimension> dimension = _facadeService.DimensionService().GetById(dimensionId);
            if (!dimension.Success)
                return new ErrorDataResult<IList<Kit>>(dimension.Message);

            IList<Kit> kits = _kitDal.GetAll(k => k.DimensionsId == dimensionId && !k.IsDeleted);
            return kits == null
                ? new ErrorDataResult<IList<Kit>>(KitConstants.DataNotGet)
                : new SuccessDataResult<IList<Kit>>(kits, KitConstants.DataGet);
        }

        public IDataResult<Kit> GetByDissertation(Guid dissertationId)
        {
            IDataResult<Dissertation> d = _facadeService.DissertationService().GetById(dissertationId);
            if (!d.Success)
                return new ErrorDataResult<Kit>(d.Message);

            Kit kit = _kitDal.Get(k => k.DissertationsId == dissertationId && !k.IsDeleted);
            return kit == null
                ? new ErrorDataResult<Kit>(KitConstants.DataNotGet)
                : new SuccessDataResult<Kit>(kit, KitConstants.DataGet);
        }

        public IDataResult<IList<Kit>> GetAllByDissertations(Guid[] dissertationIds)
        {
            IDataResult<IList<Dissertation>> ds = _facadeService.DissertationService().GetAllByIds(dissertationIds);
            if (!ds.Success)
                return new ErrorDataResult<IList<Kit>>(ds.Message);

            IList<Kit> kits = _kitDal.GetAll(k => k.Dissertations == ds.Data && !k.IsDeleted);
            return kits == null
                ? new ErrorDataResult<IList<Kit>>(KitConstants.DataNotGet)
                : new SuccessDataResult<IList<Kit>>(kits, KitConstants.DataGet);
        }

        public IDataResult<Kit> GetByElectronicsResource(Guid electronicsResourceId)
        {
            IDataResult<ElectronicsResource> eR = _facadeService.ElectronicsResourceService().GetById(electronicsResourceId);
            if (!eR.Success)
                return new ErrorDataResult<Kit>(eR.Message);

            Kit kit = _kitDal.Get(k => k.ElectronicsResourcesId == electronicsResourceId && !k.IsDeleted);
            return kit == null
                ? new ErrorDataResult<Kit>(KitConstants.DataNotGet)
                : new SuccessDataResult<Kit>(kit, KitConstants.DataGet);
        }

        public IDataResult<IList<Kit>> GetAllByElectronicsResources(Guid[] electronicsResourceIds)
        {
            IDataResult<IList<ElectronicsResource>> eRs = _facadeService.ElectronicsResourceService().GetAllByIds(electronicsResourceIds);
            if (!eRs.Success)
                return new ErrorDataResult<IList<Kit>>(eRs.Message);

            IList<Kit> kits = _kitDal.GetAll(k => k.ElectronicsResources == eRs.Data && !k.IsDeleted);
            return kits == null
                ? new ErrorDataResult<IList<Kit>>(KitConstants.DataNotGet)
                : new SuccessDataResult<IList<Kit>>(kits, KitConstants.DataGet);
        }

        public IDataResult<IList<Kit>> GetAllByEMFile(Guid eMFileId)
        {
            IDataResult<EMaterialFile> eMF = _facadeService.EMaterialFileService().GetById(eMFileId);
            if (!eMF.Success)
                return new ErrorDataResult<IList<Kit>>(eMF.Message);

            IList<Kit> kits = _kitDal.GetAll(k => k.EMaterialFilesId == eMFileId && !k.IsDeleted);
            return kits == null
                ? new ErrorDataResult<IList<Kit>>(KitConstants.DataNotGet)
                : new SuccessDataResult<IList<Kit>>(kits, KitConstants.DataGet);
        }

        public IDataResult<Kit> GetByEncyclopedia(Guid encyclopediaId)
        {
            IDataResult<Encyclopedia> eP = _facadeService.EncyclopediaService().GetById(encyclopediaId);
            if (!eP.Success)
                return new ErrorDataResult<Kit>(eP.Message);

            Kit kit = _kitDal.Get(k => k.EncyclopediasId == encyclopediaId && !k.IsDeleted);
            return kit == null
                ? new ErrorDataResult<Kit>(KitConstants.DataNotGet)
                : new SuccessDataResult<Kit>(kit, KitConstants.DataGet);
        }

        public IDataResult<IList<Kit>> GetAllByEncyclopedias(Guid[] encyclopediaIds)
        {
            IDataResult<IList<Encyclopedia>> ePs = _facadeService.EncyclopediaService().GetAllByIds(encyclopediaIds);
            if (!ePs.Success)
                return new ErrorDataResult<IList<Kit>>(ePs.Message);

            IList<Kit> kits = _kitDal.GetAll(k => k.Theses == ePs.Data && !k.IsDeleted);
            return kits == null
                ? new ErrorDataResult<IList<Kit>>(KitConstants.DataNotGet)
                : new SuccessDataResult<IList<Kit>>(kits, KitConstants.DataGet);
        }

        public IDataResult<Kit> GetByGraphicalImage(Guid graphicalImageId)
        {
            IDataResult<GraphicalImage> gI = _facadeService.GraphicalImageService().GetById(graphicalImageId);
            if (!gI.Success)
                return new ErrorDataResult<Kit>(gI.Message);

            Kit kit = _kitDal.Get(k => k.GraphicalImagesId == graphicalImageId && !k.IsDeleted);
            return kit == null
                ? new ErrorDataResult<Kit>(KitConstants.DataNotGet)
                : new SuccessDataResult<Kit>(kit, KitConstants.DataGet);
        }

        public IDataResult<IList<Kit>> GetAllByGraphicalImages(Guid[] graphicalImageIds)
        {
            IDataResult<IList<GraphicalImage>> gIs = _facadeService.GraphicalImageService().GetAllByIds(graphicalImageIds);
            if (!gIs.Success)
                return new ErrorDataResult<IList<Kit>>(gIs.Message);

            IList<Kit> kits = _kitDal.GetAll(k => k.GraphicalImages == gIs.Data && !k.IsDeleted);
            return kits == null
                ? new ErrorDataResult<IList<Kit>>(KitConstants.DataNotGet)
                : new SuccessDataResult<IList<Kit>>(kits, KitConstants.DataGet);
        }

        public IDataResult<Kit> GetById(Guid id)
        {
            Kit kit = _kitDal.Get(k => k.Id == id);

            return kit == null
                ? new ErrorDataResult<Kit>(KitConstants.DataNotGet)
                : new SuccessDataResult<Kit>(kit, KitConstants.DataGet);
        }

        public IDataResult<IList<Kit>> GetAllByIds(Guid[] ids)
        {
            IList<Kit> kits = _kitDal.GetAll(k => ids.Contains(k.Id));

            return kits == null
                ? new ErrorDataResult<IList<Kit>>(KitConstants.DataNotGet)
                : new SuccessDataResult<IList<Kit>>(kits, KitConstants.DataGet);
        }

        public IDataResult<IList<Kit>> GetAllByImage(Guid imageId)
        {
            IDataResult<Image> i = _facadeService.ImageService().GetById(imageId);
            if (!i.Success)
                return new ErrorDataResult<IList<Kit>>(i.Message);

            IList<Kit> kits = _kitDal.GetAll(k => k.ImageId == imageId && !k.IsDeleted);
            return kits == null
                ? new ErrorDataResult<IList<Kit>>(KitConstants.DataNotGet)
                : new SuccessDataResult<IList<Kit>>(kits, KitConstants.DataGet);
        }

        public IDataResult<Kit> GetByMagazine(Guid magazineId)
        {
            IDataResult<Magazine> m = _facadeService.MagazineService().GetById(magazineId);
            if (!m.Success)
                return new ErrorDataResult<Kit>(m.Message);

            Kit kit = _kitDal.Get(k => k.MagazinesId == magazineId && !k.IsDeleted);
            return kit == null
                ? new ErrorDataResult<Kit>(KitConstants.DataNotGet)
                : new SuccessDataResult<Kit>(kit, KitConstants.DataGet);
        }

        public IDataResult<IList<Kit>> GetAllByMagazines(Guid[] magazineIds)
        {
            IDataResult<IList<Magazine>> ms = _facadeService.MagazineService().GetAllByIds(magazineIds);
            if (!ms.Success)
                return new ErrorDataResult<IList<Kit>>(ms.Message);

            IList<Kit> kits = _kitDal.GetAll(k => k.Magazines == ms.Data && !k.IsDeleted);
            return kits == null
                ? new ErrorDataResult<IList<Kit>>(KitConstants.DataNotGet)
                : new SuccessDataResult<IList<Kit>>(kits, KitConstants.DataGet);
        }

        public IDataResult<Kit> GetByMicroform(Guid microformId)
        {
            IDataResult<Microform> mF = _facadeService.MicroformService().GetById(microformId);
            if (!mF.Success)
                return new ErrorDataResult<Kit>(mF.Message);

            Kit kit = _kitDal.Get(k => k.MicroformsId == microformId && !k.IsDeleted);
            return kit == null
                ? new ErrorDataResult<Kit>(KitConstants.DataNotGet)
                : new SuccessDataResult<Kit>(kit, KitConstants.DataGet);
        }

        public IDataResult<IList<Kit>> GetAllByMicroforms(Guid[] microformIds)
        {
            IDataResult<IList<Microform>> mFs = _facadeService.MicroformService().GetAllByIds(microformIds);
            if (!mFs.Success)
                return new ErrorDataResult<IList<Kit>>(mFs.Message);

            IList<Kit> kits = _kitDal.GetAll(k => k.Microforms == mFs.Data && !k.IsDeleted);
            return kits == null
                ? new ErrorDataResult<IList<Kit>>(KitConstants.DataNotGet)
                : new SuccessDataResult<IList<Kit>>(kits, KitConstants.DataGet);
        }

        public IDataResult<Kit> GetByMusicalNote(Guid musicalNoteId)
        {
            IDataResult<MusicalNote> mN = _facadeService.MusicalNoteService().GetById(musicalNoteId);
            if (!mN.Success)
                return new ErrorDataResult<Kit>(mN.Message);

            Kit kit = _kitDal.Get(k => k.MusicalNotesId == musicalNoteId && !k.IsDeleted);
            return kit == null
                ? new ErrorDataResult<Kit>(KitConstants.DataNotGet)
                : new SuccessDataResult<Kit>(kit, KitConstants.DataGet);
        }

        public IDataResult<IList<Kit>> GetAllByMusicalNotes(Guid[] musicalNoteIds)
        {
            IDataResult<IList<MusicalNote>> mNs = _facadeService.MusicalNoteService().GetAllByIds(musicalNoteIds);
            if (!mNs.Success)
                return new ErrorDataResult<IList<Kit>>(mNs.Message);

            IList<Kit> kits = _kitDal.GetAll(k => k.MusicalNotes == mNs.Data && !k.IsDeleted);
            return kits == null
                ? new ErrorDataResult<IList<Kit>>(KitConstants.DataNotGet)
                : new SuccessDataResult<IList<Kit>>(kits, KitConstants.DataGet);
        }

        public IDataResult<IList<Kit>> GetAllByName(string name)
        {
            IList<Kit> kits = _kitDal.GetAll(k => k.Name.Contains(name) && !k.IsDeleted);
            return kits == null
                ? new ErrorDataResult<IList<Kit>>(KitConstants.DataNotGet)
                : new SuccessDataResult<IList<Kit>>(kits, KitConstants.DataGet);
        }

        public IDataResult<Kit> GetByNewsPaper(Guid newsPaperId)
        {
            IDataResult<NewsPaper> nP = _facadeService.NewsPaperService().GetById(newsPaperId);
            if (!nP.Success)
                return new ErrorDataResult<Kit>(nP.Message);

            Kit kit = _kitDal.Get(k => k.NewsPapersId == newsPaperId && !k.IsDeleted);
            return kit == null
                ? new ErrorDataResult<Kit>(KitConstants.DataNotGet)
                : new SuccessDataResult<Kit>(kit, KitConstants.DataGet);
        }

        public IDataResult<IList<Kit>> GetAllByNewsPapers(Guid[] newsPaperIds)
        {
            IDataResult<IList<NewsPaper>> nPs = _facadeService.NewsPaperService().GetAllByIds(newsPaperIds);
            if (!nPs.Success)
                return new ErrorDataResult<IList<Kit>>(nPs.Message);

            IList<Kit> kits = _kitDal.GetAll(k => k.NewsPapers == nPs.Data && !k.IsDeleted);
            return kits == null
                ? new ErrorDataResult<IList<Kit>>(KitConstants.DataNotGet)
                : new SuccessDataResult<IList<Kit>>(kits, KitConstants.DataGet);
        }

        public IDataResult<Kit> GetByObject3D(Guid object3DId)
        {
            IDataResult<Object3D> o3D = _facadeService.Object3DService().GetById(object3DId);
            if (!o3D.Success)
                return new ErrorDataResult<Kit>(o3D.Message);

            Kit kit = _kitDal.Get(k => k.Object3DsId == object3DId && !k.IsDeleted);
            return kit == null
                ? new ErrorDataResult<Kit>(KitConstants.DataNotGet)
                : new SuccessDataResult<Kit>(kit, KitConstants.DataGet);
        }

        public IDataResult<IList<Kit>> GetAllByObject3Ds(Guid[] object3DIds)
        {
            IDataResult<IList<Object3D>> o3Ds = _facadeService.Object3DService().GetAllByIds(object3DIds);
            if (!o3Ds.Success)
                return new ErrorDataResult<IList<Kit>>(o3Ds.Message);

            IList<Kit> kits = _kitDal.GetAll(k => k.Object3Ds == o3Ds.Data && !k.IsDeleted);
            return kits == null
                ? new ErrorDataResult<IList<Kit>>(KitConstants.DataNotGet)
                : new SuccessDataResult<IList<Kit>>(kits, KitConstants.DataGet);
        }

        public IDataResult<Kit> GetByPainting(Guid paintingId)
        {
            IDataResult<Painting> ps = _facadeService.PaintingService().GetById(paintingId);
            if (!ps.Success)
                return new ErrorDataResult<Kit>(ps.Message);

            Kit kit = _kitDal.Get(k => k.PaintingsId == paintingId && !k.IsDeleted);
            return kit == null
                ? new ErrorDataResult<Kit>(KitConstants.DataNotGet)
                : new SuccessDataResult<Kit>(kit, KitConstants.DataGet);
        }

        public IDataResult<IList<Kit>> GetAllByPaintings(Guid[] paintingIds)
        {
            IDataResult<IList<Painting>> ps = _facadeService.PaintingService().GetAllByIds(paintingIds);
            if (!ps.Success)
                return new ErrorDataResult<IList<Kit>>(ps.Message);

            IList<Kit> kits = _kitDal.GetAll(k => k.Paintings == ps.Data && !k.IsDeleted);
            return kits == null
                ? new ErrorDataResult<IList<Kit>>(KitConstants.DataNotGet)
                : new SuccessDataResult<IList<Kit>>(kits, KitConstants.DataGet);
        }

        public IDataResult<Kit> GetByPoster(Guid posterId)
        {
            IDataResult<Poster> ps = _facadeService.PosterService().GetById(posterId);
            if (!ps.Success)
                return new ErrorDataResult<Kit>(ps.Message);

            Kit kit = _kitDal.Get(k => k.PostersId == posterId && !k.IsDeleted);
            return kit == null
                ? new ErrorDataResult<Kit>(KitConstants.DataNotGet)
                : new SuccessDataResult<Kit>(kit, KitConstants.DataGet);
        }

        public IDataResult<IList<Kit>> GetAllByPosters(Guid[] posterIds)
        {
            IDataResult<IList<Poster>> ps = _facadeService.PosterService().GetAllByIds(posterIds);
            if (!ps.Success)
                return new ErrorDataResult<IList<Kit>>(ps.Message);

            IList<Kit> kits = _kitDal.GetAll(k => k.Posters == ps.Data && !k.IsDeleted);
            return kits == null
                ? new ErrorDataResult<IList<Kit>>(KitConstants.DataNotGet)
                : new SuccessDataResult<IList<Kit>>(kits, KitConstants.DataGet);
        }

        public IDataResult<IList<Kit>> GetAllByPrice(decimal minPrice, decimal? maxPrice = null)
        {
            IList<Kit> kits = maxPrice == null
                ? _kitDal.GetAll(k => k.Price == minPrice && !k.IsDeleted)
                : _kitDal.GetAll(k => k.Price >= minPrice && k.Price <= maxPrice && !k.IsDeleted);

            return kits == null
                ? new ErrorDataResult<IList<Kit>>(KitConstants.DataNotGet)
                : new SuccessDataResult<IList<Kit>>(kits, KitConstants.DataGet);
        }

        public IDataResult<IList<Kit>> GetAllByTechnicalPlaceholder(Guid technicalPlaceholderId)
        {
            IDataResult<TechnicalPlaceholder> placeHolder = _facadeService.TechnicalPlaceholderService().GetById(technicalPlaceholderId);
            if (!placeHolder.Success)
                return new ErrorDataResult<IList<Kit>>(placeHolder.Message);

            IList<Kit> kits = _kitDal.GetAll(k => k.TechnicalPlaceholdersId == technicalPlaceholderId && !k.IsDeleted);
            return kits == null
                ? new ErrorDataResult<IList<Kit>>(KitConstants.DataNotGet)
                : new SuccessDataResult<IList<Kit>>(kits, KitConstants.DataGet);
        }

        public IDataResult<Kit> GetByThesis(Guid thesisId)
        {
            IDataResult<Thesis> t = _facadeService.ThesisService().GetById(thesisId);
            if (!t.Success)
                return new ErrorDataResult<Kit>(t.Message);

            Kit kit = _kitDal.Get(k => k.ThesesId == thesisId && !k.IsDeleted);
            return kit == null
                ? new ErrorDataResult<Kit>(KitConstants.DataNotGet)
                : new SuccessDataResult<Kit>(kit, KitConstants.DataGet);
        }

        public IDataResult<IList<Kit>> GetAllByThesis(Guid[] thesisIds)
        {
            IDataResult<IList<Thesis>> tS = _facadeService.ThesisService().GetAllByIds(thesisIds);
            if (!tS.Success)
                return new ErrorDataResult<IList<Kit>>(tS.Message);

            IList<Kit> kits = _kitDal.GetAll(k => k.Theses == tS.Data && !k.IsDeleted);
            return kits == null
                ? new ErrorDataResult<IList<Kit>>(KitConstants.DataNotGet)
                : new SuccessDataResult<IList<Kit>>(kits, KitConstants.DataGet);
        }

        public IDataResult<IList<Kit>> GetAllByTitle(string title)
        {
            IList<Kit> kits = _kitDal.GetAll(k => k.Title.Contains(title) && !k.IsDeleted);
            return kits == null
                ? new ErrorDataResult<IList<Kit>>(KitConstants.DataNotGet)
                : new SuccessDataResult<IList<Kit>>(kits, KitConstants.DataGet);
        }

        public IDataResult<byte?> GetSecretLevel(Guid id)
        {
            byte? sLevel = _kitDal.Get(k => k.Id == id && !k.IsDeleted).SecretLevel;
            return sLevel == null
                ? new ErrorDataResult<byte?>(KitConstants.DataNotGet)
                : new SuccessDataResult<byte?>(sLevel, KitConstants.DataGet);
        }

        public IDataResult<byte> GetState(Guid id)
        {
            return new SuccessDataResult<byte>(_kitDal.Get(k => k.Id == id && !k.IsDeleted).State, KitConstants.DataGet);
        }

        public IDataResult<Kit> GetByStock(Guid stockId)
        {
            IDataResult<Stock> stock = _facadeService.StockService().GetById(stockId);
            if (!stock.Success)
                return new ErrorDataResult<Kit>(stock.Message);

            Kit kit = _kitDal.Get(k => k.Stock == stock.Data && !k.IsDeleted);
            return kit == null
                ? new ErrorDataResult<Kit>(KitConstants.NotMatch)
                : new SuccessDataResult<Kit>(kit, KitConstants.DataGet);
        }

        private IResult KitControl(Kit kit)
        {
            bool controlKit = _kitDal.Get(k =>

                k.Name == kit.Name
             && k.Title == kit.Title
             && k.Description.Contains(kit.Description)
             && k.CategoryId == kit.CategoryId
             && k.TechnicalPlaceholdersId == kit.TechnicalPlaceholdersId
             && k.DimensionsId == kit.DimensionsId
             && k.EMaterialFilesId == kit.EMaterialFilesId
             && k.State == kit.State
             && k.IsKitBroken == kit.IsKitBroken

             ) != null;

            if (controlKit)
                return new ErrorResult(KitConstants.AlreadyExists);

            return new SuccessResult();
        }
    }
}
