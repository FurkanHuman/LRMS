using Business.Abstract;
using Core.Utilities.Result.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System.Linq.Expressions;


namespace Business.Concrete
{   // todo: write 
    public class DissertationManager : IDissertationService
    {
        private readonly IDissertationDal _dissertationDal;

        public IResult Add(Dissertation entity)
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

        public IResult Update(Dissertation entity)
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<Dissertation>> GetAll()
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<Dissertation>> GetAllByFilter(Expression<Func<Dissertation, bool>>? filter = null)
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<Dissertation>> GetAllBySecrets()
        {
            throw new NotImplementedException();
        }

        public IDataResult<Dissertation> GetByApprovalStatus(Guid id)
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<Dissertation>> GetByCategories(int[] categoriesId)
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<Dissertation>> GetByCities(int cityId)
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<Dissertation>> GetByCityName(string cityName)
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<Dissertation>> GetByCountries(int CountryId)
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<Dissertation>> GetByCountryName(string countryName)
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<Dissertation>> GetByDateTimeYear(ushort year, ushort? yearMax = null)
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<Dissertation>> GetByDescriptionFinder(string finderString)
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<Dissertation>> GetByDimension(Guid dimensionId)
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<Dissertation>> GetByDissertationNumber(int dissertationNumber)
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<Dissertation>> GetByEMFiles(Guid eMFilesId)
        {
            throw new NotImplementedException();
        }

        public IDataResult<Dissertation> GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<Dissertation>> GetByIds(Guid[] ids)
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<Dissertation>> GetByLanguages(int languageId)
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<Dissertation>> GetByLanguagesName(string languageName)
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<Dissertation>> GetByNames(string name)
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<Dissertation>> GetByPrice(decimal minPrice, decimal? maxPrice = null)
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<Dissertation>> GetByTechnicalPlaceholders(Guid technicalPlaceholderId)
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<Dissertation>> GetByTitles(string title)
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<Dissertation>> GetByUniversity(Guid universityId)
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<Dissertation>> GetByUniversityName(string universityName)
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
