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
    public class CartographicMaterialManager : ICartographicMaterialService
    {
        private readonly ICartographicMaterialDal _cartographicMaterialDal;
        private readonly IFacadeService _facadeService;

        public CartographicMaterialManager(ICartographicMaterialDal cartographicMaterialDal)
        {
            _cartographicMaterialDal = cartographicMaterialDal;
        }

        [ValidationAspect(typeof(CartographicMaterialValidator))]
        public IResult Add(CartographicMaterial entity)
        {
            IResult result = BusinessRules.Run(CheckCartographicMaterial(entity));
            if (result != null)
                return result;

            entity.IsDeleted = false;
            _cartographicMaterialDal.Add(entity);
            return new SuccessResult(CartographicMaterialConstants.AddSuccess);
        }

        public IResult Delete(Guid id)
        {
            CartographicMaterial cartographicMaterial = _cartographicMaterialDal.Get(cm => cm.Id == id);
            if (cartographicMaterial == null)
                return new ErrorResult(CartographicMaterialConstants.NotMatch);

            _cartographicMaterialDal.Delete(cartographicMaterial);
            return new SuccessResult(CartographicMaterialConstants.DeleteSuccess);
        }

        public IResult ShadowDelete(Guid id)
        {
            CartographicMaterial cartographicMaterial = _cartographicMaterialDal.Get(cm => cm.Id == id && !cm.IsDeleted);
            if (cartographicMaterial == null)
                return new ErrorResult(CartographicMaterialConstants.NotMatch);

            cartographicMaterial.IsDeleted = true;
            _cartographicMaterialDal.Update(cartographicMaterial);
            return new SuccessResult(CartographicMaterialConstants.EfDeletedSuccsess);
        }

        [ValidationAspect(typeof(CartographicMaterialValidator))]
        public IResult Update(CartographicMaterial entity)
        {
            IResult result = BusinessRules.Run(CheckCartographicMaterial(entity));
            if (result != null)
                return result;

            entity.IsDeleted = false;
            _cartographicMaterialDal.Update(entity);
            return new SuccessResult(CartographicMaterialConstants.UpdateSuccess);
        }

        public IDataResult<IList<CartographicMaterial>> GetAllByCategories(int[] categoriesId)
        {

            IDataResult<IList<Category>> categories = _facadeService.CategoryService().GetAllByIds(categoriesId);
            if (!categories.Success)
                return new ErrorDataResult<IList<CartographicMaterial>>(categories.Message);

            IList<CartographicMaterial> cartographicMaterials = _cartographicMaterialDal.GetAll(aj => categories.Data.Select(c => c.Id).Contains(aj.CategoryId) && !aj.IsDeleted);
            return cartographicMaterials == null
                ? new ErrorDataResult<IList<CartographicMaterial>>(AcademicJournalConstants.DataNotGet)
                : new SuccessDataResult<IList<CartographicMaterial>>(cartographicMaterials, AcademicJournalConstants.DataGet);
        }

        public IDataResult<IList<CartographicMaterial>> GetAll()
        {

            return new SuccessDataResult<IList<CartographicMaterial>>(_cartographicMaterialDal.GetAll(cm => !cm.IsDeleted));
        }

        public IDataResult<IList<CartographicMaterial>> GetAllByFilter(Expression<Func<CartographicMaterial, bool>>? filter = null)
        {
            return new SuccessDataResult<IList<CartographicMaterial>>(_cartographicMaterialDal.GetAll(filter));
        }

        public IDataResult<IList<CartographicMaterial>> GetAllByIsDeleted()
        {
            return new SuccessDataResult<IList<CartographicMaterial>>(_cartographicMaterialDal.GetAll(cm => cm.IsDeleted));
        }

        public IDataResult<IList<CartographicMaterial>> GetAllByDate(DateTime dateTimeMin, DateTime? dateTimeMax)
        {
            IList<CartographicMaterial> cartographicMaterials = dateTimeMax == null
                ? _cartographicMaterialDal.GetAll(cm => cm.Date == dateTimeMin && !cm.IsDeleted)
                : _cartographicMaterialDal.GetAll(cm => cm.Date <= dateTimeMin && cm.Date >= dateTimeMax && !cm.IsDeleted);

            return cartographicMaterials == null
                 ? new ErrorDataResult<IList<CartographicMaterial>>(CartographicMaterialConstants.DataNotGet)
                 : new SuccessDataResult<IList<CartographicMaterial>>(cartographicMaterials, CartographicMaterialConstants.DataGet);
        }

        public IDataResult<IList<CartographicMaterial>> GetAllByDescriptionFinder(string finderString)
        {
            IList<CartographicMaterial> cartographicMaterials = _cartographicMaterialDal.GetAll(cm => cm.Description.Contains(finderString) && !cm.IsDeleted);
            return cartographicMaterials == null
                ? new ErrorDataResult<IList<CartographicMaterial>>(CartographicMaterialConstants.DataNotGet)
                : new SuccessDataResult<IList<CartographicMaterial>>(cartographicMaterials, CartographicMaterialConstants.DataGet);
        }

        public IDataResult<IList<CartographicMaterial>> GetAllByDimension(Guid dimensionId)
        {
            IDataResult<Dimension> dimension = _facadeService.DimensionService().GetById(dimensionId);
            if (!dimension.Success)
                return new SuccessDataResult<IList<CartographicMaterial>>(dimension.Message);

            IList<CartographicMaterial> cartographicMaterials = _cartographicMaterialDal.GetAll(cm => cm.DimensionsId == dimensionId && cm.IsDeleted);
            return cartographicMaterials == null
                ? new ErrorDataResult<IList<CartographicMaterial>>(CartographicMaterialConstants.DataNotGet)
                : new SuccessDataResult<IList<CartographicMaterial>>(cartographicMaterials, CartographicMaterialConstants.DataGet);
        }

        public IDataResult<IList<CartographicMaterial>> GetAllByEMFile(Guid eMFileId)
        {
            IDataResult<EMaterialFile> eMaterialFile = _facadeService.EMaterialFileService().GetById(eMFileId);
            if (!eMaterialFile.Success)
                return new ErrorDataResult<IList<CartographicMaterial>>(eMaterialFile.Message);

            IList<CartographicMaterial> cartographicMaterials = _cartographicMaterialDal.GetAll(cm => cm.EMaterialFilesId == eMFileId && cm.IsDeleted);
            return cartographicMaterials == null
                ? new ErrorDataResult<IList<CartographicMaterial>>(CartographicMaterialConstants.DataNotGet)
                : new SuccessDataResult<IList<CartographicMaterial>>(cartographicMaterials, CartographicMaterialConstants.DataGet);
        }

        public IDataResult<CartographicMaterial> GetById(Guid id)
        {
            CartographicMaterial cartographicMaterial = _cartographicMaterialDal.Get(cm => cm.Id == id);
            _facadeService.CounterService().Count(cartographicMaterial);
            return cartographicMaterial == null
               ? new ErrorDataResult<CartographicMaterial>(CartographicMaterialConstants.DataNotGet)
               : new ErrorDataResult<CartographicMaterial>(cartographicMaterial, CartographicMaterialConstants.DataGet);
        }

        public IDataResult<IList<CartographicMaterial>> GetAllByIds(Guid[] ids)
        {
            IList<CartographicMaterial> cartographicMaterials = _cartographicMaterialDal.GetAll(cm => ids.Contains(cm.Id) && cm.IsDeleted);
            _facadeService.CounterService().Count(cartographicMaterials);
            return cartographicMaterials == null
                ? new ErrorDataResult<IList<CartographicMaterial>>(CartographicMaterialConstants.DataNotGet)
                : new SuccessDataResult<IList<CartographicMaterial>>(cartographicMaterials, CartographicMaterialConstants.DataGet);
        }

        public IDataResult<CartographicMaterial> GetAllByImageId(Guid imageId)
        {
            IDataResult<Image> image = _facadeService.ImageService().GetById(imageId);
            if (!image.Success)
                return new ErrorDataResult<CartographicMaterial>(image.Message);

            CartographicMaterial cartographicMaterial = _cartographicMaterialDal.Get(cm => cm.ImageId == imageId && !cm.IsDeleted);
            return cartographicMaterial == null
                ? new ErrorDataResult<CartographicMaterial>(CartographicMaterialConstants.DataNotGet)
                : new SuccessDataResult<CartographicMaterial>(cartographicMaterial, CartographicMaterialConstants.DataGet);
        }

        public IDataResult<IList<CartographicMaterial>> GetAllByImageIds(Guid[] imageIds)
        {
            return new ErrorDataResult<IList<CartographicMaterial>>(CartographicMaterialConstants.Disabled);
        }

        public IDataResult<IList<CartographicMaterial>> GetAllByName(string name)
        {
            IList<CartographicMaterial> cartographicMaterials = _cartographicMaterialDal.GetAll(cm => cm.Name.Contains(name) && !cm.IsDeleted);

            return cartographicMaterials == null
            ? new ErrorDataResult<IList<CartographicMaterial>>(CartographicMaterialConstants.DataNotGet)
            : new SuccessDataResult<IList<CartographicMaterial>>(cartographicMaterials, CartographicMaterialConstants.DataGet);
        }

        public IDataResult<IList<CartographicMaterial>> GetAllByPrice(decimal minPrice, decimal? maxPrice = null)
        {
            IList<CartographicMaterial> cartographicMaterials = maxPrice == null
                ? _cartographicMaterialDal.GetAll(cm => cm.Price == minPrice && !cm.IsDeleted)
                : _cartographicMaterialDal.GetAll(ar => ar.Price >= minPrice && ar.Price <= maxPrice && !ar.IsDeleted);

            return cartographicMaterials == null
            ? new ErrorDataResult<IList<CartographicMaterial>>(CartographicMaterialConstants.DataNotGet)
            : new SuccessDataResult<IList<CartographicMaterial>>(cartographicMaterials, CartographicMaterialConstants.DataGet);
        }

        public IDataResult<IList<CartographicMaterial>> GetAllByTechnicalPlaceholder(Guid technicalPlaceholderId)
        {
            IDataResult<TechnicalPlaceholder> tPHolder = _facadeService.TechnicalPlaceholderService().GetById(technicalPlaceholderId);
            if (!tPHolder.Success)
                return new ErrorDataResult<IList<CartographicMaterial>>(tPHolder.Message);

            IList<CartographicMaterial> cartographicMaterials = _cartographicMaterialDal.GetAll(cm => cm.TechnicalPlaceholdersId == technicalPlaceholderId && !cm.IsDeleted);
            return cartographicMaterials == null
                ? new ErrorDataResult<IList<CartographicMaterial>>(CartographicMaterialConstants.DataNotGet)
                : new SuccessDataResult<IList<CartographicMaterial>>(cartographicMaterials, CartographicMaterialConstants.DataGet);
        }

        public IDataResult<IList<CartographicMaterial>> GetAllByTitle(string title)
        {
            IList<CartographicMaterial> cartographicMaterials = _cartographicMaterialDal.GetAll(cm => cm.Title.Contains(title) && !cm.IsDeleted);

            return cartographicMaterials == null
            ? new ErrorDataResult<IList<CartographicMaterial>>(CartographicMaterialConstants.DataNotGet)
            : new SuccessDataResult<IList<CartographicMaterial>>(cartographicMaterials, CartographicMaterialConstants.DataGet);
        }

        public IDataResult<byte?> GetSecretLevel(Guid id)
        {
            byte? sLevel = _cartographicMaterialDal.Get(cm => cm.Id == id).SecretLevel;
            return sLevel == null
                ? new ErrorDataResult<byte?>(CartographicMaterialConstants.DataNotGet)
                : new SuccessDataResult<byte?>(sLevel, CartographicMaterialConstants.DataGet);
        }

        public IDataResult<byte> GetState(Guid id)
        {
            return new SuccessDataResult<byte>(_cartographicMaterialDal.Get(cm => cm.Id == id && !cm.IsDeleted).State, CartographicMaterialConstants.DataGet);
        }

        public IDataResult<CartographicMaterial> GetByStock(Guid stockId)
        {
            IDataResult<Stock> stock = _facadeService.StockService().GetById(stockId);
            if (!stock.Success)
                return new ErrorDataResult<CartographicMaterial>(stock.Message);

            CartographicMaterial cartographicMaterial = _cartographicMaterialDal.Get(cm => cm.Stock == stock.Data && !cm.IsDeleted);
            _facadeService.CounterService().Count(cartographicMaterial);
            return cartographicMaterial == null
                ? new ErrorDataResult<CartographicMaterial>(CartographicMaterialConstants.NotMatch)
                : new SuccessDataResult<CartographicMaterial>(cartographicMaterial, CartographicMaterialConstants.DataGet);
        }

        private IResult CheckCartographicMaterial(CartographicMaterial cartographicMaterial)
        {

            bool control = _cartographicMaterialDal.Get(cm =>
                cm.Name == cartographicMaterial.Name
             && cm.Title == cartographicMaterial.Title
             && cm.Description.Contains(cartographicMaterial.Description)
             && cm.CategoryId == cartographicMaterial.CategoryId
             && cm.TechnicalPlaceholdersId == cartographicMaterial.TechnicalPlaceholdersId
             && cm.DimensionsId == cartographicMaterial.DimensionsId
             && cm.EMaterialFilesId == cartographicMaterial.EMaterialFilesId
             && cm.State == cartographicMaterial.State
             && cm.Date == cartographicMaterial.Date
             && cm.ImageId == cartographicMaterial.ImageId) != null;

            if (control)
                return new ErrorResult(CartographicMaterialConstants.AlreadyExists);
            return new SuccessResult();
        }
    }
}
