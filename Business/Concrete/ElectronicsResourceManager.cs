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
    public class ElectronicsResourceManager : IElectronicsResourceService
    {
        private readonly IElectronicsResourceDal _electronicsResourceDal;

        private readonly ICategoryService _categoryService;
        private readonly IDimensionService _dimensionService;
        private readonly IEMaterialFileService _eMaterialFileService;
        private readonly ITechnicalPlaceholderService _technicalPlaceholderService;
        private readonly IStockService _stockService;

        [ValidationAspect(typeof(ElectronicsResourceValidator))]
        public IResult Add(ElectronicsResource electronicsResource)
        {
            IResult result = BusinessRules.Run(ElectronicsResourceControl(electronicsResource));
            if (result != null)
                return result;

            electronicsResource.IsDeleted = false;
            _electronicsResourceDal.Add(electronicsResource);
            return new SuccessResult(ElectronicsResourceConstants.AddSuccess);
        }

        public IResult Delete(Guid id)
        {
            ElectronicsResource electronicsResource = _electronicsResourceDal.Get(er => er.Id == id);
            if (electronicsResource == null)
                return new SuccessResult(ElectronicsResourceConstants.NotMatch);

            electronicsResource.IsDeleted = true;
            _electronicsResourceDal.Update(electronicsResource);
            return new SuccessResult(ElectronicsResourceConstants.EfDeletedSuccsess);
        }

        public IResult ShadowDelete(Guid id)
        {
            ElectronicsResource electronicsResource = _electronicsResourceDal.Get(er => er.Id == id && !er.IsDeleted);
            if (electronicsResource == null)
                return new SuccessResult(ElectronicsResourceConstants.NotMatch);

            electronicsResource.IsDeleted = true;
            _electronicsResourceDal.Update(electronicsResource);
            return new SuccessResult(ElectronicsResourceConstants.EfDeletedSuccsess);
        }

        [ValidationAspect(typeof(ElectronicsResourceValidator))]
        public IResult Update(ElectronicsResource electronicsResource)
        {
            IResult result = BusinessRules.Run(ElectronicsResourceControl(electronicsResource));
            if (result != null)
                return result;

            electronicsResource.IsDeleted = false;
            _electronicsResourceDal.Update(electronicsResource);
            return new SuccessResult(ElectronicsResourceConstants.UpdateSuccess);
        }

        public IDataResult<List<ElectronicsResource>> GetAll()
        {
            return new SuccessDataResult<List<ElectronicsResource>>(_electronicsResourceDal.GetAll(er => !er.IsDeleted).ToList(), ElectronicsResourceConstants.DataGet);
        }

        public IDataResult<List<ElectronicsResource>> GetAllByFilter(Expression<Func<ElectronicsResource, bool>>? filter = null)
        {
            return new SuccessDataResult<List<ElectronicsResource>>(_electronicsResourceDal.GetAll(filter).ToList(), ElectronicsResourceConstants.DataGet);
        }

        public IDataResult<List<ElectronicsResource>> GetAllBySecrets()
        {
            return new SuccessDataResult<List<ElectronicsResource>>(_electronicsResourceDal.GetAll(er => er.IsDeleted).ToList(), ElectronicsResourceConstants.DataGet);
        }

        public IDataResult<List<ElectronicsResource>> GetByCategories(int[] categoriesId)
        {
            var categories = _categoryService.GetByIds(categoriesId);
            if (!categories.Success)
                return new ErrorDataResult<List<ElectronicsResource>>(categories.Message);

            List<ElectronicsResource> electronicsResources = _electronicsResourceDal.GetAll(er => categoriesId.Contains(er.CategoryId) && !er.IsDeleted).ToList();
            return electronicsResources == null
                ? new ErrorDataResult<List<ElectronicsResource>>(ElectronicsResourceConstants.DataNotGet)
                : new SuccessDataResult<List<ElectronicsResource>>(electronicsResources, ElectronicsResourceConstants.DataGet);
        }

        public IDataResult<List<ElectronicsResource>> GetByDescriptionFinder(string finderString)
        {
            List<ElectronicsResource> electronicsResources = _electronicsResourceDal.GetAll(er => er.Description.Contains(finderString) && !er.IsDeleted).ToList();
            return electronicsResources == null
                ? new ErrorDataResult<List<ElectronicsResource>>(ElectronicsResourceConstants.DataNotGet)
                : new SuccessDataResult<List<ElectronicsResource>>(electronicsResources, ElectronicsResourceConstants.DataGet);
        }

        public IDataResult<List<ElectronicsResource>> GetByDimension(Guid dimensionId)
        {
            IDataResult<Dimension> dimension = _dimensionService.GetById(dimensionId);
            if (!dimension.Success)
                return new ErrorDataResult<List<ElectronicsResource>>(dimension.Message);

            List<ElectronicsResource> electronicsResources = _electronicsResourceDal.GetAll(er => er.DimensionsId == dimensionId && !er.IsDeleted).ToList();
            return electronicsResources == null
                ? new ErrorDataResult<List<ElectronicsResource>>(ElectronicsResourceConstants.DataNotGet)
                : new SuccessDataResult<List<ElectronicsResource>>(electronicsResources, ElectronicsResourceConstants.DataGet);
        }

        public IDataResult<List<ElectronicsResource>> GetByEMFiles(Guid eMFilesId)
        {
            IDataResult<EMaterialFile> eMFile = _eMaterialFileService.GetById(eMFilesId);
            if (!eMFile.Success)
                return new ErrorDataResult<List<ElectronicsResource>>(eMFile.Message);

            List<ElectronicsResource> electronicsResources = _electronicsResourceDal.GetAll(er => er.EMaterialFilesId == eMFilesId && !er.IsDeleted).ToList();
            return electronicsResources == null
                ? new ErrorDataResult<List<ElectronicsResource>>(ElectronicsResourceConstants.DataNotGet)
                : new SuccessDataResult<List<ElectronicsResource>>(electronicsResources, ElectronicsResourceConstants.DataGet);
        }

        public IDataResult<ElectronicsResource> GetById(Guid id)
        {
            ElectronicsResource electronicsResource = _electronicsResourceDal.Get(er => er.Id == id);
            return electronicsResource == null
                ? new ErrorDataResult<ElectronicsResource>(ElectronicsResourceConstants.NotMatch)
                : new SuccessDataResult<ElectronicsResource>(electronicsResource, ElectronicsResourceConstants.DataGet);
        }

        public IDataResult<List<ElectronicsResource>> GetByIds(Guid[] ids)
        {
            List<ElectronicsResource> electronicsResources = _electronicsResourceDal.GetAll(er => ids.Contains(er.Id) && !er.IsDeleted).ToList();
            return electronicsResources == null
                ? new ErrorDataResult<List<ElectronicsResource>>(ElectronicsResourceConstants.DataNotGet)
                : new SuccessDataResult<List<ElectronicsResource>>(electronicsResources, ElectronicsResourceConstants.DataGet);
        }

        public IDataResult<List<ElectronicsResource>> GetByNames(string name)
        {
            List<ElectronicsResource> electronicsResources = _electronicsResourceDal.GetAll(er => er.Name.Contains(name) && !er.IsDeleted).ToList();
            return electronicsResources == null
                ? new ErrorDataResult<List<ElectronicsResource>>(ElectronicsResourceConstants.DataNotGet)
                : new SuccessDataResult<List<ElectronicsResource>>(electronicsResources, ElectronicsResourceConstants.DataGet);
        }

        public IDataResult<List<ElectronicsResource>> GetByPrice(decimal minPrice, decimal? maxPrice = null)
        {
            List<ElectronicsResource> electronicsResources = maxPrice == null
                ? _electronicsResourceDal.GetAll(er => er.Price == minPrice && !er.IsDeleted).ToList()
                : _electronicsResourceDal.GetAll(er => er.Price >= minPrice && er.Price <= maxPrice && !er.IsDeleted).ToList();

            return electronicsResources == null
                ? new ErrorDataResult<List<ElectronicsResource>>(ElectronicsResourceConstants.DataNotGet)
                : new SuccessDataResult<List<ElectronicsResource>>(electronicsResources, ElectronicsResourceConstants.DataGet);
        }

        public IDataResult<List<ElectronicsResource>> GetByResourceUrlFinderString(string finderStr)
        {
            List<ElectronicsResource> electronicsResources = _electronicsResourceDal.GetAll(er => er.ResourceUrl.Contains(finderStr) && !er.IsDeleted).ToList();
            return electronicsResources == null
                ? new ErrorDataResult<List<ElectronicsResource>>(ElectronicsResourceConstants.DataNotGet)
                : new SuccessDataResult<List<ElectronicsResource>>(electronicsResources, ElectronicsResourceConstants.DataGet);
        }

        public IDataResult<List<ElectronicsResource>> GetByTechnicalPlaceholders(Guid technicalPlaceholderId)
        {
            IDataResult<TechnicalPlaceholder> techPlacHold = _technicalPlaceholderService.GetById(technicalPlaceholderId);
            if (!techPlacHold.Success)
                return new ErrorDataResult<List<ElectronicsResource>>(techPlacHold.Message);

            List<ElectronicsResource> electronicsResources = _electronicsResourceDal.GetAll(er => er.TechnicalPlaceholdersId == technicalPlaceholderId && !er.IsDeleted).ToList();
            return electronicsResources == null
                ? new ErrorDataResult<List<ElectronicsResource>>(ElectronicsResourceConstants.DataNotGet)
                : new SuccessDataResult<List<ElectronicsResource>>(electronicsResources, ElectronicsResourceConstants.DataGet);
        }

        public IDataResult<List<ElectronicsResource>> GetByTitles(string title)
        {
            List<ElectronicsResource> electronicsResources = _electronicsResourceDal.GetAll(er => er.Title.Contains(title) && !er.IsDeleted).ToList();
            return electronicsResources == null
                ? new ErrorDataResult<List<ElectronicsResource>>(ElectronicsResourceConstants.DataNotGet)
                : new SuccessDataResult<List<ElectronicsResource>>(electronicsResources, ElectronicsResourceConstants.DataGet);
        }

        public IDataResult<byte?> GetSecretLevel(Guid id)
        {
            byte? sLevel = _electronicsResourceDal.Get(er => er.Id == id && !er.IsDeleted).SecretLevel;
            return sLevel == null
                ? new ErrorDataResult<byte?>(ElectronicsResourceConstants.DataNotGet)
                : new SuccessDataResult<byte?>(sLevel, ElectronicsResourceConstants.DataGet);
        }

        public IDataResult<byte> GetState(Guid id)
        {
            return new SuccessDataResult<byte>(_electronicsResourceDal.Get(er => er.Id == id && !er.IsDeleted).State, ElectronicsResourceConstants.DataGet);
        }

        public IDataResult<ElectronicsResource> GetByStock(Guid stockId)
        {
            IDataResult<Stock> stock = _stockService.GetById(stockId);
            if (!stock.Success)
                return new ErrorDataResult<ElectronicsResource>(stock.Message);

            ElectronicsResource eResource = _electronicsResourceDal.Get(er => er.Stock == stock.Data && !er.IsDeleted);
            return eResource == null
                ? new ErrorDataResult<ElectronicsResource>(ElectronicsResourceConstants.NotMatch)
                : new SuccessDataResult<ElectronicsResource>(eResource, ElectronicsResourceConstants.DataGet);
        }

        private IResult ElectronicsResourceControl(ElectronicsResource electronicsResource)
        {
            bool check = _electronicsResourceDal.Get(er =>
                er.Name == electronicsResource.Name
             && er.Title == electronicsResource.Title
             && er.Description.Contains(electronicsResource.Description)
             && er.CategoryId == electronicsResource.CategoryId
             && er.TechnicalPlaceholdersId == electronicsResource.TechnicalPlaceholdersId
             && er.DimensionsId == electronicsResource.DimensionsId
             && er.EMaterialFilesId == electronicsResource.EMaterialFilesId
             && er.State == electronicsResource.State
             && er.ResourceUrl == electronicsResource.ResourceUrl
                ) != null;

            if (check)
                return new ErrorResult(ElectronicsResourceConstants.AlreadyExists);
            return new SuccessResult();
        }
    }
}
