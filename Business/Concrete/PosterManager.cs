namespace Business.Concrete
{
    public class PosterManager : IPosterService
    {

        private readonly IPosterDal _posterDal;
        private readonly IFacadeService _facadeService;

        public PosterManager(IPosterDal posterDal)
        {
            _posterDal = posterDal;
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

        public IDataResult<IList<Poster>> GetAll()
        {
            return new SuccessDataResult<IList<Poster>>(_posterDal.GetAll(p => !p.IsDeleted), PosterConstants.DataGet);
        }

        public IDataResult<IList<Poster>> GetAllByCategories(int[] categoriesId)
        {
            IDataResult<IList<Category>> categories = _facadeService.CategoryService().GetAllByIds(categoriesId);
            if (!categories.Success)
                return new ErrorDataResult<IList<Poster>>(categories.Message);

            IList<Poster> Posters = _posterDal.GetAll(p => p.Categories == categories.Data && !p.IsDeleted);
            return Posters == null
                ? new ErrorDataResult<IList<Poster>>(PosterConstants.DataNotGet)
                : new SuccessDataResult<IList<Poster>>(Posters, PosterConstants.DataGet);
        }

        public IDataResult<IList<Poster>> GetAllByDescriptionFinder(string finderString)
        {
            IList<Poster> Posters = _posterDal.GetAll(p => p.Description.Contains(finderString) && !p.IsDeleted);
            return Posters == null
                ? new ErrorDataResult<IList<Poster>>(PosterConstants.DataNotGet)
                : new SuccessDataResult<IList<Poster>>(Posters, PosterConstants.DataGet);
        }

        public IDataResult<IList<Poster>> GetAllByDestroyState(bool state)
        {
            IList<Poster> Posters = _posterDal.GetAll(p => p.IsDestroyed == state && !p.IsDeleted);
            return Posters == null
                ? new ErrorDataResult<IList<Poster>>(PosterConstants.DataNotGet)
                : new SuccessDataResult<IList<Poster>>(Posters, PosterConstants.DataGet);
        }

        public IDataResult<IList<Poster>> GetAllByDimension(Guid dimensionId)
        {
            IDataResult<Dimension> dimension = _facadeService.DimensionService().GetById(dimensionId);
            if (!dimension.Success)
                return new ErrorDataResult<IList<Poster>>(dimension.Message);

            IList<Poster> Posters = _posterDal.GetAll(p => p.DimensionsId == dimensionId && !p.IsDeleted);
            return Posters == null
                ? new ErrorDataResult<IList<Poster>>(PosterConstants.DataNotGet)
                : new SuccessDataResult<IList<Poster>>(Posters, PosterConstants.DataGet);
        }

        public IDataResult<IList<Poster>> GetAllByEMFile(Guid eMFileId)
        {
            IDataResult<EMaterialFile> eMFile = _facadeService.EMaterialFileService().GetById(eMFileId);
            if (!eMFile.Success)
                return new ErrorDataResult<IList<Poster>>(eMFile.Message);

            IList<Poster> Posters = _posterDal.GetAll(p => p.EMaterialFilesId == eMFileId && !p.IsDeleted);
            return Posters == null
                ? new ErrorDataResult<IList<Poster>>(PosterConstants.DataNotGet)
                : new SuccessDataResult<IList<Poster>>(Posters, PosterConstants.DataGet);
        }

        public IDataResult<IList<Poster>> GetAllByFilter(Expression<Func<Poster, bool>>? filter = null)
        {
            return new SuccessDataResult<IList<Poster>>(_posterDal.GetAll(filter), PosterConstants.DataGet);
        }

        public IDataResult<IList<Poster>> GetAllByIds(Guid[] ids)
        {
            IList<Poster> posters = _posterDal.GetAll(p => ids.Contains(p.Id) && !p.IsDeleted);
            _facadeService.CounterService().Count(posters);
            return posters == null
                ? new ErrorDataResult<IList<Poster>>(PosterConstants.DataNotGet)
                : new SuccessDataResult<IList<Poster>>(posters, PosterConstants.DataGet);
        }

        public IDataResult<IList<Poster>> GetAllByName(string name)
        {
            IList<Poster> Posters = _posterDal.GetAll(p => p.Name.Contains(name) && !p.IsDeleted);
            return Posters == null
                ? new ErrorDataResult<IList<Poster>>(PosterConstants.DataNotGet)
                : new SuccessDataResult<IList<Poster>>(Posters, PosterConstants.DataGet);
        }

        public IDataResult<IList<Poster>> GetAllByOwnerId(Guid ownerId)
        {
            IDataResult<OtherPeople> owner = _facadeService.OtherPeopleService().GetById(ownerId);
            if (!owner.Success)
                return new ErrorDataResult<IList<Poster>>(owner.Message);

            IList<Poster> Posters = _posterDal.GetAll(p => p.Owner == owner && !p.IsDeleted);
            return Posters == null
                ? new ErrorDataResult<IList<Poster>>(PosterConstants.DataNotGet)
                : new SuccessDataResult<IList<Poster>>(Posters, PosterConstants.DataGet);
        }

        public IDataResult<IList<Poster>> GetAllByOwnersId(Guid[] ownerIds)
        {
            IDataResult<IList<OtherPeople>> owners = _facadeService.OtherPeopleService().GetAllByIds(ownerIds);
            if (!owners.Success)
                return new ErrorDataResult<IList<Poster>>(owners.Message);

            IList<Poster> Posters = _posterDal.GetAll(p => owners.Data.Contains(p.Owner) && !p.IsDeleted);
            return Posters == null
                ? new ErrorDataResult<IList<Poster>>(PosterConstants.DataNotGet)
                : new SuccessDataResult<IList<Poster>>(Posters, PosterConstants.DataGet);
        }

        public IDataResult<IList<Poster>> GetAllByPrice(decimal minPrice, decimal? maxPrice = null)
        {
            IList<Poster> Posters = maxPrice == null
                ? _posterDal.GetAll(p => p.Price == minPrice && !p.IsDeleted)
                : _posterDal.GetAll(p => p.Price >= minPrice && p.Price <= maxPrice && !p.IsDeleted);

            return Posters == null
                ? new ErrorDataResult<IList<Poster>>(PosterConstants.DataNotGet)
                : new SuccessDataResult<IList<Poster>>(Posters, PosterConstants.DataGet);
        }

        public IDataResult<IList<Poster>> GetAllByIsDeleted()
        {
            return new SuccessDataResult<IList<Poster>>(_posterDal.GetAll(p => p.IsDeleted), PosterConstants.DataGet);
        }

        public IDataResult<IList<Poster>> GetAllByTechnicalPlaceholder(Guid technicalPlaceholderId)
        {
            IDataResult<TechnicalPlaceholder> techPlaceHolder = _facadeService.TechnicalPlaceholderService().GetById(technicalPlaceholderId);
            if (!techPlaceHolder.Success)
                return new ErrorDataResult<IList<Poster>>(techPlaceHolder.Message);

            IList<Poster> Posters = _posterDal.GetAll(p => p.TechnicalPlaceholdersId == technicalPlaceholderId && !p.IsDeleted);
            return Posters == null
                ? new ErrorDataResult<IList<Poster>>(PosterConstants.DataNotGet)
                : new SuccessDataResult<IList<Poster>>(Posters, PosterConstants.DataGet);
        }

        public IDataResult<IList<Poster>> GetAllByTitle(string title)
        {
            IList<Poster> Posters = _posterDal.GetAll(p => p.Title.Contains(title) && !p.IsDeleted);
            return Posters == null
                ? new ErrorDataResult<IList<Poster>>(PosterConstants.DataNotGet)
                : new SuccessDataResult<IList<Poster>>(Posters, PosterConstants.DataGet);
        }

        public IDataResult<Poster> GetById(Guid id)
        {
            Poster poster = _posterDal.Get(p => p.Id == id);
            _facadeService.CounterService().Count(poster);
            return poster == null
                ? new ErrorDataResult<Poster>(PosterConstants.DataNotGet)
                : new SuccessDataResult<Poster>(poster, PosterConstants.DataGet);
        }

        public IDataResult<Poster> GetByImageId(Guid imageId)
        {
            IDataResult<Image> image = _facadeService.ImageService().GetById(imageId);
            if (!image.Success)
                return new ErrorDataResult<Poster>(image.Message);

            Poster Poster = _posterDal.Get(p => p.ImageId == imageId && !p.IsDeleted);
            _facadeService.CounterService().Count(Poster);
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
            _facadeService.CounterService().Count(Poster);
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
