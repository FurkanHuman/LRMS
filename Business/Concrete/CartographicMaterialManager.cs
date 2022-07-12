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
    public class CartographicMaterialManager : ICartographicMaterialService
    {
        private readonly ICartographicMaterialDal _cartographicMaterialDal; // Todo I know hell is here
        private readonly ICategoryService _categoryService;
        private readonly IDimensionService _dimensionService;
        private readonly IEMaterialFileService _eMaterialFileService;
        private readonly IImageService _imageService;
        private readonly ITechnicalPlaceholderService _technicalPlaceholderService;
        private readonly IStockService _stockService;

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

        public IDataResult<List<CartographicMaterial>> GetByCategories(int[] categoriesId)
        {

            IDataResult<List<Category>> categories = _categoryService.GetAllByFilter(c => categoriesId.Contains(c.Id));
            if (!categories.Success)
                return new ErrorDataResult<List<CartographicMaterial>>(categories.Message);

            List<CartographicMaterial> cartographicMaterials = _cartographicMaterialDal.GetAll(aj => categories.Data.Select(c => c.Id).Contains(aj.CategoryId) && !aj.IsDeleted).ToList();
            return cartographicMaterials == null
                ? new ErrorDataResult<List<CartographicMaterial>>(AcademicJournalConstants.DataNotGet)
                : new SuccessDataResult<List<CartographicMaterial>>(cartographicMaterials, AcademicJournalConstants.DataGet);
        }

        public IDataResult<List<CartographicMaterial>> GetAll()
        {

            return new SuccessDataResult<List<CartographicMaterial>>(_cartographicMaterialDal.GetAll(cm => !cm.IsDeleted).ToList());
        }

        public IDataResult<List<CartographicMaterial>> GetAllByFilter(Expression<Func<CartographicMaterial, bool>>? filter = null)
        {
            return new SuccessDataResult<List<CartographicMaterial>>(_cartographicMaterialDal.GetAll(filter).ToList());
        }

        public IDataResult<List<CartographicMaterial>> GetAllBySecrets()
        {
            return new SuccessDataResult<List<CartographicMaterial>>(_cartographicMaterialDal.GetAll(cm => cm.IsDeleted).ToList());
        }

        public IDataResult<List<CartographicMaterial>> GetByDate(DateTime dateTimeMin, DateTime? dateTimeMax)
        {
            List<CartographicMaterial> cartographicMaterials = dateTimeMax == null
                ? _cartographicMaterialDal.GetAll(cm => cm.Date == dateTimeMin && !cm.IsDeleted).ToList()
                : _cartographicMaterialDal.GetAll(cm => cm.Date <= dateTimeMin && cm.Date >= dateTimeMax && !cm.IsDeleted).ToList();

            return cartographicMaterials == null
                 ? new ErrorDataResult<List<CartographicMaterial>>(CartographicMaterialConstants.DataNotGet)
                 : new SuccessDataResult<List<CartographicMaterial>>(cartographicMaterials, CartographicMaterialConstants.DataGet);
        }

        public IDataResult<List<CartographicMaterial>> GetByDescriptionFinder(string finderString)
        {
            List<CartographicMaterial> cartographicMaterials = _cartographicMaterialDal.GetAll(cm => cm.Description.Contains(finderString) && !cm.IsDeleted).ToList();
            return cartographicMaterials == null
                ? new ErrorDataResult<List<CartographicMaterial>>(CartographicMaterialConstants.DataNotGet)
                : new SuccessDataResult<List<CartographicMaterial>>(cartographicMaterials, CartographicMaterialConstants.DataGet);
        }

        public IDataResult<List<CartographicMaterial>> GetByDimension(Guid dimensionId)
        {
            IDataResult<Dimension> dimension = _dimensionService.GetById(dimensionId);
            if (!dimension.Success)
                return new SuccessDataResult<List<CartographicMaterial>>(dimension.Message);

            List<CartographicMaterial> cartographicMaterials = _cartographicMaterialDal.GetAll(cm => cm.DimensionsId == dimensionId && cm.IsDeleted).ToList();
            return cartographicMaterials == null
                ? new ErrorDataResult<List<CartographicMaterial>>(CartographicMaterialConstants.DataNotGet)
                : new SuccessDataResult<List<CartographicMaterial>>(cartographicMaterials, CartographicMaterialConstants.DataGet);
        }

        public IDataResult<List<CartographicMaterial>> GetByEMFiles(Guid eMFilesId)
        {
            IDataResult<EMaterialFile> eMaterialFile = _eMaterialFileService.GetById(eMFilesId);
            if (!eMaterialFile.Success)
                return new ErrorDataResult<List<CartographicMaterial>>(eMaterialFile.Message);

            List<CartographicMaterial> cartographicMaterials = _cartographicMaterialDal.GetAll(cm => cm.EMaterialFilesId == eMFilesId && cm.IsDeleted).ToList();
            return cartographicMaterials == null
                ? new ErrorDataResult<List<CartographicMaterial>>(CartographicMaterialConstants.DataNotGet)
                : new SuccessDataResult<List<CartographicMaterial>>(cartographicMaterials, CartographicMaterialConstants.DataGet);
        }

        public IDataResult<CartographicMaterial> GetById(Guid id)
        {
            CartographicMaterial cartographicMaterial = _cartographicMaterialDal.Get(cm => cm.Id == id);
            return cartographicMaterial == null
               ? new ErrorDataResult<CartographicMaterial>(CartographicMaterialConstants.DataNotGet)
               : new ErrorDataResult<CartographicMaterial>(cartographicMaterial, CartographicMaterialConstants.DataGet);
        }

        public IDataResult<List<CartographicMaterial>> GetByIds(Guid[] ids)
        {
            List<CartographicMaterial> cartographicMaterials = _cartographicMaterialDal.GetAll(cm => ids.Contains(cm.Id) && cm.IsDeleted).ToList();
            return cartographicMaterials == null
                ? new ErrorDataResult<List<CartographicMaterial>>(CartographicMaterialConstants.DataNotGet)
                : new SuccessDataResult<List<CartographicMaterial>>(cartographicMaterials, CartographicMaterialConstants.DataGet);
        }

        public IDataResult<CartographicMaterial> GetByImageId(Guid imageId)
        {
            IDataResult<Image> image = _imageService.GetById(imageId);
            if (!image.Success)
                return new ErrorDataResult<CartographicMaterial>(image.Message);

            CartographicMaterial cartographicMaterial = _cartographicMaterialDal.Get(cm => cm.ImageId == imageId && !cm.IsDeleted);
            return cartographicMaterial == null
                ? new ErrorDataResult<CartographicMaterial>(CartographicMaterialConstants.DataNotGet)
                : new SuccessDataResult<CartographicMaterial>(cartographicMaterial, CartographicMaterialConstants.DataGet);
        }

        public IDataResult<List<CartographicMaterial>> GetByImageIds(Guid[] imageIds)
        {
            return new ErrorDataResult<List<CartographicMaterial>>(CartographicMaterialConstants.Disabled);
        }

        public IDataResult<List<CartographicMaterial>> GetByNames(string name)
        {
            List<CartographicMaterial> cartographicMaterials = _cartographicMaterialDal.GetAll(cm => cm.Name.Contains(name) && !cm.IsDeleted).ToList();

            return cartographicMaterials == null
            ? new ErrorDataResult<List<CartographicMaterial>>(CartographicMaterialConstants.DataNotGet)
            : new SuccessDataResult<List<CartographicMaterial>>(cartographicMaterials, CartographicMaterialConstants.DataGet);
        }

        public IDataResult<List<CartographicMaterial>> GetByPrice(decimal minPrice, decimal? maxPrice = null)
        {
            List<CartographicMaterial> cartographicMaterials = maxPrice == null
                ? _cartographicMaterialDal.GetAll(cm => cm.Price == minPrice && !cm.IsDeleted).ToList()
                : _cartographicMaterialDal.GetAll(ar => ar.Price >= minPrice && ar.Price <= maxPrice && !ar.IsDeleted).ToList();

            return cartographicMaterials == null
            ? new ErrorDataResult<List<CartographicMaterial>>(CartographicMaterialConstants.DataNotGet)
            : new SuccessDataResult<List<CartographicMaterial>>(cartographicMaterials, CartographicMaterialConstants.DataGet);
        }

        public IDataResult<List<CartographicMaterial>> GetByTechnicalPlaceholders(Guid technicalPlaceholderId)
        {
            IDataResult<TechnicalPlaceholder> tPHolder = _technicalPlaceholderService.GetById(technicalPlaceholderId);
            if (!tPHolder.Success)
                return new ErrorDataResult<List<CartographicMaterial>>(tPHolder.Message);

            List<CartographicMaterial> cartographicMaterials = _cartographicMaterialDal.GetAll(cm => cm.TechnicalPlaceholdersId == technicalPlaceholderId && !cm.IsDeleted).ToList();
            return cartographicMaterials == null
                ? new ErrorDataResult<List<CartographicMaterial>>(CartographicMaterialConstants.DataNotGet)
                : new SuccessDataResult<List<CartographicMaterial>>(cartographicMaterials, CartographicMaterialConstants.DataGet);
        }

        public IDataResult<List<CartographicMaterial>> GetByTitles(string title)
        {
            List<CartographicMaterial> cartographicMaterials = _cartographicMaterialDal.GetAll(cm => cm.Title.Contains(title) && !cm.IsDeleted).ToList();

            return cartographicMaterials == null
            ? new ErrorDataResult<List<CartographicMaterial>>(CartographicMaterialConstants.DataNotGet)
            : new SuccessDataResult<List<CartographicMaterial>>(cartographicMaterials, CartographicMaterialConstants.DataGet);
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
            IDataResult<Stock> stock = _stockService.GetById(stockId);
            if (!stock.Success)
                return new ErrorDataResult<CartographicMaterial>(stock.Message);

           CartographicMaterial cartographicMaterial=_cartographicMaterialDal.Get(cm => cm.Stock == stock.Data && !cm.IsDeleted);
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
