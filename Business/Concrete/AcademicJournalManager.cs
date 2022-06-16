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
        private readonly IReferenceService _referenceService;
        private readonly IPublisherService _publisherService;
        private readonly IEMaterialFileService _eMaterialFileService;
        private readonly IEditorService _editorService;
        private readonly IResearcherService _researcherService;

        public AcademicJournalManager(IAcademicJournalDal academicJournalDal, IReferenceService referenceService, IPublisherService publisherService, IEMaterialFileService eMaterialFileService, IEditorService editorService, IResearcherService researcherService)
        {
            _academicJournalDal = academicJournalDal;
            _referenceService = referenceService;
            _publisherService = publisherService;
            _eMaterialFileService = eMaterialFileService;
            _editorService = editorService;
            _researcherService = researcherService;
        }

        [ValidationAspect(typeof(AcademicJournalValidator), Priority = 1)]
        public IResult Add(AcademicJournal entity)
        {
            IResult result = BusinessRules.Run(CheckIfAcademicJournalExists(entity));
            if (result != null)
                return result;
            entity.IsSecret = false;
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
            AcademicJournal academicJournal = _academicJournalDal.Get(aj => aj.Id == id && !aj.IsSecret);
            if (academicJournal == null)
                return new ErrorResult(AcademicJournalConstants.NotMatch);

            academicJournal.IsSecret = false;
            _academicJournalDal.Update(academicJournal);
            return new SuccessResult(AcademicJournalConstants.EfDeletedSuccsess);
        }

        [ValidationAspect(typeof(AcademicJournalValidator), Priority = 1)]
        public IResult Update(AcademicJournal entity)
        {
            IResult result = BusinessRules.Run(CheckIfAcademicJournalExists(entity));
            if (result != null)
                return result;
            _academicJournalDal.Update(entity);
            return new SuccessResult(AcademicJournalConstants.AddSuccess);
        }

        public IDataResult<List<AcademicJournal>> GetByAJNumber(ushort aJNumber)
        {
            List<AcademicJournal> academicJournals = _academicJournalDal.GetAll(aj => aj.AJNumber == aJNumber && !aj.IsSecret).ToList();
            return academicJournals == null
                ? new ErrorDataResult<List<AcademicJournal>>(AcademicJournalConstants.DataNotGet)
                : new SuccessDataResult<List<AcademicJournal>>(academicJournals, AcademicJournalConstants.DataGet);
        }

        public IDataResult<List<AcademicJournal>> GetByCategories(int[] categoriesId)
        {
            List<AcademicJournal> academicJournals = _academicJournalDal.GetAll(aj => categoriesId.Contains(aj.CategoryId) && !aj.IsSecret).ToList();
            return academicJournals == null
                ? new ErrorDataResult<List<AcademicJournal>>(AcademicJournalConstants.DataNotGet)
                : new SuccessDataResult<List<AcademicJournal>>(academicJournals, AcademicJournalConstants.DataGet);
        }

        public IDataResult<List<AcademicJournal>> GetByDateOfYear(ushort dateOfYear)
        {
            List<AcademicJournal> academicJournals = _academicJournalDal.GetAll(aj => aj.DateOfYear == dateOfYear && !aj.IsSecret).ToList();
            return academicJournals == null
                ? new ErrorDataResult<List<AcademicJournal>>(AcademicJournalConstants.DataNotGet)
                : new SuccessDataResult<List<AcademicJournal>>(academicJournals, AcademicJournalConstants.DataGet);
        }

        public IDataResult<List<AcademicJournal>> GetByDescriptionFinder(string finderString)
        {
            List<AcademicJournal> academicJournals = _academicJournalDal.GetAll(aj => aj.Description.Contains(finderString) && !aj.IsSecret).ToList();
            return academicJournals == null
                ? new ErrorDataResult<List<AcademicJournal>>(AcademicJournalConstants.DataNotGet)
                : new SuccessDataResult<List<AcademicJournal>>(academicJournals, AcademicJournalConstants.DataGet);
        }

        public IDataResult<List<AcademicJournal>> GetByDimension(Guid dimensionId)
        {
            List<AcademicJournal> academicJournals = _academicJournalDal.GetAll(aj => aj.DimensionsId == dimensionId && !aj.IsSecret).ToList();
            return academicJournals == null
                ? new ErrorDataResult<List<AcademicJournal>>(AcademicJournalConstants.DataNotGet)
                : new SuccessDataResult<List<AcademicJournal>>(academicJournals, AcademicJournalConstants.DataGet);
        }

        public IDataResult<List<AcademicJournal>> GetByEditor(Guid editorId)
        {
            IDataResult<Editor> editor = _editorService.GetById(editorId);
            if (!editor.Success)
                return new ErrorDataResult<List<AcademicJournal>>(editor.Message);

            List<AcademicJournal> academicJournals = _academicJournalDal.GetAll(aj => aj.EditorId == editorId && !aj.IsSecret).ToList();
            return academicJournals == null
                ? new ErrorDataResult<List<AcademicJournal>>(AcademicJournalConstants.DataNotGet)
                : new SuccessDataResult<List<AcademicJournal>>(academicJournals, AcademicJournalConstants.DataGet);
        }

        public IDataResult<List<AcademicJournal>> GetByEditor(Guid[] editorIds)
        {
            IDataResult<List<Editor>> editors = _editorService.GetAllByFilter(e => editorIds.Contains(e.Id));
            if (!editors.Success)
                return new ErrorDataResult<List<AcademicJournal>>(AcademicJournalConstants.DataNotGet);

            List<AcademicJournal> academicJournals = _academicJournalDal.GetAll(aj => editors.Data.Select(e => e.Id).Contains(aj.EditorId) && !aj.IsSecret).ToList();
            return academicJournals == null
                ? new ErrorDataResult<List<AcademicJournal>>(AcademicJournalConstants.DataNotGet)
                : new SuccessDataResult<List<AcademicJournal>>(academicJournals, AcademicJournalConstants.DataGet);
        }

        public IDataResult<List<AcademicJournal>> GetByEMFiles(Guid eMFilesId)
        {
            IDataResult<EMaterialFile> eMFiles = _eMaterialFileService.GetById(eMFilesId);
            if (!eMFiles.Success)
                return new ErrorDataResult<List<AcademicJournal>>(eMFiles.Message);

            List<AcademicJournal> academicJournals = _academicJournalDal.GetAll(aj => aj.EMaterialFilesId == eMFilesId && !aj.IsSecret).ToList();
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

        public IDataResult<List<AcademicJournal>> GetByNames(string name)
        {
            List<AcademicJournal> academicJournals = _academicJournalDal.GetAll(aj => aj.Name.Contains(name) && !aj.IsSecret).ToList();
            return academicJournals.Count == 0
                ? new ErrorDataResult<List<AcademicJournal>>(AcademicJournalConstants.NotMatch)
                : new SuccessDataResult<List<AcademicJournal>>(academicJournals, AcademicJournalConstants.DataGet);
        }

        public IDataResult<List<AcademicJournal>> GetByPageRange(ushort startPage, ushort endPage)
        {
            List<AcademicJournal> academicJournals = _academicJournalDal.GetAll(aj => aj.StartPageNumber >= startPage && aj.EndPageNumber <= endPage && !aj.IsSecret).ToList();
            return academicJournals.Count == 0
                ? new ErrorDataResult<List<AcademicJournal>>(AcademicJournalConstants.NotMatch)
                : new SuccessDataResult<List<AcademicJournal>>(academicJournals, AcademicJournalConstants.DataGet);
        }

        public IDataResult<List<AcademicJournal>> GetByPrice(decimal minPrice, decimal? maxPrice = null)
        {
            List<AcademicJournal> academicJournal = maxPrice == null
                ? _academicJournalDal.GetAll(aj => aj.Price >= minPrice && !aj.IsSecret).ToList()
                : _academicJournalDal.GetAll(aj => aj.Price >= minPrice && aj.Price <= maxPrice && !aj.IsSecret).ToList();

            return academicJournal.Count == 0
                ? new ErrorDataResult<List<AcademicJournal>>(AcademicJournalConstants.DataNotGet)
                : new SuccessDataResult<List<AcademicJournal>>(academicJournal, AcademicJournalConstants.DataGet);
        }

        public IDataResult<List<AcademicJournal>> GetByPublisher(Guid publisherId)
        {
            IDataResult<Publisher> publisher = _publisherService.GetById(publisherId);
            if (!publisher.Success)
                return new ErrorDataResult<List<AcademicJournal>>(publisher.Message);

            List<AcademicJournal> academicJournal = _academicJournalDal.GetAll(aj => aj.PublisherId == publisherId && !aj.IsSecret).ToList();
            return academicJournal.Count == 0
                ? new ErrorDataResult<List<AcademicJournal>>(AcademicJournalConstants.DataNotGet)
                : new SuccessDataResult<List<AcademicJournal>>(academicJournal, AcademicJournalConstants.DataGet);
        }

        public IDataResult<List<AcademicJournal>> GetByPublisherDateOfPublication(DateTime DateOfPublication)
        {
            IDataResult<List<Publisher>> publishers = _publisherService.GetByDateOfPublication(DateOfPublication);
            if (!publishers.Success)
                return new ErrorDataResult<List<AcademicJournal>>(publishers.Message);

            List<AcademicJournal> academicJournal = _academicJournalDal.GetAll(aj => aj.Publishers == publishers.Data && !aj.IsSecret).ToList();
            return academicJournal.Count == 0
                ? new ErrorDataResult<List<AcademicJournal>>(AcademicJournalConstants.DataNotGet)
                : new SuccessDataResult<List<AcademicJournal>>(academicJournal, AcademicJournalConstants.DataGet);
        }

        public IDataResult<List<AcademicJournal>> GetByReferenceDate(DateTime referenceDate)
        {
            IDataResult<List<Reference>> references = _referenceService.GetByReferenceDate(referenceDate);
            if (!references.Success)
                return new ErrorDataResult<List<AcademicJournal>>(references.Message);

            List<AcademicJournal> academicJournals = _academicJournalDal.GetAll(aj => aj.References == references.Data && !aj.IsSecret).ToList();
            return academicJournals.Count == 0
                ? new ErrorDataResult<List<AcademicJournal>>(AcademicJournalConstants.DataNotGet)
                : new SuccessDataResult<List<AcademicJournal>>(academicJournals, AcademicJournalConstants.DataGet);
        }

        public IDataResult<List<AcademicJournal>> GetByReferenceId(Guid referenceId)
        {
            IDataResult<Reference> reference = _referenceService.GetById(referenceId);
            if (!reference.Success)
                return new ErrorDataResult<List<AcademicJournal>>(reference.Message);

            List<AcademicJournal> academicJournals = _academicJournalDal.GetAll(aj => aj.ReferenceId == referenceId && !aj.IsSecret).ToList();
            return academicJournals != null
                ? new SuccessDataResult<List<AcademicJournal>>(academicJournals, AcademicJournalConstants.DataGet)
                : new ErrorDataResult<List<AcademicJournal>>(AcademicJournalConstants.DataNotGet);
        }

        public IDataResult<List<AcademicJournal>> GetByReferenceOwner(string owner)
        {
            IDataResult<List<Reference>> references = _referenceService.GetByOwner(owner);
            if (!references.Success)
                return new ErrorDataResult<List<AcademicJournal>>(references.Message);

            List<AcademicJournal> academicJournals = _academicJournalDal.GetAll(aj => aj.References == references.Data && !aj.IsSecret).ToList();
            return academicJournals != null
                ? new SuccessDataResult<List<AcademicJournal>>(academicJournals, AcademicJournalConstants.DataGet)
                : new ErrorDataResult<List<AcademicJournal>>(AcademicJournalConstants.DataNotGet);
        }

        public IDataResult<List<AcademicJournal>> GetByResearcher(Guid researcherId)
        {
            IDataResult<Researcher> researcher = _researcherService.GetById(researcherId);
            if (!researcher.Success)
                return new ErrorDataResult<List<AcademicJournal>>(researcher.Message);

            List<AcademicJournal> _academicJournals = _academicJournalDal.GetAll(aj => aj.ResearcherId == researcherId && !aj.IsSecret).ToList();
            return _academicJournals.Count == 0
                ? new ErrorDataResult<List<AcademicJournal>>(AcademicJournalConstants.NotMatch)
                : new SuccessDataResult<List<AcademicJournal>>(_academicJournals, AcademicJournalConstants.DataGet);
        }

        public IDataResult<List<AcademicJournal>> GetByResearcher(Guid[] researcherIds)
        {
            IDataResult<List<Researcher>> researchers = _researcherService.GetAllByFilter(r => researcherIds.Contains(r.Id));
            if (!researchers.Success)
                return new ErrorDataResult<List<AcademicJournal>>("Researcher not found");

            List<AcademicJournal> _academicJournals = _academicJournalDal.GetAll(aj => researcherIds.Contains(aj.ResearcherId) && !aj.IsSecret).ToList();
            return _academicJournals.Count == 0
                ? new ErrorDataResult<List<AcademicJournal>>(AcademicJournalConstants.NotMatch)
                : new SuccessDataResult<List<AcademicJournal>>(_academicJournals, AcademicJournalConstants.DataGet);
        }

        public IDataResult<List<AcademicJournal>> GetByTitles(string title)
        {
            List<AcademicJournal> _academicJournals = _academicJournalDal.GetAll(aj => aj.Title.Contains(title) && !aj.IsSecret).ToList();
            return _academicJournals.Count == 0
                ? new ErrorDataResult<List<AcademicJournal>>(AcademicJournalConstants.NotMatch)
                : new SuccessDataResult<List<AcademicJournal>>(_academicJournals, AcademicJournalConstants.DataGet);
        }

        public IDataResult<List<AcademicJournal>> GetByVolume(ushort volume)
        {
            List<AcademicJournal> _academicJournals = _academicJournalDal.GetAll(aj => aj.Volume == volume && !aj.IsSecret).ToList();
            return _academicJournals.Count == 0
                ? new ErrorDataResult<List<AcademicJournal>>(AcademicJournalConstants.NotMatch)
                : new SuccessDataResult<List<AcademicJournal>>(_academicJournals, AcademicJournalConstants.DataGet);
        }

        public IDataResult<byte?> GetSecretLevel(Guid id)
        {
            AcademicJournal academicJournal = _academicJournalDal.Get(aj => aj.Id == id && !aj.IsSecret);

            return academicJournal == null
                ? new ErrorDataResult<byte?>(AcademicJournalConstants.DataNotGet)
                : new SuccessDataResult<byte?>(academicJournal.SecretLevel, AcademicJournalConstants.DataGet);
        }

        public IDataResult<byte> GetState(Guid id)
        {
            AcademicJournal academicJournal = _academicJournalDal.Get(aj => aj.Id == id && !aj.IsSecret);
            return academicJournal == null
                ? new ErrorDataResult<byte>(AcademicJournalConstants.DataNotGet)
                : new SuccessDataResult<byte>(academicJournal.State, AcademicJournalConstants.DataGet);
        }

        public IDataResult<List<AcademicJournal>> GetAllByFilter(Expression<Func<AcademicJournal, bool>>? filter = null)
        {
            return new SuccessDataResult<List<AcademicJournal>>(_academicJournalDal.GetAll(filter).ToList(), AcademicJournalConstants.DataGet);
        }

        public IDataResult<List<AcademicJournal>> GetAllBySecrets()
        {
            return new SuccessDataResult<List<AcademicJournal>>(_academicJournalDal.GetAll(aj => aj.IsSecret).ToList(), AcademicJournalConstants.DataGet);
        }

        public IDataResult<List<AcademicJournal>> GetAll()
        {
            return new SuccessDataResult<List<AcademicJournal>>(_academicJournalDal.GetAll(aj => !aj.IsSecret).ToList(), AcademicJournalConstants.DataGet);
        }

        private IResult CheckIfAcademicJournalExists(AcademicJournal academicJournal)
        {
            AcademicJournal academicJournalControl = _academicJournalDal.Get(aj =>
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
            && aj.State == academicJournal.State
            && aj.StartPageNumber == academicJournal.StartPageNumber
            && aj.EndPageNumber == academicJournal.EndPageNumber);

            if (academicJournalControl != null)
                return new ErrorResult(AcademicJournalConstants.AlreadyExists);
            return new SuccessResult();
        }
    }
}
