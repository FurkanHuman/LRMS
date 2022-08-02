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
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class ThesisManager : IThesisService
    {
        private readonly IThesisDal _thesisDal;
        private readonly IFacadeService _facadeService;

        public ThesisManager(IThesisDal thesisDal, IFacadeService facadeService)
        {
            _thesisDal = thesisDal;
            _facadeService = facadeService;
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

        public IDataResult<List<Thesis>> GetAll()
        {
            return new SuccessDataResult<List<Thesis>>(_thesisDal.GetAll(t => !t.IsDeleted).ToList(), ThesisConstants.DataGet);
        }

        public IDataResult<IEnumerable<Thesis>> GetAllByApprovalStatus(bool status)
        {
            List<Thesis> thesises = _thesisDal.GetAll(t => t.ApprovalStatus == status && !t.IsDeleted).ToList();
            return thesises == null
                ? new ErrorDataResult<List<Thesis>>(ThesisConstants.DataNotGet)
                : new SuccessDataResult<List<Thesis>>(thesises, ThesisConstants.DataGet);
        }

        public IDataResult<List<Thesis>> GetAllByCategories(int[] categoriesId)
        {
            IDataResult<List<Category>> categories = _facadeService.CategoryService().GetAllByIds(categoriesId);
            if (!categories.Success)
                return new ErrorDataResult<List<Thesis>>(categories.Message);

            List<Thesis> thesises = _thesisDal.GetAll(t => t.Categories.ToList() == categories.Data && !t.IsDeleted).ToList();
            return thesises == null
                ? new ErrorDataResult<List<Thesis>>(ThesisConstants.DataNotGet)
                : new SuccessDataResult<List<Thesis>>(thesises, ThesisConstants.DataGet);
        }

        public IDataResult<IEnumerable<Thesis>> GetAllByCityId(int cityId)
        {
            IDataResult<City> city = _facadeService.CityService().GetById(cityId);
            if (!city.Success)
                return new ErrorDataResult<IEnumerable<Thesis>>(city.Message);

            IEnumerable<Thesis> thesises = _thesisDal.GetAll(t => t.City.Id == cityId && !t.IsDeleted);
            return thesises == null
                ? new ErrorDataResult<IEnumerable<Thesis>>(ThesisConstants.DataNotGet)
                : new SuccessDataResult<IEnumerable<Thesis>>(thesises, ThesisConstants.DataGet);
        }

        public IDataResult<IEnumerable<Thesis>> GetAllByCityName(string cityName)
        {
            IDataResult<List<City>> cities = _facadeService.CityService().GetAllByName(cityName);
            if (!cities.Success)
                return new ErrorDataResult<IEnumerable<Thesis>>(cities.Message);

            IEnumerable<Thesis> thesises = _thesisDal.GetAll(t => cities.Data.Any(c => t.City.Id == c.Id) && !t.IsDeleted);
            return thesises == null
                ? new ErrorDataResult<IEnumerable<Thesis>>(ThesisConstants.DataNotGet)
                : new SuccessDataResult<IEnumerable<Thesis>>(thesises, ThesisConstants.DataGet);
        }

        public IDataResult<IEnumerable<Thesis>> GetAllByConsultantId(Guid consultantId)
        {
            IDataResult<Consultant> consultant = _facadeService.ConsultantService().GetById(consultantId);
            if (!consultant.Success)
                return new ErrorDataResult<IEnumerable<Thesis>>(consultant.Message);

            IEnumerable<Thesis> thesises = _thesisDal.GetAll(t => t.Consultant.Id == consultantId && !t.IsDeleted);
            return thesises == null
                ? new ErrorDataResult<IEnumerable<Thesis>>(ThesisConstants.DataNotGet)
                : new SuccessDataResult<IEnumerable<Thesis>>(thesises, ThesisConstants.DataGet);
        }

        public IDataResult<IEnumerable<Thesis>> GetAllByConsultantIds(Guid[] consultantIds)
        {
            IDataResult<List<Consultant>> consultants = _facadeService.ConsultantService().GetAllByIds(consultantIds);
            if (!consultants.Success)
                return new ErrorDataResult<IEnumerable<Thesis>>(consultants.Message);

            IEnumerable<Thesis> thesises = _thesisDal.GetAll(t => consultants.Data.Any(c => t.ConsultantId == c.Id) && !t.IsDeleted);
            return thesises == null
                ? new ErrorDataResult<IEnumerable<Thesis>>(ThesisConstants.DataNotGet)
                : new SuccessDataResult<IEnumerable<Thesis>>(thesises, ThesisConstants.DataGet);
        }

        public IDataResult<IEnumerable<Thesis>> GetAllByCountryCode(string countryCode)
        {
            IDataResult<List<Country>> countries = _facadeService.CountryService().GetAllByCountryCode(countryCode);
            if (!countries.Success)
                return new ErrorDataResult<IEnumerable<Thesis>>(countries.Message);

            IEnumerable<Thesis> thesises = _thesisDal.GetAll(t => countries.Data.Any(c => c.Id == t.City.CountryId) && !t.IsDeleted);
            return thesises == null
                ? new ErrorDataResult<IEnumerable<Thesis>>(ThesisConstants.DataNotGet)
                : new SuccessDataResult<IEnumerable<Thesis>>(thesises, ThesisConstants.DataGet);
        }

        public IDataResult<IEnumerable<Thesis>> GetAllByCountryId(int countryId)
        {
            IDataResult<Country> country = _facadeService.CountryService().GetById(countryId);
            if (!country.Success)
                return new ErrorDataResult<IEnumerable<Thesis>>(country.Message);

            IEnumerable<Thesis> thesises = _thesisDal.GetAll(t => t.City.CountryId == countryId && !t.IsDeleted);
            return thesises == null
                ? new ErrorDataResult<IEnumerable<Thesis>>(ThesisConstants.DataNotGet)
                : new SuccessDataResult<IEnumerable<Thesis>>(thesises, ThesisConstants.DataGet);
        }

        public IDataResult<IEnumerable<Thesis>> GetAllByDateTimeYear(ushort year)
        {
            IEnumerable<Thesis> thesises = _thesisDal.GetAll(t => t.DateTimeYear == year && !t.IsDeleted);
            return thesises == null
                ? new ErrorDataResult<IEnumerable<Thesis>>(ThesisConstants.DataNotGet)
                : new SuccessDataResult<IEnumerable<Thesis>>(thesises, ThesisConstants.DataGet);
        }

        public IDataResult<List<Thesis>> GetAllByDescriptionFinder(string finderString)
        {
            List<Thesis> thesises = _thesisDal.GetAll(t => t.Description.Contains(finderString) && !t.IsDeleted).ToList();
            return thesises == null
                ? new ErrorDataResult<List<Thesis>>(ThesisConstants.DataNotGet)
                : new SuccessDataResult<List<Thesis>>(thesises, ThesisConstants.DataGet);
        }

        public IDataResult<List<Thesis>> GetAllByDimension(Guid dimensionId)
        {
            IDataResult<Dimension> eMFile = _facadeService.DimensionService().GetById(dimensionId);
            if (!eMFile.Success)
                return new ErrorDataResult<List<Thesis>>(eMFile.Message);

            List<Thesis> thesises = _thesisDal.GetAll(t => t.DimensionsId == dimensionId && !t.IsDeleted).ToList();
            return thesises == null
                ? new ErrorDataResult<List<Thesis>>(ThesisConstants.DataNotGet)
                : new SuccessDataResult<List<Thesis>>(thesises, ThesisConstants.DataGet);
        }

        public IDataResult<List<Thesis>> GetAllByEMFile(Guid eMFileId)
        {
            IDataResult<EMaterialFile> eMFile = _facadeService.EMaterialFileService().GetById(eMFileId);
            if (!eMFile.Success)
                return new ErrorDataResult<List<Thesis>>(eMFile.Message);

            List<Thesis> thesises = _thesisDal.GetAll(t => t.EMaterialFilesId == eMFileId && !t.IsDeleted).ToList();
            return thesises == null
                ? new ErrorDataResult<List<Thesis>>(ThesisConstants.DataNotGet)
                : new SuccessDataResult<List<Thesis>>(thesises, ThesisConstants.DataGet);
        }

        public IDataResult<List<Thesis>> GetAllByFilter(Expression<Func<Thesis, bool>>? filter = null)
        {
            return new SuccessDataResult<List<Thesis>>(_thesisDal.GetAll(filter).ToList(), ThesisConstants.DataGet);
        }

        public IDataResult<List<Thesis>> GetAllByIds(Guid[] ids)
        {
            List<Thesis> thesises = _thesisDal.GetAll(t => ids.Contains(t.Id) && !t.IsDeleted).ToList();
            return thesises == null
                ? new ErrorDataResult<List<Thesis>>(ThesisConstants.DataNotGet)
                : new SuccessDataResult<List<Thesis>>(thesises, ThesisConstants.DataGet);
        }

        public IDataResult<IEnumerable<Thesis>> GetAllBylangaugeId(int langaugeId)
        {
            IDataResult<Language> lang = _facadeService.LanguageService().GetById(langaugeId);
            if (!lang.Success)
                return new ErrorDataResult<IEnumerable<Thesis>>(lang.Message);

            IEnumerable<Thesis> thesises = _thesisDal.GetAll(t => t.Language.Id == langaugeId && !t.IsDeleted);
            return thesises == null
                ? new ErrorDataResult<IEnumerable<Thesis>>(ThesisConstants.DataNotGet)
                : new SuccessDataResult<IEnumerable<Thesis>>(thesises, ThesisConstants.DataGet);
        }

        public IDataResult<List<Thesis>> GetAllByName(string name)
        {
            List<Thesis> thesises = _thesisDal.GetAll(t => t.Name.Contains(name) && !t.IsDeleted).ToList();
            return thesises == null
                ? new ErrorDataResult<List<Thesis>>(ThesisConstants.DataNotGet)
                : new SuccessDataResult<List<Thesis>>(thesises, ThesisConstants.DataGet);
        }

        public IDataResult<IEnumerable<Thesis>> GetAllByPermissionStatus(bool status)
        {
            IEnumerable<Thesis> thesises = _thesisDal.GetAll(t => t.PermissionStatus == status && !t.IsDeleted);
            return thesises == null
                ? new ErrorDataResult<IEnumerable<Thesis>>(ThesisConstants.DataNotGet)
                : new SuccessDataResult<IEnumerable<Thesis>>(thesises, ThesisConstants.DataGet);
        }

        public IDataResult<List<Thesis>> GetAllByPrice(decimal minPrice, decimal? maxPrice = null)
        {
            List<Thesis> thesises = maxPrice == null
                ? _thesisDal.GetAll(t => t.Price == minPrice && !t.IsDeleted).ToList()
                : _thesisDal.GetAll(t => t.Price >= minPrice && t.Price <= maxPrice && !t.IsDeleted).ToList();

            return thesises == null
                ? new ErrorDataResult<List<Thesis>>(ThesisConstants.DataNotGet)
                : new SuccessDataResult<List<Thesis>>(thesises, ThesisConstants.DataGet);
        }

        public IDataResult<IEnumerable<Thesis>> GetAllByResearcherId(Guid researcherId)
        {
            IDataResult<Researcher> researcher = _facadeService.ResearcherService().GetById(researcherId);
            if (!researcher.Success)
                return new ErrorDataResult<IEnumerable<Thesis>>(researcher.Message);

            IEnumerable<Thesis> thesises = _thesisDal.GetAll(t => t.ResearcherId == researcherId && !t.IsDeleted);
            return thesises == null
                ? new ErrorDataResult<IEnumerable<Thesis>>(ThesisConstants.DataNotGet)
                : new SuccessDataResult<IEnumerable<Thesis>>(thesises, ThesisConstants.DataGet);
        }

        public IDataResult<IEnumerable<Thesis>> GetAllByResearcherIds(Guid[] researcherIds)
        {
            IDataResult<List<Researcher>> researchers = _facadeService.ResearcherService().GetAllByIds(researcherIds);
            if (!researchers.Success)
                return new ErrorDataResult<IEnumerable<Thesis>>(researchers.Message);

            IEnumerable<Thesis> thesises = _thesisDal.GetAll(t => researchers.Data.Any(r => r.Id == t.ResearcherId) && !t.IsDeleted);
            return thesises == null
                ? new ErrorDataResult<IEnumerable<Thesis>>(ThesisConstants.DataNotGet)
                : new SuccessDataResult<IEnumerable<Thesis>>(thesises, ThesisConstants.DataGet);
        }

        public IDataResult<List<Thesis>> GetAllBySecret()
        {
            return new SuccessDataResult<List<Thesis>>(_thesisDal.GetAll(t => t.IsDeleted).ToList(), ThesisConstants.DataGet);
        }

        public IDataResult<List<Thesis>> GetAllByTechnicalPlaceholder(Guid technicalPlaceholderId)
        {
            var techPlaceHolder = _facadeService.TechnicalPlaceholderService().GetById(technicalPlaceholderId);
            if (!techPlaceHolder.Success)
                return new ErrorDataResult<List<Thesis>>(techPlaceHolder.Message);

            List<Thesis> thesises = _thesisDal.GetAll(t => t.TechnicalPlaceholdersId == technicalPlaceholderId && !t.IsDeleted).ToList();
            return thesises == null
                ? new ErrorDataResult<List<Thesis>>(ThesisConstants.DataNotGet)
                : new SuccessDataResult<List<Thesis>>(thesises, ThesisConstants.DataGet);
        }

        public IDataResult<IEnumerable<Thesis>> GetAllByThesisDegree(byte degree)
        {
            IEnumerable<Thesis> thesises = _thesisDal.GetAll(t => t.ThesisDegree == degree && !t.IsDeleted);
            return thesises == null
                ? new ErrorDataResult<IEnumerable<Thesis>>(ThesisConstants.DataNotGet)
                : new SuccessDataResult<IEnumerable<Thesis>>(thesises, ThesisConstants.DataGet);
        }

        public IDataResult<IEnumerable<Thesis>> GetAllByThesisNumber(int thesisNumber)
        {
            IEnumerable<Thesis> thesises = _thesisDal.GetAll(t => t.ThesisNumber == thesisNumber && !t.IsDeleted);
            return thesises == null
                ? new ErrorDataResult<IEnumerable<Thesis>>(ThesisConstants.DataNotGet)
                : new SuccessDataResult<IEnumerable<Thesis>>(thesises, ThesisConstants.DataGet);
        }

        public IDataResult<List<Thesis>> GetAllByTitle(string title)
        {
            List<Thesis> thesises = _thesisDal.GetAll(t => t.Title.Contains(title) && !t.IsDeleted).ToList();
            return thesises == null
                ? new ErrorDataResult<List<Thesis>>(ThesisConstants.DataNotGet)
                : new SuccessDataResult<List<Thesis>>(thesises, ThesisConstants.DataGet);
        }

        public IDataResult<IEnumerable<Thesis>> GetAllByUniversityId(Guid universityId)
        {
            IDataResult<University> university = _facadeService.UniversityService().GetById(universityId);
            if (!university.Success)
                return new ErrorDataResult<IEnumerable<Thesis>>(university.Message);

            IEnumerable<Thesis> thesises = _thesisDal.GetAll(t => t.UniversityId == universityId && !t.IsDeleted);
            return thesises == null
                ? new ErrorDataResult<IEnumerable<Thesis>>(ThesisConstants.DataNotGet)
                : new SuccessDataResult<IEnumerable<Thesis>>(thesises, ThesisConstants.DataGet);
        }

        public IDataResult<IEnumerable<Thesis>> GetAllByUniversityId(Guid[] universityIds)
        {
            IDataResult<List<University>> universities = _facadeService.UniversityService().GetAllByIds(universityIds);
            if (!universities.Success)
                return new ErrorDataResult<IEnumerable<Thesis>>(universities.Message);

            IEnumerable<Thesis> thesises = _thesisDal.GetAll(t => universities.Data.Any(u => u.Id == t.UniversityId) && !t.IsDeleted);
            return thesises == null
                ? new ErrorDataResult<IEnumerable<Thesis>>(ThesisConstants.DataNotGet)
                : new SuccessDataResult<IEnumerable<Thesis>>(thesises, ThesisConstants.DataGet);
        }

        public IDataResult<Thesis> GetById(Guid id)
        {
            Thesis thesis = _thesisDal.Get(t => t.Id == id);
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
