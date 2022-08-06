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
{
    public class ElectronicsResourceManager : IElectronicsResourceService
    {
        private readonly IElectronicsResourceDal _electronicsResourceDal;
        private readonly IFacadeService _facadeService;

        public ElectronicsResourceManager(IElectronicsResourceDal electronicsResourceDal, IFacadeService facadeService)
        {
            _electronicsResourceDal = electronicsResourceDal;
            _facadeService = facadeService;
        }

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

            _electronicsResourceDal.Delete(electronicsResource);
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

        public IDataResult<IList<ElectronicsResource>> GetAll()
        {
            return new SuccessDataResult<IList<ElectronicsResource>>(_electronicsResourceDal.GetAll(er => !er.IsDeleted), ElectronicsResourceConstants.DataGet);
        }

        public IDataResult<IList<ElectronicsResource>> GetAllByFilter(Expression<Func<ElectronicsResource, bool>>? filter = null)
        {
            return new SuccessDataResult<IList<ElectronicsResource>>(_electronicsResourceDal.GetAll(filter), ElectronicsResourceConstants.DataGet);
        }

        public IDataResult<IList<ElectronicsResource>> GetAllByIsDeleted()
        {
            return new SuccessDataResult<IList<ElectronicsResource>>(_electronicsResourceDal.GetAll(er => er.IsDeleted), ElectronicsResourceConstants.DataGet);
        }

        public IDataResult<IList<ElectronicsResource>> GetAllByCategories(int[] categoriesId)
        {
            IDataResult<IList<Category>> categories = _facadeService.CategoryService().GetAllByIds(categoriesId);
            if (!categories.Success)
                return new ErrorDataResult<IList<ElectronicsResource>>(categories.Message);

            IList<ElectronicsResource> electronicsResources = _electronicsResourceDal.GetAll(er => categoriesId.Contains(er.CategoryId) && !er.IsDeleted);
            return electronicsResources == null
                ? new ErrorDataResult<IList<ElectronicsResource>>(ElectronicsResourceConstants.DataNotGet)
                : new SuccessDataResult<IList<ElectronicsResource>>(electronicsResources, ElectronicsResourceConstants.DataGet);
        }

        public IDataResult<IList<ElectronicsResource>> GetAllByDescriptionFinder(string finderString)
        {
            IList<ElectronicsResource> electronicsResources = _electronicsResourceDal.GetAll(er => er.Description.Contains(finderString) && !er.IsDeleted);
            return electronicsResources == null
                ? new ErrorDataResult<IList<ElectronicsResource>>(ElectronicsResourceConstants.DataNotGet)
                : new SuccessDataResult<IList<ElectronicsResource>>(electronicsResources, ElectronicsResourceConstants.DataGet);
        }

        public IDataResult<IList<ElectronicsResource>> GetAllByDimension(Guid dimensionId)
        {
            IDataResult<Dimension> dimension = _facadeService.DimensionService().GetById(dimensionId);
            if (!dimension.Success)
                return new ErrorDataResult<IList<ElectronicsResource>>(dimension.Message);

            IList<ElectronicsResource> electronicsResources = _electronicsResourceDal.GetAll(er => er.DimensionsId == dimensionId && !er.IsDeleted);
            return electronicsResources == null
                ? new ErrorDataResult<IList<ElectronicsResource>>(ElectronicsResourceConstants.DataNotGet)
                : new SuccessDataResult<IList<ElectronicsResource>>(electronicsResources, ElectronicsResourceConstants.DataGet);
        }

        public IDataResult<IList<ElectronicsResource>> GetAllByEMFile(Guid eMFileId)
        {
            IDataResult<EMaterialFile> eMFile = _facadeService.EMaterialFileService().GetById(eMFileId);
            if (!eMFile.Success)
                return new ErrorDataResult<IList<ElectronicsResource>>(eMFile.Message);

            IList<ElectronicsResource> electronicsResources = _electronicsResourceDal.GetAll(er => er.EMaterialFilesId == eMFileId && !er.IsDeleted);
            return electronicsResources == null
                ? new ErrorDataResult<IList<ElectronicsResource>>(ElectronicsResourceConstants.DataNotGet)
                : new SuccessDataResult<IList<ElectronicsResource>>(electronicsResources, ElectronicsResourceConstants.DataGet);
        }

        public IDataResult<ElectronicsResource> GetById(Guid id)
        {
            ElectronicsResource electronicsResource = _electronicsResourceDal.Get(er => er.Id == id);
            return electronicsResource == null
                ? new ErrorDataResult<ElectronicsResource>(ElectronicsResourceConstants.NotMatch)
                : new SuccessDataResult<ElectronicsResource>(electronicsResource, ElectronicsResourceConstants.DataGet);
        }

        public IDataResult<IList<ElectronicsResource>> GetAllByIds(Guid[] ids)
        {
            IList<ElectronicsResource> electronicsResources = _electronicsResourceDal.GetAll(er => ids.Contains(er.Id) && !er.IsDeleted);
            return electronicsResources == null
                ? new ErrorDataResult<IList<ElectronicsResource>>(ElectronicsResourceConstants.DataNotGet)
                : new SuccessDataResult<IList<ElectronicsResource>>(electronicsResources, ElectronicsResourceConstants.DataGet);
        }

        public IDataResult<IList<ElectronicsResource>> GetAllByName(string name)
        {
            IList<ElectronicsResource> electronicsResources = _electronicsResourceDal.GetAll(er => er.Name.Contains(name) && !er.IsDeleted);
            return electronicsResources == null
                ? new ErrorDataResult<IList<ElectronicsResource>>(ElectronicsResourceConstants.DataNotGet)
                : new SuccessDataResult<IList<ElectronicsResource>>(electronicsResources, ElectronicsResourceConstants.DataGet);
        }

        public IDataResult<IList<ElectronicsResource>> GetAllByPrice(decimal minPrice, decimal? maxPrice = null)
        {
            IList<ElectronicsResource> electronicsResources = maxPrice == null
                ? _electronicsResourceDal.GetAll(er => er.Price == minPrice && !er.IsDeleted)
                : _electronicsResourceDal.GetAll(er => er.Price >= minPrice && er.Price <= maxPrice && !er.IsDeleted);

            return electronicsResources == null
                ? new ErrorDataResult<IList<ElectronicsResource>>(ElectronicsResourceConstants.DataNotGet)
                : new SuccessDataResult<IList<ElectronicsResource>>(electronicsResources, ElectronicsResourceConstants.DataGet);
        }

        public IDataResult<IList<ElectronicsResource>> GetAllByResourceUrlFinderString(string finderStr)
        {
            IList<ElectronicsResource> electronicsResources = _electronicsResourceDal.GetAll(er => er.ResourceUrl.Contains(finderStr) && !er.IsDeleted);
            return electronicsResources == null
                ? new ErrorDataResult<IList<ElectronicsResource>>(ElectronicsResourceConstants.DataNotGet)
                : new SuccessDataResult<IList<ElectronicsResource>>(electronicsResources, ElectronicsResourceConstants.DataGet);
        }

        public IDataResult<IList<ElectronicsResource>> GetAllByTechnicalPlaceholder(Guid technicalPlaceholderId)
        {
            IDataResult<TechnicalPlaceholder> techPlacHold = _facadeService.TechnicalPlaceholderService().GetById(technicalPlaceholderId);
            if (!techPlacHold.Success)
                return new ErrorDataResult<IList<ElectronicsResource>>(techPlacHold.Message);

            IList<ElectronicsResource> electronicsResources = _electronicsResourceDal.GetAll(er => er.TechnicalPlaceholdersId == technicalPlaceholderId && !er.IsDeleted);
            return electronicsResources == null
                ? new ErrorDataResult<IList<ElectronicsResource>>(ElectronicsResourceConstants.DataNotGet)
                : new SuccessDataResult<IList<ElectronicsResource>>(electronicsResources, ElectronicsResourceConstants.DataGet);
        }

        public IDataResult<IList<ElectronicsResource>> GetAllByTitle(string title)
        {
            IList<ElectronicsResource> electronicsResources = _electronicsResourceDal.GetAll(er => er.Title.Contains(title) && !er.IsDeleted);
            return electronicsResources == null
                ? new ErrorDataResult<IList<ElectronicsResource>>(ElectronicsResourceConstants.DataNotGet)
                : new SuccessDataResult<IList<ElectronicsResource>>(electronicsResources, ElectronicsResourceConstants.DataGet);
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
            IDataResult<Stock> stock = _facadeService.StockService().GetById(stockId);
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
