using Business.Abstract;
using Business.Constants;
using Core.Utilities.Result.Abstract;
using Core.Utilities.Result.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
using System.Linq.Expressions;

namespace Business.Concrete
{
    public class BookManager : IBookService
    {
        private readonly IBookDal _bookDal;//  Todo: servisleri yazmayı unutma

        public BookManager(IBookDal bookDal)
        {
            _bookDal = bookDal;
        }

        public IResult Add(Book entity)
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

        public IResult Update(Book entity)
        {
            throw new NotImplementedException();
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

        public IDataResult<List<Book>> GetByCategories(int[] categoriesId)
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<Book>> GetByCommunications(Guid communicationId)
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<Book>> GetByCoverCaps(byte CoverCapNum)
        {
            throw new NotImplementedException();
        }

        public IDataResult<Book> GetByCoverImage(Guid cImageId)
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<Book>> GetByDescriptionFinder(string finderString)
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<Book>> GetByDimension(Guid dimensionId)
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<Book>> GetByDirectors(Guid directorId)
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<Book>> GetByEditions(Guid editionNum)
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<Book>> GetByEditors(Guid editorId)
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<Book>> GetByEMFiles(Guid eMFilesId)
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<Book>> GetByGraphicDesigns(Guid graphicDesignId)
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<Book>> GetByGraphicDirectors(Guid graphicDirectorId)
        {
            throw new NotImplementedException();
        }

        public IDataResult<Book> GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<Book>> GetByInterpreters(Guid interpreterId)
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<Book>> GetByNames(string name)
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<Book>> GetByOriginalBookName(string originalBookName)
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<Book>> GetByPrice(decimal minPrice, decimal? maxPrice = null)
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<Book>> GetByPublishers(Guid publisherNum)
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<Book>> GetByRedactions(Guid redactionId)
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<Book>> GetByReferences(Guid referenceId)
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<Book>> GetByTechnicalNumbers(Guid technicalNumberId)
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<Book>> GetByTitles(string title)
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<Book>> GetByWriters(Guid writerId)
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
