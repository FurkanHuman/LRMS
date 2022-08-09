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
{   // todo: write 
    public class DissertationManager : IDissertationService
    {
        private readonly IDissertationDal _dissertationDal;
        private readonly IFacadeService _facadeService;

        public DissertationManager(IDissertationDal dissertationDal, IFacadeService facadeService)
        {
            _dissertationDal = dissertationDal;
            _facadeService = facadeService;
        }

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

        public IDataResult<IList<Dissertation>> GetAll()
        {
            return new SuccessDataResult<IList<Dissertation>>(_dissertationDal.GetAll(d => !d.IsDeleted), DissertationConstants.DataGet);
        }

        public IDataResult<IList<Dissertation>> GetAllByFilter(Expression<Func<Dissertation, bool>>? filter = null)
        {
            return new SuccessDataResult<IList<Dissertation>>(_dissertationDal.GetAll(filter), DissertationConstants.DataGet);
        }

        public IDataResult<IList<Dissertation>> GetAllByIsDeleted()
        {
            return new SuccessDataResult<IList<Dissertation>>(_dissertationDal.GetAll(d => d.IsDeleted), DissertationConstants.DataGet);
        }

        public IDataResult<Dissertation> GetByApprovalStatus(Guid id)
        {
            Dissertation dissertation = _dissertationDal.Get(d => d.Id == id && !d.IsDeleted);
            return dissertation == null
                ? new ErrorDataResult<Dissertation>(DissertationConstants.DataNotGet)
                : new SuccessDataResult<Dissertation>(dissertation, DissertationConstants.DataGet);
        }

        public IDataResult<IList<Dissertation>> GetAllByCategories(int[] categoriesId)
        {
            IDataResult<IList<Category>> categories = _facadeService.CategoryService().GetAllByIds(categoriesId);
            if (!categories.Success)
                return new ErrorDataResult<IList<Dissertation>>(categories.Message);

            IList<Dissertation> dissertations = _dissertationDal.GetAll(d => categoriesId.Contains(d.CategoryId) && !d.IsDeleted);
            return dissertations == null
                ? new ErrorDataResult<IList<Dissertation>>(DissertationConstants.DataNotGet)
                : new SuccessDataResult<IList<Dissertation>>(dissertations, DissertationConstants.DataGet);
        }

        public IDataResult<IList<Dissertation>> GetAllByCity(int cityId)
        {
            IDataResult<City> city = _facadeService.CityService().GetById(cityId);
            if (city.Success)
                return new ErrorDataResult<IList<Dissertation>>(city.Message);

            IList<Dissertation> dissertations = _dissertationDal.GetAll(d => d.City.Id == cityId && !d.IsDeleted);
            return dissertations == null
                ? new ErrorDataResult<IList<Dissertation>>(DissertationConstants.DataNotGet)
                : new SuccessDataResult<IList<Dissertation>>(dissertations, DissertationConstants.DataGet);
        }

        public IDataResult<IList<Dissertation>> GetAllByCountry(int countryId)
        {
            IDataResult<Country> country = _facadeService.CountryService().GetById(countryId);
            if (country.Success)
                return new ErrorDataResult<IList<Dissertation>>(country.Message);

            IList<Dissertation> dissertations = _dissertationDal.GetAll(d => d.City.CountryId == countryId && !d.IsDeleted);
            return dissertations == null
                ? new ErrorDataResult<IList<Dissertation>>(DissertationConstants.DataNotGet)
                : new SuccessDataResult<IList<Dissertation>>(dissertations, DissertationConstants.DataGet);
        }

        public IDataResult<IList<Dissertation>> GetAllByDateTimeYear(ushort year, ushort? yearMax = null)
        {
            IList<Dissertation> dissertations = yearMax == null
                ? _dissertationDal.GetAll(d => d.DateTimeYear == year && !d.IsDeleted)
                : _dissertationDal.GetAll(d => d.DateTimeYear >= year && d.DateTimeYear <= yearMax && !d.IsDeleted);

            return dissertations == null
                ? new ErrorDataResult<IList<Dissertation>>(DissertationConstants.DataNotGet)
                : new SuccessDataResult<IList<Dissertation>>(dissertations, DissertationConstants.DataGet);
        }

        public IDataResult<IList<Dissertation>> GetAllByDescriptionFinder(string finderString)
        {
            IList<Dissertation> dissertations = _dissertationDal.GetAll(d => d.Description.Contains(finderString) && !d.IsDeleted);
            return dissertations == null
                ? new ErrorDataResult<IList<Dissertation>>(DissertationConstants.DataNotGet)
                : new SuccessDataResult<IList<Dissertation>>(dissertations, DissertationConstants.DataGet);
        }

        public IDataResult<IList<Dissertation>> GetAllByDimension(Guid dimensionId)
        {
            IDataResult<Dimension> dimension = _facadeService.DimensionService().GetById(dimensionId);
            if (!dimension.Success)
                return new ErrorDataResult<IList<Dissertation>>(dimension.Message);

            IList<Dissertation> dissertations = _dissertationDal.GetAll(d => d.DimensionsId == dimensionId && !d.IsDeleted);
            return dissertations == null
                ? new ErrorDataResult<IList<Dissertation>>(DissertationConstants.DataNotGet)
                : new SuccessDataResult<IList<Dissertation>>(dissertations, DissertationConstants.DataGet);
        }


        public IDataResult<IList<Dissertation>> GetAllByDissertationNumber(int dissertationNumber)
        {
            IList<Dissertation> dissertations = _dissertationDal.GetAll(d => d.DissertationNumber == dissertationNumber && !d.IsDeleted);
            return dissertations == null
                ? new ErrorDataResult<IList<Dissertation>>(DissertationConstants.DataNotGet)
                : new SuccessDataResult<IList<Dissertation>>(dissertations, DissertationConstants.DataGet);
        }

        public IDataResult<IList<Dissertation>> GetAllByEMFile(Guid eMFileId)
        {
            IDataResult<EMaterialFile> eMFiles = _facadeService.EMaterialFileService().GetById(eMFileId);
            if (!eMFiles.Success)
                return new ErrorDataResult<IList<Dissertation>>(eMFiles.Message);

            IList<Dissertation> dissertations = _dissertationDal.GetAll(d => d.EMaterialFilesId == eMFileId && !d.IsDeleted);
            return dissertations == null
                ? new ErrorDataResult<IList<Dissertation>>(DissertationConstants.DataNotGet)
                : new SuccessDataResult<IList<Dissertation>>(dissertations, DissertationConstants.DataGet);
        }

        public IDataResult<Dissertation> GetById(Guid id)
        {
            Dissertation dissertation = _dissertationDal.Get(d => id == d.Id && !d.IsDeleted);
            _facadeService.CounterService().Count(dissertation);
            return dissertation == null
                ? new ErrorDataResult<Dissertation>(DissertationConstants.DataNotGet)
                : new SuccessDataResult<Dissertation>(dissertation, DissertationConstants.DataGet);
        }

        public IDataResult<IList<Dissertation>> GetAllByIds(Guid[] ids)
        {
            IList<Dissertation> dissertations = _dissertationDal.GetAll(d => ids.Contains(d.Id) && !d.IsDeleted);
            _facadeService.CounterService().Count(dissertations);
            return dissertations == null
                ? new ErrorDataResult<IList<Dissertation>>(DissertationConstants.DataNotGet)
                : new SuccessDataResult<IList<Dissertation>>(dissertations, DissertationConstants.DataGet);
        }

        public IDataResult<IList<Dissertation>> GetAllByLanguage(int languageId)
        {
            IDataResult<Language> language = _facadeService.LanguageService().GetById(languageId);
            if (!language.Success)
                return new ErrorDataResult<IList<Dissertation>>(language.Message);

            IList<Dissertation> dissertations = _dissertationDal.GetAll(d => d.Language.Id == languageId && !d.IsDeleted);
            return dissertations == null
                ? new ErrorDataResult<IList<Dissertation>>(DissertationConstants.DataNotGet)
                : new SuccessDataResult<IList<Dissertation>>(dissertations, DissertationConstants.DataGet);
        }

        public IDataResult<IList<Dissertation>> GetAllByName(string name)
        {
            IList<Dissertation> dissertations = _dissertationDal.GetAll(d => d.Name.Contains(name) && !d.IsDeleted);
            return dissertations == null
                ? new ErrorDataResult<IList<Dissertation>>(DissertationConstants.DataNotGet)
                : new SuccessDataResult<IList<Dissertation>>(dissertations, DissertationConstants.DataGet);
        }

        public IDataResult<IList<Dissertation>> GetAllByPrice(decimal minPrice, decimal? maxPrice = null)
        {
            IList<Dissertation> dissertations = maxPrice == null
                ? _dissertationDal.GetAll(d => d.Price == minPrice && !d.IsDeleted)
                : _dissertationDal.GetAll(d => d.Price >= minPrice && d.Price <= maxPrice && !d.IsDeleted);

            return dissertations == null
                ? new ErrorDataResult<IList<Dissertation>>(DissertationConstants.DataNotGet)
                : new SuccessDataResult<IList<Dissertation>>(dissertations, DissertationConstants.DataGet);
        }

        public IDataResult<IList<Dissertation>> GetAllByTechnicalPlaceholder(Guid technicalPlaceholderId)
        {
            IDataResult<TechnicalPlaceholder> tPH = _facadeService.TechnicalPlaceholderService().GetById(technicalPlaceholderId);
            if (!tPH.Success)
                return new ErrorDataResult<IList<Dissertation>>(tPH.Message);

            IList<Dissertation> dissertations = _dissertationDal.GetAll(d => d.TechnicalPlaceholdersId == technicalPlaceholderId && !d.IsDeleted);
            return dissertations == null
                ? new ErrorDataResult<IList<Dissertation>>(DissertationConstants.DataNotGet)
                : new SuccessDataResult<IList<Dissertation>>(dissertations, DissertationConstants.DataGet);
        }

        public IDataResult<IList<Dissertation>> GetAllByTitle(string title)
        {

            IList<Dissertation> dissertations = _dissertationDal.GetAll(d => d.Title.Contains(title) && !d.IsDeleted);
            return dissertations == null
                ? new ErrorDataResult<IList<Dissertation>>(DissertationConstants.DataNotGet)
                : new SuccessDataResult<IList<Dissertation>>(dissertations, DissertationConstants.DataGet);
        }

        public IDataResult<IList<Dissertation>> GetAllByUniversity(Guid universityId)
        {
            IDataResult<University> universities = _facadeService.UniversityService().GetById(universityId);
            if (!universities.Success)
                return new ErrorDataResult<IList<Dissertation>>(universities.Message);

            IList<Dissertation> dissertations = _dissertationDal.GetAll(d => d.UniversityId == universityId && !d.IsDeleted);
            return dissertations == null
                ? new ErrorDataResult<IList<Dissertation>>(DissertationConstants.DataNotGet)
                : new SuccessDataResult<IList<Dissertation>>(dissertations, DissertationConstants.DataGet);
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
            IDataResult<Stock> stock = _facadeService.StockService().GetById(stockId);
            if (!stock.Success)
                return new ErrorDataResult<Dissertation>(stock.Message);

            Dissertation dissertation = _dissertationDal.Get(d => d.Stock == stock.Data && !d.IsDeleted);
            _facadeService.CounterService().Count(dissertation);
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
