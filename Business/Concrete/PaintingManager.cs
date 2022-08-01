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

        public PaintingManager(IPaintingDal paintingDal, IFacadeService facadeService)
        {
            _paintingDal = paintingDal;
            _facadeService = facadeService;
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

        public IDataResult<List<Painting>> GetAll()
        {
            return new SuccessDataResult<List<Painting>>(_paintingDal.GetAll(p => !p.IsDeleted).ToList(), PaintingConstants.DataGet);
        }

        public IDataResult<List<Painting>> GetAllByCategories(int[] categoriesId)
        {
            IDataResult<List<Category>> categories = _facadeService.CategoryService().GetAllByIds(categoriesId);
            if (!categories.Success)
                return new ErrorDataResult<List<Painting>>(categories.Message);

            List<Painting> paintings = _paintingDal.GetAll(p => p.Categories.ToList() == categories.Data.ToList() && !p.IsDeleted).ToList();
            return paintings == null
                ? new ErrorDataResult<List<Painting>>(PaintingConstants.DataNotGet)
                : new SuccessDataResult<List<Painting>>(paintings, PaintingConstants.DataGet);
        }

        public IDataResult<List<Painting>> GetAllByDescriptionFinder(string finderString)
        {
            List<Painting> paintings = _paintingDal.GetAll(p => p.Description.Contains(finderString) && !p.IsDeleted).ToList();
            return paintings == null
                ? new ErrorDataResult<List<Painting>>(PaintingConstants.DataNotGet)
                : new SuccessDataResult<List<Painting>>(paintings, PaintingConstants.DataGet);
        }

        public IDataResult<List<Painting>> GetAllByDestroyState(bool state)
        {
            List<Painting> paintings = _paintingDal.GetAll(p => p.IsDestroyed == state && !p.IsDeleted).ToList();
            return paintings == null
                ? new ErrorDataResult<List<Painting>>(PaintingConstants.DataNotGet)
                : new SuccessDataResult<List<Painting>>(paintings, PaintingConstants.DataGet);
        }

        public IDataResult<List<Painting>> GetAllByDimension(Guid dimensionId)
        {
            IDataResult<Dimension> dimension = _facadeService.DimensionService().GetById(dimensionId);
            if (!dimension.Success)
                return new ErrorDataResult<List<Painting>>(dimension.Message);

            List<Painting> paintings = _paintingDal.GetAll(p => p.DimensionsId == dimensionId && !p.IsDeleted).ToList();
            return paintings == null
                ? new ErrorDataResult<List<Painting>>(PaintingConstants.DataNotGet)
                : new SuccessDataResult<List<Painting>>(paintings, PaintingConstants.DataGet);
        }

        public IDataResult<List<Painting>> GetAllByEMFile(Guid eMFileId)
        {
            IDataResult<EMaterialFile> eMFile = _facadeService.EMaterialFileService().GetById(eMFileId);
            if (!eMFile.Success)
                return new ErrorDataResult<List<Painting>>(eMFile.Message);

            List<Painting> paintings = _paintingDal.GetAll(p => p.EMaterialFilesId == eMFileId && !p.IsDeleted).ToList();
            return paintings == null
                ? new ErrorDataResult<List<Painting>>(PaintingConstants.DataNotGet)
                : new SuccessDataResult<List<Painting>>(paintings, PaintingConstants.DataGet);
        }

        public IDataResult<List<Painting>> GetAllByFilter(Expression<Func<Painting, bool>>? filter = null)
        {
            return new SuccessDataResult<List<Painting>>(_paintingDal.GetAll(filter).ToList(), PaintingConstants.DataGet);
        }

        public IDataResult<List<Painting>> GetAllByIds(Guid[] ids)
        {
            List<Painting> paintings = _paintingDal.GetAll(p => ids.Contains(p.Id) && !p.IsDeleted).ToList();
            return paintings == null
                ? new ErrorDataResult<List<Painting>>(PaintingConstants.DataNotGet)
                : new SuccessDataResult<List<Painting>>(paintings, PaintingConstants.DataGet);
        }

        public IDataResult<List<Painting>> GetAllByName(string name)
        {
            List<Painting> paintings = _paintingDal.GetAll(p => p.Name.Contains(name) && !p.IsDeleted).ToList();
            return paintings == null
                ? new ErrorDataResult<List<Painting>>(PaintingConstants.DataNotGet)
                : new SuccessDataResult<List<Painting>>(paintings, PaintingConstants.DataGet);
        }

        public IDataResult<List<Painting>> GetAllByOwnerId(Guid ownerId)
        {
            IDataResult<OtherPeople> owner = _facadeService.OtherPeopleService().GetById(ownerId);
            if (!owner.Success)
                return new ErrorDataResult<List<Painting>>(owner.Message);

            List<Painting> paintings = _paintingDal.GetAll(p => p.Owner == owner && !p.IsDeleted).ToList();
            return paintings == null
                ? new ErrorDataResult<List<Painting>>(PaintingConstants.DataNotGet)
                : new SuccessDataResult<List<Painting>>(paintings, PaintingConstants.DataGet);
        }

        public IDataResult<List<Painting>> GetAllByOwnersId(Guid[] ownerIds)
        {
            IDataResult<List<OtherPeople>> owners = _facadeService.OtherPeopleService().GetAllByIds(ownerIds);
            if (!owners.Success)
                return new ErrorDataResult<List<Painting>>(owners.Message);

            List<Painting> paintings = _paintingDal.GetAll(p => owners.Data.Contains(p.Owner) && !p.IsDeleted).ToList();
            return paintings == null
                ? new ErrorDataResult<List<Painting>>(PaintingConstants.DataNotGet)
                : new SuccessDataResult<List<Painting>>(paintings, PaintingConstants.DataGet);
        }

        public IDataResult<List<Painting>> GetAllByPrice(decimal minPrice, decimal? maxPrice = null)
        {
            List<Painting> paintings = maxPrice == null
                ? _paintingDal.GetAll(p => p.Price == minPrice && !p.IsDeleted).ToList()
                : _paintingDal.GetAll(p => p.Price >= minPrice && p.Price <= maxPrice && !p.IsDeleted).ToList();

            return paintings == null
                ? new ErrorDataResult<List<Painting>>(PaintingConstants.DataNotGet)
                : new SuccessDataResult<List<Painting>>(paintings, PaintingConstants.DataGet);
        }

        public IDataResult<List<Painting>> GetAllBySecret()
        {
            return new SuccessDataResult<List<Painting>>(_paintingDal.GetAll(p => p.IsDeleted).ToList(), PaintingConstants.DataGet);
        }

        public IDataResult<List<Painting>> GetAllByTechnicalPlaceholder(Guid technicalPlaceholderId)
        {
            IDataResult<TechnicalPlaceholder> techPlaceHolder = _facadeService.TechnicalPlaceholderService().GetById(technicalPlaceholderId);
            if (!techPlaceHolder.Success)
                return new ErrorDataResult<List<Painting>>(techPlaceHolder.Message);

            List<Painting> paintings = _paintingDal.GetAll(p => p.TechnicalPlaceholdersId == technicalPlaceholderId && !p.IsDeleted).ToList();
            return paintings == null
                ? new ErrorDataResult<List<Painting>>(PaintingConstants.DataNotGet)
                : new SuccessDataResult<List<Painting>>(paintings, PaintingConstants.DataGet);
        }

        public IDataResult<List<Painting>> GetAllByTitle(string title)
        {
            List<Painting> paintings = _paintingDal.GetAll(p => p.Title.Contains(title) && !p.IsDeleted).ToList();
            return paintings == null
                ? new ErrorDataResult<List<Painting>>(PaintingConstants.DataNotGet)
                : new SuccessDataResult<List<Painting>>(paintings, PaintingConstants.DataGet);
        }

        public IDataResult<Painting> GetById(Guid id)
        {
            Painting painting = _paintingDal.Get(p => p.Id == id);
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
