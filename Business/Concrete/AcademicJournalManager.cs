using Business.Abstract;
using Business.Constants;
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
    public class AcademicJournalManager : IAcademicJournalService
    {
        private readonly IAcademicJournalDal _academicJournalDal;
        private readonly ICategoryService _categoryService;
        private readonly IDimensionService _dimensionService;
        private readonly IReferenceService _referenceService;
        private readonly IPublisherService _publisherService;
        private readonly IEMaterialFileService _eMaterialFileService;
        private readonly IEditorService _editorService;
        private readonly ITechnicalPlaceholderService _technicalPlaceholderService;
        private readonly IResearcherService _researcherService;
        private readonly IStockService _stockService;

        [ValidationAspect(typeof(AcademicJournalValidator), Priority = 1)]
        public IResult Add(AcademicJournal entity) // Todo: control
        {
            IResult result = BusinessRules.Run(CheckIfAcademicJournalExists(entity));
            if (result != null)
                return result;

            entity.IsDeleted = false;
            _academicJournalDal.Add(entity);
            return new SuccessResult(AcademicJournalConstants.AddSuccess);
        }

        public IResult Delete(Guid id)
        {
            AcademicJournal academicJournal = _academicJournalDal.Get(aj => aj.Id == id);
            if (academicJournal == null)
                return new ErrorResult(AcademicJournalConstants.NotMatch);

            _academicJournalDal.Delete(academicJournal);
            return new SuccessResult(AcademicJournalConstants.DeleteSuccess);
        }

        public IResult ShadowDelete(Guid id)
        {
            AcademicJournal academicJournal = _academicJournalDal.Get(aj => aj.Id == id && !aj.IsDeleted);
            if (academicJournal == null)
                return new ErrorResult(AcademicJournalConstants.NotMatch);

            academicJournal.IsDeleted = false;
            _academicJournalDal.Update(academicJournal);
            return new SuccessResult(AcademicJournalConstants.EfDeletedSuccsess);
        }

        [ValidationAspect(typeof(AcademicJournalValidator), Priority = 1)]
        public IResult Update(AcademicJournal entity) // other service update add todo
        {
            IResult result = BusinessRules.Run(CheckIfAcademicJournalExists(entity));
            if (result != null)
                return result;
            _academicJournalDal.Update(entity);
            return new SuccessResult(AcademicJournalConstants.AddSuccess);
        }

        public IDataResult<List<AcademicJournal>> GetByAJNumber(ushort aJNumber)
        {
            List<AcademicJournal> academicJournals = _academicJournalDal.GetAll(aj => aj.AJNumber == aJNumber && !aj.IsDeleted).ToList();
            return academicJournals == null
                ? new ErrorDataResult<List<AcademicJournal>>(AcademicJournalConstants.DataNotGet)
                : new SuccessDataResult<List<AcademicJournal>>(academicJournals, AcademicJournalConstants.DataGet);
        }

        public IDataResult<List<AcademicJournal>> GetByCategories(int[] categoriesId)
        {
            IDataResult<List<Category>> categories = _categoryService.GetAllByFilter(c => categoriesId.Contains(c.Id));
            if (!categories.Success)
                return new ErrorDataResult<List<AcademicJournal>>(categories.Message);

            List<AcademicJournal> academicJournals = _academicJournalDal.GetAll(aj => categories.Data.Select(c => c.Id).Contains(aj.CategoryId) && !aj.IsDeleted).ToList();
            return academicJournals == null
                ? new ErrorDataResult<List<AcademicJournal>>(AcademicJournalConstants.DataNotGet)
                : new SuccessDataResult<List<AcademicJournal>>(academicJournals, AcademicJournalConstants.DataGet);
        }

        public IDataResult<List<AcademicJournal>> GetByDateOfYear(ushort dateOfYear)
        {
            List<AcademicJournal> academicJournals = _academicJournalDal.GetAll(aj => aj.DateOfYear == dateOfYear && !aj.IsDeleted).ToList();
            return academicJournals == null
                ? new ErrorDataResult<List<AcademicJournal>>(AcademicJournalConstants.DataNotGet)
                : new SuccessDataResult<List<AcademicJournal>>(academicJournals, AcademicJournalConstants.DataGet);
        }

        public IDataResult<List<AcademicJournal>> GetByDescriptionFinder(string finderString)
        {
            List<AcademicJournal> academicJournals = _academicJournalDal.GetAll(aj => aj.Description.Contains(finderString) && !aj.IsDeleted).ToList();
            return academicJournals == null
                ? new ErrorDataResult<List<AcademicJournal>>(AcademicJournalConstants.DataNotGet)
                : new SuccessDataResult<List<AcademicJournal>>(academicJournals, AcademicJournalConstants.DataGet);
        }

        public IDataResult<List<AcademicJournal>> GetByDimension(Guid dimensionId)
        {
            IDataResult<Dimension> dimension = _dimensionService.GetById(dimensionId);
            if (!dimension.Success)
                return new ErrorDataResult<List<AcademicJournal>>(dimension.Message);

            List<AcademicJournal> academicJournals = _academicJournalDal.GetAll(aj => aj.DimensionsId == dimensionId && !aj.IsDeleted).ToList();
            return academicJournals == null
                ? new ErrorDataResult<List<AcademicJournal>>(AcademicJournalConstants.DataNotGet)
                : new SuccessDataResult<List<AcademicJournal>>(academicJournals, AcademicJournalConstants.DataGet);
        }

        public IDataResult<List<AcademicJournal>> GetByEditor(Guid editorId)
        {
            IDataResult<Editor> editor = _editorService.GetById(editorId);
            if (!editor.Success)
                return new ErrorDataResult<List<AcademicJournal>>(editor.Message);

            List<AcademicJournal> academicJournals = _academicJournalDal.GetAll(aj => aj.EditorId == editorId && !aj.IsDeleted).ToList();
            return academicJournals == null
                ? new ErrorDataResult<List<AcademicJournal>>(AcademicJournalConstants.DataNotGet)
                : new SuccessDataResult<List<AcademicJournal>>(academicJournals, AcademicJournalConstants.DataGet);
        }

        public IDataResult<List<AcademicJournal>> GetByEditor(Guid[] editorIds)
        {
            IDataResult<List<Editor>> editors = _editorService.GetAllByFilter(e => editorIds.Contains(e.Id));
            if (!editors.Success)
                return new ErrorDataResult<List<AcademicJournal>>(AcademicJournalConstants.DataNotGet);

            List<AcademicJournal> academicJournals = _academicJournalDal.GetAll(aj => editors.Data.Select(e => e.Id).Contains(aj.EditorId) && !aj.IsDeleted).ToList();
            return academicJournals == null
                ? new ErrorDataResult<List<AcademicJournal>>(AcademicJournalConstants.DataNotGet)
                : new SuccessDataResult<List<AcademicJournal>>(academicJournals, AcademicJournalConstants.DataGet);
        }

        public IDataResult<List<AcademicJournal>> GetByEMFiles(Guid eMFilesId)
        {
            IDataResult<EMaterialFile> eMFiles = _eMaterialFileService.GetById(eMFilesId);
            if (!eMFiles.Success)
                return new ErrorDataResult<List<AcademicJournal>>(eMFiles.Message);

            List<AcademicJournal> academicJournals = _academicJournalDal.GetAll(aj => aj.EMaterialFilesId == eMFilesId && !aj.IsDeleted).ToList();
            return academicJournals == null
                ? new ErrorDataResult<List<AcademicJournal>>(AcademicJournalConstants.DataNotGet)
                : new SuccessDataResult<List<AcademicJournal>>(academicJournals, AcademicJournalConstants.DataGet);
        }

        public IDataResult<AcademicJournal> GetById(Guid id)
        {
            AcademicJournal academicJournal = _academicJournalDal.Get(aj => aj.Id == id);
            return academicJournal == null
                ? new ErrorDataResult<AcademicJournal>(AcademicJournalConstants.DataNotGet)
                : new SuccessDataResult<AcademicJournal>(academicJournal, AcademicJournalConstants.DataGet);
        }

        public IDataResult<List<AcademicJournal>> GetByIds(Guid[] ids)
        {
            List<AcademicJournal> academicJournals = _academicJournalDal.GetAll(aj => ids.Contains(aj.Id) && !aj.IsDeleted).ToList();
            return academicJournals.Count == 0
                ? new ErrorDataResult<List<AcademicJournal>>(AcademicJournalConstants.NotMatch)
                : new SuccessDataResult<List<AcademicJournal>>(academicJournals, AcademicJournalConstants.DataGet);
        }

        public IDataResult<List<AcademicJournal>> GetByNames(string name)
        {
            List<AcademicJournal> academicJournals = _academicJournalDal.GetAll(aj => aj.Name.Contains(name) && !aj.IsDeleted).ToList();
            return academicJournals.Count == 0
                ? new ErrorDataResult<List<AcademicJournal>>(AcademicJournalConstants.NotMatch)
                : new SuccessDataResult<List<AcademicJournal>>(academicJournals, AcademicJournalConstants.DataGet);
        }

        public IDataResult<List<AcademicJournal>> GetByPageRange(ushort startPage, ushort endPage)
        {
            List<AcademicJournal> academicJournals = _academicJournalDal.GetAll(aj => aj.StartPageNumber >= startPage && aj.EndPageNumber <= endPage && !aj.IsDeleted).ToList();
            return academicJournals.Count == 0
                ? new ErrorDataResult<List<AcademicJournal>>(AcademicJournalConstants.NotMatch)
                : new SuccessDataResult<List<AcademicJournal>>(academicJournals, AcademicJournalConstants.DataGet);
        }

        public IDataResult<List<AcademicJournal>> GetByPrice(decimal minPrice, decimal? maxPrice = null)
        {
            List<AcademicJournal> academicJournal = maxPrice == null
                ? _academicJournalDal.GetAll(aj => aj.Price >= minPrice && !aj.IsDeleted).ToList()
                : _academicJournalDal.GetAll(aj => aj.Price >= minPrice && aj.Price <= maxPrice && !aj.IsDeleted).ToList();

            return academicJournal.Count == 0
                ? new ErrorDataResult<List<AcademicJournal>>(AcademicJournalConstants.DataNotGet)
                : new SuccessDataResult<List<AcademicJournal>>(academicJournal, AcademicJournalConstants.DataGet);
        }

        public IDataResult<List<AcademicJournal>> GetByPublisher(Guid publisherId)
        {
            IDataResult<Publisher> publisher = _publisherService.GetById(publisherId);
            if (!publisher.Success)
                return new ErrorDataResult<List<AcademicJournal>>(publisher.Message);

            List<AcademicJournal> academicJournal = _academicJournalDal.GetAll(aj => aj.PublisherId == publisherId && !aj.IsDeleted).ToList();
            return academicJournal.Count == 0
                ? new ErrorDataResult<List<AcademicJournal>>(AcademicJournalConstants.DataNotGet)
                : new SuccessDataResult<List<AcademicJournal>>(academicJournal, AcademicJournalConstants.DataGet);
        }

        public IDataResult<List<AcademicJournal>> GetByPublisherDateOfPublication(DateTime DateOfPublication)
        {
            IDataResult<List<Publisher>> publishers = _publisherService.GetByDateOfPublication(DateOfPublication);
            if (!publishers.Success)
                return new ErrorDataResult<List<AcademicJournal>>(publishers.Message);

            List<AcademicJournal> academicJournal = _academicJournalDal.GetAll(aj => aj.Publishers == publishers.Data && !aj.IsDeleted).ToList();
            return academicJournal.Count == 0
                ? new ErrorDataResult<List<AcademicJournal>>(AcademicJournalConstants.DataNotGet)
                : new SuccessDataResult<List<AcademicJournal>>(academicJournal, AcademicJournalConstants.DataGet);
        }

        public IDataResult<List<AcademicJournal>> GetByReferenceDate(DateTime referenceDate)
        {
            IDataResult<List<Reference>> references = _referenceService.GetByReferenceDate(referenceDate);
            if (!references.Success)
                return new ErrorDataResult<List<AcademicJournal>>(references.Message);

            List<AcademicJournal> academicJournals = _academicJournalDal.GetAll(aj => aj.References == references.Data && !aj.IsDeleted).ToList();
            return academicJournals.Count == 0
                ? new ErrorDataResult<List<AcademicJournal>>(AcademicJournalConstants.DataNotGet)
                : new SuccessDataResult<List<AcademicJournal>>(academicJournals, AcademicJournalConstants.DataGet);
        }

        public IDataResult<List<AcademicJournal>> GetByReferenceId(Guid referenceId)
        {
            IDataResult<Reference> reference = _referenceService.GetById(referenceId);
            if (!reference.Success)
                return new ErrorDataResult<List<AcademicJournal>>(reference.Message);

            List<AcademicJournal> academicJournals = _academicJournalDal.GetAll(aj => aj.ReferenceId == referenceId && !aj.IsDeleted).ToList();
            return academicJournals != null
                ? new SuccessDataResult<List<AcademicJournal>>(academicJournals, AcademicJournalConstants.DataGet)
                : new ErrorDataResult<List<AcademicJournal>>(AcademicJournalConstants.DataNotGet);
        }

        public IDataResult<List<AcademicJournal>> GetByReferenceOwner(string owner)
        {
            IDataResult<List<Reference>> references = _referenceService.GetByOwner(owner);
            if (!references.Success)
                return new ErrorDataResult<List<AcademicJournal>>(references.Message);

            List<AcademicJournal> academicJournals = _academicJournalDal.GetAll(aj => aj.References == references.Data && !aj.IsDeleted).ToList();
            return academicJournals != null
                ? new SuccessDataResult<List<AcademicJournal>>(academicJournals, AcademicJournalConstants.DataGet)
                : new ErrorDataResult<List<AcademicJournal>>(AcademicJournalConstants.DataNotGet);
        }

        public IDataResult<List<AcademicJournal>> GetByResearcher(Guid researcherId)
        {
            IDataResult<Researcher> researcher = _researcherService.GetById(researcherId);
            if (!researcher.Success)
                return new ErrorDataResult<List<AcademicJournal>>(researcher.Message);

            List<AcademicJournal> _academicJournals = _academicJournalDal.GetAll(aj => aj.ResearcherId == researcherId && !aj.IsDeleted).ToList();
            return _academicJournals.Count == 0
                ? new ErrorDataResult<List<AcademicJournal>>(AcademicJournalConstants.NotMatch)
                : new SuccessDataResult<List<AcademicJournal>>(_academicJournals, AcademicJournalConstants.DataGet);
        }

        public IDataResult<List<AcademicJournal>> GetByResearcher(Guid[] researcherIds)
        {
            IDataResult<List<Researcher>> researchers = _researcherService.GetAllByFilter(r => researcherIds.Contains(r.Id));
            if (!researchers.Success)
                return new ErrorDataResult<List<AcademicJournal>>("Researcher not found");

            List<AcademicJournal> _academicJournals = _academicJournalDal.GetAll(aj => researcherIds.Contains(aj.ResearcherId) && !aj.IsDeleted).ToList();
            return _academicJournals.Count == 0
                ? new ErrorDataResult<List<AcademicJournal>>(AcademicJournalConstants.NotMatch)
                : new SuccessDataResult<List<AcademicJournal>>(_academicJournals, AcademicJournalConstants.DataGet);
        }

        public IDataResult<List<AcademicJournal>> GetByTechnicalPlaceholders(Guid technicalPlaceholderId)
        {
            IDataResult<TechnicalPlaceholder> technicalPlaceholder = _technicalPlaceholderService.GetById(technicalPlaceholderId);
            if (!technicalPlaceholder.Success)
                return new ErrorDataResult<List<AcademicJournal>>(technicalPlaceholder.Message);

            List<AcademicJournal> academicJournals = _academicJournalDal.GetAll(aj => aj.TechnicalPlaceholders == technicalPlaceholder.Data && !aj.IsDeleted).ToList();
            return academicJournals != null
                ? new SuccessDataResult<List<AcademicJournal>>(academicJournals, AcademicJournalConstants.DataGet)
                : new ErrorDataResult<List<AcademicJournal>>(AcademicJournalConstants.DataNotGet);
        }

        public IDataResult<List<AcademicJournal>> GetByTitles(string title)
        {
            List<AcademicJournal> _academicJournals = _academicJournalDal.GetAll(aj => aj.Title.Contains(title) && !aj.IsDeleted).ToList();
            return _academicJournals.Count == 0
                ? new ErrorDataResult<List<AcademicJournal>>(AcademicJournalConstants.NotMatch)
                : new SuccessDataResult<List<AcademicJournal>>(_academicJournals, AcademicJournalConstants.DataGet);
        }

        public IDataResult<List<AcademicJournal>> GetByVolume(ushort volume)
        {
            List<AcademicJournal> _academicJournals = _academicJournalDal.GetAll(aj => aj.Volume == volume && !aj.IsDeleted).ToList();
            return _academicJournals.Count == 0
                ? new ErrorDataResult<List<AcademicJournal>>(AcademicJournalConstants.NotMatch)
                : new SuccessDataResult<List<AcademicJournal>>(_academicJournals, AcademicJournalConstants.DataGet);
        }

        public IDataResult<byte?> GetSecretLevel(Guid id)
        {
            byte? sLevel = _academicJournalDal.Get(aj => aj.Id == id && !aj.IsDeleted).SecretLevel;
            return sLevel == null
                ? new ErrorDataResult<byte?>(AcademicJournalConstants.DataNotGet)
                : new SuccessDataResult<byte?>(sLevel, AcademicJournalConstants.DataGet);
        }

        public IDataResult<byte> GetState(Guid id)
        {
            return new SuccessDataResult<byte>(_academicJournalDal.Get(aj => aj.Id == id && !aj.IsDeleted).State, AcademicJournalConstants.DataGet);
        }

        public IDataResult<List<AcademicJournal>> GetAllByFilter(Expression<Func<AcademicJournal, bool>>? filter = null)
        {
            return new SuccessDataResult<List<AcademicJournal>>(_academicJournalDal.GetAll(filter).ToList(), AcademicJournalConstants.DataGet);
        }

        public IDataResult<List<AcademicJournal>> GetAllBySecrets()
        {
            return new SuccessDataResult<List<AcademicJournal>>(_academicJournalDal.GetAll(aj => aj.IsDeleted).ToList(), AcademicJournalConstants.DataGet);
        }

        public IDataResult<List<AcademicJournal>> GetAll()
        {
            return new SuccessDataResult<List<AcademicJournal>>(_academicJournalDal.GetAll(aj => !aj.IsDeleted).ToList(), AcademicJournalConstants.DataGet);
        }

        public IDataResult<AcademicJournal> GetByStock(Guid stockId)
        {
            IDataResult<Stock> stock = _stockService.GetById(stockId);
            if (!stock.Success)
                return new ErrorDataResult<AcademicJournal>(stock.Message);

            AcademicJournal academicJournals = _academicJournalDal.Get(aj => aj.Stock == stock.Data && !aj.IsDeleted);            
            return academicJournals != null
                ? new SuccessDataResult<AcademicJournal>(academicJournals, AcademicJournalConstants.DataGet)
                : new ErrorDataResult<AcademicJournal>(AcademicJournalConstants.DataNotGet);
        }

        private IResult CheckIfAcademicJournalExists(AcademicJournal academicJournal)
        {
            bool academicJournalControl = _academicJournalDal.Get(aj =>
            aj.Name == academicJournal.Name
            && aj.Title == academicJournal.Title
            && aj.Volume == academicJournal.Volume
            && aj.DateOfYear == academicJournal.DateOfYear
            && aj.ReferenceId == academicJournal.ReferenceId
            && aj.ResearcherId == academicJournal.ResearcherId
            && aj.Description.Contains(academicJournal.Description)
            && aj.SecretLevel == academicJournal.SecretLevel
            && aj.EditorId == academicJournal.EditorId
            && aj.CategoryId == academicJournal.CategoryId
            && aj.StartPageNumber == academicJournal.StartPageNumber
            && aj.EndPageNumber == academicJournal.EndPageNumber) != null;

            if (academicJournalControl)
                return new ErrorResult(AcademicJournalConstants.AlreadyExists);
            return new SuccessResult();
        }
    }
}
