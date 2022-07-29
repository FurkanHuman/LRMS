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
    public class NewsPaperManager : INewsPaperService
    {
        private readonly INewsPaperDal _newsPaperDal;
        private readonly ICategoryService _categoryService;
        private readonly ITechnicalPlaceholderService _technicalPlaceholder;
        private readonly IDimensionService _dimension;
        private readonly IEMaterialFileService _eMaterialFile;
        private readonly ICoverCapService _coverCapService;
        private readonly IEditionService _editionService;
        private readonly IImageService _imageService;
        private readonly IWriterService _writerService;
        private readonly IEditorService _editorService;
        private readonly IDirectorService _directorService;
        private readonly IGraphicDesignerService _graphicDesignerService;
        private readonly IGraphicDirectorService _graphicDirectorService;
        private readonly IInterpretersService _interpreterService;
        private readonly IRedactionService _redactionService;
        private readonly ITechnicalNumberService _technicalNumberService;
        private readonly IStockService _stockService;



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

        public IDataResult<List<NewsPaper>> GetAll()
        {
            return new SuccessDataResult<List<NewsPaper>>(_newsPaperDal.GetAll(np => !np.IsDeleted).ToList(), NewsPaperConstants.DataGet);
        }

        public IDataResult<List<NewsPaper>> GetAllByCategories(int[] categoriesId)
        {
            IDataResult<List<Category>> categories = _categoryService.GetAllByIds(categoriesId);
            if (!categories.Success)
                return new ErrorDataResult<List<NewsPaper>>(categories.Message);

            List<NewsPaper> newsPapers = _newsPaperDal.GetAll(np => np.Categories.ToList() == categories.Data && !np.IsDeleted).ToList();
            return newsPapers == null
                ? new ErrorDataResult<List<NewsPaper>>(NewsPaperConstants.DataNotGet)
                : new SuccessDataResult<List<NewsPaper>>(newsPapers, NewsPaperConstants.DataGet);
        }

        public IDataResult<List<NewsPaper>> GetAllByCommunication(Guid communicationId)
        {
            IDataResult<Edition> editionByCommunication = _editionService.GetByCommunicationId(communicationId);
            if (!editionByCommunication.Success)
                return new ErrorDataResult<List<NewsPaper>>(editionByCommunication.Message);

            List<NewsPaper> newsPapers = _newsPaperDal.GetAll(np => np.EditionId == editionByCommunication.Data.Id && !np.IsDeleted).ToList();
            return newsPapers == null
                ? new ErrorDataResult<List<NewsPaper>>(NewsPaperConstants.DataNotGet)
                : new SuccessDataResult<List<NewsPaper>>(newsPapers, NewsPaperConstants.DataGet);
        }

        public IDataResult<List<NewsPaper>> GetAllByCoverCap(byte coverCapNum)
        {
            IDataResult<CoverCap> CoverCap = _coverCapService.GetById(coverCapNum);
            if (!CoverCap.Success)
                return new ErrorDataResult<List<NewsPaper>>(CoverCap.Message);

            List<NewsPaper> newsPapers = _newsPaperDal.GetAll(np => np.CoverCapId == coverCapNum && !np.IsDeleted).ToList();
            return newsPapers == null
                ? new ErrorDataResult<List<NewsPaper>>(NewsPaperConstants.DataNotGet)
                : new SuccessDataResult<List<NewsPaper>>(newsPapers, NewsPaperConstants.DataGet);
        }

        public IDataResult<List<NewsPaper>> GetAllByDate(DateTime date)
        {
            List<NewsPaper> newsPapers = _newsPaperDal.GetAll(np => np.Date == date && !np.IsDeleted).ToList();
            return newsPapers == null
                ? new ErrorDataResult<List<NewsPaper>>(NewsPaperConstants.DataNotGet)
                : new SuccessDataResult<List<NewsPaper>>(newsPapers, NewsPaperConstants.DataGet);
        }

        public IDataResult<List<NewsPaper>> GetAllByDescriptionFinder(string finderString)
        {
            List<NewsPaper> newsPapers = _newsPaperDal.GetAll(np => np.Description.Contains(finderString) && !np.IsDeleted).ToList();
            return newsPapers == null
                ? new ErrorDataResult<List<NewsPaper>>(NewsPaperConstants.DataNotGet)
                : new SuccessDataResult<List<NewsPaper>>(newsPapers, NewsPaperConstants.DataGet);
        }

        public IDataResult<List<NewsPaper>> GetAllByDimension(Guid dimensionId)
        {
            IDataResult<Dimension> dimmension = _dimension.GetById(dimensionId);
            if (!dimmension.Success)
                return new ErrorDataResult<List<NewsPaper>>(dimmension.Message);

            List<NewsPaper> newsPapers = _newsPaperDal.GetAll(np => np.DimensionsId == dimensionId && !np.IsDeleted).ToList();
            return newsPapers == null
                ? new ErrorDataResult<List<NewsPaper>>(NewsPaperConstants.DataNotGet)
                : new SuccessDataResult<List<NewsPaper>>(newsPapers, NewsPaperConstants.DataGet);
        }

        public IDataResult<List<NewsPaper>> GetAllByDirector(Guid directorId)
        {
            IDataResult<Director> director = _directorService.GetById(directorId);
            if (!director.Success)
                return new ErrorDataResult<List<NewsPaper>>(director.Message);

            List<NewsPaper> newsPapers = _newsPaperDal.GetAll(np => np.DirectorId == directorId && !np.IsDeleted).ToList();
            return newsPapers == null
                ? new ErrorDataResult<List<NewsPaper>>(NewsPaperConstants.DataNotGet)
                : new SuccessDataResult<List<NewsPaper>>(newsPapers, NewsPaperConstants.DataGet);
        }

        public IDataResult<List<NewsPaper>> GetAllByEdition(Guid editionId)
        {
            IDataResult<Edition> edition = _editionService.GetById(editionId);
            if (!edition.Success)
                return new ErrorDataResult<List<NewsPaper>>(edition.Message);

            List<NewsPaper> newsPapers = _newsPaperDal.GetAll(np => np.EditionId == editionId && !np.IsDeleted).ToList();
            return newsPapers == null
                ? new ErrorDataResult<List<NewsPaper>>(NewsPaperConstants.DataNotGet)
                : new SuccessDataResult<List<NewsPaper>>(newsPapers, NewsPaperConstants.DataGet);
        }

        public IDataResult<List<NewsPaper>> GetAllByEditor(Guid editorId)
        {
            IDataResult<Editor> editor = _editorService.GetById(editorId);
            if (!editor.Success)
                return new ErrorDataResult<List<NewsPaper>>(editor.Message);

            List<NewsPaper> newsPapers = _newsPaperDal.GetAll(np => np.EditorId == editorId && !np.IsDeleted).ToList();
            return newsPapers == null
                ? new ErrorDataResult<List<NewsPaper>>(NewsPaperConstants.DataNotGet)
                : new SuccessDataResult<List<NewsPaper>>(newsPapers, NewsPaperConstants.DataGet);
        }

        public IDataResult<List<NewsPaper>> GetAllByEMFile(Guid eMFileId)
        {
            IDataResult<EMaterialFile> eMFile = _eMaterialFile.GetById(eMFileId);
            if (!eMFile.Success)
                return new ErrorDataResult<List<NewsPaper>>(eMFile.Message);

            List<NewsPaper> newsPapers = _newsPaperDal.GetAll(np => np.EMaterialFilesId == eMFileId && !np.IsDeleted).ToList();
            return newsPapers == null
                ? new ErrorDataResult<List<NewsPaper>>(NewsPaperConstants.DataNotGet)
                : new SuccessDataResult<List<NewsPaper>>(newsPapers, NewsPaperConstants.DataGet);
        }

        public IDataResult<List<NewsPaper>> GetAllByFilter(Expression<Func<NewsPaper, bool>>? filter = null)
        {
            return new SuccessDataResult<List<NewsPaper>>(_newsPaperDal.GetAll(filter).ToList(), NewsPaperConstants.DataGet);
        }

        public IDataResult<List<NewsPaper>> GetAllByGraphicDesign(Guid graphicDesignId)
        {
            IDataResult<GraphicDesigner> graphicDesing = _graphicDesignerService.GetById(graphicDesignId);
            if (!graphicDesing.Success)
                return new ErrorDataResult<List<NewsPaper>>(graphicDesing.Message);

            List<NewsPaper> newsPapers = _newsPaperDal.GetAll(np => np.GraphicDesignId == graphicDesignId && !np.IsDeleted).ToList();
            return newsPapers == null
                ? new ErrorDataResult<List<NewsPaper>>(NewsPaperConstants.DataNotGet)
                : new SuccessDataResult<List<NewsPaper>>(newsPapers, NewsPaperConstants.DataGet);
        }

        public IDataResult<List<NewsPaper>> GetAllByGraphicDirector(Guid graphicDirectorId)
        {
            IDataResult<GraphicDirector> gDirector = _graphicDirectorService.GetById(graphicDirectorId);
            if (!gDirector.Success)
                return new ErrorDataResult<List<NewsPaper>>(gDirector.Message);

            List<NewsPaper> newsPapers = _newsPaperDal.GetAll(np => np.GraphicDirectorId == graphicDirectorId && !np.IsDeleted).ToList();
            return newsPapers == null
                ? new ErrorDataResult<List<NewsPaper>>(NewsPaperConstants.DataNotGet)
                : new SuccessDataResult<List<NewsPaper>>(newsPapers, NewsPaperConstants.DataGet);
        }

        public IDataResult<List<NewsPaper>> GetAllByIds(Guid[] ids)
        {
            List<NewsPaper> newsPapers = _newsPaperDal.GetAll(np => ids.Contains(np.Id) && !np.IsDeleted).ToList();
            return newsPapers == null
                ? new ErrorDataResult<List<NewsPaper>>(NewsPaperConstants.DataNotGet)
                : new SuccessDataResult<List<NewsPaper>>(newsPapers, NewsPaperConstants.DataGet);
        }

        public IDataResult<List<NewsPaper>> GetAllByInterpreter(Guid interpreterId)
        {
            IDataResult<Interpreters> interpreter = _interpreterService.GetById(interpreterId);
            if (!interpreter.Success)
                return new ErrorDataResult<List<NewsPaper>>(interpreter.Message);

            List<NewsPaper> newsPapers = _newsPaperDal.GetAll(np => np.InterpretersId == interpreterId && !np.IsDeleted).ToList();
            return newsPapers == null
                ? new ErrorDataResult<List<NewsPaper>>(NewsPaperConstants.DataNotGet)
                : new SuccessDataResult<List<NewsPaper>>(newsPapers, NewsPaperConstants.DataGet);
        }

        public IDataResult<List<NewsPaper>> GetAllByName(string name)
        {
            List<NewsPaper> newsPapers = _newsPaperDal.GetAll(np => np.Name.Contains(name) && !np.IsDeleted).ToList();
            return newsPapers == null
                ? new ErrorDataResult<List<NewsPaper>>(NewsPaperConstants.DataNotGet)
                : new SuccessDataResult<List<NewsPaper>>(newsPapers, NewsPaperConstants.DataGet);
        }

        public IDataResult<List<NewsPaper>> GetAllByNewsPaperName(string newPaperName)
        {
            List<NewsPaper> newsPapers = _newsPaperDal.GetAll(np => np.NewsPaperName.Contains(newPaperName) && !np.IsDeleted).ToList();
            return newsPapers == null
                ? new ErrorDataResult<List<NewsPaper>>(NewsPaperConstants.DataNotGet)
                : new SuccessDataResult<List<NewsPaper>>(newsPapers, NewsPaperConstants.DataGet);
        }

        public IDataResult<List<NewsPaper>> GetAllByNewsPaperNumber(uint number)
        {
            List<NewsPaper> newsPapers = _newsPaperDal.GetAll(np => np.Number == number && !np.IsDeleted).ToList();
            return newsPapers == null
                ? new ErrorDataResult<List<NewsPaper>>(NewsPaperConstants.DataNotGet)
                : new SuccessDataResult<List<NewsPaper>>(newsPapers, NewsPaperConstants.DataGet);
        }

        public IDataResult<List<NewsPaper>> GetAllByPrice(decimal minPrice, decimal? maxPrice = null)
        {
            List<NewsPaper> newsPapers = maxPrice == null
                ? _newsPaperDal.GetAll(np => np.Price == minPrice && !np.IsDeleted).ToList()
                : _newsPaperDal.GetAll(np => np.Price >= minPrice && np.Price <= maxPrice && !np.IsDeleted).ToList();

            return newsPapers == null
                ? new ErrorDataResult<List<NewsPaper>>(NewsPaperConstants.DataNotGet)
                : new SuccessDataResult<List<NewsPaper>>(newsPapers, NewsPaperConstants.DataGet);
        }

        public IDataResult<List<NewsPaper>> GetAllByPublisher(Guid publisherId)
        {
            IDataResult<Edition> editionOfPublisher = _editionService.GetByPublisherId(publisherId);
            if (!editionOfPublisher.Success)
                return new ErrorDataResult<List<NewsPaper>>(editionOfPublisher.Message);

            List<NewsPaper> newsPapers = _newsPaperDal.GetAll(np => np.EditionId == editionOfPublisher.Data.Id && !np.IsDeleted).ToList();
            return newsPapers == null
                ? new ErrorDataResult<List<NewsPaper>>(NewsPaperConstants.DataNotGet)
                : new SuccessDataResult<List<NewsPaper>>(newsPapers, NewsPaperConstants.DataGet);
        }

        public IDataResult<List<NewsPaper>> GetAllByRedaction(Guid redactionId)
        {
            IDataResult<Redaction> redaction = _redactionService.GetById(redactionId);
            if (!redaction.Success)
                return new ErrorDataResult<List<NewsPaper>>(redaction.Message);

            List<NewsPaper> newsPapers = _newsPaperDal.GetAll(np => np.RedactionId == redactionId && !np.IsDeleted).ToList();
            return newsPapers == null
                ? new ErrorDataResult<List<NewsPaper>>(NewsPaperConstants.DataNotGet)
                : new SuccessDataResult<List<NewsPaper>>(newsPapers, NewsPaperConstants.DataGet);
        }

        public IDataResult<List<NewsPaper>> GetAllBySecret()
        {
            return new SuccessDataResult<List<NewsPaper>>(_newsPaperDal.GetAll(np => np.IsDeleted).ToList(), NewsPaperConstants.DataGet);
        }

        public IDataResult<List<NewsPaper>> GetAllByTechnicalNumber(Guid technicalNumberId)
        {
            IDataResult<TechnicalNumber> techNumber = _technicalNumberService.GetById(technicalNumberId);
            if (!techNumber.Success)
                return new ErrorDataResult<List<NewsPaper>>(techNumber.Message);

            List<NewsPaper> newsPapers = _newsPaperDal.GetAll(np => np.TechnicalNumberId == technicalNumberId && !np.IsDeleted).ToList();
            return newsPapers == null
                ? new ErrorDataResult<List<NewsPaper>>(NewsPaperConstants.DataNotGet)
                : new SuccessDataResult<List<NewsPaper>>(newsPapers, NewsPaperConstants.DataGet);
        }

        public IDataResult<List<NewsPaper>> GetAllByTechnicalPlaceholder(Guid technicalPlaceholderId)
        {
            IDataResult<TechnicalPlaceholder> techPlaceHolder = _technicalPlaceholder.GetById(technicalPlaceholderId);
            if (!techPlaceHolder.Success)
                return new ErrorDataResult<List<NewsPaper>>(techPlaceHolder.Message);

            List<NewsPaper> newsPapers = _newsPaperDal.GetAll(np => np.TechnicalNumberId == technicalPlaceholderId && !np.IsDeleted).ToList();
            return newsPapers == null
                ? new ErrorDataResult<List<NewsPaper>>(NewsPaperConstants.DataNotGet)
                : new SuccessDataResult<List<NewsPaper>>(newsPapers, NewsPaperConstants.DataGet);
        }

        public IDataResult<List<NewsPaper>> GetAllByTitle(string title)
        {
            List<NewsPaper> newsPapers = _newsPaperDal.GetAll(np => np.Title.Contains(title) && !np.IsDeleted).ToList();
            return newsPapers == null
                ? new ErrorDataResult<List<NewsPaper>>(NewsPaperConstants.DataNotGet)
                : new SuccessDataResult<List<NewsPaper>>(newsPapers, NewsPaperConstants.DataGet);
        }

        public IDataResult<List<NewsPaper>> GetAllByWriter(Guid writerId)
        {
            IDataResult<Writer> writer = _writerService.GetById(writerId);
            if (!writer.Success)
                return new ErrorDataResult<List<NewsPaper>>(writer.Message);

            List<NewsPaper> newsPapers = _newsPaperDal.GetAll(np => np.WriterId == writerId && !np.IsDeleted).ToList();
            return newsPapers == null
                ? new ErrorDataResult<List<NewsPaper>>(NewsPaperConstants.DataNotGet)
                : new SuccessDataResult<List<NewsPaper>>(newsPapers, NewsPaperConstants.DataGet);
        }

        public IDataResult<NewsPaper> GetByCoverImage(Guid cImageId)
        {
            IDataResult<Image> coverImage = _imageService.GetById(cImageId);
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
            return newsPaper == null
                ? new ErrorDataResult<NewsPaper>(NewsPaperConstants.DataNotGet)
                : new SuccessDataResult<NewsPaper>(newsPaper, NewsPaperConstants.DataGet);
        }

        public IDataResult<NewsPaper> GetByImage(Guid imageId)
        {
            IDataResult<Image> image = _imageService.GetById(imageId);
            if (!image.Success)
                return new ErrorDataResult<NewsPaper>(image.Message);

            NewsPaper newsPaper = _newsPaperDal.Get(np => np.ImageId == imageId && !np.IsDeleted);
            return newsPaper == null
                ? new ErrorDataResult<NewsPaper>(NewsPaperConstants.DataNotGet)
                : new SuccessDataResult<NewsPaper>(newsPaper, NewsPaperConstants.DataGet);
        }

        public IDataResult<NewsPaper> GetByStock(Guid stockId)
        {
            var stock = _stockService.GetById(stockId);
            if (stock.Success)
                return new ErrorDataResult<NewsPaper>(stock.Message);

            NewsPaper newsPaper = _newsPaperDal.Get(np => np.StockId == stockId && !np.IsDeleted);
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
