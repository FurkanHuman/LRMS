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
    public class NewsPaperManager : INewsPaperService
    {
        private readonly INewsPaperDal _newsPaperDal;
        private readonly IFacadeService _facadeService;

        public NewsPaperManager(INewsPaperDal newsPaperDal, IFacadeService facadeService)
        {
            _newsPaperDal = newsPaperDal;
            _facadeService = facadeService;
        }

        [ValidationAspect(typeof(NewsPaperValidator))]
        public IResult Add(NewsPaper newsPaper)
        {
            IResult result = BusinessRules.Run(CheckIfNewsPaperControl(newsPaper));
            if (result != null)
                return result;

            newsPaper.IsDeleted = false;
            _newsPaperDal.Add(newsPaper);
            return new SuccessResult(NewsPaperConstants.AddSuccess);
        }

        public IResult Delete(Guid id)
        {
            NewsPaper newsPaper = _newsPaperDal.Get(np => np.Id == id);
            if (newsPaper == null)
                return new ErrorResult(NewsPaperConstants.NotMatch);

            _newsPaperDal.Delete(newsPaper);
            return new SuccessResult(NewsPaperConstants.DeleteSuccess);
        }

        public IResult ShadowDelete(Guid id)
        {
            NewsPaper newsPaper = _newsPaperDal.Get(np => np.Id == id && !np.IsDeleted);
            if (newsPaper == null)
                return new ErrorResult(NewsPaperConstants.NotMatch);

            newsPaper.IsDeleted = true;
            _newsPaperDal.Update(newsPaper);
            return new SuccessResult(NewsPaperConstants.EfDeletedSuccsess);
        }

        [ValidationAspect(typeof(NewsPaperValidator))]
        public IResult Update(NewsPaper newsPaper)
        {
            IResult result = BusinessRules.Run(CheckIfNewsPaperControl(newsPaper));
            if (result != null)
                return result;

            newsPaper.IsDeleted = false;
            _newsPaperDal.Update(newsPaper);
            return new SuccessResult(NewsPaperConstants.UpdateSuccess);
        }

        public IDataResult<IList<NewsPaper>> GetAll()
        {
            return new SuccessDataResult<IList<NewsPaper>>(_newsPaperDal.GetAll(np => !np.IsDeleted), NewsPaperConstants.DataGet);
        }

        public IDataResult<IList<NewsPaper>> GetAllByCategories(int[] categoriesId)
        {
            IDataResult<IList<Category>> categories = _facadeService.CategoryService().GetAllByIds(categoriesId);
            if (!categories.Success)
                return new ErrorDataResult<IList<NewsPaper>>(categories.Message);

            IList<NewsPaper> newsPapers = _newsPaperDal.GetAll(np => np.Categories == categories.Data && !np.IsDeleted);
            return newsPapers == null
                ? new ErrorDataResult<IList<NewsPaper>>(NewsPaperConstants.DataNotGet)
                : new SuccessDataResult<IList<NewsPaper>>(newsPapers, NewsPaperConstants.DataGet);
        }

        public IDataResult<IList<NewsPaper>> GetAllByCommunication(Guid communicationId)
        {
            IDataResult<Edition> editionByCommunication = _facadeService.EditionService().GetByCommunicationId(communicationId);
            if (!editionByCommunication.Success)
                return new ErrorDataResult<IList<NewsPaper>>(editionByCommunication.Message);

            IList<NewsPaper> newsPapers = _newsPaperDal.GetAll(np => np.EditionId == editionByCommunication.Data.Id && !np.IsDeleted);
            return newsPapers == null
                ? new ErrorDataResult<IList<NewsPaper>>(NewsPaperConstants.DataNotGet)
                : new SuccessDataResult<IList<NewsPaper>>(newsPapers, NewsPaperConstants.DataGet);
        }

        public IDataResult<IList<NewsPaper>> GetAllByCoverCap(byte coverCapNum)
        {
            IDataResult<CoverCap> CoverCap = _facadeService.CoverCapService().GetById(coverCapNum);
            if (!CoverCap.Success)
                return new ErrorDataResult<IList<NewsPaper>>(CoverCap.Message);

            IList<NewsPaper> newsPapers = _newsPaperDal.GetAll(np => np.CoverCapId == coverCapNum && !np.IsDeleted);
            return newsPapers == null
                ? new ErrorDataResult<IList<NewsPaper>>(NewsPaperConstants.DataNotGet)
                : new SuccessDataResult<IList<NewsPaper>>(newsPapers, NewsPaperConstants.DataGet);
        }

        public IDataResult<IList<NewsPaper>> GetAllByDate(DateTime date)
        {
            IList<NewsPaper> newsPapers = _newsPaperDal.GetAll(np => np.Date == date && !np.IsDeleted);
            return newsPapers == null
                ? new ErrorDataResult<IList<NewsPaper>>(NewsPaperConstants.DataNotGet)
                : new SuccessDataResult<IList<NewsPaper>>(newsPapers, NewsPaperConstants.DataGet);
        }

        public IDataResult<IList<NewsPaper>> GetAllByDescriptionFinder(string finderString)
        {
            IList<NewsPaper> newsPapers = _newsPaperDal.GetAll(np => np.Description.Contains(finderString) && !np.IsDeleted);
            return newsPapers == null
                ? new ErrorDataResult<IList<NewsPaper>>(NewsPaperConstants.DataNotGet)
                : new SuccessDataResult<IList<NewsPaper>>(newsPapers, NewsPaperConstants.DataGet);
        }

        public IDataResult<IList<NewsPaper>> GetAllByDimension(Guid dimensionId)
        {
            IDataResult<Dimension> dimmension = _facadeService.DimensionService().GetById(dimensionId);
            if (!dimmension.Success)
                return new ErrorDataResult<IList<NewsPaper>>(dimmension.Message);

            IList<NewsPaper> newsPapers = _newsPaperDal.GetAll(np => np.DimensionsId == dimensionId && !np.IsDeleted);
            return newsPapers == null
                ? new ErrorDataResult<IList<NewsPaper>>(NewsPaperConstants.DataNotGet)
                : new SuccessDataResult<IList<NewsPaper>>(newsPapers, NewsPaperConstants.DataGet);
        }

        public IDataResult<IList<NewsPaper>> GetAllByDirector(Guid directorId)
        {
            IDataResult<Director> director = _facadeService.DirectorService().GetById(directorId);
            if (!director.Success)
                return new ErrorDataResult<IList<NewsPaper>>(director.Message);

            IList<NewsPaper> newsPapers = _newsPaperDal.GetAll(np => np.DirectorId == directorId && !np.IsDeleted);
            return newsPapers == null
                ? new ErrorDataResult<IList<NewsPaper>>(NewsPaperConstants.DataNotGet)
                : new SuccessDataResult<IList<NewsPaper>>(newsPapers, NewsPaperConstants.DataGet);
        }

        public IDataResult<IList<NewsPaper>> GetAllByEdition(Guid editionId)
        {
            IDataResult<Edition> edition = _facadeService.EditionService().GetById(editionId);
            if (!edition.Success)
                return new ErrorDataResult<IList<NewsPaper>>(edition.Message);

            IList<NewsPaper> newsPapers = _newsPaperDal.GetAll(np => np.EditionId == editionId && !np.IsDeleted);
            return newsPapers == null
                ? new ErrorDataResult<IList<NewsPaper>>(NewsPaperConstants.DataNotGet)
                : new SuccessDataResult<IList<NewsPaper>>(newsPapers, NewsPaperConstants.DataGet);
        }

        public IDataResult<IList<NewsPaper>> GetAllByEditor(Guid editorId)
        {
            IDataResult<Editor> editor = _facadeService.EditorService().GetById(editorId);
            if (!editor.Success)
                return new ErrorDataResult<IList<NewsPaper>>(editor.Message);

            IList<NewsPaper> newsPapers = _newsPaperDal.GetAll(np => np.EditorId == editorId && !np.IsDeleted);
            return newsPapers == null
                ? new ErrorDataResult<IList<NewsPaper>>(NewsPaperConstants.DataNotGet)
                : new SuccessDataResult<IList<NewsPaper>>(newsPapers, NewsPaperConstants.DataGet);
        }

        public IDataResult<IList<NewsPaper>> GetAllByEMFile(Guid eMFileId)
        {
            IDataResult<EMaterialFile> eMFile = _facadeService.EMaterialFileService().GetById(eMFileId);
            if (!eMFile.Success)
                return new ErrorDataResult<IList<NewsPaper>>(eMFile.Message);

            IList<NewsPaper> newsPapers = _newsPaperDal.GetAll(np => np.EMaterialFilesId == eMFileId && !np.IsDeleted);
            return newsPapers == null
                ? new ErrorDataResult<IList<NewsPaper>>(NewsPaperConstants.DataNotGet)
                : new SuccessDataResult<IList<NewsPaper>>(newsPapers, NewsPaperConstants.DataGet);
        }

        public IDataResult<IList<NewsPaper>> GetAllByFilter(Expression<Func<NewsPaper, bool>>? filter = null)
        {
            return new SuccessDataResult<IList<NewsPaper>>(_newsPaperDal.GetAll(filter), NewsPaperConstants.DataGet);
        }

        public IDataResult<IList<NewsPaper>> GetAllByGraphicDesign(Guid graphicDesignId)
        {
            IDataResult<GraphicDesigner> graphicDesing = _facadeService.GraphicDesignerService().GetById(graphicDesignId);
            if (!graphicDesing.Success)
                return new ErrorDataResult<IList<NewsPaper>>(graphicDesing.Message);

            IList<NewsPaper> newsPapers = _newsPaperDal.GetAll(np => np.GraphicDesignId == graphicDesignId && !np.IsDeleted);
            return newsPapers == null
                ? new ErrorDataResult<IList<NewsPaper>>(NewsPaperConstants.DataNotGet)
                : new SuccessDataResult<IList<NewsPaper>>(newsPapers, NewsPaperConstants.DataGet);
        }

        public IDataResult<IList<NewsPaper>> GetAllByGraphicDirector(Guid graphicDirectorId)
        {
            IDataResult<GraphicDirector> gDirector = _facadeService.GraphicDirectorService().GetById(graphicDirectorId);
            if (!gDirector.Success)
                return new ErrorDataResult<IList<NewsPaper>>(gDirector.Message);

            IList<NewsPaper> newsPapers = _newsPaperDal.GetAll(np => np.GraphicDirectorId == graphicDirectorId && !np.IsDeleted);
            return newsPapers == null
                ? new ErrorDataResult<IList<NewsPaper>>(NewsPaperConstants.DataNotGet)
                : new SuccessDataResult<IList<NewsPaper>>(newsPapers, NewsPaperConstants.DataGet);
        }

        public IDataResult<IList<NewsPaper>> GetAllByIds(Guid[] ids)
        {
            IList<NewsPaper> newsPapers = _newsPaperDal.GetAll(np => ids.Contains(np.Id) && !np.IsDeleted);
            _facadeService.CounterService().Count(newsPapers);
            return newsPapers == null
                ? new ErrorDataResult<IList<NewsPaper>>(NewsPaperConstants.DataNotGet)
                : new SuccessDataResult<IList<NewsPaper>>(newsPapers, NewsPaperConstants.DataGet);
        }

        public IDataResult<IList<NewsPaper>> GetAllByInterpreter(Guid interpreterId)
        {
            IDataResult<Interpreters> interpreter = _facadeService.InterpretersService().GetById(interpreterId);
            if (!interpreter.Success)
                return new ErrorDataResult<IList<NewsPaper>>(interpreter.Message);

            IList<NewsPaper> newsPapers = _newsPaperDal.GetAll(np => np.InterpretersId == interpreterId && !np.IsDeleted);
            return newsPapers == null
                ? new ErrorDataResult<IList<NewsPaper>>(NewsPaperConstants.DataNotGet)
                : new SuccessDataResult<IList<NewsPaper>>(newsPapers, NewsPaperConstants.DataGet);
        }

        public IDataResult<IList<NewsPaper>> GetAllByName(string name)
        {
            IList<NewsPaper> newsPapers = _newsPaperDal.GetAll(np => np.Name.Contains(name) && !np.IsDeleted);
            return newsPapers == null
                ? new ErrorDataResult<IList<NewsPaper>>(NewsPaperConstants.DataNotGet)
                : new SuccessDataResult<IList<NewsPaper>>(newsPapers, NewsPaperConstants.DataGet);
        }

        public IDataResult<IList<NewsPaper>> GetAllByNewsPaperName(string newPaperName)
        {
            IList<NewsPaper> newsPapers = _newsPaperDal.GetAll(np => np.NewsPaperName.Contains(newPaperName) && !np.IsDeleted);
            return newsPapers == null
                ? new ErrorDataResult<IList<NewsPaper>>(NewsPaperConstants.DataNotGet)
                : new SuccessDataResult<IList<NewsPaper>>(newsPapers, NewsPaperConstants.DataGet);
        }

        public IDataResult<IList<NewsPaper>> GetAllByNewsPaperNumber(uint number)
        {
            IList<NewsPaper> newsPapers = _newsPaperDal.GetAll(np => np.Number == number && !np.IsDeleted);
            return newsPapers == null
                ? new ErrorDataResult<IList<NewsPaper>>(NewsPaperConstants.DataNotGet)
                : new SuccessDataResult<IList<NewsPaper>>(newsPapers, NewsPaperConstants.DataGet);
        }

        public IDataResult<IList<NewsPaper>> GetAllByPrice(decimal minPrice, decimal? maxPrice = null)
        {
            IList<NewsPaper> newsPapers = maxPrice == null
                ? _newsPaperDal.GetAll(np => np.Price == minPrice && !np.IsDeleted)
                : _newsPaperDal.GetAll(np => np.Price >= minPrice && np.Price <= maxPrice && !np.IsDeleted);

            return newsPapers == null
                ? new ErrorDataResult<IList<NewsPaper>>(NewsPaperConstants.DataNotGet)
                : new SuccessDataResult<IList<NewsPaper>>(newsPapers, NewsPaperConstants.DataGet);
        }

        public IDataResult<IList<NewsPaper>> GetAllByPublisher(Guid publisherId)
        {
            IDataResult<Edition> editionOfPublisher = _facadeService.EditionService().GetByPublisherId(publisherId);
            if (!editionOfPublisher.Success)
                return new ErrorDataResult<IList<NewsPaper>>(editionOfPublisher.Message);

            IList<NewsPaper> newsPapers = _newsPaperDal.GetAll(np => np.EditionId == editionOfPublisher.Data.Id && !np.IsDeleted);
            return newsPapers == null
                ? new ErrorDataResult<IList<NewsPaper>>(NewsPaperConstants.DataNotGet)
                : new SuccessDataResult<IList<NewsPaper>>(newsPapers, NewsPaperConstants.DataGet);
        }

        public IDataResult<IList<NewsPaper>> GetAllByRedaction(Guid redactionId)
        {
            IDataResult<Redaction> redaction = _facadeService.RedactionService().GetById(redactionId);
            if (!redaction.Success)
                return new ErrorDataResult<IList<NewsPaper>>(redaction.Message);

            IList<NewsPaper> newsPapers = _newsPaperDal.GetAll(np => np.RedactionId == redactionId && !np.IsDeleted);
            return newsPapers == null
                ? new ErrorDataResult<IList<NewsPaper>>(NewsPaperConstants.DataNotGet)
                : new SuccessDataResult<IList<NewsPaper>>(newsPapers, NewsPaperConstants.DataGet);
        }

        public IDataResult<IList<NewsPaper>> GetAllByIsDeleted()
        {
            return new SuccessDataResult<IList<NewsPaper>>(_newsPaperDal.GetAll(np => np.IsDeleted), NewsPaperConstants.DataGet);
        }

        public IDataResult<IList<NewsPaper>> GetAllByTechnicalNumber(Guid technicalNumberId)
        {
            IDataResult<TechnicalNumber> techNumber = _facadeService.TechnicalNumberService().GetById(technicalNumberId);
            if (!techNumber.Success)
                return new ErrorDataResult<IList<NewsPaper>>(techNumber.Message);

            IList<NewsPaper> newsPapers = _newsPaperDal.GetAll(np => np.TechnicalNumberId == technicalNumberId && !np.IsDeleted);
            return newsPapers == null
                ? new ErrorDataResult<IList<NewsPaper>>(NewsPaperConstants.DataNotGet)
                : new SuccessDataResult<IList<NewsPaper>>(newsPapers, NewsPaperConstants.DataGet);
        }

        public IDataResult<IList<NewsPaper>> GetAllByTechnicalPlaceholder(Guid technicalPlaceholderId)
        {
            IDataResult<TechnicalPlaceholder> techPlaceHolder = _facadeService.TechnicalPlaceholderService().GetById(technicalPlaceholderId);
            if (!techPlaceHolder.Success)
                return new ErrorDataResult<IList<NewsPaper>>(techPlaceHolder.Message);

            IList<NewsPaper> newsPapers = _newsPaperDal.GetAll(np => np.TechnicalNumberId == technicalPlaceholderId && !np.IsDeleted);
            return newsPapers == null
                ? new ErrorDataResult<IList<NewsPaper>>(NewsPaperConstants.DataNotGet)
                : new SuccessDataResult<IList<NewsPaper>>(newsPapers, NewsPaperConstants.DataGet);
        }

        public IDataResult<IList<NewsPaper>> GetAllByTitle(string title)
        {
            IList<NewsPaper> newsPapers = _newsPaperDal.GetAll(np => np.Title.Contains(title) && !np.IsDeleted);
            return newsPapers == null
                ? new ErrorDataResult<IList<NewsPaper>>(NewsPaperConstants.DataNotGet)
                : new SuccessDataResult<IList<NewsPaper>>(newsPapers, NewsPaperConstants.DataGet);
        }

        public IDataResult<IList<NewsPaper>> GetAllByWriter(Guid writerId)
        {
            IDataResult<Writer> writer = _facadeService.WriterService().GetById(writerId);
            if (!writer.Success)
                return new ErrorDataResult<IList<NewsPaper>>(writer.Message);

            IList<NewsPaper> newsPapers = _newsPaperDal.GetAll(np => np.WriterId == writerId && !np.IsDeleted);
            return newsPapers == null
                ? new ErrorDataResult<IList<NewsPaper>>(NewsPaperConstants.DataNotGet)
                : new SuccessDataResult<IList<NewsPaper>>(newsPapers, NewsPaperConstants.DataGet);
        }

        public IDataResult<NewsPaper> GetByCoverImage(Guid cImageId)
        {
            IDataResult<Image> coverImage = _facadeService.ImageService().GetById(cImageId);
            if (!coverImage.Success)
                return new ErrorDataResult<NewsPaper>(coverImage.Message);

            NewsPaper newsPaper = _newsPaperDal.Get(np => np.CoverImageId == cImageId && !np.IsDeleted);
            return newsPaper == null
                ? new ErrorDataResult<NewsPaper>(NewsPaperConstants.DataNotGet)
                : new SuccessDataResult<NewsPaper>(newsPaper, NewsPaperConstants.DataGet);
        }

        public IDataResult<NewsPaper> GetById(Guid id)
        {
            NewsPaper newsPaper = _newsPaperDal.Get(np => np.Id == id && !np.IsDeleted);
            _facadeService.CounterService().Count(newsPaper);
            return newsPaper == null
                ? new ErrorDataResult<NewsPaper>(NewsPaperConstants.DataNotGet)
                : new SuccessDataResult<NewsPaper>(newsPaper, NewsPaperConstants.DataGet);
        }

        public IDataResult<NewsPaper> GetByImage(Guid imageId)
        {
            IDataResult<Image> image = _facadeService.ImageService().GetById(imageId);
            if (!image.Success)
                return new ErrorDataResult<NewsPaper>(image.Message);

            NewsPaper newsPaper = _newsPaperDal.Get(np => np.ImageId == imageId && !np.IsDeleted);
            return newsPaper == null
                ? new ErrorDataResult<NewsPaper>(NewsPaperConstants.DataNotGet)
                : new SuccessDataResult<NewsPaper>(newsPaper, NewsPaperConstants.DataGet);
        }

        public IDataResult<NewsPaper> GetByStock(Guid stockId)
        {
            IDataResult<Stock> stock = _facadeService.StockService().GetById(stockId);
            if (stock.Success)
                return new ErrorDataResult<NewsPaper>(stock.Message);

            NewsPaper newsPaper = _newsPaperDal.Get(np => np.StockId == stockId && !np.IsDeleted);
            _facadeService.CounterService().Count(newsPaper);
            return newsPaper == null
                ? new ErrorDataResult<NewsPaper>(NewsPaperConstants.DataNotGet)
                : new SuccessDataResult<NewsPaper>(newsPaper, NewsPaperConstants.DataGet);
        }

        public IDataResult<byte?> GetSecretLevel(Guid id)
        {
            byte? sLevel = _newsPaperDal.Get(np => np.Id == id && !np.IsDeleted).SecretLevel;
            return sLevel == null
                ? new ErrorDataResult<byte?>(NewsPaperConstants.DataNotGet)
                : new SuccessDataResult<byte?>(sLevel, NewsPaperConstants.DataGet);
        }

        public IDataResult<byte> GetState(Guid id)
        {
            return new ErrorDataResult<byte>(_newsPaperDal.Get(np => np.Id == id).State, NewsPaperConstants.DataGet);
        }

        private IResult CheckIfNewsPaperControl(NewsPaper newsPaper)
        {

            bool newsPaperControl = _newsPaperDal.Get(np =>
                np.Name == newsPaper.Name
             && np.Title == newsPaper.Title
             && np.Description.Contains(newsPaper.Description)
             && np.CategoryId == newsPaper.CategoryId
             && np.TechnicalPlaceholdersId == newsPaper.TechnicalPlaceholdersId
             && np.DimensionsId == newsPaper.DimensionsId
             && np.EMaterialFilesId == newsPaper.EMaterialFilesId
             && np.State == newsPaper.State
             && np.CoverCapId == newsPaper.CoverCapId
             && np.CoverImageId == newsPaper.CoverImageId
             && np.WriterId == newsPaper.WriterId
             && np.EditorId == newsPaper.EditorId
             && np.TechnicalNumberId == newsPaper.TechnicalNumberId
             && np.EditionId == newsPaper.EditionId
             && np.NewsPaperName == newsPaper.NewsPaperName
             && np.Number == newsPaper.Number
             && np.ImageId == newsPaper.ImageId
             && np.Date == newsPaper.Date
             && np.IsDestroyed == newsPaper.IsDestroyed

                ) != null;

            if (newsPaperControl)
                return new ErrorResult(NewsPaperConstants.AlreadyExists);
            return new SuccessResult();
        }
    }
}
