using Business.Abstract;
using Business.Constants;
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
    public class CartographicMaterialManager : ICartographicMaterialService
    {
        private readonly ICartographicMaterialDal _cartographicMaterialDal;

        private readonly ICategoryService _categoryService;
        private readonly IDimensionService _dimensionService;
        private readonly IEMaterialFileService _eMaterialFileService;
        private readonly IImageService _imageService;
        private readonly ITechnicalPlaceholderService _technicalPlaceholderService;

        public IResult Add(CartographicMaterial entity)
        {
            throw new NotImplementedException();
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

        public IResult Update(CartographicMaterial entity)
        {
            throw new NotImplementedException();
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
            return new SuccessDataResult<List<CartographicMaterial>>(_cartographicMaterialDal.GetAll(cm=>cm.IsDeleted).ToList());
        }

        public IDataResult<List<CartographicMaterial>> GetByCategories(int[] categoriesId)
        {
            IDataResult<List<Category>> categories = _categoryService.GetAllByFilter(c => categoriesId.Contains(c.Id));
            if (categories.Success)
                return new ErrorDataResult<List<CartographicMaterial>>(categories.Message);

            List<CartographicMaterial> cartographicMaterials = _cartographicMaterialDal.GetAll(cm => categories.Data.Select(c => c.Id).Contains(cm.CategoryId) && !cm.IsDeleted).ToList();
            return cartographicMaterials == null
                ? new ErrorDataResult<List<CartographicMaterial>>(CartographicMaterialConstants.DataNotGet)
                : new SuccessDataResult<List<CartographicMaterial>>(cartographicMaterials, CartographicMaterialConstants.DataGet);
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
            return new ErrorDataResult<List<CartographicMaterial>>(CartographicMaterialConstants.Disabled);
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
    }
}
