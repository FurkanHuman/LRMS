﻿using Business.Abstract;
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
    public class BookSeriesManager : IBookSeriesService
    {
        private readonly IBookSeriesDal _bookSeriesDal; //  Todo: servisleri yazmayı unutma
        private readonly IBookService _bookService;
        private readonly ICategoryService _categoryService;
        private readonly ITechnicalPlaceholderService _technicalPlaceholder;
        private readonly IDimensionService _dimension;
        private readonly IEMaterialFileService _eMaterialFile;
        private readonly ICoverCapService _coverCapService;
        private readonly IEditionService _editionService;
        private readonly IImageService _imageService;
        private readonly IWriterService _writerService;
        private readonly IEditorService _editorService;
        private readonly IDirectorService _directorService;
        private readonly IGraphicDesignerService _graphicDesignerService;
        private readonly IGraphicDirectorService _graphicDirectorService;
        private readonly IInterpretersService _interpreterService;
        private readonly IRedactionService _redactionService;
        private readonly ITechnicalNumberService _technicalNumberService;
        private readonly IStockService _stockService;

        [ValidationAspect(typeof(BookSeriesValidator))]
        public IResult Add(BookSeries entity) // Todo: add fix later
        {
            IResult result = BusinessRules.Run(CheckBookSeriess(entity));
            if (result != null)
                return result;

            entity.IsDeleted = false;
            _bookSeriesDal.Add(entity);
            return new SuccessResult(BookSeriesConstants.AddSuccess);
        }

        public IResult Delete(Guid id)
        {
            BookSeries bookSeries = _bookSeriesDal.Get(bs => bs.Id == id);
            if (bookSeries == null)
                return new ErrorResult(BookSeriesConstants.NotMatch);

            _bookSeriesDal.Delete(bookSeries);
            return new SuccessResult(BookSeriesConstants.DeleteSuccess);
        }

        public IResult ShadowDelete(Guid id)
        {
            BookSeries bookSeries = _bookSeriesDal.Get(bs => bs.Id == id && !bs.IsDeleted);
            if (bookSeries == null)
                return new ErrorResult(BookSeriesConstants.NotMatch);

            bookSeries.IsDeleted = true;
            _bookSeriesDal.Update(bookSeries);
            return new SuccessResult(BookSeriesConstants.EfDeletedSuccsess);
        }

        [ValidationAspect(typeof(BookSeriesValidator))]
        public IResult Update(BookSeries entity) // Todo: update fix later
        {
            IResult result = BusinessRules.Run(CheckBookSeriess(entity));
            if (result != null)
                return result;

            entity.IsDeleted = false;
            _bookSeriesDal.Update(entity);
            return new SuccessResult(BookSeriesConstants.UpdateSuccess);
        }

        public IDataResult<BookSeries> GetById(Guid id)
        {
            BookSeries bookSeries = _bookSeriesDal.Get(bs => bs.Id == id);
            return bookSeries == null
                ? new ErrorDataResult<BookSeries>(BookSeriesConstants.NotMatch)
                : new SuccessDataResult<BookSeries>(bookSeries, BookSeriesConstants.DataGet);
        }

        public IDataResult<IList<BookSeries>> GetAllByIds(Guid[] ids)
        {
            IList<BookSeries> bookSeries = _bookSeriesDal.GetAll(bs => ids.Contains(bs.Id) && !bs.IsDeleted);
            return bookSeries == null
                ? new ErrorDataResult<IList<BookSeries>>(BookSeriesConstants.NotMatch)
                : new SuccessDataResult<IList<BookSeries>>(bookSeries, BookSeriesConstants.DataGet);
        }

        public IDataResult<BookSeries> GetByBookId(Guid bookId)
        {
            IDataResult<Book> book = _bookService.GetById(bookId);
            if (!book.Success)
                return new ErrorDataResult<BookSeries>(book.Message);

            BookSeries bookSeries = _bookSeriesDal.Get(bs => bs.BooksIds == bookId && !bs.IsDeleted);
            return bookSeries == null
                ? new ErrorDataResult<BookSeries>(BookSeriesConstants.DataNotGet)
                : new SuccessDataResult<BookSeries>(bookSeries, BookSeriesConstants.DataGet);
        }

        public IDataResult<BookSeries> GetByCoverImage(Guid cImageId)
        {
            IDataResult<Image> cImage = _imageService.GetById(cImageId);
            if (!cImage.Success)
                return new SuccessDataResult<BookSeries>(cImage.Message);

            BookSeries bookSeries = _bookSeriesDal.Get(bs => bs.CoverImageId == cImageId && !bs.IsDeleted);
            return bookSeries == null
                ? new ErrorDataResult<BookSeries>(BookSeriesConstants.DataNotGet)
                : new SuccessDataResult<BookSeries>(bookSeries, BookSeriesConstants.DataGet);
        }

        public IDataResult<IList<BookSeries>> GetAllByCoverCap(byte coverCapNum)
        {
            IDataResult<CoverCap> coverCap = _coverCapService.GetById(coverCapNum);
            if (!coverCap.Success)
                return new ErrorDataResult<IList<BookSeries>>(coverCap.Message);

            IList<BookSeries> bookSeries = _bookSeriesDal.GetAll(bs => bs.CoverCapId == coverCapNum && !bs.IsDeleted);
            return bookSeries == null
                ? new ErrorDataResult<IList<BookSeries>>(BookSeriesConstants.NotMatch)
                : new SuccessDataResult<IList<BookSeries>>(bookSeries, BookSeriesConstants.DataGet);
        }

        public IDataResult<IList<BookSeries>> GetAllByCommunication(Guid communicationId)
        {
            IDataResult<Edition> comm = _editionService.GetByCommunicationId(communicationId);
            if (!comm.Success)
                return new ErrorDataResult<IList<BookSeries>>(comm.Message);

            IList<BookSeries> bookSeries = _bookSeriesDal.GetAll(bs => bs.EditionId == comm.Data.Id && !bs.IsDeleted);
            return bookSeries == null
                ? new ErrorDataResult<IList<BookSeries>>(BookSeriesConstants.NotMatch)
                : new SuccessDataResult<IList<BookSeries>>(bookSeries, BookSeriesConstants.DataGet);
        }

        public IDataResult<IList<BookSeries>> GetAllByDirector(Guid directorId)
        {
            IDataResult<Director> director = _directorService.GetById(directorId);
            if (!director.Success)
                return new ErrorDataResult<IList<BookSeries>>(director.Message);

            IList<BookSeries> bookSeries = _bookSeriesDal.GetAll(bs => bs.DirectorId == directorId && !bs.IsDeleted);
            return bookSeries == null
                ? new ErrorDataResult<IList<BookSeries>>(BookSeriesConstants.DataNotGet)
                : new SuccessDataResult<IList<BookSeries>>(bookSeries, BookSeriesConstants.DataGet);
        }

        public IDataResult<IList<BookSeries>> GetAllByEditor(Guid editorId)
        {
            IDataResult<Editor> editor = _editorService.GetById(editorId);
            if (!editor.Success)
                return new ErrorDataResult<IList<BookSeries>>(editor.Message);

            IList<BookSeries> bookSeries = _bookSeriesDal.GetAll(bs => bs.EditorId == editorId && !bs.IsDeleted);
            return bookSeries == null
                ? new ErrorDataResult<IList<BookSeries>>(BookSeriesConstants.DataNotGet)
                : new SuccessDataResult<IList<BookSeries>>(bookSeries, BookSeriesConstants.DataGet);
        }

        public IDataResult<IList<BookSeries>> GetAllByEdition(Guid editionId)
        {
            IDataResult<Edition> edition = _editionService.GetById(editionId);
            if (!edition.Success)
                return new ErrorDataResult<IList<BookSeries>>(edition.Message);

            IList<BookSeries> bookSeries = _bookSeriesDal.GetAll(bs => bs.EditionId == edition.Data.Id && !bs.IsDeleted);
            return bookSeries == null
                ? new ErrorDataResult<IList<BookSeries>>(BookSeriesConstants.NotMatch)
                : new SuccessDataResult<IList<BookSeries>>(bookSeries, BookSeriesConstants.DataGet);
        }

        public IDataResult<IList<BookSeries>> GetAllByGraphicDirector(Guid graphicDirectorId)
        {
            IDataResult<GraphicDirector> graphicDirector = _graphicDirectorService.GetById(graphicDirectorId);
            if (!graphicDirector.Success)
                return new ErrorDataResult<IList<BookSeries>>(graphicDirector.Message);

            IList<BookSeries> bookSeries = _bookSeriesDal.GetAll(bs => bs.GraphicDirectorId == graphicDirector.Data.Id && !bs.IsDeleted);
            return bookSeries == null
                ? new ErrorDataResult<IList<BookSeries>>(BookSeriesConstants.NotMatch)
                : new SuccessDataResult<IList<BookSeries>>(bookSeries, BookSeriesConstants.DataGet);
        }

        public IDataResult<IList<BookSeries>> GetAllByGraphicDesign(Guid graphicDesignId)
        {
            IDataResult<GraphicDesigner> graphicDesign = _graphicDesignerService.GetById(graphicDesignId);
            if (!graphicDesign.Success)
                return new ErrorDataResult<IList<BookSeries>>(graphicDesign.Message);

            IList<BookSeries> bookSeries = _bookSeriesDal.GetAll(bs => bs.GraphicDesignId == graphicDesign.Data.Id && !bs.IsDeleted);
            return bookSeries == null
                ? new ErrorDataResult<IList<BookSeries>>(BookSeriesConstants.NotMatch)
                : new SuccessDataResult<IList<BookSeries>>(bookSeries, BookSeriesConstants.DataGet);
        }

        public IDataResult<IList<BookSeries>> GetAllByInterpreter(Guid interpreterId)
        {
            IDataResult<Interpreters> interpreter = _interpreterService.GetById(interpreterId);
            if (!interpreter.Success)
                return new ErrorDataResult<IList<BookSeries>>(interpreter.Message);

            IList<BookSeries> bookSeries = _bookSeriesDal.GetAll(bs => bs.InterpretersId == interpreter.Data.Id && !bs.IsDeleted);
            return bookSeries == null
                ? new ErrorDataResult<IList<BookSeries>>(BookSeriesConstants.NotMatch)
                : new SuccessDataResult<IList<BookSeries>>(bookSeries, BookSeriesConstants.DataGet);
        }

        public IDataResult<IList<BookSeries>> GetAllByPublisher(Guid publisherId)
        {
            IDataResult<Edition> edition = _editionService.GetByPublisherId(publisherId);
            if (!edition.Success)
                return new ErrorDataResult<IList<BookSeries>>(edition.Message);

            IList<BookSeries> bookSeries = _bookSeriesDal.GetAll(bs => bs.EditionId == edition.Data.Id && !bs.IsDeleted);
            return bookSeries == null
                ? new ErrorDataResult<IList<BookSeries>>(BookSeriesConstants.NotMatch)
                : new SuccessDataResult<IList<BookSeries>>(bookSeries, BookSeriesConstants.DataGet);
        }

        public IDataResult<IList<BookSeries>> GetAllByTechnicalNumber(Guid technicalNumberId)
        {
            IDataResult<TechnicalNumber> technicalNumber = _technicalNumberService.GetById(technicalNumberId);
            if (!technicalNumber.Success)
                return new ErrorDataResult<IList<BookSeries>>(technicalNumber.Message);

            IList<BookSeries> bookSeries = _bookSeriesDal.GetAll(bs => bs.TechnicalNumberId == technicalNumber.Data.Id && !bs.IsDeleted);
            return bookSeries == null
                ? new ErrorDataResult<IList<BookSeries>>(BookSeriesConstants.NotMatch)
                : new SuccessDataResult<IList<BookSeries>>(bookSeries, BookSeriesConstants.DataGet);
        }

        public IDataResult<IList<BookSeries>> GetAllByRedaction(Guid redactionId)
        {
            IDataResult<Redaction> redaction = _redactionService.GetById(redactionId);
            if (!redaction.Success)
                return new ErrorDataResult<IList<BookSeries>>(redaction.Message);

            IList<BookSeries> bookSeries = _bookSeriesDal.GetAll(bs => bs.RedactionId == redaction.Data.Id && !bs.IsDeleted);
            return bookSeries == null
                ? new ErrorDataResult<IList<BookSeries>>(BookSeriesConstants.NotMatch)
                : new SuccessDataResult<IList<BookSeries>>(bookSeries, BookSeriesConstants.DataGet);
        }

        public IDataResult<IList<BookSeries>> GetAllByWriter(Guid writerId)
        {
            IDataResult<Writer> writer = _writerService.GetById(writerId);
            if (!writer.Success)
                return new ErrorDataResult<IList<BookSeries>>(writer.Message);

            IList<BookSeries> bookSeries = _bookSeriesDal.GetAll(bs => bs.WriterId == writer.Data.Id && !bs.IsDeleted);
            return bookSeries == null
                ? new ErrorDataResult<IList<BookSeries>>(BookSeriesConstants.NotMatch)
                : new SuccessDataResult<IList<BookSeries>>(bookSeries, BookSeriesConstants.DataGet);
        }

        public IDataResult<byte?> GetSecretLevel(Guid id)
        {
            byte? sLevel = _bookSeriesDal.Get(bs => bs.Id == id && !bs.IsDeleted).SecretLevel;
            return sLevel == null
                ? new ErrorDataResult<byte?>(BookSeriesConstants.DataNotGet)
                : new SuccessDataResult<byte?>(sLevel, BookSeriesConstants.DataGet);
        }

        public IDataResult<byte> GetState(Guid id)
        {
            return new SuccessDataResult<byte>(_bookSeriesDal.Get(bs => bs.Id == id && !bs.IsDeleted).State);
        }

        public IDataResult<IList<BookSeries>> GetAllByCategories(int[] categoriesId)
        {
            IDataResult<IList<Category>> categories = _categoryService.GetAllByFilter(c => categoriesId.Contains(c.Id));
            if (categories.Data.Count != categoriesId.Length)
                return new ErrorDataResult<IList<BookSeries>>(categories.Message); // todo: look at true usage

            IList<BookSeries> bookSeries = _bookSeriesDal.GetAll(b => categoriesId.Contains(b.CategoryId) && !b.IsDeleted);
            return bookSeries.Count > 0
                ? new SuccessDataResult<IList<BookSeries>>(bookSeries, BookSeriesConstants.DataGet)
                : new ErrorDataResult<IList<BookSeries>>(BookSeriesConstants.DataNotGet);
        }

        public IDataResult<IList<BookSeries>> GetAllByDescriptionFinder(string finderString)
        {
            IList<BookSeries> bookSeries = _bookSeriesDal.GetAll(bs => bs.Description.Contains(finderString) && !bs.IsDeleted);
            return bookSeries == null
                ? new ErrorDataResult<IList<BookSeries>>(BookSeriesConstants.DataNotGet)
                : new SuccessDataResult<IList<BookSeries>>(bookSeries, BookSeriesConstants.DataGet);
        }

        public IDataResult<IList<BookSeries>> GetAllByDimension(Guid dimensionId)
        {
            IDataResult<Dimension> dimension = _dimension.GetById(dimensionId);
            if (!dimension.Success)
                return new ErrorDataResult<IList<BookSeries>>(dimension.Message);
            IList<BookSeries> bookSeries = _bookSeriesDal.GetAll(x => x.DimensionsId == dimensionId && !x.IsDeleted);

            return bookSeries.Count > 0
                ? new SuccessDataResult<IList<BookSeries>>(bookSeries, BookSeriesConstants.DataGet)
                : new ErrorDataResult<IList<BookSeries>>(BookConstants.DataNotGet);
        }

        public IDataResult<IList<BookSeries>> GetAllByEMFile(Guid eMFilesId)
        {
            IDataResult<EMaterialFile> eMaterialFile = _eMaterialFile.GetById(eMFilesId);
            if (!eMaterialFile.Success)
                return new SuccessDataResult<IList<BookSeries>>(eMaterialFile.Message);

            IList<BookSeries> bookSeries = _bookSeriesDal.GetAll(bs => bs.EMaterialFilesId == eMaterialFile.Data.Id && !bs.IsDeleted);
            return bookSeries == null
                ? new ErrorDataResult<IList<BookSeries>>(BookSeriesConstants.DataNotGet)
                : new SuccessDataResult<IList<BookSeries>>(bookSeries, BookSeriesConstants.DataGet);
        }

        public IDataResult<IList<BookSeries>> GetAllByPrice(decimal minPrice, decimal? maxPrice = null)
        {
            IList<BookSeries> bookSeries = maxPrice == null
                ? _bookSeriesDal.GetAll(bs => bs.Price >= minPrice && !bs.IsDeleted)
                : _bookSeriesDal.GetAll(bs => bs.Price >= minPrice && bs.Price <= maxPrice && !bs.IsDeleted);

            return bookSeries.Count > 0
                ? new SuccessDataResult<IList<BookSeries>>(bookSeries, BookSeriesConstants.DataGet)
                : new ErrorDataResult<IList<BookSeries>>(BookSeriesConstants.DataNotGet);
        }

        public IDataResult<IList<BookSeries>> GetAllByTechnicalPlaceholder(Guid technicalPlaceholderId)
        {
            IDataResult<TechnicalPlaceholder> technicalPlaceholder = _technicalPlaceholder.GetById(technicalPlaceholderId);
            if (!technicalPlaceholder.Success)
                return new ErrorDataResult<IList<BookSeries>>(technicalPlaceholder.Message);

            IList<BookSeries> bookSeries = _bookSeriesDal.GetAll(bs => bs.TechnicalPlaceholdersId == technicalPlaceholder.Data.Id && !bs.IsDeleted);
            return bookSeries == null
                ? new ErrorDataResult<IList<BookSeries>>(BookSeriesConstants.DataNotGet)
                : new SuccessDataResult<IList<BookSeries>>(bookSeries, BookSeriesConstants.DataGet);
        }

        public IDataResult<IList<BookSeries>> GetAllByTitle(string title)
        {
            IList<BookSeries> bookSeries = _bookSeriesDal.GetAll(bs => bs.Title.Contains(title) && !bs.IsDeleted);
            return bookSeries == null
                ? new ErrorDataResult<IList<BookSeries>>(BookSeriesConstants.DataNotGet)
                : new SuccessDataResult<IList<BookSeries>>(bookSeries, BookSeriesConstants.DataGet);
        }

        public IDataResult<IList<BookSeries>> GetAllByName(string name)
        {
            IList<BookSeries> bookSeries = _bookSeriesDal.GetAll(bs => bs.Name.Contains(name) && !bs.IsDeleted);
            return bookSeries == null
                ? new ErrorDataResult<IList<BookSeries>>(BookSeriesConstants.DataNotGet)
                : new SuccessDataResult<IList<BookSeries>>(bookSeries, BookSeriesConstants.DataGet);
        }

        public IDataResult<IList<BookSeries>> GetAllByFilter(Expression<Func<BookSeries, bool>>? filter = null)
        {
            return new SuccessDataResult<IList<BookSeries>>(_bookSeriesDal.GetAll(filter), BookSeriesConstants.DataGet);
        }

        public IDataResult<IList<BookSeries>> GetAllByIsDeleted()
        {
            return new SuccessDataResult<IList<BookSeries>>(_bookSeriesDal.GetAll(bs => bs.IsDeleted), BookSeriesConstants.DataGet);
        }

        public IDataResult<IList<BookSeries>> GetAll()
        {
            return new SuccessDataResult<IList<BookSeries>>(_bookSeriesDal.GetAll(bs => !bs.IsDeleted), BookSeriesConstants.DataGet);
        }

        public IDataResult<BookSeries> GetByStock(Guid stockId)
        {
            IDataResult<Stock> stock = _stockService.GetById(stockId);
            if (!stock.Success)
                return new ErrorDataResult<BookSeries>(stock.Message);

            BookSeries audioRecord = _bookSeriesDal.Get(ar => ar.Stock == stock.Data && !ar.IsDeleted);
            return audioRecord == null
                ? new ErrorDataResult<BookSeries>(BookSeriesConstants.NotMatch)
                : new SuccessDataResult<BookSeries>(audioRecord, BookSeriesConstants.DataGet);
        }

        private IResult CheckBookSeriess(BookSeries bookSeries)
        {   // todo: check if book series is already in db

            bool checkBookS = _bookSeriesDal.Get(bs =>

                bs.Name == bookSeries.Name
             && bs.Title == bookSeries.Title// todo: false usage string equıalty.
             && bs.Description.Contains(bookSeries.Description)
             && bs.CategoryId == bookSeries.CategoryId
             && bs.TechnicalPlaceholdersId == bookSeries.TechnicalPlaceholdersId
             && bs.DimensionsId == bookSeries.DimensionsId
             && bs.EMaterialFilesId == bookSeries.EMaterialFilesId
             && bs.State == bookSeries.State
             && bs.CoverCapId == bookSeries.CoverCapId
             && bs.CoverImageId == bookSeries.CoverImageId
             && bs.WriterId == bookSeries.WriterId
             && bs.EditorId == bookSeries.EditorId
             && bs.TechnicalNumberId == bookSeries.TechnicalNumberId
             && bs.EditionId == bookSeries.EditionId
             && bs.BooksIds == bookSeries.BooksIds
                ) != null;

            if (checkBookS)
                return new ErrorResult(BookSeriesConstants.AlreadyExists);
            return new SuccessResult();

        }
    }
}
