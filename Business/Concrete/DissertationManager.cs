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
{   // todo: write 
    public class DissertationManager : IDissertationService
    {
        private readonly IDissertationDal _dissertationDal;

        private readonly ICategoryService _categoryService;
        private readonly ICityService _cityService;
        private readonly ICountryService _countryService;
        private readonly IDimensionService _dimensionService;
        private readonly IEMaterialFileService _eMaterialFileService;
        private readonly ILanguageService _languageService;
        private readonly ITechnicalPlaceholderService _technicalPlaceholderService;
        private readonly IUniversityService _universityService;
        private readonly IStockService _stockService;

        [ValidationAspect(typeof(DissertationValidator))]
        public IResult Add(Dissertation entity)
        {
            IResult result = BusinessRules.Run(DissertationControl(entity));
            if (result != null)
                return new ErrorResult(result.Message);

            _dissertationDal.Add(entity);
            return new SuccessResult(DissertationConstants.AddSuccess);
        }

        public IResult Delete(Guid id)
        {
            Dissertation dissertation = _dissertationDal.Get(d => d.Id == id);
            if (dissertation == null)
                return new ErrorResult(DissertationConstants.NotMatch);

            _dissertationDal.Delete(dissertation);
            return new SuccessResult(DissertationConstants.DeleteSuccess);
        }

        public IResult ShadowDelete(Guid id)
        {
            Dissertation dissertation = _dissertationDal.Get(d => d.Id == id && !d.IsDeleted);
            if (dissertation == null)
                return new ErrorResult(DissertationConstants.NotMatch);

            dissertation.IsDeleted = false;
            _dissertationDal.Update(dissertation);
            return new SuccessResult(DissertationConstants.EfDeletedSuccsess);
        }

        [ValidationAspect(typeof(DissertationValidator))]
        public IResult Update(Dissertation entity)
        {
            IResult result = BusinessRules.Run(DissertationControl(entity));
            if (result != null)
                return new ErrorResult(result.Message);

            entity.IsDeleted = false;
            _dissertationDal.Update(entity);
            return new SuccessResult(DissertationConstants.UpdateSuccess);
        }

        public IDataResult<List<Dissertation>> GetAll()
        {
            return new SuccessDataResult<List<Dissertation>>(_dissertationDal.GetAll(d => !d.IsDeleted).ToList(), DissertationConstants.DataGet);
        }

        public IDataResult<List<Dissertation>> GetAllByFilter(Expression<Func<Dissertation, bool>>? filter = null)
        {
            return new SuccessDataResult<List<Dissertation>>(_dissertationDal.GetAll(filter).ToList(), DissertationConstants.DataGet);
        }

        public IDataResult<List<Dissertation>> GetAllBySecret()
        {
            return new SuccessDataResult<List<Dissertation>>(_dissertationDal.GetAll(d => d.IsDeleted).ToList(), DissertationConstants.DataGet);
        }

        public IDataResult<Dissertation> GetByApprovalStatus(Guid id)
        {
            Dissertation dissertation = _dissertationDal.Get(d => d.Id == id && !d.IsDeleted);
            return dissertation == null
                ? new ErrorDataResult<Dissertation>(DissertationConstants.DataNotGet)
                : new SuccessDataResult<Dissertation>(dissertation, DissertationConstants.DataGet);
        }

        public IDataResult<List<Dissertation>> GetAllByCategories(int[] categoriesId)
        {
            IDataResult<List<Category>> categories = _categoryService.GetAllByIds(categoriesId);
            if (!categories.Success)
                return new ErrorDataResult<List<Dissertation>>(categories.Message);

            List<Dissertation> dissertations = _dissertationDal.GetAll(d => categoriesId.Contains(d.CategoryId) && !d.IsDeleted).ToList();
            return dissertations == null
                ? new ErrorDataResult<List<Dissertation>>(DissertationConstants.DataNotGet)
                : new SuccessDataResult<List<Dissertation>>(dissertations, DissertationConstants.DataGet);
        }

        public IDataResult<List<Dissertation>> GetAllByCity(int cityId)
        {
            IDataResult<City> city = _cityService.GetById(cityId);
            if (city.Success)
                return new ErrorDataResult<List<Dissertation>>(city.Message);

            List<Dissertation> dissertations = _dissertationDal.GetAll(d => d.City.Id == cityId && !d.IsDeleted).ToList();
            return dissertations == null
                ? new ErrorDataResult<List<Dissertation>>(DissertationConstants.DataNotGet)
                : new SuccessDataResult<List<Dissertation>>(dissertations, DissertationConstants.DataGet);
        }

        public IDataResult<List<Dissertation>> GetAllByCountry(int countryId)
        {
            IDataResult<Country> country = _countryService.GetById(countryId);
            if (country.Success)
                return new ErrorDataResult<List<Dissertation>>(country.Message);

            List<Dissertation> dissertations = _dissertationDal.GetAll(d => d.City.CountryId == countryId && !d.IsDeleted).ToList();
            return dissertations == null
                ? new ErrorDataResult<List<Dissertation>>(DissertationConstants.DataNotGet)
                : new SuccessDataResult<List<Dissertation>>(dissertations, DissertationConstants.DataGet);
        }

        public IDataResult<List<Dissertation>> GetAllByDateTimeYear(ushort year, ushort? yearMax = null)
        {
            List<Dissertation> dissertations = yearMax == null
                ? _dissertationDal.GetAll(d => d.DateTimeYear == year && !d.IsDeleted).ToList()
                : _dissertationDal.GetAll(d => d.DateTimeYear >= year && d.DateTimeYear <= yearMax && !d.IsDeleted).ToList();

            return dissertations == null
                ? new ErrorDataResult<List<Dissertation>>(DissertationConstants.DataNotGet)
                : new SuccessDataResult<List<Dissertation>>(dissertations, DissertationConstants.DataGet);
        }

        public IDataResult<List<Dissertation>> GetAllByDescriptionFinder(string finderString)
        {
            List<Dissertation> dissertations = _dissertationDal.GetAll(d => d.Description.Contains(finderString) && !d.IsDeleted).ToList();
            return dissertations == null
                ? new ErrorDataResult<List<Dissertation>>(DissertationConstants.DataNotGet)
                : new SuccessDataResult<List<Dissertation>>(dissertations, DissertationConstants.DataGet);
        }

        public IDataResult<List<Dissertation>> GetAllByDimension(Guid dimensionId)
        {
            IDataResult<Dimension> dimension = _dimensionService.GetById(dimensionId);
            if (!dimension.Success)
                return new ErrorDataResult<List<Dissertation>>(dimension.Message);

            List<Dissertation> dissertations = _dissertationDal.GetAll(d => d.DimensionsId == dimensionId && !d.IsDeleted).ToList();
            return dissertations == null
                ? new ErrorDataResult<List<Dissertation>>(DissertationConstants.DataNotGet)
                : new SuccessDataResult<List<Dissertation>>(dissertations, DissertationConstants.DataGet);
        }


        public IDataResult<List<Dissertation>> GetAllByDissertationNumber(int dissertationNumber)
        {
            List<Dissertation> dissertations = _dissertationDal.GetAll(d => d.DissertationNumber == dissertationNumber && !d.IsDeleted).ToList();
            return dissertations == null
                ? new ErrorDataResult<List<Dissertation>>(DissertationConstants.DataNotGet)
                : new SuccessDataResult<List<Dissertation>>(dissertations, DissertationConstants.DataGet);
        }

        public IDataResult<List<Dissertation>> GetAllByEMFile(Guid eMFilesId)
        {
            var eMFiles = _eMaterialFileService.GetById(eMFilesId);
            if (!eMFiles.Success)
                return new ErrorDataResult<List<Dissertation>>(eMFiles.Message);

            List<Dissertation> dissertations = _dissertationDal.GetAll(d => d.EMaterialFilesId == eMFilesId && !d.IsDeleted).ToList();
            return dissertations == null
                ? new ErrorDataResult<List<Dissertation>>(DissertationConstants.DataNotGet)
                : new SuccessDataResult<List<Dissertation>>(dissertations, DissertationConstants.DataGet);
        }

        public IDataResult<Dissertation> GetById(Guid id)
        {
            Dissertation dissertation = _dissertationDal.Get(d => id == d.Id && !d.IsDeleted);
            return dissertation == null
                ? new ErrorDataResult<Dissertation>(DissertationConstants.DataNotGet)
                : new SuccessDataResult<Dissertation>(dissertation, DissertationConstants.DataGet);
        }

        public IDataResult<List<Dissertation>> GetAllByIds(Guid[] ids)
        {
            List<Dissertation> dissertations = _dissertationDal.GetAll(d => ids.Contains(d.Id) && !d.IsDeleted).ToList();
            return dissertations == null
                ? new ErrorDataResult<List<Dissertation>>(DissertationConstants.DataNotGet)
                : new SuccessDataResult<List<Dissertation>>(dissertations, DissertationConstants.DataGet);
        }

        public IDataResult<List<Dissertation>> GetAllByLanguage(int languageId)
        {
            IDataResult<Language> language = _languageService.GetById(languageId);
            if (!language.Success)
                return new ErrorDataResult<List<Dissertation>>(language.Message);

            List<Dissertation> dissertations = _dissertationDal.GetAll(d => d.Language.Id == languageId && !d.IsDeleted).ToList();
            return dissertations == null
                ? new ErrorDataResult<List<Dissertation>>(DissertationConstants.DataNotGet)
                : new SuccessDataResult<List<Dissertation>>(dissertations, DissertationConstants.DataGet);
        }

        public IDataResult<List<Dissertation>> GetAllByName(string name)
        {
            List<Dissertation> dissertations = _dissertationDal.GetAll(d => d.Name.Contains(name) && !d.IsDeleted).ToList();
            return dissertations == null
                ? new ErrorDataResult<List<Dissertation>>(DissertationConstants.DataNotGet)
                : new SuccessDataResult<List<Dissertation>>(dissertations, DissertationConstants.DataGet);
        }

        public IDataResult<List<Dissertation>> GetAllByPrice(decimal minPrice, decimal? maxPrice = null)
        {
            List<Dissertation> dissertations = maxPrice == null
                ? _dissertationDal.GetAll(d => d.Price == minPrice && !d.IsDeleted).ToList()
                : _dissertationDal.GetAll(d => d.Price >= minPrice && d.Price <= maxPrice && !d.IsDeleted).ToList();

            return dissertations == null
                ? new ErrorDataResult<List<Dissertation>>(DissertationConstants.DataNotGet)
                : new SuccessDataResult<List<Dissertation>>(dissertations, DissertationConstants.DataGet);
        }

        public IDataResult<List<Dissertation>> GetAllByTechnicalPlaceholder(Guid technicalPlaceholderId)
        {
            IDataResult<TechnicalPlaceholder> tPH = _technicalPlaceholderService.GetById(technicalPlaceholderId);
            if (!tPH.Success)
                return new ErrorDataResult<List<Dissertation>>(tPH.Message);

            List<Dissertation> dissertations = _dissertationDal.GetAll(d => d.TechnicalPlaceholdersId == technicalPlaceholderId && !d.IsDeleted).ToList();
            return dissertations == null
                ? new ErrorDataResult<List<Dissertation>>(DissertationConstants.DataNotGet)
                : new SuccessDataResult<List<Dissertation>>(dissertations, DissertationConstants.DataGet);
        }

        public IDataResult<List<Dissertation>> GetAllByTitle(string title)
        {

            List<Dissertation> dissertations = _dissertationDal.GetAll(d => d.Title.Contains(title) && !d.IsDeleted).ToList();
            return dissertations == null
                ? new ErrorDataResult<List<Dissertation>>(DissertationConstants.DataNotGet)
                : new SuccessDataResult<List<Dissertation>>(dissertations, DissertationConstants.DataGet);
        }

        public IDataResult<List<Dissertation>> GetAllByUniversity(Guid universityId)
        {
            IDataResult<University> universities = _universityService.GetById(universityId);
            if (!universities.Success)
                return new ErrorDataResult<List<Dissertation>>(universities.Message);

            List<Dissertation> dissertations = _dissertationDal.GetAll(d => d.UniversityId == universityId && !d.IsDeleted).ToList();
            return dissertations == null
                ? new ErrorDataResult<List<Dissertation>>(DissertationConstants.DataNotGet)
                : new SuccessDataResult<List<Dissertation>>(dissertations, DissertationConstants.DataGet);
        }

        public IDataResult<byte?> GetSecretLevel(Guid id)
        {
            byte? sLevel = _dissertationDal.Get(d => d.Id == id && !d.IsDeleted).SecretLevel;
            return sLevel == null
                ? new ErrorDataResult<byte?>(DissertationConstants.DataNotGet)
                : new SuccessDataResult<byte?>(sLevel, DissertationConstants.DataGet);
        }

        public IDataResult<byte> GetState(Guid id)
        {
            return new SuccessDataResult<byte>(_dissertationDal.Get(d => d.Id == id && !d.IsDeleted).State, DissertationConstants.DataGet);
        }

        public IDataResult<Dissertation> GetByStock(Guid stockId)
        {
            IDataResult<Stock> stock = _stockService.GetById(stockId);
            if (!stock.Success)
                return new ErrorDataResult<Dissertation>(stock.Message);

            Dissertation dissertation = _dissertationDal.Get(d => d.Stock == stock.Data && !d.IsDeleted);
            return dissertation == null
                ? new ErrorDataResult<Dissertation>(DissertationConstants.NotMatch)
                : new SuccessDataResult<Dissertation>(dissertation, DissertationConstants.DataGet);
        }

        private IResult DissertationControl(Dissertation dissertation)
        {
            bool result = _dissertationDal.Get(d =>
                d.Name == dissertation.Name
             && d.Title == dissertation.Title
             && d.Description.Contains(dissertation.Description)
             && d.CategoryId == dissertation.CategoryId
             && d.TechnicalPlaceholdersId == dissertation.TechnicalPlaceholdersId
             && d.DimensionsId == dissertation.DimensionsId
             && d.EMaterialFilesId == dissertation.EMaterialFilesId
             && d.State == dissertation.State
             && d.UniversityId == dissertation.UniversityId
             && d.ResearcherId == dissertation.ResearcherId
             && d.Language == dissertation.Language
             && d.City == dissertation.City
             && d.DateTimeYear == dissertation.DateTimeYear
             && d.DissertationNumber == dissertation.DissertationNumber
             && d.ApprovalStatus == dissertation.ApprovalStatus) != null;

            if (result)
                return new ErrorResult(DissertationConstants.AlreadyExists);
            return new SuccessResult();
        }
    }
}
