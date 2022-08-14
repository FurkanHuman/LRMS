using Business.Abstract;
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
    public class AcademicJournalManager : IAcademicJournalService
    {
        private readonly IAcademicJournalDal _academicJournalDal;
        private readonly IFacadeService _facadeService;

        public AcademicJournalManager(IAcademicJournalDal academicJournalDal)
        {
            _academicJournalDal = academicJournalDal;
        }

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
            return new SuccessResult(AcademicJournalConstants.UpdateSuccess);
        }

        public IDataResult<IList<AcademicJournal>> GetAllByAJNumber(ushort aJNumber)
        {
            IList<AcademicJournal> academicJournals = _academicJournalDal.GetAll(aj => aj.AJNumber == aJNumber && !aj.IsDeleted);
            return academicJournals == null
                ? new ErrorDataResult<IList<AcademicJournal>>(AcademicJournalConstants.DataNotGet)
                : new SuccessDataResult<IList<AcademicJournal>>(academicJournals, AcademicJournalConstants.DataGet);
        }

        public IDataResult<IList<AcademicJournal>> GetAllByCategories(int[] categoriesId)
        {
            IDataResult<IList<Category>> categories = _facadeService.CategoryService().GetAllByIds(categoriesId);
            if (!categories.Success)
                return new ErrorDataResult<IList<AcademicJournal>>(categories.Message);

            IList<AcademicJournal> academicJournals = _academicJournalDal.GetAll(aj => categories.Data.Select(c => c.Id).Contains(aj.CategoryId) && !aj.IsDeleted);
            return academicJournals == null
                ? new ErrorDataResult<IList<AcademicJournal>>(AcademicJournalConstants.DataNotGet)
                : new SuccessDataResult<IList<AcademicJournal>>(academicJournals, AcademicJournalConstants.DataGet);
        }

        public IDataResult<IList<AcademicJournal>> GetAllByDateOfYear(ushort dateOfYear)
        {
            IList<AcademicJournal> academicJournals = _academicJournalDal.GetAll(aj => aj.DateOfYear == dateOfYear && !aj.IsDeleted);
            return academicJournals == null
                ? new ErrorDataResult<IList<AcademicJournal>>(AcademicJournalConstants.DataNotGet)
                : new SuccessDataResult<IList<AcademicJournal>>(academicJournals, AcademicJournalConstants.DataGet);
        }

        public IDataResult<IList<AcademicJournal>> GetAllByDescriptionFinder(string finderString)
        {
            IList<AcademicJournal> academicJournals = _academicJournalDal.GetAll(aj => aj.Description.Contains(finderString) && !aj.IsDeleted);
            return academicJournals == null
                ? new ErrorDataResult<IList<AcademicJournal>>(AcademicJournalConstants.DataNotGet)
                : new SuccessDataResult<IList<AcademicJournal>>(academicJournals, AcademicJournalConstants.DataGet);
        }

        public IDataResult<IList<AcademicJournal>> GetAllByDimension(Guid dimensionId)
        {
            IDataResult<Dimension> dimension = _facadeService.DimensionService().GetById(dimensionId);

            if (!dimension.Success)
                return new ErrorDataResult<IList<AcademicJournal>>(dimension.Message);

            IList<AcademicJournal> academicJournals = _academicJournalDal.GetAll(aj => aj.DimensionsId == dimensionId && !aj.IsDeleted);
            return academicJournals == null
                ? new ErrorDataResult<IList<AcademicJournal>>(AcademicJournalConstants.DataNotGet)
                : new SuccessDataResult<IList<AcademicJournal>>(academicJournals, AcademicJournalConstants.DataGet);
        }

        public IDataResult<IList<AcademicJournal>> GetAllByEditor(Guid editorId)
        {
            IDataResult<Editor> editor = _facadeService.EditorService().GetById(editorId);
            if (!editor.Success)
                return new ErrorDataResult<IList<AcademicJournal>>(editor.Message);

            IList<AcademicJournal> academicJournals = _academicJournalDal.GetAll(aj => aj.EditorId == editorId && !aj.IsDeleted);
            return academicJournals == null
                ? new ErrorDataResult<IList<AcademicJournal>>(AcademicJournalConstants.DataNotGet)
                : new SuccessDataResult<IList<AcademicJournal>>(academicJournals, AcademicJournalConstants.DataGet);
        }

        public IDataResult<IList<AcademicJournal>> GetAllByEditors(Guid[] editorIds)
        {
            IDataResult<IList<Editor>> editors = _facadeService.EditorService().GetAllByIds(editorIds);
            if (!editors.Success)
                return new ErrorDataResult<IList<AcademicJournal>>(AcademicJournalConstants.DataNotGet);

            IList<AcademicJournal> academicJournals = _academicJournalDal.GetAll(aj => editors.Data.Select(e => e.Id).Contains(aj.EditorId) && !aj.IsDeleted);
            return academicJournals == null
                ? new ErrorDataResult<IList<AcademicJournal>>(AcademicJournalConstants.DataNotGet)
                : new SuccessDataResult<IList<AcademicJournal>>(academicJournals, AcademicJournalConstants.DataGet);
        }

        public IDataResult<IList<AcademicJournal>> GetAllByEMFile(Guid eMFileId)
        {
            IDataResult<EMaterialFile> eMFiles = _facadeService.EMaterialFileService().GetById(eMFileId);
            if (!eMFiles.Success)
                return new ErrorDataResult<IList<AcademicJournal>>(eMFiles.Message);

            IList<AcademicJournal> academicJournals = _academicJournalDal.GetAll(aj => aj.EMaterialFilesId == eMFileId && !aj.IsDeleted);
            return academicJournals == null
                ? new ErrorDataResult<IList<AcademicJournal>>(AcademicJournalConstants.DataNotGet)
                : new SuccessDataResult<IList<AcademicJournal>>(academicJournals, AcademicJournalConstants.DataGet);
        }

        public IDataResult<AcademicJournal> GetById(Guid id)
        {
            AcademicJournal academicJournal = _academicJournalDal.Get(aj => aj.Id == id);
            _facadeService.CounterService().Count(academicJournal);
            return academicJournal == null
                ? new ErrorDataResult<AcademicJournal>(AcademicJournalConstants.DataNotGet)
                : new SuccessDataResult<AcademicJournal>(academicJournal, AcademicJournalConstants.DataGet);
        }

        public IDataResult<IList<AcademicJournal>> GetAllByIds(Guid[] ids)
        {
            IList<AcademicJournal> academicJournals = _academicJournalDal.GetAll(aj => ids.Contains(aj.Id) && !aj.IsDeleted);
            _facadeService.CounterService().Count(academicJournals);
            return academicJournals.Count == 0
                ? new ErrorDataResult<IList<AcademicJournal>>(AcademicJournalConstants.NotMatch)
                : new SuccessDataResult<IList<AcademicJournal>>(academicJournals, AcademicJournalConstants.DataGet);
        }

        public IDataResult<IList<AcademicJournal>> GetAllByName(string name)
        {
            IList<AcademicJournal> academicJournals = _academicJournalDal.GetAll(aj => aj.Name.Contains(name) && !aj.IsDeleted);
            return academicJournals.Count == 0
                ? new ErrorDataResult<IList<AcademicJournal>>(AcademicJournalConstants.NotMatch)
                : new SuccessDataResult<IList<AcademicJournal>>(academicJournals, AcademicJournalConstants.DataGet);
        }

        public IDataResult<IList<AcademicJournal>> GetAllByPageRange(ushort startPage, ushort endPage)
        {
            IList<AcademicJournal> academicJournals = _academicJournalDal.GetAll(aj => aj.StartPageNumber >= startPage && aj.EndPageNumber <= endPage && !aj.IsDeleted);
            return academicJournals.Count == 0
                ? new ErrorDataResult<IList<AcademicJournal>>(AcademicJournalConstants.NotMatch)
                : new SuccessDataResult<IList<AcademicJournal>>(academicJournals, AcademicJournalConstants.DataGet);
        }

        public IDataResult<IList<AcademicJournal>> GetAllByPrice(decimal minPrice, decimal? maxPrice = null)
        {
            IList<AcademicJournal> academicJournal = maxPrice == null
                ? _academicJournalDal.GetAll(aj => aj.Price >= minPrice && !aj.IsDeleted)
                : _academicJournalDal.GetAll(aj => aj.Price >= minPrice && aj.Price <= maxPrice && !aj.IsDeleted);

            return academicJournal.Count == 0
                ? new ErrorDataResult<IList<AcademicJournal>>(AcademicJournalConstants.DataNotGet)
                : new SuccessDataResult<IList<AcademicJournal>>(academicJournal, AcademicJournalConstants.DataGet);
        }

        public IDataResult<IList<AcademicJournal>> GetAllByPublisher(Guid publisherId)
        {
            IDataResult<Publisher> publisher = _facadeService.PublisherService().GetById(publisherId);
            if (!publisher.Success)
                return new ErrorDataResult<IList<AcademicJournal>>(publisher.Message);

            IList<AcademicJournal> academicJournal = _academicJournalDal.GetAll(aj => aj.PublisherId == publisherId && !aj.IsDeleted);
            return academicJournal.Count == 0
                ? new ErrorDataResult<IList<AcademicJournal>>(AcademicJournalConstants.DataNotGet)
                : new SuccessDataResult<IList<AcademicJournal>>(academicJournal, AcademicJournalConstants.DataGet);
        }

        public IDataResult<IList<AcademicJournal>> GetAllByPublisherDateOfPublication(DateTime DateOfPublication)
        {
            IDataResult<IList<Publisher>> publishers = _facadeService.PublisherService().GetAllByDateOfPublication(DateOfPublication);
            if (!publishers.Success)
                return new ErrorDataResult<IList<AcademicJournal>>(publishers.Message);

            IList<AcademicJournal> academicJournal = _academicJournalDal.GetAll(aj => aj.Publishers == publishers.Data && !aj.IsDeleted);
            return academicJournal.Count == 0
                ? new ErrorDataResult<IList<AcademicJournal>>(AcademicJournalConstants.DataNotGet)
                : new SuccessDataResult<IList<AcademicJournal>>(academicJournal, AcademicJournalConstants.DataGet);
        }

        public IDataResult<IList<AcademicJournal>> GetAllByReferenceDate(DateTime referenceDate)
        {
            IDataResult<IList<Reference>> references = _facadeService.ReferenceService().GetAllByReferenceDate(referenceDate);
            if (!references.Success)
                return new ErrorDataResult<IList<AcademicJournal>>(references.Message);

            IList<AcademicJournal> academicJournals = _academicJournalDal.GetAll(aj => aj.References == references.Data && !aj.IsDeleted);
            return academicJournals.Count == 0
                ? new ErrorDataResult<IList<AcademicJournal>>(AcademicJournalConstants.DataNotGet)
                : new SuccessDataResult<IList<AcademicJournal>>(academicJournals, AcademicJournalConstants.DataGet);
        }

        public IDataResult<IList<AcademicJournal>> GetAllByReferenceId(Guid referenceId)
        {
            IDataResult<Reference> reference = _facadeService.ReferenceService().GetById(referenceId);
            if (!reference.Success)
                return new ErrorDataResult<IList<AcademicJournal>>(reference.Message);

            IList<AcademicJournal> academicJournals = _academicJournalDal.GetAll(aj => aj.ReferenceId == referenceId && !aj.IsDeleted);
            return academicJournals != null
                ? new SuccessDataResult<IList<AcademicJournal>>(academicJournals, AcademicJournalConstants.DataGet)
                : new ErrorDataResult<IList<AcademicJournal>>(AcademicJournalConstants.DataNotGet);
        }

        public IDataResult<IList<AcademicJournal>> GetAllByReferenceOwner(string owner)
        {
            IDataResult<IList<Reference>> references = _facadeService.ReferenceService().GetAllByOwner(owner);
            if (!references.Success)
                return new ErrorDataResult<IList<AcademicJournal>>(references.Message);

            IList<AcademicJournal> academicJournals = _academicJournalDal.GetAll(aj => aj.References == references.Data && !aj.IsDeleted);
            return academicJournals != null
                ? new SuccessDataResult<IList<AcademicJournal>>(academicJournals, AcademicJournalConstants.DataGet)
                : new ErrorDataResult<IList<AcademicJournal>>(AcademicJournalConstants.DataNotGet);
        }

        public IDataResult<IList<AcademicJournal>> GetAllByResearcher(Guid researcherId)
        {
            IDataResult<Researcher> researcher = _facadeService.ResearcherService().GetById(researcherId);
            if (!researcher.Success)
                return new ErrorDataResult<IList<AcademicJournal>>(researcher.Message);

            IList<AcademicJournal> _academicJournals = _academicJournalDal.GetAll(aj => aj.ResearcherId == researcherId && !aj.IsDeleted);
            return _academicJournals.Count == 0
                ? new ErrorDataResult<IList<AcademicJournal>>(AcademicJournalConstants.NotMatch)
                : new SuccessDataResult<IList<AcademicJournal>>(_academicJournals, AcademicJournalConstants.DataGet);
        }

        public IDataResult<IList<AcademicJournal>> GetAllByResearchers(Guid[] researcherIds)
        {
            IDataResult<IList<Researcher>> researchers = _facadeService.ResearcherService().GetAllByIds(researcherIds);
            if (!researchers.Success)
                return new ErrorDataResult<IList<AcademicJournal>>("Researcher not found");

            IList<AcademicJournal> _academicJournals = _academicJournalDal.GetAll(aj => researcherIds.Contains(aj.ResearcherId) && !aj.IsDeleted);
            return _academicJournals.Count == 0
                ? new ErrorDataResult<IList<AcademicJournal>>(AcademicJournalConstants.NotMatch)
                : new SuccessDataResult<IList<AcademicJournal>>(_academicJournals, AcademicJournalConstants.DataGet);
        }

        public IDataResult<IList<AcademicJournal>> GetAllByTechnicalPlaceholder(Guid technicalPlaceholderId)
        {
            IDataResult<TechnicalPlaceholder> technicalPlaceholder = _facadeService.TechnicalPlaceholderService().GetById(technicalPlaceholderId);
            if (!technicalPlaceholder.Success)
                return new ErrorDataResult<IList<AcademicJournal>>(technicalPlaceholder.Message);

            IList<AcademicJournal> academicJournals = _academicJournalDal.GetAll(aj => aj.TechnicalPlaceholders == technicalPlaceholder.Data && !aj.IsDeleted);
            return academicJournals != null
                ? new SuccessDataResult<IList<AcademicJournal>>(academicJournals, AcademicJournalConstants.DataGet)
                : new ErrorDataResult<IList<AcademicJournal>>(AcademicJournalConstants.DataNotGet);
        }

        public IDataResult<IList<AcademicJournal>> GetAllByTitle(string title)
        {
            IList<AcademicJournal> _academicJournals = _academicJournalDal.GetAll(aj => aj.Title.Contains(title) && !aj.IsDeleted);
            return _academicJournals.Count == 0
                ? new ErrorDataResult<IList<AcademicJournal>>(AcademicJournalConstants.NotMatch)
                : new SuccessDataResult<IList<AcademicJournal>>(_academicJournals, AcademicJournalConstants.DataGet);
        }

        public IDataResult<IList<AcademicJournal>> GetAllByVolume(ushort volume)
        {
            IList<AcademicJournal> _academicJournals = _academicJournalDal.GetAll(aj => aj.Volume == volume && !aj.IsDeleted);
            return _academicJournals.Count == 0
                ? new ErrorDataResult<IList<AcademicJournal>>(AcademicJournalConstants.NotMatch)
                : new SuccessDataResult<IList<AcademicJournal>>(_academicJournals, AcademicJournalConstants.DataGet);
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

        public IDataResult<IList<AcademicJournal>> GetAllByFilter(Expression<Func<AcademicJournal, bool>>? filter = null)
        {
            return new SuccessDataResult<IList<AcademicJournal>>(_academicJournalDal.GetAll(filter), AcademicJournalConstants.DataGet);
        }

        public IDataResult<IList<AcademicJournal>> GetAllByIsDeleted()
        {
            return new SuccessDataResult<IList<AcademicJournal>>(_academicJournalDal.GetAll(aj => aj.IsDeleted), AcademicJournalConstants.DataGet);
        }

        public IDataResult<IList<AcademicJournal>> GetAll()
        {
            return new SuccessDataResult<IList<AcademicJournal>>(_academicJournalDal.GetAll(aj => !aj.IsDeleted), AcademicJournalConstants.DataGet);
        }

        public IDataResult<AcademicJournal> GetByStock(Guid stockId)
        {
            IDataResult<Stock> stock = _facadeService.StockService().GetById(stockId);
            if (!stock.Success)
                return new ErrorDataResult<AcademicJournal>(stock.Message);

            AcademicJournal academicJournal = _academicJournalDal.Get(aj => aj.Stock == stock.Data && !aj.IsDeleted);
            _facadeService.CounterService().Count(academicJournal);
            return academicJournal != null
                ? new SuccessDataResult<AcademicJournal>(academicJournal, AcademicJournalConstants.DataGet)
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
