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
using Microsoft.AspNetCore.Http;
using System.Linq.Expressions;

namespace Business.Concrete
{
    public class DepictionManager : IDepictionService
    {
        private readonly IDepictionDal _depictionDal;

        private readonly ICategoryService _categoryService;
        private readonly IDimensionService _dimensionService;
        private readonly IEMaterialFileService _eMaterialFileService;
        private readonly IImageService _imageService;
        private readonly ITechnicalPlaceholderService _technicalPlaceholderService;

        [ValidationAspect(typeof(DepictionValidator))]
        public IResult Add(Depiction entity)
        {
            IResult result = BusinessRules.Run(DepictionControl(entity));
            if (result != null)
                return result;

            entity.IsDeleted = false;
            _depictionDal.Add(entity);
            return new SuccessResult(DepictionConstants.AddSuccess);
        }

        public IResult Add(IFormFile formFile, Depiction depiction)
        {
            IDataResult<Image> imageAddResult = _imageService.Add(formFile);
            if (!imageAddResult.Success)
                return imageAddResult;

            depiction.Image = imageAddResult.Data;
            IResult addResult = Add(depiction);
            if (!addResult.Success)
                return addResult;

            return new SuccessResult(DepictionConstants.AddSuccess);
        }

        public IResult Delete(Guid id)
        {
            Depiction depiction = _depictionDal.Get(d => d.Id == id);
            if (depiction == null)
                return new ErrorResult(DepictionConstants.NotMatch);

            _depictionDal.Delete(depiction);
            return new SuccessResult(DepictionConstants.DeleteSuccess);
        }

        public IResult ShadowDelete(Guid id)
        {
            Depiction depiction = _depictionDal.Get(d => d.Id == id && !d.IsDeleted);
            if (depiction == null)
                return new ErrorResult(DepictionConstants.NotMatch);

            depiction.IsDeleted = false;
            _depictionDal.Update(depiction);
            return new SuccessResult(DepictionConstants.DeleteSuccess);
        }

        [ValidationAspect(typeof(DepictionValidator))]
        public IResult Update(Depiction entity)
        {
            IResult result = BusinessRules.Run(DepictionControl(entity));
            if (result != null)
                return result;

            entity.IsDeleted = false;
            _depictionDal.Update(entity);
            return new SuccessResult(DepictionConstants.UpdateSuccess);
        }

        public IResult Update(IFormFile formFile, Depiction depiction, Guid imageId)
        {
            IResult updateResult = Update(depiction);
            if (!updateResult.Success)
                return updateResult;

            IDataResult<Image> image = _imageService.GetById(imageId);
            if (!image.Success)
                return image;

            IResult imageUpdateResult = _imageService.Update(formFile, image.Data);
            if (!imageUpdateResult.Success)
                return imageUpdateResult;

            return new SuccessResult(DepictionConstants.UpdateSuccess);
        }

        public IDataResult<List<Depiction>> GetAll()
        {
            return new SuccessDataResult<List<Depiction>>(_depictionDal.GetAll(d => !d.IsDeleted).ToList(), DepictionConstants.DataGet);
        }

        public IDataResult<List<Depiction>> GetAllByFilter(Expression<Func<Depiction, bool>>? filter = null)
        {
            return new SuccessDataResult<List<Depiction>>(_depictionDal.GetAll(filter).ToList(), DepictionConstants.DataGet);
        }

        public IDataResult<List<Depiction>> GetAllBySecrets()
        {
            return new SuccessDataResult<List<Depiction>>(_depictionDal.GetAll(d => d.IsDeleted).ToList(), DepictionConstants.DataGet);
        }

        public IDataResult<List<Depiction>> GetByCategories(int[] categoriesId)
        {
            IDataResult<List<Category>> categories = _categoryService.GetAllByFilter(c => categoriesId.Contains(c.Id));
            if (!categories.Success)
                return new ErrorDataResult<List<Depiction>>(categories.Message);

            List<Depiction> results = _depictionDal.GetAll(d => d.Categories.Any(c => categoriesId.Contains(c.Id)) && !d.IsDeleted).ToList();
            return results != null
                ? new SuccessDataResult<List<Depiction>>(results, DepictionConstants.DataGet)
                : new ErrorDataResult<List<Depiction>>(DepictionConstants.DataNotGet);
        }

        public IDataResult<List<Depiction>> GetByDescriptionFinder(string finderString)
        {
            List<Depiction> results = _depictionDal.GetAll(d => d.Description.Contains(finderString) && !d.IsDeleted).ToList();
            return results != null
                ? new SuccessDataResult<List<Depiction>>(results, DepictionConstants.DataGet)
                : new ErrorDataResult<List<Depiction>>(DepictionConstants.DataNotGet);
        }

        public IDataResult<List<Depiction>> GetByDimension(Guid dimensionId)
        {
            IDataResult<Dimension> dimension = _dimensionService.GetById(dimensionId);
            if (!dimension.Success)
                return new ErrorDataResult<List<Depiction>>(dimension.Message);

            List<Depiction> results = _depictionDal.GetAll(d => d.DimensionsId == dimensionId && !d.IsDeleted).ToList();
            return results != null
                ? new SuccessDataResult<List<Depiction>>(results, DepictionConstants.DataGet)
                : new ErrorDataResult<List<Depiction>>(DepictionConstants.DataNotGet);
        }

        public IDataResult<List<Depiction>> GetByEMFiles(Guid eMFilesId)
        {
            IDataResult<EMaterialFile> eMFile = _eMaterialFileService.GetById(eMFilesId);
            if (!eMFile.Success)
                return new ErrorDataResult<List<Depiction>>(eMFile.Message);

            List<Depiction> results = _depictionDal.GetAll(d => d.EMaterialFilesId == eMFilesId && !d.IsDeleted).ToList();
            return results != null
                ? new SuccessDataResult<List<Depiction>>(results, DepictionConstants.DataGet)
                : new ErrorDataResult<List<Depiction>>(DepictionConstants.DataNotGet);
        }

        public IDataResult<Depiction> GetById(Guid id)
        {
            Depiction result = _depictionDal.Get(d => d.Id == id && !d.IsDeleted);
            return result != null
                ? new SuccessDataResult<Depiction>(result, DepictionConstants.DataGet)
                : new ErrorDataResult<Depiction>(DepictionConstants.NotMatch);
        }

        public IDataResult<Depiction> GetByImages(Guid imageId)
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<Depiction>> GetByNames(string name)
        {
            List<Depiction> results = _depictionDal.GetAll(d => d.Name == name && !d.IsDeleted).ToList();
            return results != null
                ? new SuccessDataResult<List<Depiction>>(results, DepictionConstants.DataGet)
                : new ErrorDataResult<List<Depiction>>(DepictionConstants.DataNotGet);
        }

        public IDataResult<List<Depiction>> GetByPrice(decimal minPrice, decimal? maxPrice = null)
        {
            List<Depiction> results = maxPrice == null
                ? _depictionDal.GetAll(d => d.Price == minPrice && !d.IsDeleted).ToList()
                : _depictionDal.GetAll(d => d.Price >= minPrice && d.Price <= maxPrice && !d.IsDeleted).ToList();

            return results != null
                ? new SuccessDataResult<List<Depiction>>(results, DepictionConstants.DataGet)
                : new ErrorDataResult<List<Depiction>>(DepictionConstants.DataNotGet);
        }

        public IDataResult<List<Depiction>> GetByTechnicalPlaceholders(Guid technicalPlaceholderId)
        {
            IDataResult<TechnicalPlaceholder> technicalPlaceholder = _technicalPlaceholderService.GetById(technicalPlaceholderId);
            if (!technicalPlaceholder.Success)
                return new ErrorDataResult<List<Depiction>>(technicalPlaceholder.Message);

            List<Depiction> results = _depictionDal.GetAll(d => d.TechnicalPlaceholdersId == technicalPlaceholderId && !d.IsDeleted).ToList();
            return results != null
                ? new SuccessDataResult<List<Depiction>>(results, DepictionConstants.DataGet)
                : new ErrorDataResult<List<Depiction>>(DepictionConstants.DataNotGet);
        }

        public IDataResult<List<Depiction>> GetByTitles(string title)
        {
            List<Depiction> titles = _depictionDal.GetAll(d => d.Title == title && !d.IsDeleted).ToList();
            return titles != null
                ? new SuccessDataResult<List<Depiction>>(titles, DepictionConstants.DataGet)
                : new ErrorDataResult<List<Depiction>>(DepictionConstants.DataNotGet);
        }

        public IDataResult<byte?> GetSecretLevel(Guid id)
        {
            byte? sLevel = _depictionDal.Get(d => d.Id == id && !d.IsDeleted).SecretLevel;
            return sLevel == null
                ? new ErrorDataResult<byte?>(DepictionConstants.DataNotGet)
                : new SuccessDataResult<byte?>(sLevel, DepictionConstants.DataGet);
        }

        public IDataResult<byte> GetState(Guid id)
        {
            return new SuccessDataResult<byte>(_depictionDal.Get(d => d.Id == id && !d.IsDeleted).State, DepictionConstants.DataGet);
        }

        private IResult DepictionControl(Depiction depiction)
        {
            bool control = _depictionDal.Get(d =>


                d.Name == depiction.Name
             && d.Title == depiction.Title
             && d.Description.Contains(depiction.Description)
             && d.CategoryId == depiction.CategoryId
             && d.TechnicalPlaceholdersId == depiction.TechnicalPlaceholdersId
             && d.DimensionsId == depiction.DimensionsId
             && d.EMaterialFilesId == depiction.EMaterialFilesId
             && d.State == depiction.State
             && d.Image == depiction.Image) != null;

            if (!control)
                return new ErrorResult(DepictionConstants.AlreadyExists);
            return new SuccessResult();
        }
    }
}
