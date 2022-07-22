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
    public class GraphicalImageManager : IGraphicalImageService
    {
        private readonly IGraphicalImageDal _graphicalImageDal;

        private readonly ICategoryService _categoryService;
        private readonly IDimensionService _dimensionService;
        private readonly IImageService _imageService;
        private readonly IEMaterialFileService _eMaterialFileService;
        private readonly IOtherPeopleService _otherPeopleService;
        private readonly ITechnicalPlaceholderService _technicalPlaceholderService;
        private readonly IStockService _stockService;



        [ValidationAspect(typeof(GraphicalImageValidator))]
        public IResult Add(GraphicalImage entity)
        {
            IResult result = BusinessRules.Run(CheckGraphicalImage(entity));
            if (result != null)
                return result;

            entity.IsDeleted = false;
            _graphicalImageDal.Add(entity);
            return new SuccessResult(GraphicalImageConstants.AddSuccess);
        }

        public IResult Delete(Guid id)
        {
            GraphicalImage graphicalImage = _graphicalImageDal.Get(gi => gi.Id == id);
            if (graphicalImage == null)
                return new SuccessResult(GraphicalImageConstants.NotMatch);

            _graphicalImageDal.Delete(graphicalImage);
            return new SuccessResult(GraphicalImageConstants.DeleteSuccess);
        }

        public IResult ShadowDelete(Guid id)
        {
            GraphicalImage graphicalImage = _graphicalImageDal.Get(gi => gi.Id == id && !gi.IsDeleted);
            if (graphicalImage == null)
                return new SuccessResult(GraphicalImageConstants.NotMatch);
            graphicalImage.IsDeleted = true;
            _graphicalImageDal.Update(graphicalImage);
            return new SuccessResult(GraphicalImageConstants.EfDeletedSuccsess);
        }

        [ValidationAspect(typeof(GraphicalImageValidator))]
        public IResult Update(GraphicalImage entity)
        {
            IResult result = BusinessRules.Run(CheckGraphicalImage(entity));
            if (result != null)
                return result;

            entity.IsDeleted = false;
            _graphicalImageDal.Update(entity);
            return new SuccessResult(GraphicalImageConstants.UpdateSuccess);
        }

        public IDataResult<List<GraphicalImage>> GetAll()
        {
            return new SuccessDataResult<List<GraphicalImage>>(_graphicalImageDal.GetAll(gi => !gi.IsDeleted).ToList(), GraphicalImageConstants.DataGet);
        }

        public IDataResult<List<GraphicalImage>> GetAllByFilter(Expression<Func<GraphicalImage, bool>>? filter = null)
        {
            return new SuccessDataResult<List<GraphicalImage>>(_graphicalImageDal.GetAll(filter).ToList(), GraphicalImageConstants.DataGet);

        }

        public IDataResult<List<GraphicalImage>> GetAllBySecret()
        {
            return new SuccessDataResult<List<GraphicalImage>>(_graphicalImageDal.GetAll(gi => gi.IsDeleted).ToList(), GraphicalImageConstants.DataGet);
        }

        public IDataResult<List<GraphicalImage>> GetAllByCategories(int[] categoriesId)
        {
            IDataResult<List<Category>> categories = _categoryService.GetAllByIds(categoriesId);
            if (!categories.Success)
                return new ErrorDataResult<List<GraphicalImage>>(categories.Message);

            List<GraphicalImage> graphicalImages = _graphicalImageDal.GetAll(gi => categoriesId.Contains(gi.CategoryId) && !gi.IsDeleted).ToList();
            return graphicalImages == null
                ? new ErrorDataResult<List<GraphicalImage>>(GraphicalImageConstants.DataNotGet)
                : new ErrorDataResult<List<GraphicalImage>>(graphicalImages, GraphicalImageConstants.DataGet);
        }

        public IDataResult<List<GraphicalImage>> GetAllByDescriptionFinder(string finderString)
        {
            List<GraphicalImage> graphicalImages = _graphicalImageDal.GetAll(gi => gi.Description.Contains(finderString) && !gi.IsDeleted).ToList();
            return graphicalImages == null
            ? new ErrorDataResult<List<GraphicalImage>>(GraphicalImageConstants.DataNotGet)
            : new SuccessDataResult<List<GraphicalImage>>(graphicalImages, GraphicalImageConstants.DataGet);
        }

        public IDataResult<List<GraphicalImage>> GetAllByDimension(Guid dimensionId)
        {
            var dimension = _dimensionService.GetById(dimensionId);
            if (!dimension.Success)
                return new ErrorDataResult<List<GraphicalImage>>(dimension.Message);

            List<GraphicalImage> graphicalImages = _graphicalImageDal.GetAll(gi => gi.DimensionsId == dimensionId && !gi.IsDeleted).ToList();
            return graphicalImages == null
                ? new ErrorDataResult<List<GraphicalImage>>(GraphicalImageConstants.DataNotGet)
                : new ErrorDataResult<List<GraphicalImage>>(graphicalImages, GraphicalImageConstants.DataGet);
        }

        public IDataResult<List<GraphicalImage>> GetAllByEMFile(Guid eMFilesId)
        {
            IDataResult<EMaterialFile> eMFiles = _eMaterialFileService.GetById(eMFilesId);
            if (!eMFiles.Success)
                return new ErrorDataResult<List<GraphicalImage>>(eMFiles.Message);

            List<GraphicalImage> graphicalImages = _graphicalImageDal.GetAll(gi => gi.EMaterialFilesId == eMFilesId && !gi.IsDeleted).ToList();
            return graphicalImages == null
                ? new ErrorDataResult<List<GraphicalImage>>(GraphicalImageConstants.DataNotGet)
                : new ErrorDataResult<List<GraphicalImage>>(graphicalImages, GraphicalImageConstants.DataGet);
        }

        public IDataResult<GraphicalImage> GetById(Guid id)
        {
            GraphicalImage graphicalImage = _graphicalImageDal.Get(gi => gi.Id == id);
            return graphicalImage == null
                ? new ErrorDataResult<GraphicalImage>(GraphicalImageConstants.NotMatch)
                : new SuccessDataResult<GraphicalImage>(graphicalImage, GraphicalImageConstants.DataGet);
        }

        public IDataResult<List<GraphicalImage>> GetAllByIds(Guid[] ids)
        {
            List<GraphicalImage> graphicalImages = _graphicalImageDal.GetAll(gi => ids.Contains(gi.Id) && !gi.IsDeleted).ToList();
            return graphicalImages == null
            ? new ErrorDataResult<List<GraphicalImage>>(GraphicalImageConstants.DataNotGet)
            : new SuccessDataResult<List<GraphicalImage>>(graphicalImages, GraphicalImageConstants.DataGet);
        }

        public IDataResult<GraphicalImage> GetByImage(Guid imageId)
        {
            IDataResult<Image> image = _imageService.GetById(imageId);
            if (!image.Success)
                return new ErrorDataResult<GraphicalImage>(image.Message);

            GraphicalImage graphicalImage = _graphicalImageDal.Get(gi => gi.Image == image.Data && !gi.IsDeleted);
            return graphicalImage == null
                ? new ErrorDataResult<GraphicalImage>(GraphicalImageConstants.DataNotGet)
                : new ErrorDataResult<GraphicalImage>(graphicalImage, GraphicalImageConstants.DataGet);
        }

        public IDataResult<List<GraphicalImage>> GetAllByImageCreatedDate(DateTime dateTime)
        {
            List<GraphicalImage> graphicalImages = _graphicalImageDal.GetAll(gi => gi.ImageCreatedDate == dateTime && !gi.IsDeleted).ToList();
            return graphicalImages == null
            ? new ErrorDataResult<List<GraphicalImage>>(GraphicalImageConstants.DataNotGet)
            : new SuccessDataResult<List<GraphicalImage>>(graphicalImages, GraphicalImageConstants.DataGet);
        }

        public IDataResult<List<GraphicalImage>> GetAllByName(string name)
        {
            List<GraphicalImage> graphicalImages = _graphicalImageDal.GetAll(gi => gi.Name.Contains(name) && !gi.IsDeleted).ToList();
            return graphicalImages == null
            ? new ErrorDataResult<List<GraphicalImage>>(GraphicalImageConstants.DataNotGet)
            : new SuccessDataResult<List<GraphicalImage>>(graphicalImages, GraphicalImageConstants.DataGet);
        }

        public IDataResult<List<GraphicalImage>> GetAllByOtherPeople(Guid otherPeopleId)
        {
            IDataResult<OtherPeople> otherPeople = _otherPeopleService.GetById(otherPeopleId);
            if (!otherPeople.Success)
                return new ErrorDataResult<List<GraphicalImage>>(otherPeople.Message);

            List<GraphicalImage> graphicalImages = _graphicalImageDal.GetAll(gi => gi.OtherPeople == otherPeople && !gi.IsDeleted).ToList();
            return graphicalImages == null
                ? new ErrorDataResult<List<GraphicalImage>>(GraphicalImageConstants.DataNotGet)
                : new ErrorDataResult<List<GraphicalImage>>(graphicalImages, GraphicalImageConstants.DataGet);
        }

        public IDataResult<List<GraphicalImage>> GetAllByPrice(decimal minPrice, decimal? maxPrice = null)
        {
            List<GraphicalImage> graphicalImages = maxPrice == null
                ? _graphicalImageDal.GetAll(gi => gi.Price == minPrice && !gi.IsDeleted).ToList()
                : _graphicalImageDal.GetAll(gi => gi.Price >= minPrice && gi.Price <= maxPrice && !gi.IsDeleted).ToList();

            return graphicalImages == null
                ? new ErrorDataResult<List<GraphicalImage>>(GraphicalImageConstants.DataNotGet)
                : new SuccessDataResult<List<GraphicalImage>>(graphicalImages, GraphicalImageConstants.DataGet);
        }

        public IDataResult<List<GraphicalImage>> GetAllByTechnicalPlaceholder(Guid technicalPlaceholderId)
        {
            IDataResult<TechnicalPlaceholder> techPlacehol = _technicalPlaceholderService.GetById(technicalPlaceholderId);
            if (!techPlacehol.Success)
                return new ErrorDataResult<List<GraphicalImage>>(techPlacehol.Message);

            List<GraphicalImage> graphicalImages = _graphicalImageDal.GetAll(gi => gi.TechnicalPlaceholdersId == technicalPlaceholderId && !gi.IsDeleted).ToList();
            return graphicalImages == null
                ? new ErrorDataResult<List<GraphicalImage>>(GraphicalImageConstants.DataNotGet)
                : new ErrorDataResult<List<GraphicalImage>>(graphicalImages, GraphicalImageConstants.DataGet);
        }

        public IDataResult<List<GraphicalImage>> GetAllByTitle(string title)
        {
            List<GraphicalImage> graphicalImages = _graphicalImageDal.GetAll(gi => gi.Title.Contains(title) && !gi.IsDeleted).ToList();
            return graphicalImages == null
            ? new ErrorDataResult<List<GraphicalImage>>(GraphicalImageConstants.DataNotGet)
            : new SuccessDataResult<List<GraphicalImage>>(graphicalImages, GraphicalImageConstants.DataGet);
        }

        public IDataResult<byte?> GetSecretLevel(Guid id)
        {
            byte? sLevel = _graphicalImageDal.Get(gi => gi.Id == id && !gi.IsDeleted).SecretLevel;
            return sLevel == null
            ? new ErrorDataResult<byte?>(GraphicalImageConstants.DataNotGet)
            : new SuccessDataResult<byte?>(sLevel, GraphicalImageConstants.DataGet);
        }

        public IDataResult<byte> GetState(Guid id)
        {
            return new SuccessDataResult<byte>(_graphicalImageDal.Get(gi => gi.Id == id && !gi.IsDeleted).State, GraphicalImageConstants.DataGet);
        }

        public IDataResult<GraphicalImage> GetByStock(Guid stockId)
        {
            IDataResult<Stock> stock = _stockService.GetById(stockId);
            if (!stock.Success)
                return new ErrorDataResult<GraphicalImage>(stock.Message);

            GraphicalImage graphicalImage = _graphicalImageDal.Get(gi => gi.Stock == stock.Data && !gi.IsDeleted);
            return graphicalImage == null
                ? new ErrorDataResult<GraphicalImage>(GraphicalImageConstants.NotMatch)
                : new SuccessDataResult<GraphicalImage>(graphicalImage, GraphicalImageConstants.DataGet);
        }

        private IResult CheckGraphicalImage(GraphicalImage graphicalImage)
        {
            bool graphicalImageControl = _graphicalImageDal.Get(gi =>

                gi.Name == graphicalImage.Name
             && gi.Title == graphicalImage.Title
             && gi.Description.Contains(graphicalImage.Description)
             && gi.CategoryId == graphicalImage.CategoryId
             && gi.TechnicalPlaceholdersId == graphicalImage.TechnicalPlaceholdersId
             && gi.DimensionsId == graphicalImage.DimensionsId
             && gi.EMaterialFilesId == graphicalImage.EMaterialFilesId
             && gi.State == graphicalImage.State
             && gi.ImageCreatedDate == graphicalImage.ImageCreatedDate
             && gi.Image.Id == graphicalImage.Image.Id
             && gi.OtherPeople.Id == graphicalImage.OtherPeople.Id
             ) != null;

            if (graphicalImageControl)
                return new ErrorResult(GraphicalImageConstants.AlreadyExists);

            return new SuccessResult();
        }
    }
}
