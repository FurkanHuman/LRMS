using Business.Abstract;
using Core.Utilities.Result.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System.Linq.Expressions;

namespace Business.Concrete
{
    public class BookSeriesManager : IBookSeriesService
    {
        private readonly IBookSeriesDal _bookSeriesDal; //  Todo: servisleri yazmayı unutma

        public BookSeriesManager(IBookSeriesDal bookSeriesDal)
        {
            _bookSeriesDal = bookSeriesDal;
        }

        public IResult Add(BookSeries entity)
        {
            throw new NotImplementedException();
        }

        public IResult Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public IResult ShadowDelete(Guid id)
        {
            throw new NotImplementedException();
        }

        public IResult Update(BookSeries entity)
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<BookSeries>> GetAll()
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<BookSeries>> GetAllByFilter(Expression<Func<BookSeries, bool>>? filter = null)
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<BookSeries>> GetAllBySecrets()
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<BookSeries>> GetByBookId(Guid bookId)
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<BookSeries>> GetByCategories(int[] categoriesId)
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<BookSeries>> GetByCommunications(Guid communicationId)
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<BookSeries>> GetByCoverCaps(byte CoverCapNum)
        {
            throw new NotImplementedException();
        }

        public IDataResult<BookSeries> GetByCoverImage(Guid cImageId)
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<BookSeries>> GetByDescriptionFinder(string finderString)
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<BookSeries>> GetByDimension(Guid dimensionId)
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<BookSeries>> GetByDirectors(Guid directorId)
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<BookSeries>> GetByEditions(Guid editionNum)
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<BookSeries>> GetByEditors(Guid editorId)
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<BookSeries>> GetByEMFiles(Guid eMFilesId)
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<BookSeries>> GetByGraphicDesigns(Guid graphicDesignId)
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<BookSeries>> GetByGraphicDirectors(Guid graphicDirectorId)
        {
            throw new NotImplementedException();
        }

        public IDataResult<BookSeries> GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<BookSeries>> GetByInterpreters(Guid interpreterId)
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<BookSeries>> GetByNames(string name)
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<BookSeries>> GetByPrice(decimal minPrice, decimal? maxPrice = null)
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<BookSeries>> GetByPublishers(Guid publisherNum)
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<BookSeries>> GetByRedactions(Guid redactionId)
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<BookSeries>> GetByTechnicalNumbers(Guid technicalNumberId)
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<BookSeries>> GetByTitles(string title)
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<BookSeries>> GetByWriters(Guid writerId)
        {
            throw new NotImplementedException();
        }

        public IDataResult<byte?> GetSecretLevel(Guid id)
        {
            throw new NotImplementedException();
        }

        public IDataResult<byte> GetState(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}