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
    public class PaintingManager : IPaintingService
    {
        private readonly IPaintingDal _paintingDal;
        private readonly IFacadeService _facadeService;

        public PaintingManager(IPaintingDal paintingDal)
        {
            _paintingDal = paintingDal;
        }

        [ValidationAspect(typeof(PaintingValidator))]
        public IResult Add(Painting painting)
        {
            IResult result = BusinessRules.Run(PaintingControlDB(painting));
            if (result != null)
                return result;

            painting.IsDeleted = false;
            _paintingDal.Add(painting);
            return new SuccessResult(PaintingConstants.AddSuccess);
        }

        public IResult Delete(Guid id)
        {
            Painting painting = _paintingDal.Get(p => p.Id == id);
            if (painting == null)
                return new ErrorResult(PaintingConstants.NotMatch);

            _paintingDal.Delete(painting);
            return new SuccessResult(PaintingConstants.EfDeletedSuccsess);
        }

        public IResult ShadowDelete(Guid id)
        {
            Painting painting = _paintingDal.Get(p => p.Id == id && !p.IsDeleted);
            if (painting == null)
                return new ErrorResult(PaintingConstants.NotMatch);

            painting.IsDeleted = true;
            _paintingDal.Update(painting);
            return new SuccessResult(PaintingConstants.EfDeletedSuccsess);
        }

        [ValidationAspect(typeof(PaintingValidator))]
        public IResult Update(Painting painting)
        {
            IResult result = BusinessRules.Run(PaintingControlDB(painting));
            if (result != null)
                return result;

            painting.IsDeleted = false;
            _paintingDal.Update(painting);
            return new SuccessResult(PaintingConstants.UpdateSuccess);
        }

        public IDataResult<IList<Painting>> GetAll()
        {
            return new SuccessDataResult<IList<Painting>>(_paintingDal.GetAll(p => !p.IsDeleted), PaintingConstants.DataGet);
        }

        public IDataResult<IList<Painting>> GetAllByCategories(int[] categoriesId)
        {
            IDataResult<IList<Category>> categories = _facadeService.CategoryService().GetAllByIds(categoriesId);
            if (!categories.Success)
                return new ErrorDataResult<IList<Painting>>(categories.Message);

            IList<Painting> paintings = _paintingDal.GetAll(p => p.Categories == categories.Data && !p.IsDeleted);
            return paintings == null
                ? new ErrorDataResult<IList<Painting>>(PaintingConstants.DataNotGet)
                : new SuccessDataResult<IList<Painting>>(paintings, PaintingConstants.DataGet);
        }

        public IDataResult<IList<Painting>> GetAllByDescriptionFinder(string finderString)
        {
            IList<Painting> paintings = _paintingDal.GetAll(p => p.Description.Contains(finderString) && !p.IsDeleted);
            return paintings == null
                ? new ErrorDataResult<IList<Painting>>(PaintingConstants.DataNotGet)
                : new SuccessDataResult<IList<Painting>>(paintings, PaintingConstants.DataGet);
        }

        public IDataResult<IList<Painting>> GetAllByDestroyState(bool state)
        {
            IList<Painting> paintings = _paintingDal.GetAll(p => p.IsDestroyed == state && !p.IsDeleted);
            return paintings == null
                ? new ErrorDataResult<IList<Painting>>(PaintingConstants.DataNotGet)
                : new SuccessDataResult<IList<Painting>>(paintings, PaintingConstants.DataGet);
        }

        public IDataResult<IList<Painting>> GetAllByDimension(Guid dimensionId)
        {
            IDataResult<Dimension> dimension = _facadeService.DimensionService().GetById(dimensionId);
            if (!dimension.Success)
                return new ErrorDataResult<IList<Painting>>(dimension.Message);

            IList<Painting> paintings = _paintingDal.GetAll(p => p.DimensionsId == dimensionId && !p.IsDeleted);
            return paintings == null
                ? new ErrorDataResult<IList<Painting>>(PaintingConstants.DataNotGet)
                : new SuccessDataResult<IList<Painting>>(paintings, PaintingConstants.DataGet);
        }

        public IDataResult<IList<Painting>> GetAllByEMFile(Guid eMFileId)
        {
            IDataResult<EMaterialFile> eMFile = _facadeService.EMaterialFileService().GetById(eMFileId);
            if (!eMFile.Success)
                return new ErrorDataResult<IList<Painting>>(eMFile.Message);

            IList<Painting> paintings = _paintingDal.GetAll(p => p.EMaterialFilesId == eMFileId && !p.IsDeleted);
            return paintings == null
                ? new ErrorDataResult<IList<Painting>>(PaintingConstants.DataNotGet)
                : new SuccessDataResult<IList<Painting>>(paintings, PaintingConstants.DataGet);
        }

        public IDataResult<IList<Painting>> GetAllByFilter(Expression<Func<Painting, bool>>? filter = null)
        {
            return new SuccessDataResult<IList<Painting>>(_paintingDal.GetAll(filter), PaintingConstants.DataGet);
        }

        public IDataResult<IList<Painting>> GetAllByIds(Guid[] ids)
        {
            IList<Painting> paintings = _paintingDal.GetAll(p => ids.Contains(p.Id) && !p.IsDeleted);
            _facadeService.CounterService().Count(paintings);
            return paintings == null
                ? new ErrorDataResult<IList<Painting>>(PaintingConstants.DataNotGet)
                : new SuccessDataResult<IList<Painting>>(paintings, PaintingConstants.DataGet);
        }

        public IDataResult<IList<Painting>> GetAllByName(string name)
        {
            IList<Painting> paintings = _paintingDal.GetAll(p => p.Name.Contains(name) && !p.IsDeleted);
            return paintings == null
                ? new ErrorDataResult<IList<Painting>>(PaintingConstants.DataNotGet)
                : new SuccessDataResult<IList<Painting>>(paintings, PaintingConstants.DataGet);
        }

        public IDataResult<IList<Painting>> GetAllByOwnerId(Guid ownerId)
        {
            IDataResult<OtherPeople> owner = _facadeService.OtherPeopleService().GetById(ownerId);
            if (!owner.Success)
                return new ErrorDataResult<IList<Painting>>(owner.Message);

            IList<Painting> paintings = _paintingDal.GetAll(p => p.Owner == owner && !p.IsDeleted);
            return paintings == null
                ? new ErrorDataResult<IList<Painting>>(PaintingConstants.DataNotGet)
                : new SuccessDataResult<IList<Painting>>(paintings, PaintingConstants.DataGet);
        }

        public IDataResult<IList<Painting>> GetAllByOwnersId(Guid[] ownerIds)
        {
            IDataResult<IList<OtherPeople>> owners = _facadeService.OtherPeopleService().GetAllByIds(ownerIds);
            if (!owners.Success)
                return new ErrorDataResult<IList<Painting>>(owners.Message);

            IList<Painting> paintings = _paintingDal.GetAll(p => owners.Data.Contains(p.Owner) && !p.IsDeleted);
            return paintings == null
                ? new ErrorDataResult<IList<Painting>>(PaintingConstants.DataNotGet)
                : new SuccessDataResult<IList<Painting>>(paintings, PaintingConstants.DataGet);
        }

        public IDataResult<IList<Painting>> GetAllByPrice(decimal minPrice, decimal? maxPrice = null)
        {
            IList<Painting> paintings = maxPrice == null
                ? _paintingDal.GetAll(p => p.Price == minPrice && !p.IsDeleted)
                : _paintingDal.GetAll(p => p.Price >= minPrice && p.Price <= maxPrice && !p.IsDeleted);

            return paintings == null
                ? new ErrorDataResult<IList<Painting>>(PaintingConstants.DataNotGet)
                : new SuccessDataResult<IList<Painting>>(paintings, PaintingConstants.DataGet);
        }

        public IDataResult<IList<Painting>> GetAllByIsDeleted()
        {
            return new SuccessDataResult<IList<Painting>>(_paintingDal.GetAll(p => p.IsDeleted), PaintingConstants.DataGet);
        }

        public IDataResult<IList<Painting>> GetAllByTechnicalPlaceholder(Guid technicalPlaceholderId)
        {
            IDataResult<TechnicalPlaceholder> techPlaceHolder = _facadeService.TechnicalPlaceholderService().GetById(technicalPlaceholderId);
            if (!techPlaceHolder.Success)
                return new ErrorDataResult<IList<Painting>>(techPlaceHolder.Message);

            IList<Painting> paintings = _paintingDal.GetAll(p => p.TechnicalPlaceholdersId == technicalPlaceholderId && !p.IsDeleted);
            return paintings == null
                ? new ErrorDataResult<IList<Painting>>(PaintingConstants.DataNotGet)
                : new SuccessDataResult<IList<Painting>>(paintings, PaintingConstants.DataGet);
        }

        public IDataResult<IList<Painting>> GetAllByTitle(string title)
        {
            IList<Painting> paintings = _paintingDal.GetAll(p => p.Title.Contains(title) && !p.IsDeleted);
            return paintings == null
                ? new ErrorDataResult<IList<Painting>>(PaintingConstants.DataNotGet)
                : new SuccessDataResult<IList<Painting>>(paintings, PaintingConstants.DataGet);
        }

        public IDataResult<Painting> GetById(Guid id)
        {
            Painting painting = _paintingDal.Get(p => p.Id == id);
            _facadeService.CounterService().Count(painting);
            return painting == null
                ? new ErrorDataResult<Painting>(PaintingConstants.DataNotGet)
                : new SuccessDataResult<Painting>(painting, PaintingConstants.DataGet);
        }

        public IDataResult<Painting> GetByImageId(Guid imageId)
        {
            IDataResult<Image> image = _facadeService.ImageService().GetById(imageId);
            if (!image.Success)
                return new ErrorDataResult<Painting>(image.Message);

            Painting painting = _paintingDal.Get(p => p.ImageId == imageId && !p.IsDeleted);
            _facadeService.CounterService().Count(painting);
            return painting == null
                ? new ErrorDataResult<Painting>(PaintingConstants.DataNotGet)
                : new SuccessDataResult<Painting>(painting, PaintingConstants.DataGet);
        }

        public IDataResult<Painting> GetByStock(Guid stockId)
        {
            IDataResult<Stock> stock = _facadeService.StockService().GetById(stockId);
            if (!stock.Success)
                return new ErrorDataResult<Painting>(stock.Message);

            Painting painting = _paintingDal.Get(p => p.StockId == stockId && !p.IsDeleted);
            _facadeService.CounterService().Count(painting);
            return painting == null
                ? new ErrorDataResult<Painting>(PaintingConstants.DataNotGet)
                : new SuccessDataResult<Painting>(painting, PaintingConstants.DataGet);
        }

        public IDataResult<byte?> GetSecretLevel(Guid id)
        {
            byte? sLevel = _paintingDal.Get(p => p.Id == id && !p.IsDeleted).SecretLevel;
            return sLevel == null
                ? new ErrorDataResult<byte?>(PaintingConstants.DataNotGet)
                : new SuccessDataResult<byte?>(sLevel, PaintingConstants.DataGet);
        }

        public IDataResult<byte> GetState(Guid id)
        {
            return new SuccessDataResult<byte>(_paintingDal.Get(p => p.Id == id).State, PaintingConstants.DataGet);
        }

        private IResult PaintingControlDB(Painting Painting)
        {
            bool paint = _paintingDal.Get(o =>

               o.Name == Painting.Name
            && o.Title == Painting.Title
            && o.Description == Painting.Description
            && o.Price == Painting.Price
            && o.StockId == Painting.StockId
            && o.State == Painting.State
            && o.Owner == Painting.Owner
            ) != null;

            if (paint)
                return new ErrorResult(PaintingConstants.AlreadyExists);
            return new SuccessResult();
        }
    }
}
