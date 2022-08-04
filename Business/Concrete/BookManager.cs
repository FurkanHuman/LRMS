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
        private readonly IBookDal _bookDal;//  Todo: constuructor hell fuck
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
        private readonly IStockService _stockService;

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
            return new SuccessResult(BookConstants.DeleteSuccess);
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

        public IDataResult<IList<Book>> GetAllByIds(Guid[] ids)
        {
            IList<Book> books = _bookDal.GetAll(b => ids.Contains(b.Id) && !b.IsDeleted);
            return books == null
                ? new ErrorDataResult<IList<Book>>(BookConstants.DataNotGet)
                : new SuccessDataResult<IList<Book>>(books, BookConstants.DataGet);
        }

        public IDataResult<IList<Book>> GetAll()
        {
            return new SuccessDataResult<IList<Book>>(_bookDal.GetAll(b => !b.IsDeleted), BookConstants.DataGet);
        }

        public IDataResult<IList<Book>> GetAllByFilter(Expression<Func<Book, bool>>? filter = null)
        {
            return new SuccessDataResult<IList<Book>>(_bookDal.GetAll(filter), BookConstants.DataGet);
        }

        public IDataResult<IList<Book>> GetAllByIsDeleted()
        {
            return new SuccessDataResult<IList<Book>>(_bookDal.GetAll(b => b.IsDeleted), BookConstants.DataGet);
        }

        public IDataResult<IList<Book>> GetAllByOriginalBookName(string originalBookName)
        {
            IList<Book> books = _bookDal.GetAll(b => b.OriginalBookName.Contains(originalBookName) && !b.IsDeleted);
            return books == null
                ? new ErrorDataResult<IList<Book>>(BookConstants.DataNotGet)
                : new SuccessDataResult<IList<Book>>(books, BookConstants.DataGet);
        }

        public IDataResult<IList<Book>> GetAllByReference(Guid referenceId)
        {
            IDataResult<Reference> reference = _referenceService.GetById(referenceId);
            if (!reference.Success)
                return new ErrorDataResult<IList<Book>>(reference.Message);

            IList<Book> books = _bookDal.GetAll(b => b.ReferenceId == referenceId && !b.IsDeleted);
            return books == null
                ? new ErrorDataResult<IList<Book>>(BookConstants.DataNotGet)
                : new SuccessDataResult<IList<Book>>(books, BookConstants.DataGet);
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

        public IDataResult<IList<Book>> GetAllByCoverCap(byte coverCapNum)
        {
            IDataResult<CoverCap> covercap = _coverCapService.GetById(coverCapNum);
            if (!covercap.Success)
                return new ErrorDataResult<IList<Book>>(covercap.Message);

            IList<Book> books = _bookDal.GetAll(b => b.CoverCapId == coverCapNum && !b.IsDeleted);
            return books == null
                ? new ErrorDataResult<IList<Book>>(BookConstants.DataNotGet)
                : new SuccessDataResult<IList<Book>>(books, BookConstants.DataGet);
        }

        public IDataResult<IList<Book>> GetAllByCommunication(Guid communicationId)
        {
            IDataResult<Edition> edition = _editionService.GetByCommunicationId(communicationId);
            if (!edition.Success)
                return new ErrorDataResult<IList<Book>>(edition.Message);

            IList<Book> books = _bookDal.GetAll(b => b.EditionId == edition.Data.Id && !b.IsDeleted);
            return books == null
                ? new ErrorDataResult<IList<Book>>(BookConstants.DataNotGet)
                : new SuccessDataResult<IList<Book>>(books, BookConstants.DataGet);
        }

        public IDataResult<IList<Book>> GetAllByDirector(Guid directorId)
        {
            IDataResult<Director> director = _directorService.GetById(directorId);
            if (!director.Success)
                return new ErrorDataResult<IList<Book>>(director.Message);

            IList<Book> books = _bookDal.GetAll(b => b.DirectorId == directorId && !b.IsDeleted);
            return books == null
                ? new ErrorDataResult<IList<Book>>(BookConstants.DataNotGet)
                : new SuccessDataResult<IList<Book>>(books, BookConstants.DataGet);
        }

        public IDataResult<IList<Book>> GetAllByEditor(Guid editorId)
        {
            IDataResult<Editor> editor = _editorService.GetById(editorId);
            if (!editor.Success)
                return new ErrorDataResult<IList<Book>>(editor.Message);

            IList<Book> books = _bookDal.GetAll(b => b.EditorId == editorId && !b.IsDeleted);
            return books == null
                ? new ErrorDataResult<IList<Book>>(BookConstants.DataNotGet)
                : new SuccessDataResult<IList<Book>>(books, BookConstants.DataGet);
        }

        public IDataResult<IList<Book>> GetAllByEdition(Guid editionId)
        {
            IDataResult<Edition> edition = _editionService.GetById(editionId);
            if (!edition.Success)
                return new ErrorDataResult<IList<Book>>(edition.Message);

            IList<Book> books = _bookDal.GetAll(b => b.EditionId == editionId && !b.IsDeleted);
            return books == null
                ? new ErrorDataResult<IList<Book>>(BookConstants.DataNotGet)
                : new SuccessDataResult<IList<Book>>(books, BookConstants.DataGet);
        }

        public IDataResult<IList<Book>> GetAllByGraphicDirector(Guid graphicDirectorId)
        {
            IDataResult<GraphicDirector> graphicDirector = _graphicDirectorService.GetById(graphicDirectorId);
            if (!graphicDirector.Success)
                return new ErrorDataResult<IList<Book>>(graphicDirector.Message);

            IList<Book> books = _bookDal.GetAll(b => b.GraphicDirectorId == graphicDirectorId && !b.IsDeleted);
            return books == null
                ? new ErrorDataResult<IList<Book>>(BookConstants.DataNotGet)
                : new SuccessDataResult<IList<Book>>(books, BookConstants.DataGet);
        }

        public IDataResult<IList<Book>> GetAllByGraphicDesign(Guid graphicDesignId)
        {
            IDataResult<GraphicDesigner> graphicDesign = _graphicDesignerService.GetById(graphicDesignId);
            if (!graphicDesign.Success)
                return new ErrorDataResult<IList<Book>>(graphicDesign.Message);

            IList<Book> books = _bookDal.GetAll(b => b.GraphicDesignId == graphicDesignId && !b.IsDeleted);
            return books == null
                ? new ErrorDataResult<IList<Book>>(BookConstants.DataNotGet)
                : new SuccessDataResult<IList<Book>>(books, BookConstants.DataGet);
        }

        public IDataResult<IList<Book>> GetAllByInterpreter(Guid interpreterId)
        {
            IDataResult<Interpreters> interpreter = _interpreterService.GetById(interpreterId);
            if (!interpreter.Success)
                return new ErrorDataResult<IList<Book>>(interpreter.Message);

            IList<Book> books = _bookDal.GetAll(b => b.InterpretersId == interpreterId && !b.IsDeleted);
            return books == null
                ? new ErrorDataResult<IList<Book>>(BookConstants.DataNotGet)
                : new SuccessDataResult<IList<Book>>(books, BookConstants.DataGet);
        }

        public IDataResult<IList<Book>> GetAllByPublisher(Guid publisherId)
        {
            IDataResult<Edition> edition = _editionService.GetByPublisherId(publisherId);
            if (!edition.Success)
                return new ErrorDataResult<IList<Book>>(edition.Message);

            IList<Book> books = _bookDal.GetAll(b => b.EditionId == edition.Data.Id && !b.IsDeleted);
            return books == null
                ? new ErrorDataResult<IList<Book>>(BookConstants.DataNotGet)
                : new SuccessDataResult<IList<Book>>(books, BookConstants.DataGet);
        }

        public IDataResult<IList<Book>> GetAllByTechnicalNumber(Guid technicalNumberId)
        {
            IDataResult<TechnicalNumber> technicalNumber = _technicalNumberService.GetById(technicalNumberId);
            if (!technicalNumber.Success)
                return new ErrorDataResult<IList<Book>>(technicalNumber.Message);

            IList<Book> books = _bookDal.GetAll(b => b.TechnicalNumberId == technicalNumberId && !b.IsDeleted);
            return books == null
                ? new ErrorDataResult<IList<Book>>(BookConstants.DataNotGet)
                : new SuccessDataResult<IList<Book>>(books, BookConstants.DataGet);
        }

        public IDataResult<IList<Book>> GetAllByRedaction(Guid redactionId)
        {
            IDataResult<Redaction> redaction = _redactionService.GetById(redactionId);
            if (!redaction.Success)
                return new ErrorDataResult<IList<Book>>(redaction.Message);

            IList<Book> books = _bookDal.GetAll(b => b.RedactionId == redactionId && !b.IsDeleted);
            return books == null
                ? new ErrorDataResult<IList<Book>>(BookConstants.DataNotGet)
                : new SuccessDataResult<IList<Book>>(books, BookConstants.DataGet);
        }

        public IDataResult<IList<Book>> GetAllByWriter(Guid writerId)
        {
            IDataResult<Writer> writer = _writerService.GetById(writerId);
            if (!writer.Success)
                return new ErrorDataResult<IList<Book>>(writer.Message);

            IList<Book> books = _bookDal.GetAll(b => b.WriterId == writerId && !b.IsDeleted);
            return books == null
                ? new ErrorDataResult<IList<Book>>(BookConstants.DataNotGet)
                : new SuccessDataResult<IList<Book>>(books, BookConstants.DataGet);
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

        public IDataResult<IList<Book>> GetAllByCategories(int[] categoriesId)
        {
            IDataResult<IList<Category>> categories = _categoryService.GetAllByFilter(c => categoriesId.Contains(c.Id));
            if (!categories.Success)
                return new ErrorDataResult<IList<Book>>(categories.Message);

            IList<Book> books = _bookDal.GetAll(b => b.Categories.Any(c => categoriesId.Contains(c.Id)) && !b.IsDeleted);
            return books == null
                ? new ErrorDataResult<IList<Book>>(BookConstants.DataNotGet)
                : new SuccessDataResult<IList<Book>>(books, BookConstants.DataGet);
        }

        public IDataResult<IList<Book>> GetAllByDescriptionFinder(string finderString)
        {
            IList<Book> books = _bookDal.GetAll(b => b.Description.Contains(finderString) && !b.IsDeleted);
            return books == null
                ? new ErrorDataResult<IList<Book>>(BookConstants.DataNotGet)
                : new SuccessDataResult<IList<Book>>(books, BookConstants.DataGet);
        }

        public IDataResult<IList<Book>> GetAllByDimension(Guid dimensionId)
        {
            IDataResult<Dimension> dimension = _dimensionService.GetById(dimensionId);
            if (!dimension.Success)
                return new ErrorDataResult<IList<Book>>(dimension.Message);
            IList<Book> books = _bookDal.GetAll(b => b.DimensionsId == dimensionId && !b.IsDeleted);
            return books == null
                ? new ErrorDataResult<IList<Book>>(BookConstants.DataNotGet)
                : new SuccessDataResult<IList<Book>>(books, BookConstants.DataGet);
        }

        public IDataResult<IList<Book>> GetAllByEMFile(Guid eMFileId)
        {
            IDataResult<EMaterialFile> eMFile = _eMaterialFile.GetById(eMFileId);
            if (!eMFile.Success)
                return new ErrorDataResult<IList<Book>>(eMFile.Message);

            IList<Book> books = _bookDal.GetAll(b => b.EMaterialFilesId == eMFileId && !b.IsDeleted);
            return books == null
                ? new ErrorDataResult<IList<Book>>(BookConstants.DataNotGet)
                : new SuccessDataResult<IList<Book>>(books, BookConstants.DataGet);
        }

        public IDataResult<IList<Book>> GetAllByPrice(decimal minPrice, decimal? maxPrice = null)
        {
            IList<Book> books = maxPrice == null
                ? _bookDal.GetAll(b => b.Price >= minPrice && !b.IsDeleted)
                : _bookDal.GetAll(b => b.Price >= minPrice && b.Price <= maxPrice && !b.IsDeleted);

            return books == null
                ? new ErrorDataResult<IList<Book>>(BookConstants.DataNotGet)
                : new SuccessDataResult<IList<Book>>(books, BookConstants.DataGet);
        }

        public IDataResult<IList<Book>> GetAllByTechnicalPlaceholder(Guid technicalPlaceholderId)
        {
            IDataResult<TechnicalPlaceholder> technicalPlaceholder = _technicalPlaceholder.GetById(technicalPlaceholderId);
            if (!technicalPlaceholder.Success)
                return new ErrorDataResult<IList<Book>>(technicalPlaceholder.Message);

            IList<Book> books = _bookDal.GetAll(b => b.TechnicalPlaceholdersId == technicalPlaceholderId && !b.IsDeleted);
            return books == null
                ? new ErrorDataResult<IList<Book>>(BookConstants.DataNotGet)
                : new SuccessDataResult<IList<Book>>(books, BookConstants.DataGet);
        }

        public IDataResult<IList<Book>> GetAllByTitle(string title)
        {
            IList<Book> books = _bookDal.GetAll(b => b.Title.Contains(title) && !b.IsDeleted);
            return books == null
                ? new ErrorDataResult<IList<Book>>(BookConstants.DataNotGet)
                : new SuccessDataResult<IList<Book>>(books, BookConstants.DataGet);
        }

        public IDataResult<IList<Book>> GetAllByName(string name)
        {
            IList<Book> books = _bookDal.GetAll(b => b.Name.Contains(name) && !b.IsDeleted);
            return books == null
                ? new ErrorDataResult<IList<Book>>(BookConstants.DataNotGet)
                : new SuccessDataResult<IList<Book>>(books, BookConstants.DataGet);
        }

        public IDataResult<Book> GetByStock(Guid stockId)
        {
            IDataResult<Stock> stock = _stockService.GetById(stockId);
            if (!stock.Success)
                return new ErrorDataResult<Book>(stock.Message);

            Book book = _bookDal.Get(b => b.Stock == stock.Data && !b.IsDeleted);
            return book == null
                ? new ErrorDataResult<Book>(BookConstants.NotMatch)
                : new SuccessDataResult<Book>(book, BookConstants.DataGet);
        }

        private IResult CheckIfBookControl(Book book)
        {
            // todo: check if book control is valid,

            bool checkBook = _bookDal.Get(b =>
                b.Name == book.Name
             && b.Title == book.Title
             && b.Description.Contains(book.Description)
             && b.CategoryId == book.CategoryId
             && b.TechnicalPlaceholdersId == book.TechnicalPlaceholdersId
             && b.DimensionsId == book.DimensionsId
             && b.EMaterialFilesId == book.EMaterialFilesId
             && b.State == book.State
             && b.CoverCapId == book.CoverCapId
             && b.CoverImageId == book.CoverImageId
             && b.WriterId == book.WriterId
             && b.EditorId == book.EditorId
             && b.TechnicalNumberId == book.TechnicalNumberId
             && b.EditionId == book.EditionId
             && b.ReferenceId == book.ReferenceId
                ) != null;

            if (checkBook)
                return new ErrorResult(BookConstants.AlreadyExists);
            return new SuccessResult();
        }

    }
}
