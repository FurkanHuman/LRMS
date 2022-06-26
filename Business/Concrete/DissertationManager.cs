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

        [ValidationAspect(typeof(DissertationValidator))]
        public IResult Add(Dissertation entity)
        {
            IResult result = BusinessRules.Run(DissertationControl(entity));
            if (result != null)
                return new ErrorResult(result.Message);

            _dissertationDal.Add(entity);
            return new SuccessResult(DissertationConstans.AddSuccess);
        }

        public IResult Delete(Guid id)
        {
            Dissertation dissertation = _dissertationDal.Get(d => d.Id == id);
            if (dissertation == null)
                return new ErrorResult(DissertationConstans.NotMatch);

            _dissertationDal.Delete(dissertation);
            return new SuccessResult(DissertationConstans.DeleteSuccess);
        }

        public IResult ShadowDelete(Guid id)
        {
            Dissertation dissertation = _dissertationDal.Get(d => d.Id == id && !d.IsDeleted);
            if (dissertation == null)
                return new ErrorResult(DissertationConstans.NotMatch);

            dissertation.IsDeleted = false;
            _dissertationDal.Update(dissertation);
            return new SuccessResult(DissertationConstans.EfDeletedSuccsess);
        }

        [ValidationAspect(typeof(DissertationValidator))]
        public IResult Update(Dissertation entity)
        {
            IResult result = BusinessRules.Run(DissertationControl(entity));
            if (result != null)
                return new ErrorResult(result.Message);

            entity.IsDeleted = false;
            _dissertationDal.Update(entity);
            return new SuccessResult(DissertationConstans.UpdateSuccess);
        }

        public IDataResult<List<Dissertation>> GetAll()
        {
            return new SuccessDataResult<List<Dissertation>>(_dissertationDal.GetAll(d => !d.IsDeleted).ToList(), DissertationConstans.DataGet);
        }

        public IDataResult<List<Dissertation>> GetAllByFilter(Expression<Func<Dissertation, bool>>? filter = null)
        {
            return new SuccessDataResult<List<Dissertation>>(_dissertationDal.GetAll(filter).ToList(), DissertationConstans.DataGet);
        }

        public IDataResult<List<Dissertation>> GetAllBySecrets()
        {
            return new SuccessDataResult<List<Dissertation>>(_dissertationDal.GetAll(d => d.IsDeleted).ToList(), DissertationConstans.DataGet);
        }

        public IDataResult<Dissertation> GetByApprovalStatus(Guid id)
        {
            Dissertation dissertation = _dissertationDal.Get(d => d.Id == id && !d.IsDeleted);
            return dissertation == null
                ? new ErrorDataResult<Dissertation>(DissertationConstans.DataNotGet)
                : new SuccessDataResult<Dissertation>(dissertation, DissertationConstans.DataGet);
        }

        public IDataResult<List<Dissertation>> GetByCategories(int[] categoriesId)
        {
            IDataResult<List<Category>> categories = _categoryService.GetByIds(categoriesId);
            if (!categories.Success)
                return new ErrorDataResult<List<Dissertation>>(categories.Message);

            List<Dissertation> dissertations = _dissertationDal.GetAll(d => categoriesId.Contains(d.CategoryId) && !d.IsDeleted).ToList();
            return dissertations == null
                ? new ErrorDataResult<List<Dissertation>>(DissertationConstans.DataNotGet)
                : new SuccessDataResult<List<Dissertation>>(dissertations, DissertationConstans.DataGet);
        }

        public IDataResult<List<Dissertation>> GetByCities(int cityId)
        {
            IDataResult<City> city = _cityService.GetById(cityId);
            if (city.Success)
                return new ErrorDataResult<List<Dissertation>>(city.Message);

            List<Dissertation> dissertations = _dissertationDal.GetAll(d => d.City.Id == cityId && !d.IsDeleted).ToList();
            return dissertations == null
                ? new ErrorDataResult<List<Dissertation>>(DissertationConstans.DataNotGet)
                : new SuccessDataResult<List<Dissertation>>(dissertations, DissertationConstans.DataGet);
        }

        public IDataResult<List<Dissertation>> GetByCountries(int countryId)
        {
            IDataResult<Country> country = _countryService.GetById(countryId);
            if (country.Success)
                return new ErrorDataResult<List<Dissertation>>(country.Message);

            List<Dissertation> dissertations = _dissertationDal.GetAll(d => d.City.CountryId == countryId && !d.IsDeleted).ToList();
            return dissertations == null
                ? new ErrorDataResult<List<Dissertation>>(DissertationConstans.DataNotGet)
                : new SuccessDataResult<List<Dissertation>>(dissertations, DissertationConstans.DataGet);
        }

        public IDataResult<List<Dissertation>> GetByDateTimeYear(ushort year, ushort? yearMax = null)
        {
            List<Dissertation> dissertations = yearMax == null
                ? _dissertationDal.GetAll(d => d.DateTimeYear == year && !d.IsDeleted).ToList()
                : _dissertationDal.GetAll(d => d.DateTimeYear >= year && d.DateTimeYear <= yearMax && !d.IsDeleted).ToList();

            return dissertations == null
                ? new ErrorDataResult<List<Dissertation>>(DissertationConstans.DataNotGet)
                : new SuccessDataResult<List<Dissertation>>(dissertations, DissertationConstans.DataGet);
        }

        public IDataResult<List<Dissertation>> GetByDescriptionFinder(string finderString)
        {
            List<Dissertation> dissertations = _dissertationDal.GetAll(d => d.Description.Contains(finderString) && !d.IsDeleted).ToList();
            return dissertations == null
                ? new ErrorDataResult<List<Dissertation>>(DissertationConstans.DataNotGet)
                : new SuccessDataResult<List<Dissertation>>(dissertations, DissertationConstans.DataGet);
        }

        public IDataResult<List<Dissertation>> GetByDimension(Guid dimensionId)
        {
            IDataResult<Dimension> dimension = _dimensionService.GetById(dimensionId);
            if (!dimension.Success)
                return new ErrorDataResult<List<Dissertation>>(dimension.Message);

            List<Dissertation> dissertations = _dissertationDal.GetAll(d => d.DimensionsId == dimensionId && !d.IsDeleted).ToList();
            return dissertations == null
                ? new ErrorDataResult<List<Dissertation>>(DissertationConstans.DataNotGet)
                : new SuccessDataResult<List<Dissertation>>(dissertations, DissertationConstans.DataGet);
        }


        public IDataResult<List<Dissertation>> GetByDissertationNumber(int dissertationNumber)
        {
            List<Dissertation> dissertations = _dissertationDal.GetAll(d => d.DissertationNumber == dissertationNumber && !d.IsDeleted).ToList();
            return dissertations == null
                ? new ErrorDataResult<List<Dissertation>>(DissertationConstans.DataNotGet)
                : new SuccessDataResult<List<Dissertation>>(dissertations, DissertationConstans.DataGet);
        }

        public IDataResult<List<Dissertation>> GetByEMFiles(Guid eMFilesId)
        {
            var eMFiles = _eMaterialFileService.GetById(eMFilesId);
            if (!eMFiles.Success)
                return new ErrorDataResult<List<Dissertation>>(eMFiles.Message);

            List<Dissertation> dissertations = _dissertationDal.GetAll(d => d.EMaterialFilesId == eMFilesId && !d.IsDeleted).ToList();
            return dissertations == null
                ? new ErrorDataResult<List<Dissertation>>(DissertationConstans.DataNotGet)
                : new SuccessDataResult<List<Dissertation>>(dissertations, DissertationConstans.DataGet);
        }

        public IDataResult<Dissertation> GetById(Guid id)
        {
            Dissertation dissertation = _dissertationDal.Get(d => id == d.Id && !d.IsDeleted);
            return dissertation == null
                ? new ErrorDataResult<Dissertation>(DissertationConstans.DataNotGet)
                : new SuccessDataResult<Dissertation>(dissertation, DissertationConstans.DataGet);
        }

        public IDataResult<List<Dissertation>> GetByIds(Guid[] ids)
        {
            List<Dissertation> dissertations = _dissertationDal.GetAll(d => ids.Contains(d.Id) && !d.IsDeleted).ToList();
            return dissertations == null
                ? new ErrorDataResult<List<Dissertation>>(DissertationConstans.DataNotGet)
                : new SuccessDataResult<List<Dissertation>>(dissertations, DissertationConstans.DataGet);
        }

        public IDataResult<List<Dissertation>> GetByLanguages(int languageId)
        {
            IDataResult<Language> language = _languageService.GetById(languageId);
            if (!language.Success)
                return new ErrorDataResult<List<Dissertation>>(language.Message);

            List<Dissertation> dissertations = _dissertationDal.GetAll(d => d.Language.Id == languageId && !d.IsDeleted).ToList();
            return dissertations == null
                ? new ErrorDataResult<List<Dissertation>>(DissertationConstans.DataNotGet)
                : new SuccessDataResult<List<Dissertation>>(dissertations, DissertationConstans.DataGet);
        }

        public IDataResult<List<Dissertation>> GetByNames(string name)
        {
            List<Dissertation> dissertations = _dissertationDal.GetAll(d => d.Name.Contains(name) && !d.IsDeleted).ToList();
            return dissertations == null
                ? new ErrorDataResult<List<Dissertation>>(DissertationConstans.DataNotGet)
                : new SuccessDataResult<List<Dissertation>>(dissertations, DissertationConstans.DataGet);
        }

        public IDataResult<List<Dissertation>> GetByPrice(decimal minPrice, decimal? maxPrice = null)
        {
            List<Dissertation> dissertations = maxPrice == null
                ? _dissertationDal.GetAll(d => d.Price == minPrice && !d.IsDeleted).ToList()
                : _dissertationDal.GetAll(d => d.Price >= minPrice && d.Price <= maxPrice && !d.IsDeleted).ToList();

            return dissertations == null
                ? new ErrorDataResult<List<Dissertation>>(DissertationConstans.DataNotGet)
                : new SuccessDataResult<List<Dissertation>>(dissertations, DissertationConstans.DataGet);
        }

        public IDataResult<List<Dissertation>> GetByTechnicalPlaceholders(Guid technicalPlaceholderId)
        {
            IDataResult<TechnicalPlaceholder> tPH = _technicalPlaceholderService.GetById(technicalPlaceholderId);
            if (!tPH.Success)
                return new ErrorDataResult<List<Dissertation>>(tPH.Message);

            List<Dissertation> dissertations = _dissertationDal.GetAll(d => d.TechnicalPlaceholdersId == technicalPlaceholderId && !d.IsDeleted).ToList();
            return dissertations == null
                ? new ErrorDataResult<List<Dissertation>>(DissertationConstans.DataNotGet)
                : new SuccessDataResult<List<Dissertation>>(dissertations, DissertationConstans.DataGet);
        }

        public IDataResult<List<Dissertation>> GetByTitles(string title)
        {

            List<Dissertation> dissertations = _dissertationDal.GetAll(d => d.Title.Contains(title) && !d.IsDeleted).ToList();
            return dissertations == null
                ? new ErrorDataResult<List<Dissertation>>(DissertationConstans.DataNotGet)
                : new SuccessDataResult<List<Dissertation>>(dissertations, DissertationConstans.DataGet);
        }

        public IDataResult<List<Dissertation>> GetByUniversity(Guid universityId)
        {
            IDataResult<University> universities = _universityService.GetById(universityId);
            if (!universities.Success)
                return new ErrorDataResult<List<Dissertation>>(universities.Message);

            List<Dissertation> dissertations = _dissertationDal.GetAll(d => d.UniversityId == universityId && !d.IsDeleted).ToList();
            return dissertations == null
                ? new ErrorDataResult<List<Dissertation>>(DissertationConstans.DataNotGet)
                : new SuccessDataResult<List<Dissertation>>(dissertations, DissertationConstans.DataGet);
        }

        public IDataResult<byte?> GetSecretLevel(Guid id)
        {
            byte? sLevel = _dissertationDal.Get(d => d.Id == id && !d.IsDeleted).SecretLevel;
            return sLevel == null
                ? new ErrorDataResult<byte?>(DissertationConstans.DataNotGet)
                : new SuccessDataResult<byte?>(sLevel, DissertationConstans.DataGet);
        }

        public IDataResult<byte> GetState(Guid id)
        {
            return new SuccessDataResult<byte>(_dissertationDal.Get(d => d.Id == id && !d.IsDeleted).State, DissertationConstans.DataGet);
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
                return new ErrorResult(DissertationConstans.AlreadyExists);
            return new SuccessResult();
        }
    }
}
