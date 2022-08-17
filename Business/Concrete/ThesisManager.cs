namespace Business.Concrete
{
    public class ThesisManager : IThesisService
    {
        private readonly IThesisDal _thesisDal;
        private readonly IFacadeService _facadeService;

        public ThesisManager(IThesisDal thesisDal)
        {
            _thesisDal = thesisDal;
        }

        [ValidationAspect(typeof(ThesisValidator))]
        public IResult Add(Thesis thesis)
        {
            IResult result = BusinessRules.Run(ThesisDbControl(thesis));
            if (result != null)
                return result;

            thesis.IsDeleted = false;
            _thesisDal.Add(thesis);
            return new SuccessResult(ThesisConstants.AddSuccess);
        }

        public IResult Delete(Guid id)
        {
            Thesis thesis = _thesisDal.Get(t => t.Id == id);
            if (thesis == null)
                return new ErrorResult(ThesisConstants.NotMatch);

            _thesisDal.Delete(thesis);
            return new SuccessResult(ThesisConstants.DeleteSuccess);
        }

        public IResult ShadowDelete(Guid id)
        {
            Thesis thesis = _thesisDal.Get(t => t.Id == id);
            if (thesis == null)
                return new ErrorResult(ThesisConstants.NotMatch);

            thesis.IsDeleted = true;
            _thesisDal.Update(thesis);
            return new SuccessResult(ThesisConstants.DeleteSuccess);
        }

        [ValidationAspect(typeof(ThesisValidator))]
        public IResult Update(Thesis thesis)
        {
            IResult result = BusinessRules.Run(ThesisDbControl(thesis));
            if (result != null)
                return result;

            thesis.IsDeleted = false;
            _thesisDal.Update(thesis);
            return new SuccessResult(ThesisConstants.AddSuccess);
        }

        public IDataResult<IList<Thesis>> GetAll()
        {
            return new SuccessDataResult<IList<Thesis>>(_thesisDal.GetAll(t => !t.IsDeleted), ThesisConstants.DataGet);
        }

        public IDataResult<IList<Thesis>> GetAllByApprovalStatus(bool status)
        {
            IList<Thesis> thesises = _thesisDal.GetAll(t => t.ApprovalStatus == status && !t.IsDeleted);
            return thesises == null
                ? new ErrorDataResult<IList<Thesis>>(ThesisConstants.DataNotGet)
                : new SuccessDataResult<IList<Thesis>>(thesises, ThesisConstants.DataGet);
        }

        public IDataResult<IList<Thesis>> GetAllByCategories(int[] categoriesId)
        {
            IDataResult<IList<Category>> categories = _facadeService.CategoryService().GetAllByIds(categoriesId);
            if (!categories.Success)
                return new ErrorDataResult<IList<Thesis>>(categories.Message);

            IList<Thesis> thesises = _thesisDal.GetAll(t => t.Categories == categories.Data && !t.IsDeleted);
            return thesises == null
                ? new ErrorDataResult<IList<Thesis>>(ThesisConstants.DataNotGet)
                : new SuccessDataResult<IList<Thesis>>(thesises, ThesisConstants.DataGet);
        }

        public IDataResult<IList<Thesis>> GetAllByCityId(int cityId)
        {
            IDataResult<City> city = _facadeService.CityService().GetById(cityId);
            if (!city.Success)
                return new ErrorDataResult<IList<Thesis>>(city.Message);

            IList<Thesis> thesises = _thesisDal.GetAll(t => t.City.Id == cityId && !t.IsDeleted);
            return thesises == null
                ? new ErrorDataResult<IList<Thesis>>(ThesisConstants.DataNotGet)
                : new SuccessDataResult<IList<Thesis>>(thesises, ThesisConstants.DataGet);
        }

        public IDataResult<IList<Thesis>> GetAllByCityName(string cityName)
        {
            IDataResult<IList<City>> cities = _facadeService.CityService().GetAllByName(cityName);
            if (!cities.Success)
                return new ErrorDataResult<IList<Thesis>>(cities.Message);

            IList<Thesis> thesises = _thesisDal.GetAll(t => cities.Data.Any(c => t.City.Id == c.Id) && !t.IsDeleted);
            return thesises == null
                ? new ErrorDataResult<IList<Thesis>>(ThesisConstants.DataNotGet)
                : new SuccessDataResult<IList<Thesis>>(thesises, ThesisConstants.DataGet);
        }

        public IDataResult<IList<Thesis>> GetAllByConsultantId(Guid consultantId)
        {
            IDataResult<Consultant> consultant = _facadeService.ConsultantService().GetById(consultantId);
            if (!consultant.Success)
                return new ErrorDataResult<IList<Thesis>>(consultant.Message);

            IList<Thesis> thesises = _thesisDal.GetAll(t => t.Consultant.Id == consultantId && !t.IsDeleted);
            return thesises == null
                ? new ErrorDataResult<IList<Thesis>>(ThesisConstants.DataNotGet)
                : new SuccessDataResult<IList<Thesis>>(thesises, ThesisConstants.DataGet);
        }

        public IDataResult<IList<Thesis>> GetAllByConsultantIds(Guid[] consultantIds)
        {
            IDataResult<IList<Consultant>> consultants = _facadeService.ConsultantService().GetAllByIds(consultantIds);
            if (!consultants.Success)
                return new ErrorDataResult<IList<Thesis>>(consultants.Message);

            IList<Thesis> thesises = _thesisDal.GetAll(t => consultants.Data.Any(c => t.ConsultantId == c.Id) && !t.IsDeleted);
            return thesises == null
                ? new ErrorDataResult<IList<Thesis>>(ThesisConstants.DataNotGet)
                : new SuccessDataResult<IList<Thesis>>(thesises, ThesisConstants.DataGet);
        }

        public IDataResult<IList<Thesis>> GetAllByCountryCode(string countryCode)
        {
            IDataResult<IList<Country>> countries = _facadeService.CountryService().GetAllByCountryCode(countryCode);
            if (!countries.Success)
                return new ErrorDataResult<IList<Thesis>>(countries.Message);

            IList<Thesis> thesises = _thesisDal.GetAll(t => countries.Data.Any(c => c.Id == t.City.CountryId) && !t.IsDeleted);
            return thesises == null
                ? new ErrorDataResult<IList<Thesis>>(ThesisConstants.DataNotGet)
                : new SuccessDataResult<IList<Thesis>>(thesises, ThesisConstants.DataGet);
        }

        public IDataResult<IList<Thesis>> GetAllByCountryId(int countryId)
        {
            IDataResult<Country> country = _facadeService.CountryService().GetById(countryId);
            if (!country.Success)
                return new ErrorDataResult<IList<Thesis>>(country.Message);

            IList<Thesis> thesises = _thesisDal.GetAll(t => t.City.CountryId == countryId && !t.IsDeleted);
            return thesises == null
                ? new ErrorDataResult<IList<Thesis>>(ThesisConstants.DataNotGet)
                : new SuccessDataResult<IList<Thesis>>(thesises, ThesisConstants.DataGet);
        }

        public IDataResult<IList<Thesis>> GetAllByDateTimeYear(ushort year)
        {
            IList<Thesis> thesises = _thesisDal.GetAll(t => t.DateTimeYear == year && !t.IsDeleted);
            return thesises == null
                ? new ErrorDataResult<IList<Thesis>>(ThesisConstants.DataNotGet)
                : new SuccessDataResult<IList<Thesis>>(thesises, ThesisConstants.DataGet);
        }

        public IDataResult<IList<Thesis>> GetAllByDescriptionFinder(string finderString)
        {
            IList<Thesis> thesises = _thesisDal.GetAll(t => t.Description.Contains(finderString) && !t.IsDeleted);
            return thesises == null
                ? new ErrorDataResult<IList<Thesis>>(ThesisConstants.DataNotGet)
                : new SuccessDataResult<IList<Thesis>>(thesises, ThesisConstants.DataGet);
        }

        public IDataResult<IList<Thesis>> GetAllByDimension(Guid dimensionId)
        {
            IDataResult<Dimension> eMFile = _facadeService.DimensionService().GetById(dimensionId);
            if (!eMFile.Success)
                return new ErrorDataResult<IList<Thesis>>(eMFile.Message);

            IList<Thesis> thesises = _thesisDal.GetAll(t => t.DimensionsId == dimensionId && !t.IsDeleted);
            return thesises == null
                ? new ErrorDataResult<IList<Thesis>>(ThesisConstants.DataNotGet)
                : new SuccessDataResult<IList<Thesis>>(thesises, ThesisConstants.DataGet);
        }

        public IDataResult<IList<Thesis>> GetAllByEMFile(Guid eMFileId)
        {
            IDataResult<EMaterialFile> eMFile = _facadeService.EMaterialFileService().GetById(eMFileId);
            if (!eMFile.Success)
                return new ErrorDataResult<IList<Thesis>>(eMFile.Message);

            IList<Thesis> thesises = _thesisDal.GetAll(t => t.EMaterialFilesId == eMFileId && !t.IsDeleted);
            return thesises == null
                ? new ErrorDataResult<IList<Thesis>>(ThesisConstants.DataNotGet)
                : new SuccessDataResult<IList<Thesis>>(thesises, ThesisConstants.DataGet);
        }

        public IDataResult<IList<Thesis>> GetAllByFilter(Expression<Func<Thesis, bool>>? filter = null)
        {
            return new SuccessDataResult<IList<Thesis>>(_thesisDal.GetAll(filter), ThesisConstants.DataGet);
        }

        public IDataResult<IList<Thesis>> GetAllByIds(Guid[] ids)
        {
            IList<Thesis> thesises = _thesisDal.GetAll(t => ids.Contains(t.Id) && !t.IsDeleted);
            _facadeService.CounterService().Count(thesises);
            return thesises == null
                ? new ErrorDataResult<IList<Thesis>>(ThesisConstants.DataNotGet)
                : new SuccessDataResult<IList<Thesis>>(thesises, ThesisConstants.DataGet);
        }

        public IDataResult<IList<Thesis>> GetAllBylangaugeId(int langaugeId)
        {
            IDataResult<Language> lang = _facadeService.LanguageService().GetById(langaugeId);
            if (!lang.Success)
                return new ErrorDataResult<IList<Thesis>>(lang.Message);

            IList<Thesis> thesises = _thesisDal.GetAll(t => t.Language.Id == langaugeId && !t.IsDeleted);
            return thesises == null
                ? new ErrorDataResult<IList<Thesis>>(ThesisConstants.DataNotGet)
                : new SuccessDataResult<IList<Thesis>>(thesises, ThesisConstants.DataGet);
        }

        public IDataResult<IList<Thesis>> GetAllByName(string name)
        {
            IList<Thesis> thesises = _thesisDal.GetAll(t => t.Name.Contains(name) && !t.IsDeleted);
            return thesises == null
                ? new ErrorDataResult<IList<Thesis>>(ThesisConstants.DataNotGet)
                : new SuccessDataResult<IList<Thesis>>(thesises, ThesisConstants.DataGet);
        }

        public IDataResult<IList<Thesis>> GetAllByPermissionStatus(bool status)
        {
            IList<Thesis> thesises = _thesisDal.GetAll(t => t.PermissionStatus == status && !t.IsDeleted);
            return thesises == null
                ? new ErrorDataResult<IList<Thesis>>(ThesisConstants.DataNotGet)
                : new SuccessDataResult<IList<Thesis>>(thesises, ThesisConstants.DataGet);
        }

        public IDataResult<IList<Thesis>> GetAllByPrice(decimal minPrice, decimal? maxPrice = null)
        {
            IList<Thesis> thesises = maxPrice == null
                ? _thesisDal.GetAll(t => t.Price == minPrice && !t.IsDeleted)
                : _thesisDal.GetAll(t => t.Price >= minPrice && t.Price <= maxPrice && !t.IsDeleted);

            return thesises == null
                ? new ErrorDataResult<IList<Thesis>>(ThesisConstants.DataNotGet)
                : new SuccessDataResult<IList<Thesis>>(thesises, ThesisConstants.DataGet);
        }

        public IDataResult<IList<Thesis>> GetAllByResearcherId(Guid researcherId)
        {
            IDataResult<Researcher> researcher = _facadeService.ResearcherService().GetById(researcherId);
            if (!researcher.Success)
                return new ErrorDataResult<IList<Thesis>>(researcher.Message);

            IList<Thesis> thesises = _thesisDal.GetAll(t => t.ResearcherId == researcherId && !t.IsDeleted);
            return thesises == null
                ? new ErrorDataResult<IList<Thesis>>(ThesisConstants.DataNotGet)
                : new SuccessDataResult<IList<Thesis>>(thesises, ThesisConstants.DataGet);
        }

        public IDataResult<IList<Thesis>> GetAllByResearcherIds(Guid[] researcherIds)
        {
            IDataResult<IList<Researcher>> researchers = _facadeService.ResearcherService().GetAllByIds(researcherIds);
            if (!researchers.Success)
                return new ErrorDataResult<IList<Thesis>>(researchers.Message);

            IList<Thesis> thesises = _thesisDal.GetAll(t => researchers.Data.Any(r => r.Id == t.ResearcherId) && !t.IsDeleted);
            return thesises == null
                ? new ErrorDataResult<IList<Thesis>>(ThesisConstants.DataNotGet)
                : new SuccessDataResult<IList<Thesis>>(thesises, ThesisConstants.DataGet);
        }

        public IDataResult<IList<Thesis>> GetAllByIsDeleted()
        {
            return new SuccessDataResult<IList<Thesis>>(_thesisDal.GetAll(t => t.IsDeleted), ThesisConstants.DataGet);
        }

        public IDataResult<IList<Thesis>> GetAllByTechnicalPlaceholder(Guid technicalPlaceholderId)
        {
            var techPlaceHolder = _facadeService.TechnicalPlaceholderService().GetById(technicalPlaceholderId);
            if (!techPlaceHolder.Success)
                return new ErrorDataResult<IList<Thesis>>(techPlaceHolder.Message);

            IList<Thesis> thesises = _thesisDal.GetAll(t => t.TechnicalPlaceholdersId == technicalPlaceholderId && !t.IsDeleted);
            return thesises == null
                ? new ErrorDataResult<IList<Thesis>>(ThesisConstants.DataNotGet)
                : new SuccessDataResult<IList<Thesis>>(thesises, ThesisConstants.DataGet);
        }

        public IDataResult<IList<Thesis>> GetAllByThesisDegree(byte degree)
        {
            IList<Thesis> thesises = _thesisDal.GetAll(t => t.ThesisDegree == degree && !t.IsDeleted);
            return thesises == null
                ? new ErrorDataResult<IList<Thesis>>(ThesisConstants.DataNotGet)
                : new SuccessDataResult<IList<Thesis>>(thesises, ThesisConstants.DataGet);
        }

        public IDataResult<IList<Thesis>> GetAllByThesisNumber(int thesisNumber)
        {
            IList<Thesis> thesises = _thesisDal.GetAll(t => t.ThesisNumber == thesisNumber && !t.IsDeleted);
            return thesises == null
                ? new ErrorDataResult<IList<Thesis>>(ThesisConstants.DataNotGet)
                : new SuccessDataResult<IList<Thesis>>(thesises, ThesisConstants.DataGet);
        }

        public IDataResult<IList<Thesis>> GetAllByTitle(string title)
        {
            IList<Thesis> thesises = _thesisDal.GetAll(t => t.Title.Contains(title) && !t.IsDeleted);
            return thesises == null
                ? new ErrorDataResult<IList<Thesis>>(ThesisConstants.DataNotGet)
                : new SuccessDataResult<IList<Thesis>>(thesises, ThesisConstants.DataGet);
        }

        public IDataResult<IList<Thesis>> GetAllByUniversityId(Guid universityId)
        {
            IDataResult<University> university = _facadeService.UniversityService().GetById(universityId);
            if (!university.Success)
                return new ErrorDataResult<IList<Thesis>>(university.Message);

            IList<Thesis> thesises = _thesisDal.GetAll(t => t.UniversityId == universityId && !t.IsDeleted);
            return thesises == null
                ? new ErrorDataResult<IList<Thesis>>(ThesisConstants.DataNotGet)
                : new SuccessDataResult<IList<Thesis>>(thesises, ThesisConstants.DataGet);
        }

        public IDataResult<IList<Thesis>> GetAllByUniversityId(Guid[] universityIds)
        {
            IDataResult<IList<University>> universities = _facadeService.UniversityService().GetAllByIds(universityIds);
            if (!universities.Success)
                return new ErrorDataResult<IList<Thesis>>(universities.Message);

            IList<Thesis> thesises = _thesisDal.GetAll(t => universities.Data.Any(u => u.Id == t.UniversityId) && !t.IsDeleted);
            return thesises == null
                ? new ErrorDataResult<IList<Thesis>>(ThesisConstants.DataNotGet)
                : new SuccessDataResult<IList<Thesis>>(thesises, ThesisConstants.DataGet);
        }

        public IDataResult<Thesis> GetById(Guid id)
        {
            Thesis thesis = _thesisDal.Get(t => t.Id == id);
            _facadeService.CounterService().Count(thesis);
            return thesis == null
                ? new ErrorDataResult<Thesis>(ThesisConstants.DataNotGet)
                : new SuccessDataResult<Thesis>(thesis, ThesisConstants.DataGet);
        }

        public IDataResult<Thesis> GetByStock(Guid stockId)
        {
            IDataResult<Stock> stock = _facadeService.StockService().GetById(stockId);
            if (!stock.Success)
                return new ErrorDataResult<Thesis>(stock.Message);

            Thesis thesis = _thesisDal.Get(t => t.StockId == stockId && !t.IsDeleted);
            _facadeService.CounterService().Count(thesis);
            return thesis == null
                ? new ErrorDataResult<Thesis>(ThesisConstants.DataNotGet)
                : new SuccessDataResult<Thesis>(thesis, ThesisConstants.DataGet);
        }

        public IDataResult<byte?> GetSecretLevel(Guid id)
        {
            byte? sLevel = _thesisDal.Get(t => t.Id == id && !t.IsDeleted).SecretLevel;
            return sLevel == null
                ? new ErrorDataResult<byte?>(ThesisConstants.DataNotGet)
                : new SuccessDataResult<byte?>(sLevel, ThesisConstants.DataGet);
        }

        public IDataResult<byte> GetState(Guid id)
        {
            return new SuccessDataResult<byte>(_thesisDal.Get(t => t.Id == id && !t.IsDeleted).State, ThesisConstants.DataGet);
        }

        private IResult ThesisDbControl(Thesis thesis)
        {
            bool thesisDbControl = _thesisDal.Get(t =>
            // todo return here 

               t.Name == thesis.Name
            && t.Title == thesis.Title
            && t.Description.Contains(thesis.Description)
            && t.Categories == thesis.Categories
            && t.TechnicalPlaceholdersId == thesis.TechnicalPlaceholdersId
            && t.Stock.Id == thesis.StockId
            && t.EMaterialFiles == thesis.EMaterialFiles
            && t.State == thesis.State
            && t.UniversityId == thesis.UniversityId
            && t.ThesisDegree == thesis.ThesisDegree
            && t.ResearcherId == thesis.ResearcherId
            && t.ConsultantId == thesis.ConsultantId
            && t.City.Id == thesis.City.Id
            && t.DateTimeYear == thesis.DateTimeYear
            && t.Language.Id == thesis.Language.Id
            && t.ThesisNumber == thesis.ThesisNumber
            && t.PermissionStatus == thesis.PermissionStatus
            && t.ApprovalStatus == thesis.ApprovalStatus

            ) != null;

            if (thesisDbControl)
                return new ErrorResult(ThesisConstants.AlreadyExists);

            return new SuccessResult();
        }
    }
}
