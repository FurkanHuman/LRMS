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
    public class BookManager : IBookService
    {
        private readonly IBookDal _bookDal;//  Todo: servisleri yazmayı unutma
        private readonly ICategoryService _categoryService;
        private readonly ITechnicalPlaceholderService _technicalPlaceholder;
        private readonly IEditionService _editionService;
        private readonly IDimensionService _dimensionService;
        private readonly IEMaterialFileService _eMaterialFile;
        private readonly ICoverCapService _coverCapService;
        private readonly IImageService _imageService;
        private readonly IWriterService _writerService;
        private readonly IEditorService _editorService;
        private readonly IDirectorService _directorService;
        private readonly IGraphicDesignerService _graphicDesignerService;
        private readonly IGraphicDirectorService _graphicDirectorService;
        private readonly IInterpretersService _interpreterService;
        private readonly IRedactionService _redactionService;
        private readonly ITechnicalNumberService _technicalNumberService;
        private readonly IReferenceService _referenceService;

        [ValidationAspect(typeof(BookValidator))]
        public IResult Add(Book entity) // todo: adding fix later.
        {
            IResult result = BusinessRules.Run(CheckIfBookControl(entity));
            if (result != null)
                return result;

            entity.IsDeleted = false;
            _bookDal.Add(entity);
            return new SuccessResult(BookConstants.AddSuccess);
        }

        public IResult Delete(Guid id)
        {
            Book book = _bookDal.Get(b => b.Id == id);
            if (book == null)
                return new ErrorResult(BookConstants.NotMatch);

            _bookDal.Delete(book);
            return new SuccessResult(BookConstants.EfDeletedSuccsess);
        }

        public IResult ShadowDelete(Guid id)
        {
            Book book = _bookDal.Get(b => b.Id == id && !b.IsDeleted);
            if (book == null)
                return new ErrorResult(BookConstants.NotMatch);

            book.IsDeleted = true;
            _bookDal.Update(book);
            return new SuccessResult(BookConstants.EfDeletedSuccsess);
        }

        [ValidationAspect(typeof(BookValidator))]
        public IResult Update(Book entity) // todo: update fix later.
        {
            IResult result = BusinessRules.Run(CheckIfBookControl(entity));
            if (result != null)
                return new ErrorResult(result.Message);

            entity.IsDeleted = false;
            _bookDal.Update(entity);
            return new SuccessResult(BookConstants.UpdateSuccess);
        }

        public IDataResult<Book> GetById(Guid id)
        {
            Book book = _bookDal.Get(b => b.Id == id);
            return book == null
                ? new ErrorDataResult<Book>(BookConstants.BookNotFound)
                : new SuccessDataResult<Book>(book, BookConstants.DataGet);
        }

        public IDataResult<List<Book>> GetAll()
        {
            return new SuccessDataResult<List<Book>>(_bookDal.GetAll(b => !b.IsDeleted).ToList(), BookConstants.DataGet);
        }

        public IDataResult<List<Book>> GetAllByFilter(Expression<Func<Book, bool>>? filter = null)
        {
            return new SuccessDataResult<List<Book>>(_bookDal.GetAll(filter).ToList(), BookConstants.DataGet);
        }

        public IDataResult<List<Book>> GetAllBySecrets()
        {
            return new SuccessDataResult<List<Book>>(_bookDal.GetAll(b => b.IsDeleted).ToList(), BookConstants.DataGet);
        }

        public IDataResult<List<Book>> GetByOriginalBookName(string originalBookName)
        {
            List<Book> books = _bookDal.GetAll(b => b.OriginalBookName.Contains(originalBookName) && !b.IsDeleted).ToList();
            return books == null
                ? new ErrorDataResult<List<Book>>(BookConstants.DataNotGet)
                : new SuccessDataResult<List<Book>>(books, BookConstants.DataGet);
        }

        public IDataResult<List<Book>> GetByReferences(Guid referenceId)
        {
            IDataResult<Reference> reference = _referenceService.GetById(referenceId);
            if (!reference.Success)
                return new ErrorDataResult<List<Book>>(reference.Message);

            List<Book> books = _bookDal.GetAll(b => b.ReferenceId == referenceId && !b.IsDeleted).ToList();
            return books == null
                ? new ErrorDataResult<List<Book>>(BookConstants.DataNotGet)
                : new SuccessDataResult<List<Book>>(books, BookConstants.DataGet);
        }

        public IDataResult<Book> GetByCoverImage(Guid cImageId)
        {
            IDataResult<Image> coverImage = _imageService.GetById(cImageId);
            if (!coverImage.Success)
                return new ErrorDataResult<Book>(coverImage.Message);

            Book book = _bookDal.Get(b => b.CoverImageId == cImageId && !b.IsDeleted);
            return book == null
                ? new ErrorDataResult<Book>(BookConstants.DataNotGet)
                : new SuccessDataResult<Book>(book, BookConstants.DataGet);
        }

        public IDataResult<List<Book>> GetByCoverCaps(byte coverCapNum)
        {
            IDataResult<CoverCap> covercap = _coverCapService.GetById(coverCapNum);
            if (!covercap.Success)
                return new ErrorDataResult<List<Book>>(covercap.Message);

            List<Book> books = _bookDal.GetAll(b => b.CoverCapId == coverCapNum && !b.IsDeleted).ToList();
            return books == null
                ? new ErrorDataResult<List<Book>>(BookConstants.DataNotGet)
                : new SuccessDataResult<List<Book>>(books, BookConstants.DataGet);
        }

        public IDataResult<List<Book>> GetByCommunications(Guid communicationId)
        {
            IDataResult<Edition> edition = _editionService.GetByCommunicationId(communicationId);
            if (!edition.Success)
                return new ErrorDataResult<List<Book>>(edition.Message);

            List<Book> books = _bookDal.GetAll(b => b.EditionId == edition.Data.Id && !b.IsDeleted).ToList();
            return books == null
                ? new ErrorDataResult<List<Book>>(BookConstants.DataNotGet)
                : new SuccessDataResult<List<Book>>(books, BookConstants.DataGet);
        }

        public IDataResult<List<Book>> GetByDirectors(Guid directorId)
        {
            IDataResult<Director> director = _directorService.GetById(directorId);
            if (!director.Success)
                return new ErrorDataResult<List<Book>>(director.Message);

            List<Book> books = _bookDal.GetAll(b => b.DirectorId == directorId && !b.IsDeleted).ToList();
            return books == null
                ? new ErrorDataResult<List<Book>>(BookConstants.DataNotGet)
                : new SuccessDataResult<List<Book>>(books, BookConstants.DataGet);
        }

        public IDataResult<List<Book>> GetByEditors(Guid editorId)
        {
            IDataResult<Editor> editor = _editorService.GetById(editorId);
            if (!editor.Success)
                return new ErrorDataResult<List<Book>>(editor.Message);

            List<Book> books = _bookDal.GetAll(b => b.EditorId == editorId && !b.IsDeleted).ToList();
            return books == null
                ? new ErrorDataResult<List<Book>>(BookConstants.DataNotGet)
                : new SuccessDataResult<List<Book>>(books, BookConstants.DataGet);
        }

        public IDataResult<List<Book>> GetByEditions(Guid editionId)
        {
            IDataResult<Edition> edition = _editionService.GetById(editionId);
            if (!edition.Success)
                return new ErrorDataResult<List<Book>>(edition.Message);

            List<Book> books = _bookDal.GetAll(b => b.EditionId == editionId && !b.IsDeleted).ToList();
            return books == null
                ? new ErrorDataResult<List<Book>>(BookConstants.DataNotGet)
                : new SuccessDataResult<List<Book>>(books, BookConstants.DataGet);
        }

        public IDataResult<List<Book>> GetByGraphicDirectors(Guid graphicDirectorId)
        {
            IDataResult<GraphicDirector> graphicDirector = _graphicDirectorService.GetById(graphicDirectorId);
            if (!graphicDirector.Success)
                return new ErrorDataResult<List<Book>>(graphicDirector.Message);

            List<Book> books = _bookDal.GetAll(b => b.GraphicDirectorId == graphicDirectorId && !b.IsDeleted).ToList();
            return books == null
                ? new ErrorDataResult<List<Book>>(BookConstants.DataNotGet)
                : new SuccessDataResult<List<Book>>(books, BookConstants.DataGet);
        }

        public IDataResult<List<Book>> GetByGraphicDesigns(Guid graphicDesignId)
        {
            IDataResult<GraphicDesigner> graphicDesign = _graphicDesignerService.GetById(graphicDesignId);
            if (!graphicDesign.Success)
                return new ErrorDataResult<List<Book>>(graphicDesign.Message);

            List<Book> books = _bookDal.GetAll(b => b.GraphicDesignId == graphicDesignId && !b.IsDeleted).ToList();
            return books == null
                ? new ErrorDataResult<List<Book>>(BookConstants.DataNotGet)
                : new SuccessDataResult<List<Book>>(books, BookConstants.DataGet);
        }

        public IDataResult<List<Book>> GetByInterpreters(Guid interpreterId)
        {
            IDataResult<Interpreters> interpreter = _interpreterService.GetById(interpreterId);
            if (!interpreter.Success)
                return new ErrorDataResult<List<Book>>(interpreter.Message);

            List<Book> books = _bookDal.GetAll(b => b.InterpretersId == interpreterId && !b.IsDeleted).ToList();
            return books == null
                ? new ErrorDataResult<List<Book>>(BookConstants.DataNotGet)
                : new SuccessDataResult<List<Book>>(books, BookConstants.DataGet);
        }

        public IDataResult<List<Book>> GetByPublishers(Guid publisherId)
        {
            IDataResult<Edition> edition = _editionService.GetByPublisherId(publisherId);
            if (!edition.Success)
                return new ErrorDataResult<List<Book>>(edition.Message);

            List<Book> books = _bookDal.GetAll(b => b.EditionId == edition.Data.Id && !b.IsDeleted).ToList();
            return books == null
                ? new ErrorDataResult<List<Book>>(BookConstants.DataNotGet)
                : new SuccessDataResult<List<Book>>(books, BookConstants.DataGet);
        }

        public IDataResult<List<Book>> GetByTechnicalNumbers(Guid technicalNumberId)
        {
            IDataResult<TechnicalNumber> technicalNumber = _technicalNumberService.GetById(technicalNumberId);
            if (!technicalNumber.Success)
                return new ErrorDataResult<List<Book>>(technicalNumber.Message);

            List<Book> books = _bookDal.GetAll(b => b.TechnicalNumberId == technicalNumberId && !b.IsDeleted).ToList();
            return books == null
                ? new ErrorDataResult<List<Book>>(BookConstants.DataNotGet)
                : new SuccessDataResult<List<Book>>(books, BookConstants.DataGet);
        }

        public IDataResult<List<Book>> GetByRedactions(Guid redactionId)
        {
            IDataResult<Redaction> redaction = _redactionService.GetById(redactionId);
            if (!redaction.Success)
                return new ErrorDataResult<List<Book>>(redaction.Message);

            List<Book> books = _bookDal.GetAll(b => b.RedactionId == redactionId && !b.IsDeleted).ToList();
            return books == null
                ? new ErrorDataResult<List<Book>>(BookConstants.DataNotGet)
                : new SuccessDataResult<List<Book>>(books, BookConstants.DataGet);
        }

        public IDataResult<List<Book>> GetByWriters(Guid writerId)
        {
            IDataResult<Writer> writer = _writerService.GetById(writerId);
            if (!writer.Success)
                return new ErrorDataResult<List<Book>>(writer.Message);

            List<Book> books = _bookDal.GetAll(b => b.WriterId == writerId && !b.IsDeleted).ToList();
            return books == null
                ? new ErrorDataResult<List<Book>>(BookConstants.DataNotGet)
                : new SuccessDataResult<List<Book>>(books, BookConstants.DataGet);
        }

        public IDataResult<byte?> GetSecretLevel(Guid id)
        {
            byte? secretLevel = _bookDal.Get(b => b.Id == id).SecretLevel;
            return secretLevel == null
                ? new ErrorDataResult<byte?>(BookConstants.DataNotGet)
                : new SuccessDataResult<byte?>(secretLevel, BookConstants.DataGet);
        }

        public IDataResult<byte> GetState(Guid id)
        {
            return new SuccessDataResult<byte>(_bookDal.Get(b => b.Id == id).State, BookConstants.DataGet);
        }

        public IDataResult<List<Book>> GetByCategories(int[] categoriesId)
        {
            IDataResult<List<Category>> categories = _categoryService.GetAllByFilter(c => categoriesId.Contains(c.Id));
            if (!categories.Success)
                return new ErrorDataResult<List<Book>>(BookConstants.DataNotGet);

            List<Book> books = _bookDal.GetAll(b => b.Categories.Any(c => categoriesId.Contains(c.Id)) && !b.IsDeleted).ToList();
            return books == null
                ? new ErrorDataResult<List<Book>>(BookConstants.DataNotGet)
                : new SuccessDataResult<List<Book>>(books, BookConstants.DataGet);
        }

        public IDataResult<List<Book>> GetByDescriptionFinder(string finderString)
        {
            List<Book> books = _bookDal.GetAll(b => b.Description.Contains(finderString) && !b.IsDeleted).ToList();
            return books == null
                ? new ErrorDataResult<List<Book>>(BookConstants.DataNotGet)
                : new SuccessDataResult<List<Book>>(books, BookConstants.DataGet);
        }

        public IDataResult<List<Book>> GetByDimension(Guid dimensionId)
        {
            IDataResult<Dimension> dimension = _dimensionService.GetById(dimensionId);
            if (!dimension.Success)
                return new ErrorDataResult<List<Book>>(dimension.Message);
            List<Book> books = _bookDal.GetAll(b => b.DimensionsId == dimensionId && !b.IsDeleted).ToList();
            return books == null
                ? new ErrorDataResult<List<Book>>(BookConstants.DataNotGet)
                : new SuccessDataResult<List<Book>>(books, BookConstants.DataGet);
        }

        public IDataResult<List<Book>> GetByEMFiles(Guid eMFilesId)
        {
            IDataResult<EMaterialFile> eMFile = _eMaterialFile.GetById(eMFilesId);
            if (!eMFile.Success)
                return new ErrorDataResult<List<Book>>(eMFile.Message);

            List<Book> books = _bookDal.GetAll(b => b.EMaterialFilesId == eMFilesId && !b.IsDeleted).ToList();
            return books == null
                ? new ErrorDataResult<List<Book>>(BookConstants.DataNotGet)
                : new SuccessDataResult<List<Book>>(books, BookConstants.DataGet);
        }

        public IDataResult<List<Book>> GetByPrice(decimal minPrice, decimal? maxPrice = null)
        {
            List<Book> books = maxPrice == null
                ? _bookDal.GetAll(b => b.Price >= minPrice && !b.IsDeleted).ToList()
                : _bookDal.GetAll(b => b.Price >= minPrice && b.Price <= maxPrice && !b.IsDeleted).ToList();

            return books == null
                ? new ErrorDataResult<List<Book>>(BookConstants.DataNotGet)
                : new SuccessDataResult<List<Book>>(books, BookConstants.DataGet);
        }

        public IDataResult<List<Book>> GetByTechnicalPlaceholders(Guid technicalPlaceholderId)
        {
            IDataResult<TechnicalPlaceholder> technicalPlaceholder = _technicalPlaceholder.GetById(technicalPlaceholderId);
            if (!technicalPlaceholder.Success)
                return new ErrorDataResult<List<Book>>(technicalPlaceholder.Message);

            List<Book> books = _bookDal.GetAll(b => b.TechnicalPlaceholdersId == technicalPlaceholderId && !b.IsDeleted).ToList();
            return books == null
                ? new ErrorDataResult<List<Book>>(BookConstants.DataNotGet)
                : new SuccessDataResult<List<Book>>(books, BookConstants.DataGet);
        }

        public IDataResult<List<Book>> GetByTitles(string title)
        {
            List<Book> books = _bookDal.GetAll(b => b.Title.Contains(title) && !b.IsDeleted).ToList();
            return books == null
                ? new ErrorDataResult<List<Book>>(BookConstants.DataNotGet)
                : new SuccessDataResult<List<Book>>(books, BookConstants.DataGet);
        }

        public IDataResult<List<Book>> GetByNames(string name)
        {
            List<Book> books = _bookDal.GetAll(b => b.Name.Contains(name) && !b.IsDeleted).ToList();
            return books == null
                ? new ErrorDataResult<List<Book>>(BookConstants.DataNotGet)
                : new SuccessDataResult<List<Book>>(books, BookConstants.DataGet);
        }

        private IResult CheckIfBookControl(Book entity)
        { // todo: check if book control is valid
            throw new NotImplementedException();
        }
    }
}
