using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Business;
using Core.Utilities.Result.Abstract;
using Core.Utilities.Result.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class KitManager : IKitService // todo: write all other services and turn here
    {
        private readonly IKitDal _kitDal;

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

        public IDataResult<List<Kit>> GetAll()
        {
            return new SuccessDataResult<List<Kit>>(_kitDal.GetAll(k => !k.IsDeleted).ToList(), KitConstants.DataGet);
        }

        public IDataResult<List<Kit>> GetAllByFilter(Expression<Func<Kit, bool>>? filter = null)
        {
            return new SuccessDataResult<List<Kit>>(_kitDal.GetAll(filter).ToList(), KitConstants.DataGet);
        }

        public IDataResult<List<Kit>> GetAllBySecrets()
        {
            return new SuccessDataResult<List<Kit>>(_kitDal.GetAll(k => k.IsDeleted).ToList(), KitConstants.DataGet);
        }

        public IDataResult<Kit> GetByAcademicJournal(Guid AcademicJournalId)
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<Kit>> GetByAcademicJournals(Guid[] AcademicJournalIds)
        {
            throw new NotImplementedException();
        }

        public IDataResult<Kit> GetByAudioRecord(Guid AudioRecordId)
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<Kit>> GetByAudioRecords(Guid[] AudioRecordIds)
        {
            throw new NotImplementedException();
        }

        public IDataResult<Kit> GetByBook(Guid bookId)
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<Kit>> GetByBooks(Guid[] bookIds)
        {
            throw new NotImplementedException();
        }

        public IDataResult<Kit> GetByBookSeries(Guid bookSeriesId)
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<Kit>> GetByBookSeries(Guid[] bookSeriesIds)
        {
            throw new NotImplementedException();
        }

        public IDataResult<Kit> GetByCartographicMaterial(Guid cartographicMaterialId)
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<Kit>> GetByCartographicMaterials(Guid[] cartographicMaterialIds)
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<Kit>> GetByCategories(int[] categoriesId)
        {
            throw new NotImplementedException();
        }

        public IDataResult<Kit> GetByDepiction(Guid depictionId)
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<Kit>> GetByDepictions(Guid[] depictionIds)
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<Kit>> GetByDescriptionFinder(string finderString)
        {
            List<Kit> kits = _kitDal.GetAll(k => k.Description.Contains(finderString) && !k.IsDeleted).ToList();
            return kits == null
                ? new ErrorDataResult<List<Kit>>(KitConstants.DataNotGet)
                : new SuccessDataResult<List<Kit>>(kits, KitConstants.DataGet);
        }

        public IDataResult<List<Kit>> GetByDimension(Guid dimensionId)
        {
            throw new NotImplementedException();
        }

        public IDataResult<Kit> GetByDissertation(Guid dissertationId)
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<Kit>> GetByDissertations(Guid[] dissertationIds)
        {
            throw new NotImplementedException();
        }

        public IDataResult<Kit> GetByElectronicsResource(Guid electronicsResourceId)
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<Kit>> GetByElectronicsResources(Guid[] electronicsResourceIds)
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<Kit>> GetByEMFiles(Guid eMFilesId)
        {
            throw new NotImplementedException();
        }

        public IDataResult<Kit> GetByEncyclopedia(Guid encyclopediaId)
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<Kit>> GetByEncyclopedias(Guid[] encyclopediaIds)
        {
            throw new NotImplementedException();
        }

        public IDataResult<Kit> GetByGraphicalImage(Guid graphicalImageId)
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<Kit>> GetByGraphicalImages(Guid[] graphicalImageIds)
        {
            throw new NotImplementedException();
        }

        public IDataResult<Kit> GetById(Guid id)
        {
            Kit kit = _kitDal.Get(k => k.Id == id);

            return kit == null
                ? new ErrorDataResult<Kit>(KitConstants.DataNotGet)
                : new SuccessDataResult<Kit>(kit, KitConstants.DataGet);
        }

        public IDataResult<List<Kit>> GetByIds(Guid[] ids)
        {
            List<Kit> kits = _kitDal.GetAll(k => ids.Contains(k.Id)).ToList();

            return kits == null
                ? new ErrorDataResult<List<Kit>>(KitConstants.DataNotGet)
                : new SuccessDataResult<List<Kit>>(kits, KitConstants.DataGet);
        }

        public IDataResult<Kit> GetByMagazine(Guid magazineId)
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<Kit>> GetByMagazines(Guid[] magazineIds)
        {
            throw new NotImplementedException();
        }

        public IDataResult<Kit> GetByMicroform(Guid microformId)
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<Kit>> GetByMicroforms(Guid[] microformIds)
        {
            throw new NotImplementedException();
        }

        public IDataResult<Kit> GetByMusicalNote(Guid musicalNoteId)
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<Kit>> GetByMusicalNotes(Guid[] musicalNoteIds)
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<Kit>> GetByNames(string name)
        {
            List<Kit> kits = _kitDal.GetAll(k => k.Name.Contains(name) && !k.IsDeleted).ToList();
            return kits == null
                ? new ErrorDataResult<List<Kit>>(KitConstants.DataNotGet)
                : new SuccessDataResult<List<Kit>>(kits, KitConstants.DataGet);
        }

        public IDataResult<Kit> GetByNewsPaper(Guid newsPaperId)
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<Kit>> GetByNewsPapers(Guid[] newsPaperIds)
        {
            throw new NotImplementedException();
        }

        public IDataResult<Kit> GetByObject3D(Guid object3DId)
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<Kit>> GetByObject3Ds(Guid[] object3DIds)
        {
            throw new NotImplementedException();
        }

        public IDataResult<Kit> GetByPainting(Guid paintingId)
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<Kit>> GetByPaintings(Guid[] paintingIds)
        {
            throw new NotImplementedException();
        }

        public IDataResult<Kit> GetByPoster(Guid posterId)
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<Kit>> GetByPosters(Guid[] posterIds)
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<Kit>> GetByPrice(decimal minPrice, decimal? maxPrice = null)
        {
            List<Kit> kits = maxPrice == null
                ? _kitDal.GetAll(k => k.Price == minPrice && !k.IsDeleted).ToList()
                : _kitDal.GetAll(k => k.Price >= minPrice && k.Price <= maxPrice && !k.IsDeleted).ToList();

            return kits == null
                ? new ErrorDataResult<List<Kit>>(KitConstants.DataNotGet)
                : new SuccessDataResult<List<Kit>>(kits, KitConstants.DataGet);
        }

        public IDataResult<List<Kit>> GetByTechnicalPlaceholders(Guid technicalPlaceholderId)
        {
            throw new NotImplementedException();
        }

        public IDataResult<Kit> GetByThesis(Guid thesisId)
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<Kit>> GetByThesis(Guid[] thesisIds)
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<Kit>> GetByTitles(string title)
        {
            List<Kit> kits = _kitDal.GetAll(k => k.Title.Contains(title) && !k.IsDeleted).ToList();
            return kits == null
                ? new ErrorDataResult<List<Kit>>(KitConstants.DataNotGet)
                : new SuccessDataResult<List<Kit>>(kits, KitConstants.DataGet);
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
