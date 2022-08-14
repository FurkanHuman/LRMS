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
    public class GraphicalImageManager : IGraphicalImageService
    {
        private readonly IGraphicalImageDal _graphicalImageDal;
        private readonly IFacadeService _facadeService;

        public GraphicalImageManager(IGraphicalImageDal graphicalImageDal)
        {
            _graphicalImageDal = graphicalImageDal;
        }

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

        public IDataResult<IList<GraphicalImage>> GetAll()
        {
            return new SuccessDataResult<IList<GraphicalImage>>(_graphicalImageDal.GetAll(gi => !gi.IsDeleted), GraphicalImageConstants.DataGet);
        }

        public IDataResult<IList<GraphicalImage>> GetAllByFilter(Expression<Func<GraphicalImage, bool>>? filter = null)
        {
            return new SuccessDataResult<IList<GraphicalImage>>(_graphicalImageDal.GetAll(filter), GraphicalImageConstants.DataGet);

        }

        public IDataResult<IList<GraphicalImage>> GetAllByIsDeleted()
        {
            return new SuccessDataResult<IList<GraphicalImage>>(_graphicalImageDal.GetAll(gi => gi.IsDeleted), GraphicalImageConstants.DataGet);
        }

        public IDataResult<IList<GraphicalImage>> GetAllByCategories(int[] categoriesId)
        {
            IDataResult<IList<Category>> categories = _facadeService.CategoryService().GetAllByIds(categoriesId);
            if (!categories.Success)
                return new ErrorDataResult<IList<GraphicalImage>>(categories.Message);

            IList<GraphicalImage> graphicalImages = _graphicalImageDal.GetAll(gi => categoriesId.Contains(gi.CategoryId) && !gi.IsDeleted);
            return graphicalImages == null
                ? new ErrorDataResult<IList<GraphicalImage>>(GraphicalImageConstants.DataNotGet)
                : new ErrorDataResult<IList<GraphicalImage>>(graphicalImages, GraphicalImageConstants.DataGet);
        }

        public IDataResult<IList<GraphicalImage>> GetAllByDescriptionFinder(string finderString)
        {
            IList<GraphicalImage> graphicalImages = _graphicalImageDal.GetAll(gi => gi.Description.Contains(finderString) && !gi.IsDeleted);
            return graphicalImages == null
            ? new ErrorDataResult<IList<GraphicalImage>>(GraphicalImageConstants.DataNotGet)
            : new SuccessDataResult<IList<GraphicalImage>>(graphicalImages, GraphicalImageConstants.DataGet);
        }

        public IDataResult<IList<GraphicalImage>> GetAllByDimension(Guid dimensionId)
        {
            IDataResult<Dimension> dimension = _facadeService.DimensionService().GetById(dimensionId);
            if (!dimension.Success)
                return new ErrorDataResult<IList<GraphicalImage>>(dimension.Message);

            IList<GraphicalImage> graphicalImages = _graphicalImageDal.GetAll(gi => gi.DimensionsId == dimensionId && !gi.IsDeleted);
            return graphicalImages == null
                ? new ErrorDataResult<IList<GraphicalImage>>(GraphicalImageConstants.DataNotGet)
                : new ErrorDataResult<IList<GraphicalImage>>(graphicalImages, GraphicalImageConstants.DataGet);
        }

        public IDataResult<IList<GraphicalImage>> GetAllByEMFile(Guid eMFileId)
        {
            IDataResult<EMaterialFile> eMFiles = _facadeService.EMaterialFileService().GetById(eMFileId);
            if (!eMFiles.Success)
                return new ErrorDataResult<IList<GraphicalImage>>(eMFiles.Message);

            IList<GraphicalImage> graphicalImages = _graphicalImageDal.GetAll(gi => gi.EMaterialFilesId == eMFileId && !gi.IsDeleted);
            return graphicalImages == null
                ? new ErrorDataResult<IList<GraphicalImage>>(GraphicalImageConstants.DataNotGet)
                : new ErrorDataResult<IList<GraphicalImage>>(graphicalImages, GraphicalImageConstants.DataGet);
        }

        public IDataResult<GraphicalImage> GetById(Guid id)
        {
            GraphicalImage graphicalImage = _graphicalImageDal.Get(gi => gi.Id == id);
            _facadeService.CounterService().Count(graphicalImage);
            return graphicalImage == null
                ? new ErrorDataResult<GraphicalImage>(GraphicalImageConstants.NotMatch)
                : new SuccessDataResult<GraphicalImage>(graphicalImage, GraphicalImageConstants.DataGet);
        }

        public IDataResult<IList<GraphicalImage>> GetAllByIds(Guid[] ids)
        {
            IList<GraphicalImage> graphicalImages = _graphicalImageDal.GetAll(gi => ids.Contains(gi.Id) && !gi.IsDeleted);
            _facadeService.CounterService().Count(graphicalImages);
            return graphicalImages == null
            ? new ErrorDataResult<IList<GraphicalImage>>(GraphicalImageConstants.DataNotGet)
            : new SuccessDataResult<IList<GraphicalImage>>(graphicalImages, GraphicalImageConstants.DataGet);
        }

        public IDataResult<GraphicalImage> GetByImage(Guid imageId)
        {
            IDataResult<Image> image = _facadeService.ImageService().GetById(imageId);
            if (!image.Success)
                return new ErrorDataResult<GraphicalImage>(image.Message);

            GraphicalImage graphicalImage = _graphicalImageDal.Get(gi => gi.Image == image.Data && !gi.IsDeleted);
            return graphicalImage == null
                ? new ErrorDataResult<GraphicalImage>(GraphicalImageConstants.DataNotGet)
                : new ErrorDataResult<GraphicalImage>(graphicalImage, GraphicalImageConstants.DataGet);
        }

        public IDataResult<IList<GraphicalImage>> GetAllByImageCreatedDate(DateTime dateTime)
        {
            IList<GraphicalImage> graphicalImages = _graphicalImageDal.GetAll(gi => gi.ImageCreatedDate == dateTime && !gi.IsDeleted);
            return graphicalImages == null
            ? new ErrorDataResult<IList<GraphicalImage>>(GraphicalImageConstants.DataNotGet)
            : new SuccessDataResult<IList<GraphicalImage>>(graphicalImages, GraphicalImageConstants.DataGet);
        }

        public IDataResult<IList<GraphicalImage>> GetAllByName(string name)
        {
            IList<GraphicalImage> graphicalImages = _graphicalImageDal.GetAll(gi => gi.Name.Contains(name) && !gi.IsDeleted);
            return graphicalImages == null
            ? new ErrorDataResult<IList<GraphicalImage>>(GraphicalImageConstants.DataNotGet)
            : new SuccessDataResult<IList<GraphicalImage>>(graphicalImages, GraphicalImageConstants.DataGet);
        }

        public IDataResult<IList<GraphicalImage>> GetAllByOtherPeople(Guid otherPeopleId)
        {
            IDataResult<OtherPeople> otherPeople = _facadeService.OtherPeopleService().GetById(otherPeopleId);
            if (!otherPeople.Success)
                return new ErrorDataResult<IList<GraphicalImage>>(otherPeople.Message);

            IList<GraphicalImage> graphicalImages = _graphicalImageDal.GetAll(gi => gi.OtherPeople == otherPeople && !gi.IsDeleted);
            return graphicalImages == null
                ? new ErrorDataResult<IList<GraphicalImage>>(GraphicalImageConstants.DataNotGet)
                : new ErrorDataResult<IList<GraphicalImage>>(graphicalImages, GraphicalImageConstants.DataGet);
        }

        public IDataResult<IList<GraphicalImage>> GetAllByPrice(decimal minPrice, decimal? maxPrice = null)
        {
            IList<GraphicalImage> graphicalImages = maxPrice == null
                ? _graphicalImageDal.GetAll(gi => gi.Price == minPrice && !gi.IsDeleted)
                : _graphicalImageDal.GetAll(gi => gi.Price >= minPrice && gi.Price <= maxPrice && !gi.IsDeleted);

            return graphicalImages == null
                ? new ErrorDataResult<IList<GraphicalImage>>(GraphicalImageConstants.DataNotGet)
                : new SuccessDataResult<IList<GraphicalImage>>(graphicalImages, GraphicalImageConstants.DataGet);
        }

        public IDataResult<IList<GraphicalImage>> GetAllByTechnicalPlaceholder(Guid technicalPlaceholderId)
        {
            IDataResult<TechnicalPlaceholder> techPlacehol = _facadeService.TechnicalPlaceholderService().GetById(technicalPlaceholderId);
            if (!techPlacehol.Success)
                return new ErrorDataResult<IList<GraphicalImage>>(techPlacehol.Message);

            IList<GraphicalImage> graphicalImages = _graphicalImageDal.GetAll(gi => gi.TechnicalPlaceholdersId == technicalPlaceholderId && !gi.IsDeleted);
            return graphicalImages == null
                ? new ErrorDataResult<IList<GraphicalImage>>(GraphicalImageConstants.DataNotGet)
                : new ErrorDataResult<IList<GraphicalImage>>(graphicalImages, GraphicalImageConstants.DataGet);
        }

        public IDataResult<IList<GraphicalImage>> GetAllByTitle(string title)
        {
            IList<GraphicalImage> graphicalImages = _graphicalImageDal.GetAll(gi => gi.Title.Contains(title) && !gi.IsDeleted);
            return graphicalImages == null
            ? new ErrorDataResult<IList<GraphicalImage>>(GraphicalImageConstants.DataNotGet)
            : new SuccessDataResult<IList<GraphicalImage>>(graphicalImages, GraphicalImageConstants.DataGet);
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
            IDataResult<Stock> stock = _facadeService.StockService().GetById(stockId);
            if (!stock.Success)
                return new ErrorDataResult<GraphicalImage>(stock.Message);

            GraphicalImage graphicalImage = _graphicalImageDal.Get(gi => gi.Stock == stock.Data && !gi.IsDeleted);
            _facadeService.CounterService().Count(graphicalImage);
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
