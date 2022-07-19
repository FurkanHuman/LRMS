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

        public IDataResult<List<Magazine>> GetAll()
        {
            return new SuccessDataResult<List<Magazine>>(_magazineDal.GetAll(m => !m.IsDeleted).ToList(), MagazineConstants.DataGet);
        }

        public IDataResult<Dictionary<byte, string>> GetAllEnumToDictionaryMagazineTypes()
        {
            Dictionary<byte, string> magTypes = Enum.GetValues(typeof(MagazineConstants.MagazineTypes)).Cast<MagazineConstants.MagazineTypes>().ToDictionary(m => (byte)m, m => m.ToString());
            return new SuccessDataResult<Dictionary<byte, string>>(magTypes, MagazineConstants.DataGet);
        }

        public IDataResult<List<Magazine>> GetAllByFilter(Expression<Func<Magazine, bool>>? filter = null)
        {
            return new SuccessDataResult<List<Magazine>>(_magazineDal.GetAll(filter).ToList(), MagazineConstants.DataGet);
        }

        public IDataResult<List<Magazine>> GetAllBySecrets()
        {
            return new SuccessDataResult<List<Magazine>>(_magazineDal.GetAll(m => m.IsDeleted).ToList(), MagazineConstants.DataGet);
        }

        public IDataResult<List<Magazine>> GetByCategories(int[] categoriesId)
        {
            IDataResult<List<Category>> categories = _categoryService.GetByIds(categoriesId);
            if (!categories.Success)
                return new ErrorDataResult<List<Magazine>>(categories.Message);

            List<Magazine> magazines = _magazineDal.GetAll(m => categoriesId.Contains(m.CategoryId) && m.IsDeleted).ToList();
            return magazines == null
                ? new ErrorDataResult<List<Magazine>>(MagazineConstants.DataNotGet)
                : new SuccessDataResult<List<Magazine>>(magazines, MagazineConstants.DataGet);
        }

        public IDataResult<List<Magazine>> GetByCommunications(Guid communicationId)
        {
            IDataResult<Edition> edition = _editionService.GetByCommunicationId(communicationId);
            if (!edition.Success)
                return new ErrorDataResult<List<Magazine>>(edition.Message);

            List<Magazine> magazines = _magazineDal.GetAll(m => m.EditionId == edition.Data.Id && m.IsDeleted).ToList();
            return magazines == null
                ? new ErrorDataResult<List<Magazine>>(MagazineConstants.DataNotGet)
                : new SuccessDataResult<List<Magazine>>(magazines, MagazineConstants.DataGet);
        }

        public IDataResult<List<Magazine>> GetByCoverCaps(byte coverCapNum)
        {
            IDataResult<CoverCap> coverCap = _coverCapService.GetById(coverCapNum);
            if (!coverCap.Success)
                return new ErrorDataResult<List<Magazine>>(coverCap.Message);

            List<Magazine> magazines = _magazineDal.GetAll(m => m.CoverCapId == coverCap.Data.Id && m.IsDeleted).ToList();
            return magazines == null
                ? new ErrorDataResult<List<Magazine>>(MagazineConstants.DataNotGet)
                : new SuccessDataResult<List<Magazine>>(magazines, MagazineConstants.DataGet);
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

        public IDataResult<List<Magazine>> GetByDescriptionFinder(string finderString)
        {
            List<Magazine> magazines = _magazineDal.GetAll(m => m.Description.Contains(finderString) && m.IsDeleted).ToList();

            return magazines == null
                ? new ErrorDataResult<List<Magazine>>(MagazineConstants.DataNotGet)
                : new SuccessDataResult<List<Magazine>>(magazines, MagazineConstants.DataGet);
        }

        public IDataResult<List<Magazine>> GetByDimension(Guid dimensionId)
        {
            IDataResult<Dimension> dimension = _dimensionService.GetById(dimensionId);
            if (!dimension.Success)
                return new ErrorDataResult<List<Magazine>>(dimension.Message);

            List<Magazine> magazines = _magazineDal.GetAll(m => m.DimensionsId == dimension.Data.Id && m.IsDeleted).ToList();
            return magazines == null
                ? new ErrorDataResult<List<Magazine>>(MagazineConstants.DataNotGet)
                : new SuccessDataResult<List<Magazine>>(magazines, MagazineConstants.DataGet);
        }

        public IDataResult<List<Magazine>> GetByDirectors(Guid directorId)
        {
            IDataResult<Director> director = _directorService.GetById(directorId);
            if (!director.Success)
                return new ErrorDataResult<List<Magazine>>(director.Message);

            List<Magazine> magazines = _magazineDal.GetAll(m => m.DirectorId == director.Data.Id && m.IsDeleted).ToList();
            return magazines == null
                ? new ErrorDataResult<List<Magazine>>(MagazineConstants.DataNotGet)
                : new SuccessDataResult<List<Magazine>>(magazines, MagazineConstants.DataGet);
        }

        public IDataResult<List<Magazine>> GetByEditions(Guid editionId)
        {
            IDataResult<Edition> edition = _editionService.GetById(editionId);
            if (!edition.Success)
                return new ErrorDataResult<List<Magazine>>(edition.Message);

            List<Magazine> magazines = _magazineDal.GetAll(m => m.EditionId == edition.Data.Id && m.IsDeleted).ToList();
            return magazines == null
                ? new ErrorDataResult<List<Magazine>>(MagazineConstants.DataNotGet)
                : new SuccessDataResult<List<Magazine>>(magazines, MagazineConstants.DataGet);
        }

        public IDataResult<List<Magazine>> GetByEditors(Guid editorId)
        {
            IDataResult<Editor> editor = _editorService.GetById(editorId);
            if (!editor.Success)
                return new ErrorDataResult<List<Magazine>>(editor.Message);

            List<Magazine> magazines = _magazineDal.GetAll(m => m.EditorId == editor.Data.Id && m.IsDeleted).ToList();
            return magazines == null
                ? new ErrorDataResult<List<Magazine>>(MagazineConstants.DataNotGet)
                : new SuccessDataResult<List<Magazine>>(magazines, MagazineConstants.DataGet);
        }

        public IDataResult<List<Magazine>> GetByEMFiles(Guid eMFilesId)
        {
            IDataResult<EMaterialFile> eMFiles = _eMaterialFileService.GetById(eMFilesId);
            if (!eMFiles.Success)
                return new ErrorDataResult<List<Magazine>>(eMFiles.Message);

            List<Magazine> magazines = _magazineDal.GetAll(m => m.EMaterialFiles == eMFiles.Data && m.IsDeleted).ToList();
            return magazines == null
                ? new ErrorDataResult<List<Magazine>>(MagazineConstants.DataNotGet)
                : new SuccessDataResult<List<Magazine>>(magazines, MagazineConstants.DataGet);
        }

        public IDataResult<List<Magazine>> GetByGraphicDesigns(Guid graphicDesignId)
        {
            IDataResult<GraphicDesigner> gdesign = _graphicDesignerService.GetById(graphicDesignId);
            if (!gdesign.Success)
                return new ErrorDataResult<List<Magazine>>(gdesign.Message);

            List<Magazine> magazines = _magazineDal.GetAll(m => m.GraphicDesignId == gdesign.Data.Id && m.IsDeleted).ToList();
            return magazines == null
                ? new ErrorDataResult<List<Magazine>>(MagazineConstants.DataNotGet)
                : new SuccessDataResult<List<Magazine>>(magazines, MagazineConstants.DataGet);
        }

        public IDataResult<List<Magazine>> GetByGraphicDirectors(Guid graphicDirectorId)
        {
            IDataResult<GraphicDirector> gDirector = _graphicDirectorService.GetById(graphicDirectorId);
            if (!gDirector.Success)
                return new ErrorDataResult<List<Magazine>>(gDirector.Message);

            List<Magazine> magazines = _magazineDal.GetAll(m => m.GraphicDirectorId == gDirector.Data.Id && m.IsDeleted).ToList();
            return magazines == null
                ? new ErrorDataResult<List<Magazine>>(MagazineConstants.DataNotGet)
                : new SuccessDataResult<List<Magazine>>(magazines, MagazineConstants.DataGet);
        }

        public IDataResult<Magazine> GetById(Guid id)
        {
            Magazine magazine = _magazineDal.Get(m => m.Id == id);

            return magazine == null
                ? new ErrorDataResult<Magazine>(MagazineConstants.DataNotGet)
                : new SuccessDataResult<Magazine>(magazine, MagazineConstants.DataGet);
        }

        public IDataResult<List<Magazine>> GetByIds(Guid[] ids)
        {
            List<Magazine> magazines = _magazineDal.GetAll(m => ids.Contains(m.Id) && m.IsDeleted).ToList();

            return magazines == null
                ? new ErrorDataResult<List<Magazine>>(MagazineConstants.DataNotGet)
                : new SuccessDataResult<List<Magazine>>(magazines, MagazineConstants.DataGet);
        }

        public IDataResult<List<Magazine>> GetByInterpreters(Guid interpreterId)
        {
            IDataResult<Interpreters> interpreters = _interpretersService.GetById(interpreterId);
            if (!interpreters.Success)
                return new ErrorDataResult<List<Magazine>>(interpreters.Message);

            List<Magazine> magazines = _magazineDal.GetAll(m => m.InterpretersId == interpreters.Data.Id && m.IsDeleted).ToList();
            return magazines == null
                ? new ErrorDataResult<List<Magazine>>(MagazineConstants.DataNotGet)
                : new SuccessDataResult<List<Magazine>>(magazines, MagazineConstants.DataGet);
        }

        public IDataResult<List<Magazine>> GetByMagazineType(byte magazineType)
        {
            List<Magazine> magazines = _magazineDal.GetAll(m => m.MagazineType == magazineType && m.IsDeleted).ToList();

            return magazines == null
                ? new ErrorDataResult<List<Magazine>>(MagazineConstants.DataNotGet)
                : new SuccessDataResult<List<Magazine>>(magazines, MagazineConstants.DataGet);
        }

        public IDataResult<List<Magazine>> GetByNames(string name)
        {
            List<Magazine> magazines = _magazineDal.GetAll(m => m.Name == name && m.IsDeleted).ToList();

            return magazines == null
                ? new ErrorDataResult<List<Magazine>>(MagazineConstants.DataNotGet)
                : new SuccessDataResult<List<Magazine>>(magazines, MagazineConstants.DataGet);
        }

        public IDataResult<List<Magazine>> GetByPrice(decimal minPrice, decimal? maxPrice = null)
        {
            List<Magazine> magazines = maxPrice == null
                ? _magazineDal.GetAll(m => m.Price == minPrice && m.IsDeleted).ToList()
                : _magazineDal.GetAll(m => m.Price >= minPrice && m.Price <= maxPrice && m.IsDeleted).ToList();

            return magazines == null
                ? new ErrorDataResult<List<Magazine>>(MagazineConstants.DataNotGet)
                : new SuccessDataResult<List<Magazine>>(magazines, MagazineConstants.DataGet);
        }

        public IDataResult<List<Magazine>> GetByPublishers(Guid publisherId)
        {
            IDataResult<Edition> edition = _editionService.GetByPublisherId(publisherId);
            if (!edition.Success)
                return new ErrorDataResult<List<Magazine>>(edition.Message);

            List<Magazine> magazines = _magazineDal.GetAll(m => m.EditorId == edition.Data.Id && m.IsDeleted).ToList();
            return magazines == null
                ? new ErrorDataResult<List<Magazine>>(MagazineConstants.DataNotGet)
                : new SuccessDataResult<List<Magazine>>(magazines, MagazineConstants.DataGet);
        }

        public IDataResult<List<Magazine>> GetByRedactions(Guid redactionId)
        {
            IDataResult<Redaction> redaction = _redactionService.GetById(redactionId);
            if (!redaction.Success)
                return new ErrorDataResult<List<Magazine>>(redaction.Message);

            List<Magazine> magazines = _magazineDal.GetAll(m => m.RedactionId == redaction.Data.Id && m.IsDeleted).ToList();
            return magazines == null
                ? new ErrorDataResult<List<Magazine>>(MagazineConstants.DataNotGet)
                : new SuccessDataResult<List<Magazine>>(magazines, MagazineConstants.DataGet);
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

        public IDataResult<List<Magazine>> GetByTechnicalNumbers(Guid technicalNumberId)
        {
            IDataResult<TechnicalNumber> tNumber = _technicalNumberService.GetById(technicalNumberId);
            if (!tNumber.Success)
                return new ErrorDataResult<List<Magazine>>(tNumber.Message);

            List<Magazine> magazines = _magazineDal.GetAll(m => m.TechnicalNumberId == tNumber.Data.Id && m.IsDeleted).ToList();
            return magazines == null
                ? new ErrorDataResult<List<Magazine>>(MagazineConstants.DataNotGet)
                : new SuccessDataResult<List<Magazine>>(magazines, MagazineConstants.DataGet);
        }

        public IDataResult<List<Magazine>> GetByTechnicalPlaceholders(Guid technicalPlaceholderId)
        {
            IDataResult<TechnicalPlaceholder> tPHolder = _technicalPlaceholderService.GetById(technicalPlaceholderId);
            if (!tPHolder.Success)
                return new ErrorDataResult<List<Magazine>>(tPHolder.Message);

            List<Magazine> magazines = _magazineDal.GetAll(m => m.TechnicalPlaceholdersId == tPHolder.Data.Id && m.IsDeleted).ToList();
            return magazines == null
                ? new ErrorDataResult<List<Magazine>>(MagazineConstants.DataNotGet)
                : new SuccessDataResult<List<Magazine>>(magazines, MagazineConstants.DataGet);
        }

        public IDataResult<List<Magazine>> GetByTitles(string title)
        {
            List<Magazine> magazines = _magazineDal.GetAll(m => m.Title == title && m.IsDeleted).ToList();

            return magazines == null
                ? new ErrorDataResult<List<Magazine>>(MagazineConstants.DataNotGet)
                : new SuccessDataResult<List<Magazine>>(magazines, MagazineConstants.DataGet);
        }

        public IDataResult<List<Magazine>> GetByVolume(uint volume)
        {
            List<Magazine> magazines = _magazineDal.GetAll(m => m.Volume == volume && m.IsDeleted).ToList();

            return magazines == null
                ? new ErrorDataResult<List<Magazine>>(MagazineConstants.DataNotGet)
                : new SuccessDataResult<List<Magazine>>(magazines, MagazineConstants.DataGet);
        }

        public IDataResult<List<Magazine>> GetByWriters(Guid writerId)
        {
            IDataResult<Writer> writer = _writerService.GetById(writerId);
            if (!writer.Success)
                return new ErrorDataResult<List<Magazine>>(writer.Message);

            List<Magazine> magazines = _magazineDal.GetAll(m => m.WriterId == writer.Data.Id && m.IsDeleted).ToList();
            return magazines == null
                ? new ErrorDataResult<List<Magazine>>(MagazineConstants.DataNotGet)
                : new SuccessDataResult<List<Magazine>>(magazines, MagazineConstants.DataGet);
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
