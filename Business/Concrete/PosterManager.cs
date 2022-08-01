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
    public class PosterManager : IPosterService
    {

        private readonly IPosterDal _posterDal;
        private readonly IFacadeService _facadeService;

        public PosterManager(IPosterDal posterDal, IFacadeService facadeService)
        {
            _posterDal = posterDal;
            _facadeService = facadeService;
        }

        [ValidationAspect(typeof(PosterValidator))]
        public IResult Add(Poster poster)
        {
            IResult result = BusinessRules.Run(PosterControlDB(poster));
            if (result != null)
                return result;

            poster.IsDeleted = false;
            _posterDal.Add(poster);
            return new SuccessResult(PosterConstants.AddSuccess);
        }

        public IResult Delete(Guid id)
        {
            Poster poster = _posterDal.Get(p => p.Id == id);
            if (poster == null)
                return new ErrorResult(PosterConstants.NotMatch);

            _posterDal.Delete(poster);
            return new SuccessResult(PosterConstants.EfDeletedSuccsess);
        }

        public IResult ShadowDelete(Guid id)
        {
            Poster poster = _posterDal.Get(p => p.Id == id && !p.IsDeleted);
            if (poster == null)
                return new ErrorResult(PosterConstants.NotMatch);

            poster.IsDeleted = true;
            _posterDal.Update(poster);
            return new SuccessResult(PosterConstants.EfDeletedSuccsess);
        }

        [ValidationAspect(typeof(PosterValidator))]
        public IResult Update(Poster poster)
        {
            IResult result = BusinessRules.Run(PosterControlDB(poster));
            if (result != null)
                return result;

            poster.IsDeleted = false;
            _posterDal.Update(poster);
            return new SuccessResult(PosterConstants.UpdateSuccess);
        }

        public IDataResult<List<Poster>> GetAll()
        {
            return new SuccessDataResult<List<Poster>>(_posterDal.GetAll(p => !p.IsDeleted).ToList(), PosterConstants.DataGet);
        }

        public IDataResult<List<Poster>> GetAllByCategories(int[] categoriesId)
        {
            IDataResult<List<Category>> categories = _facadeService.CategoryService().GetAllByIds(categoriesId);
            if (!categories.Success)
                return new ErrorDataResult<List<Poster>>(categories.Message);

            List<Poster> Posters = _posterDal.GetAll(p => p.Categories.ToList() == categories.Data.ToList() && !p.IsDeleted).ToList();
            return Posters == null
                ? new ErrorDataResult<List<Poster>>(PosterConstants.DataNotGet)
                : new SuccessDataResult<List<Poster>>(Posters, PosterConstants.DataGet);
        }

        public IDataResult<List<Poster>> GetAllByDescriptionFinder(string finderString)
        {
            List<Poster> Posters = _posterDal.GetAll(p => p.Description.Contains(finderString) && !p.IsDeleted).ToList();
            return Posters == null
                ? new ErrorDataResult<List<Poster>>(PosterConstants.DataNotGet)
                : new SuccessDataResult<List<Poster>>(Posters, PosterConstants.DataGet);
        }

        public IDataResult<List<Poster>> GetAllByDestroyState(bool state)
        {
            List<Poster> Posters = _posterDal.GetAll(p => p.IsDestroyed == state && !p.IsDeleted).ToList();
            return Posters == null
                ? new ErrorDataResult<List<Poster>>(PosterConstants.DataNotGet)
                : new SuccessDataResult<List<Poster>>(Posters, PosterConstants.DataGet);
        }

        public IDataResult<List<Poster>> GetAllByDimension(Guid dimensionId)
        {
            IDataResult<Dimension> dimension = _facadeService.DimensionService().GetById(dimensionId);
            if (!dimension.Success)
                return new ErrorDataResult<List<Poster>>(dimension.Message);

            List<Poster> Posters = _posterDal.GetAll(p => p.DimensionsId == dimensionId && !p.IsDeleted).ToList();
            return Posters == null
                ? new ErrorDataResult<List<Poster>>(PosterConstants.DataNotGet)
                : new SuccessDataResult<List<Poster>>(Posters, PosterConstants.DataGet);
        }

        public IDataResult<List<Poster>> GetAllByEMFile(Guid eMFileId)
        {
            IDataResult<EMaterialFile> eMFile = _facadeService.EMaterialFileService().GetById(eMFileId);
            if (!eMFile.Success)
                return new ErrorDataResult<List<Poster>>(eMFile.Message);

            List<Poster> Posters = _posterDal.GetAll(p => p.EMaterialFilesId == eMFileId && !p.IsDeleted).ToList();
            return Posters == null
                ? new ErrorDataResult<List<Poster>>(PosterConstants.DataNotGet)
                : new SuccessDataResult<List<Poster>>(Posters, PosterConstants.DataGet);
        }

        public IDataResult<List<Poster>> GetAllByFilter(Expression<Func<Poster, bool>>? filter = null)
        {
            return new SuccessDataResult<List<Poster>>(_posterDal.GetAll(filter).ToList(), PosterConstants.DataGet);
        }

        public IDataResult<List<Poster>> GetAllByIds(Guid[] ids)
        {
            List<Poster> Posters = _posterDal.GetAll(p => ids.Contains(p.Id) && !p.IsDeleted).ToList();
            return Posters == null
                ? new ErrorDataResult<List<Poster>>(PosterConstants.DataNotGet)
                : new SuccessDataResult<List<Poster>>(Posters, PosterConstants.DataGet);
        }

        public IDataResult<List<Poster>> GetAllByName(string name)
        {
            List<Poster> Posters = _posterDal.GetAll(p => p.Name.Contains(name) && !p.IsDeleted).ToList();
            return Posters == null
                ? new ErrorDataResult<List<Poster>>(PosterConstants.DataNotGet)
                : new SuccessDataResult<List<Poster>>(Posters, PosterConstants.DataGet);
        }

        public IDataResult<List<Poster>> GetAllByOwnerId(Guid ownerId)
        {
            IDataResult<OtherPeople> owner = _facadeService.OtherPeopleService().GetById(ownerId);
            if (!owner.Success)
                return new ErrorDataResult<List<Poster>>(owner.Message);

            List<Poster> Posters = _posterDal.GetAll(p => p.Owner == owner && !p.IsDeleted).ToList();
            return Posters == null
                ? new ErrorDataResult<List<Poster>>(PosterConstants.DataNotGet)
                : new SuccessDataResult<List<Poster>>(Posters, PosterConstants.DataGet);
        }

        public IDataResult<List<Poster>> GetAllByOwnersId(Guid[] ownerIds)
        {
            IDataResult<List<OtherPeople>> owners = _facadeService.OtherPeopleService().GetAllByIds(ownerIds);
            if (!owners.Success)
                return new ErrorDataResult<List<Poster>>(owners.Message);

            List<Poster> Posters = _posterDal.GetAll(p => owners.Data.Contains(p.Owner) && !p.IsDeleted).ToList();
            return Posters == null
                ? new ErrorDataResult<List<Poster>>(PosterConstants.DataNotGet)
                : new SuccessDataResult<List<Poster>>(Posters, PosterConstants.DataGet);
        }

        public IDataResult<List<Poster>> GetAllByPrice(decimal minPrice, decimal? maxPrice = null)
        {
            List<Poster> Posters = maxPrice == null
                ? _posterDal.GetAll(p => p.Price == minPrice && !p.IsDeleted).ToList()
                : _posterDal.GetAll(p => p.Price >= minPrice && p.Price <= maxPrice && !p.IsDeleted).ToList();

            return Posters == null
                ? new ErrorDataResult<List<Poster>>(PosterConstants.DataNotGet)
                : new SuccessDataResult<List<Poster>>(Posters, PosterConstants.DataGet);
        }

        public IDataResult<List<Poster>> GetAllBySecret()
        {
            return new SuccessDataResult<List<Poster>>(_posterDal.GetAll(p => p.IsDeleted).ToList(), PosterConstants.DataGet);
        }

        public IDataResult<List<Poster>> GetAllByTechnicalPlaceholder(Guid technicalPlaceholderId)
        {
            IDataResult<TechnicalPlaceholder> techPlaceHolder = _facadeService.TechnicalPlaceholderService().GetById(technicalPlaceholderId);
            if (!techPlaceHolder.Success)
                return new ErrorDataResult<List<Poster>>(techPlaceHolder.Message);

            List<Poster> Posters = _posterDal.GetAll(p => p.TechnicalPlaceholdersId == technicalPlaceholderId && !p.IsDeleted).ToList();
            return Posters == null
                ? new ErrorDataResult<List<Poster>>(PosterConstants.DataNotGet)
                : new SuccessDataResult<List<Poster>>(Posters, PosterConstants.DataGet);
        }

        public IDataResult<List<Poster>> GetAllByTitle(string title)
        {
            List<Poster> Posters = _posterDal.GetAll(p => p.Title.Contains(title) && !p.IsDeleted).ToList();
            return Posters == null
                ? new ErrorDataResult<List<Poster>>(PosterConstants.DataNotGet)
                : new SuccessDataResult<List<Poster>>(Posters, PosterConstants.DataGet);
        }

        public IDataResult<Poster> GetById(Guid id)
        {
            Poster Poster = _posterDal.Get(p => p.Id == id);
            return Poster == null
                ? new ErrorDataResult<Poster>(PosterConstants.DataNotGet)
                : new SuccessDataResult<Poster>(Poster, PosterConstants.DataGet);
        }

        public IDataResult<Poster> GetByImageId(Guid imageId)
        {
            IDataResult<Image> image = _facadeService.ImageService().GetById(imageId);
            if (!image.Success)
                return new ErrorDataResult<Poster>(image.Message);

            Poster Poster = _posterDal.Get(p => p.ImageId == imageId && !p.IsDeleted);
            return Poster == null
                ? new ErrorDataResult<Poster>(PosterConstants.DataNotGet)
                : new SuccessDataResult<Poster>(Poster, PosterConstants.DataGet);
        }

        public IDataResult<Poster> GetByStock(Guid stockId)
        {
            IDataResult<Stock> stock = _facadeService.StockService().GetById(stockId);
            if (!stock.Success)
                return new ErrorDataResult<Poster>(stock.Message);

            Poster Poster = _posterDal.Get(p => p.StockId == stockId && !p.IsDeleted);
            return Poster == null
                ? new ErrorDataResult<Poster>(PosterConstants.DataNotGet)
                : new SuccessDataResult<Poster>(Poster, PosterConstants.DataGet);
        }

        public IDataResult<byte?> GetSecretLevel(Guid id)
        {
            byte? sLevel = _posterDal.Get(p => p.Id == id && !p.IsDeleted).SecretLevel;
            return sLevel == null
                ? new ErrorDataResult<byte?>(PosterConstants.DataNotGet)
                : new SuccessDataResult<byte?>(sLevel, PosterConstants.DataGet);
        }

        public IDataResult<byte> GetState(Guid id)
        {
            return new SuccessDataResult<byte>(_posterDal.Get(p => p.Id == id).State, PosterConstants.DataGet);
        }

        private IResult PosterControlDB(Poster poster)
        {
            bool posterControl = _posterDal.Get(o =>

               o.Name == poster.Name
            && o.Title == poster.Title
            && o.Description == poster.Description
            && o.Price == poster.Price
            && o.StockId == poster.StockId
            && o.State == poster.State
            && o.Owner == poster.Owner
            ) != null;

            if (posterControl)
                return new ErrorResult(PosterConstants.AlreadyExists);
            return new SuccessResult();
        }
    }
}
