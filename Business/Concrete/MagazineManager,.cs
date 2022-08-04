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
    public class MagazineManager : IMagazineService
    {
        private readonly IMagazineDal _magazineDal;

        private readonly ICategoryService _categoryService;
        private readonly ICoverCapService _coverCapService;
        private readonly IDimensionService _dimensionService;
        private readonly IDirectorService _directorService;
        private readonly IEditionService _editionService;
        private readonly IEditorService _editorService;
        private readonly IEMaterialFileService _eMaterialFileService;
        private readonly IGraphicDesignerService _graphicDesignerService;
        private readonly IGraphicDirectorService _graphicDirectorService;
        private readonly IImageService _imageService;
        private readonly IInterpretersService _interpretersService;
        private readonly IRedactionService _redactionService;
        private readonly IStockService _stockService;
        private readonly ITechnicalNumberService _technicalNumberService;
        private readonly ITechnicalPlaceholderService _technicalPlaceholderService;
        private readonly IWriterService _writerService;


        [ValidationAspect(typeof(MagazineValidator))]
        public IResult Add(Magazine magazine)
        {
            IResult result = BusinessRules.Run(MagazineControl(magazine));
            if (result != null)
                return result;

            magazine.IsDeleted = false;
            _magazineDal.Add(magazine);
            return new ErrorResult(MagazineConstants.AddSuccess);
        }

        public IResult Delete(Guid id)
        {
            Magazine magazine = _magazineDal.Get(m => m.Id == id);
            if (magazine == null)
                return new ErrorResult(MagazineConstants.NotMatch);

            _magazineDal.Delete(magazine);
            return new SuccessResult(MagazineConstants.DeleteSuccess);
        }

        public IResult ShadowDelete(Guid id)
        {
            Magazine magazine = _magazineDal.Get(m => m.Id == id && !m.IsDeleted);
            if (magazine == null)
                return new ErrorResult(MagazineConstants.NotMatch);

            magazine.IsDeleted = true;
            _magazineDal.Update(magazine);
            return new SuccessResult(MagazineConstants.DeleteSuccess);
        }

        [ValidationAspect(typeof(MagazineValidator))]
        public IResult Update(Magazine magazine)
        {
            IResult result = BusinessRules.Run(MagazineControl(magazine));
            if (result != null)
                return result;

            magazine.IsDeleted = false;
            _magazineDal.Update(magazine);
            return new ErrorResult(MagazineConstants.UpdateSuccess);
        }

        public IDataResult<IList<Magazine>> GetAll()
        {
            return new SuccessDataResult<IList<Magazine>>(_magazineDal.GetAll(m => !m.IsDeleted), MagazineConstants.DataGet);
        }

        public IDataResult<Dictionary<byte, string>> GetAllEnumToDictionaryMagazineType()
        {
            Dictionary<byte, string> magTypes = Enum.GetValues(typeof(MagazineConstants.MagazineTypes)).Cast<MagazineConstants.MagazineTypes>().ToDictionary(m => (byte)m, m => m.ToString());
            return new SuccessDataResult<Dictionary<byte, string>>(magTypes, MagazineConstants.DataGet);
        }

        public IDataResult<IList<Magazine>> GetAllByFilter(Expression<Func<Magazine, bool>>? filter = null)
        {
            return new SuccessDataResult<IList<Magazine>>(_magazineDal.GetAll(filter), MagazineConstants.DataGet);
        }

        public IDataResult<IList<Magazine>> GetAllByIsDeleted()
        {
            return new SuccessDataResult<IList<Magazine>>(_magazineDal.GetAll(m => m.IsDeleted), MagazineConstants.DataGet);
        }

        public IDataResult<IList<Magazine>> GetAllByCategories(int[] categoriesId)
        {
            IDataResult<IList<Category>> categories = _categoryService.GetAllByIds(categoriesId);
            if (!categories.Success)
                return new ErrorDataResult<IList<Magazine>>(categories.Message);

            IList<Magazine> magazines = _magazineDal.GetAll(m => categoriesId.Contains(m.CategoryId) && m.IsDeleted);
            return magazines == null
                ? new ErrorDataResult<IList<Magazine>>(MagazineConstants.DataNotGet)
                : new SuccessDataResult<IList<Magazine>>(magazines, MagazineConstants.DataGet);
        }

        public IDataResult<IList<Magazine>> GetAllByCommunication(Guid communicationId)
        {
            IDataResult<Edition> edition = _editionService.GetByCommunicationId(communicationId);
            if (!edition.Success)
                return new ErrorDataResult<IList<Magazine>>(edition.Message);

            IList<Magazine> magazines = _magazineDal.GetAll(m => m.EditionId == edition.Data.Id && m.IsDeleted);
            return magazines == null
                ? new ErrorDataResult<IList<Magazine>>(MagazineConstants.DataNotGet)
                : new SuccessDataResult<IList<Magazine>>(magazines, MagazineConstants.DataGet);
        }

        public IDataResult<IList<Magazine>> GetAllByCoverCap(byte coverCapNum)
        {
            IDataResult<CoverCap> coverCap = _coverCapService.GetById(coverCapNum);
            if (!coverCap.Success)
                return new ErrorDataResult<IList<Magazine>>(coverCap.Message);

            IList<Magazine> magazines = _magazineDal.GetAll(m => m.CoverCapId == coverCap.Data.Id && m.IsDeleted);
            return magazines == null
                ? new ErrorDataResult<IList<Magazine>>(MagazineConstants.DataNotGet)
                : new SuccessDataResult<IList<Magazine>>(magazines, MagazineConstants.DataGet);
        }

        public IDataResult<Magazine> GetByCoverImage(Guid cImageId)
        {
            IDataResult<Image> image = _imageService.GetById(cImageId);
            if (!image.Success)
                return new ErrorDataResult<Magazine>(image.Message);

            Magazine magazine = _magazineDal.Get(m => m.CoverImageId == image.Data.Id && m.IsDeleted);
            return magazine == null
                ? new ErrorDataResult<Magazine>(MagazineConstants.DataNotGet)
                : new SuccessDataResult<Magazine>(magazine, MagazineConstants.DataGet);
        }

        public IDataResult<IList<Magazine>> GetAllByDescriptionFinder(string finderString)
        {
            IList<Magazine> magazines = _magazineDal.GetAll(m => m.Description.Contains(finderString) && m.IsDeleted);

            return magazines == null
                ? new ErrorDataResult<IList<Magazine>>(MagazineConstants.DataNotGet)
                : new SuccessDataResult<IList<Magazine>>(magazines, MagazineConstants.DataGet);
        }

        public IDataResult<IList<Magazine>> GetAllByDimension(Guid dimensionId)
        {
            IDataResult<Dimension> dimension = _dimensionService.GetById(dimensionId);
            if (!dimension.Success)
                return new ErrorDataResult<IList<Magazine>>(dimension.Message);

            IList<Magazine> magazines = _magazineDal.GetAll(m => m.DimensionsId == dimension.Data.Id && m.IsDeleted);
            return magazines == null
                ? new ErrorDataResult<IList<Magazine>>(MagazineConstants.DataNotGet)
                : new SuccessDataResult<IList<Magazine>>(magazines, MagazineConstants.DataGet);
        }

        public IDataResult<IList<Magazine>> GetAllByDirector(Guid directorId)
        {
            IDataResult<Director> director = _directorService.GetById(directorId);
            if (!director.Success)
                return new ErrorDataResult<IList<Magazine>>(director.Message);

            IList<Magazine> magazines = _magazineDal.GetAll(m => m.DirectorId == director.Data.Id && m.IsDeleted);
            return magazines == null
                ? new ErrorDataResult<IList<Magazine>>(MagazineConstants.DataNotGet)
                : new SuccessDataResult<IList<Magazine>>(magazines, MagazineConstants.DataGet);
        }

        public IDataResult<IList<Magazine>> GetAllByEdition(Guid editionId)
        {
            IDataResult<Edition> edition = _editionService.GetById(editionId);
            if (!edition.Success)
                return new ErrorDataResult<IList<Magazine>>(edition.Message);

            IList<Magazine> magazines = _magazineDal.GetAll(m => m.EditionId == edition.Data.Id && m.IsDeleted);
            return magazines == null
                ? new ErrorDataResult<IList<Magazine>>(MagazineConstants.DataNotGet)
                : new SuccessDataResult<IList<Magazine>>(magazines, MagazineConstants.DataGet);
        }

        public IDataResult<IList<Magazine>> GetAllByEditor(Guid editorId)
        {
            IDataResult<Editor> editor = _editorService.GetById(editorId);
            if (!editor.Success)
                return new ErrorDataResult<IList<Magazine>>(editor.Message);

            IList<Magazine> magazines = _magazineDal.GetAll(m => m.EditorId == editor.Data.Id && m.IsDeleted);
            return magazines == null
                ? new ErrorDataResult<IList<Magazine>>(MagazineConstants.DataNotGet)
                : new SuccessDataResult<IList<Magazine>>(magazines, MagazineConstants.DataGet);
        }

        public IDataResult<IList<Magazine>> GetAllByEMFile(Guid eMFilesId)
        {
            IDataResult<EMaterialFile> eMFiles = _eMaterialFileService.GetById(eMFilesId);
            if (!eMFiles.Success)
                return new ErrorDataResult<IList<Magazine>>(eMFiles.Message);

            IList<Magazine> magazines = _magazineDal.GetAll(m => m.EMaterialFiles == eMFiles.Data && m.IsDeleted);
            return magazines == null
                ? new ErrorDataResult<IList<Magazine>>(MagazineConstants.DataNotGet)
                : new SuccessDataResult<IList<Magazine>>(magazines, MagazineConstants.DataGet);
        }

        public IDataResult<IList<Magazine>> GetAllByGraphicDesign(Guid graphicDesignId)
        {
            IDataResult<GraphicDesigner> gdesign = _graphicDesignerService.GetById(graphicDesignId);
            if (!gdesign.Success)
                return new ErrorDataResult<IList<Magazine>>(gdesign.Message);

            IList<Magazine> magazines = _magazineDal.GetAll(m => m.GraphicDesignId == gdesign.Data.Id && m.IsDeleted);
            return magazines == null
                ? new ErrorDataResult<IList<Magazine>>(MagazineConstants.DataNotGet)
                : new SuccessDataResult<IList<Magazine>>(magazines, MagazineConstants.DataGet);
        }

        public IDataResult<IList<Magazine>> GetAllByGraphicDirector(Guid graphicDirectorId)
        {
            IDataResult<GraphicDirector> gDirector = _graphicDirectorService.GetById(graphicDirectorId);
            if (!gDirector.Success)
                return new ErrorDataResult<IList<Magazine>>(gDirector.Message);

            IList<Magazine> magazines = _magazineDal.GetAll(m => m.GraphicDirectorId == gDirector.Data.Id && m.IsDeleted);
            return magazines == null
                ? new ErrorDataResult<IList<Magazine>>(MagazineConstants.DataNotGet)
                : new SuccessDataResult<IList<Magazine>>(magazines, MagazineConstants.DataGet);
        }

        public IDataResult<Magazine> GetById(Guid id)
        {
            Magazine magazine = _magazineDal.Get(m => m.Id == id);

            return magazine == null
                ? new ErrorDataResult<Magazine>(MagazineConstants.DataNotGet)
                : new SuccessDataResult<Magazine>(magazine, MagazineConstants.DataGet);
        }

        public IDataResult<IList<Magazine>> GetAllByIds(Guid[] ids)
        {
            IList<Magazine> magazines = _magazineDal.GetAll(m => ids.Contains(m.Id) && m.IsDeleted);

            return magazines == null
                ? new ErrorDataResult<IList<Magazine>>(MagazineConstants.DataNotGet)
                : new SuccessDataResult<IList<Magazine>>(magazines, MagazineConstants.DataGet);
        }

        public IDataResult<IList<Magazine>> GetAllByInterpreter(Guid interpreterId)
        {
            IDataResult<Interpreters> interpreters = _interpretersService.GetById(interpreterId);
            if (!interpreters.Success)
                return new ErrorDataResult<IList<Magazine>>(interpreters.Message);

            IList<Magazine> magazines = _magazineDal.GetAll(m => m.InterpretersId == interpreters.Data.Id && m.IsDeleted);
            return magazines == null
                ? new ErrorDataResult<IList<Magazine>>(MagazineConstants.DataNotGet)
                : new SuccessDataResult<IList<Magazine>>(magazines, MagazineConstants.DataGet);
        }

        public IDataResult<IList<Magazine>> GetAllByMagazineType(byte magazineType)
        {
            IList<Magazine> magazines = _magazineDal.GetAll(m => m.MagazineType == magazineType && m.IsDeleted);

            return magazines == null
                ? new ErrorDataResult<IList<Magazine>>(MagazineConstants.DataNotGet)
                : new SuccessDataResult<IList<Magazine>>(magazines, MagazineConstants.DataGet);
        }

        public IDataResult<IList<Magazine>> GetAllByName(string name)
        {
            IList<Magazine> magazines = _magazineDal.GetAll(m => m.Name == name && m.IsDeleted);

            return magazines == null
                ? new ErrorDataResult<IList<Magazine>>(MagazineConstants.DataNotGet)
                : new SuccessDataResult<IList<Magazine>>(magazines, MagazineConstants.DataGet);
        }

        public IDataResult<IList<Magazine>> GetAllByPrice(decimal minPrice, decimal? maxPrice = null)
        {
            IList<Magazine> magazines = maxPrice == null
                ? _magazineDal.GetAll(m => m.Price == minPrice && m.IsDeleted)
                : _magazineDal.GetAll(m => m.Price >= minPrice && m.Price <= maxPrice && m.IsDeleted);

            return magazines == null
                ? new ErrorDataResult<IList<Magazine>>(MagazineConstants.DataNotGet)
                : new SuccessDataResult<IList<Magazine>>(magazines, MagazineConstants.DataGet);
        }

        public IDataResult<IList<Magazine>> GetAllByPublisher(Guid publisherId)
        {
            IDataResult<Edition> edition = _editionService.GetByPublisherId(publisherId);
            if (!edition.Success)
                return new ErrorDataResult<IList<Magazine>>(edition.Message);

            IList<Magazine> magazines = _magazineDal.GetAll(m => m.EditorId == edition.Data.Id && m.IsDeleted);
            return magazines == null
                ? new ErrorDataResult<IList<Magazine>>(MagazineConstants.DataNotGet)
                : new SuccessDataResult<IList<Magazine>>(magazines, MagazineConstants.DataGet);
        }

        public IDataResult<IList<Magazine>> GetAllByRedaction(Guid redactionId)
        {
            IDataResult<Redaction> redaction = _redactionService.GetById(redactionId);
            if (!redaction.Success)
                return new ErrorDataResult<IList<Magazine>>(redaction.Message);

            IList<Magazine> magazines = _magazineDal.GetAll(m => m.RedactionId == redaction.Data.Id && m.IsDeleted);
            return magazines == null
                ? new ErrorDataResult<IList<Magazine>>(MagazineConstants.DataNotGet)
                : new SuccessDataResult<IList<Magazine>>(magazines, MagazineConstants.DataGet);
        }

        public IDataResult<Magazine> GetByStock(Guid stockId)
        {
            IDataResult<Stock> stock = _stockService.GetById(stockId);
            if (!stock.Success)
                return new ErrorDataResult<Magazine>(stock.Message);

            Magazine magazine = _magazineDal.Get(m => m.StockId == stock.Data.Id && m.IsDeleted);
            return magazine == null
                ? new ErrorDataResult<Magazine>(MagazineConstants.DataNotGet)
                : new SuccessDataResult<Magazine>(magazine, MagazineConstants.DataGet);
        }

        public IDataResult<IList<Magazine>> GetAllByTechnicalNumber(Guid technicalNumberId)
        {
            IDataResult<TechnicalNumber> tNumber = _technicalNumberService.GetById(technicalNumberId);
            if (!tNumber.Success)
                return new ErrorDataResult<IList<Magazine>>(tNumber.Message);

            IList<Magazine> magazines = _magazineDal.GetAll(m => m.TechnicalNumberId == tNumber.Data.Id && m.IsDeleted);
            return magazines == null
                ? new ErrorDataResult<IList<Magazine>>(MagazineConstants.DataNotGet)
                : new SuccessDataResult<IList<Magazine>>(magazines, MagazineConstants.DataGet);
        }

        public IDataResult<IList<Magazine>> GetAllByTechnicalPlaceholder(Guid technicalPlaceholderId)
        {
            IDataResult<TechnicalPlaceholder> tPHolder = _technicalPlaceholderService.GetById(technicalPlaceholderId);
            if (!tPHolder.Success)
                return new ErrorDataResult<IList<Magazine>>(tPHolder.Message);

            IList<Magazine> magazines = _magazineDal.GetAll(m => m.TechnicalPlaceholdersId == tPHolder.Data.Id && m.IsDeleted);
            return magazines == null
                ? new ErrorDataResult<IList<Magazine>>(MagazineConstants.DataNotGet)
                : new SuccessDataResult<IList<Magazine>>(magazines, MagazineConstants.DataGet);
        }

        public IDataResult<IList<Magazine>> GetAllByTitle(string title)
        {
            IList<Magazine> magazines = _magazineDal.GetAll(m => m.Title == title && m.IsDeleted);

            return magazines == null
                ? new ErrorDataResult<IList<Magazine>>(MagazineConstants.DataNotGet)
                : new SuccessDataResult<IList<Magazine>>(magazines, MagazineConstants.DataGet);
        }

        public IDataResult<IList<Magazine>> GetAllByVolume(uint volume)
        {
            IList<Magazine> magazines = _magazineDal.GetAll(m => m.Volume == volume && m.IsDeleted);

            return magazines == null
                ? new ErrorDataResult<IList<Magazine>>(MagazineConstants.DataNotGet)
                : new SuccessDataResult<IList<Magazine>>(magazines, MagazineConstants.DataGet);
        }

        public IDataResult<IList<Magazine>> GetAllByWriter(Guid writerId)
        {
            IDataResult<Writer> writer = _writerService.GetById(writerId);
            if (!writer.Success)
                return new ErrorDataResult<IList<Magazine>>(writer.Message);

            IList<Magazine> magazines = _magazineDal.GetAll(m => m.WriterId == writer.Data.Id && m.IsDeleted);
            return magazines == null
                ? new ErrorDataResult<IList<Magazine>>(MagazineConstants.DataNotGet)
                : new SuccessDataResult<IList<Magazine>>(magazines, MagazineConstants.DataGet);
        }

        public IDataResult<byte?> GetSecretLevel(Guid id)
        {
            byte? sLevel = _magazineDal.Get(m => m.Id == id).SecretLevel;

            return sLevel == null
                ? new ErrorDataResult<byte?>(MagazineConstants.DataNotGet)
                : new SuccessDataResult<byte?>(sLevel, MagazineConstants.DataGet);
        }

        public IDataResult<byte> GetState(Guid id)
        {
            return new SuccessDataResult<byte>(_magazineDal.Get(m => m.Id == id && !m.IsDeleted).State, MagazineConstants.DataGet);
        }

        private IResult MagazineControl(Magazine magazine)
        {
            bool control = _magazineDal.Get(m =>

                m.Name == magazine.Name
             && m.Title == magazine.Title
             && m.Description.Contains(magazine.Description)
             && m.CategoryId == magazine.CategoryId
             && m.TechnicalPlaceholdersId == magazine.TechnicalPlaceholdersId
             && m.DimensionsId == magazine.DimensionsId
             && m.EMaterialFilesId == magazine.EMaterialFilesId
             && m.State == magazine.State
             && m.CoverCapId == magazine.CoverCapId
             && m.CoverImageId == magazine.CoverImageId
             && m.WriterId == magazine.WriterId
             && m.DirectorId == magazine.DirectorId
             && m.EditorId == magazine.EditorId
             && m.TechnicalNumberId == magazine.TechnicalNumberId
             && m.EditionId == magazine.EditionId
             && m.MagazineType == magazine.MagazineType
             && m.Volume == magazine.Volume

            ) != null;

            if (control)
                return new ErrorResult(MagazineConstants.AlreadyExists);

            return new SuccessResult();
        }
    }
}
