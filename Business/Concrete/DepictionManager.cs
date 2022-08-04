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
using Microsoft.AspNetCore.Http;
using System.Linq.Expressions;

namespace Business.Concrete
{
    public class DepictionManager : IDepictionService
    {
        private readonly IDepictionDal _depictionDal;
        private readonly IFacadeService _facadeService;

        public DepictionManager(IDepictionDal depictionDal, IFacadeService facadeService)
        {
            _depictionDal = depictionDal;
            _facadeService = facadeService;
        }

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
            IDataResult<Image> imageAddResult = _facadeService.ImageService().Add(formFile);
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

            IDataResult<Image> image = _facadeService.ImageService().GetById(imageId);
            if (!image.Success)
                return image;

            IResult imageUpdateResult =_facadeService.ImageService().Update(formFile, image.Data);
            if (!imageUpdateResult.Success)
                return imageUpdateResult;

            return new SuccessResult(DepictionConstants.UpdateSuccess);
        }

        public IDataResult<IList<Depiction>> GetAll()
        {
            return new SuccessDataResult<IList<Depiction>>(_depictionDal.GetAll(d => !d.IsDeleted), DepictionConstants.DataGet);
        }

        public IDataResult<IList<Depiction>> GetAllByFilter(Expression<Func<Depiction, bool>>? filter = null)
        {
            return new SuccessDataResult<IList<Depiction>>(_depictionDal.GetAll(filter), DepictionConstants.DataGet);
        }

        public IDataResult<IList<Depiction>> GetAllByIsDeleted()
        {
            return new SuccessDataResult<IList<Depiction>>(_depictionDal.GetAll(d => d.IsDeleted), DepictionConstants.DataGet);
        }

        public IDataResult<IList<Depiction>> GetAllByCategories(int[] categoriesId)
        {
            IDataResult<IList<Category>> categories = _facadeService.CategoryService().GetAllByFilter(c => categoriesId.Contains(c.Id));
            if (!categories.Success)
                return new ErrorDataResult<IList<Depiction>>(categories.Message);

            IList<Depiction> results = _depictionDal.GetAll(d => d.Categories.Any(c => categoriesId.Contains(c.Id)) && !d.IsDeleted);
            return results != null
                ? new SuccessDataResult<IList<Depiction>>(results, DepictionConstants.DataGet)
                : new ErrorDataResult<IList<Depiction>>(DepictionConstants.DataNotGet);
        }

        public IDataResult<IList<Depiction>> GetAllByDescriptionFinder(string finderString)
        {
            IList<Depiction> results = _depictionDal.GetAll(d => d.Description.Contains(finderString) && !d.IsDeleted);
            return results != null
                ? new SuccessDataResult<IList<Depiction>>(results, DepictionConstants.DataGet)
                : new ErrorDataResult<IList<Depiction>>(DepictionConstants.DataNotGet);
        }

        public IDataResult<IList<Depiction>> GetAllByDimension(Guid dimensionId)
        {
            IDataResult<Dimension> dimension = _facadeService.DimensionService().GetById(dimensionId);
            if (!dimension.Success)
                return new ErrorDataResult<IList<Depiction>>(dimension.Message);

            IList<Depiction> results = _depictionDal.GetAll(d => d.DimensionsId == dimensionId && !d.IsDeleted);
            return results != null
                ? new SuccessDataResult<IList<Depiction>>(results, DepictionConstants.DataGet)
                : new ErrorDataResult<IList<Depiction>>(DepictionConstants.DataNotGet);
        }

        public IDataResult<IList<Depiction>> GetAllByEMFile(Guid eMFileId)
        {
            IDataResult<EMaterialFile> eMFile = _facadeService.EMaterialFileService().GetById(eMFileId);
            if (!eMFile.Success)
                return new ErrorDataResult<IList<Depiction>>(eMFile.Message);

            IList<Depiction> results = _depictionDal.GetAll(d => d.EMaterialFilesId == eMFileId && !d.IsDeleted);
            return results != null
                ? new SuccessDataResult<IList<Depiction>>(results, DepictionConstants.DataGet)
                : new ErrorDataResult<IList<Depiction>>(DepictionConstants.DataNotGet);
        }

        public IDataResult<Depiction> GetById(Guid id)
        {
            Depiction result = _depictionDal.Get(d => d.Id == id && !d.IsDeleted);
            return result != null
                ? new SuccessDataResult<Depiction>(result, DepictionConstants.DataGet)
                : new ErrorDataResult<Depiction>(DepictionConstants.NotMatch);
        }

        public IDataResult<IList<Depiction>> GetAllByIds(Guid[] ids)
        {
            IList<Depiction> titles = _depictionDal.GetAll(d => ids.Contains(d.Id) && !d.IsDeleted);
            return titles != null
                ? new SuccessDataResult<IList<Depiction>>(titles, DepictionConstants.DataGet)
                : new ErrorDataResult<IList<Depiction>>(DepictionConstants.DataNotGet);
        }

        public IDataResult<Depiction> GetByImage(Guid imageId)
        {
            Depiction result = _depictionDal.Get(d => d.Image.Id == imageId && !d.IsDeleted);
            return result != null
                ? new SuccessDataResult<Depiction>(result, DepictionConstants.DataGet)
                : new ErrorDataResult<Depiction>(DepictionConstants.NotMatch);
        }

        public IDataResult<IList<Depiction>> GetAllByName(string name)
        {
            IList<Depiction> results = _depictionDal.GetAll(d => d.Name == name && !d.IsDeleted);
            return results != null
                ? new SuccessDataResult<IList<Depiction>>(results, DepictionConstants.DataGet)
                : new ErrorDataResult<IList<Depiction>>(DepictionConstants.DataNotGet);
        }

        public IDataResult<IList<Depiction>> GetAllByPrice(decimal minPrice, decimal? maxPrice = null)
        {
            IList<Depiction> results = maxPrice == null
                ? _depictionDal.GetAll(d => d.Price == minPrice && !d.IsDeleted)
                : _depictionDal.GetAll(d => d.Price >= minPrice && d.Price <= maxPrice && !d.IsDeleted);

            return results != null
                ? new SuccessDataResult<IList<Depiction>>(results, DepictionConstants.DataGet)
                : new ErrorDataResult<IList<Depiction>>(DepictionConstants.DataNotGet);
        }

        public IDataResult<IList<Depiction>> GetAllByTechnicalPlaceholder(Guid technicalPlaceholderId)
        {
            IDataResult<TechnicalPlaceholder> technicalPlaceholder = _facadeService.TechnicalPlaceholderService().GetById(technicalPlaceholderId);
            if (!technicalPlaceholder.Success)
                return new ErrorDataResult<IList<Depiction>>(technicalPlaceholder.Message);

            IList<Depiction> results = _depictionDal.GetAll(d => d.TechnicalPlaceholdersId == technicalPlaceholderId && !d.IsDeleted);
            return results != null
                ? new SuccessDataResult<IList<Depiction>>(results, DepictionConstants.DataGet)
                : new ErrorDataResult<IList<Depiction>>(DepictionConstants.DataNotGet);
        }

        public IDataResult<IList<Depiction>> GetAllByTitle(string title)
        {
            IList<Depiction> titles = _depictionDal.GetAll(d => d.Title == title && !d.IsDeleted);
            return titles != null
                ? new SuccessDataResult<IList<Depiction>>(titles, DepictionConstants.DataGet)
                : new ErrorDataResult<IList<Depiction>>(DepictionConstants.DataNotGet);
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

        public IDataResult<Depiction> GetByStock(Guid stockId)
        {
            IDataResult<Stock> stock = _facadeService.StockService().GetById(stockId);
            if (!stock.Success)
                return new ErrorDataResult<Depiction>(stock.Message);

            Depiction depiction = _depictionDal.Get(d => d.Stock == stock.Data && !d.IsDeleted);
            return depiction == null
                ? new ErrorDataResult<Depiction>(DepictionConstants.NotMatch)
                : new SuccessDataResult<Depiction>(depiction, DepictionConstants.DataGet);
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
