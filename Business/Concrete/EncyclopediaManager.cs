using Business.Abstract;
using Business.Constants;
using Core.Utilities.Business;
using Core.Utilities.Result.Abstract;
using Core.Utilities.Result.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Concrete.Infos;
using System.Linq.Expressions;

namespace Business.Concrete
{
    public class EncyclopediaManager : IEncyclopediaService
    {
        private readonly IEncyclopediaDal _encyclopediaDal;
        private readonly ICategoryService _categoryService;
        private readonly ICoverCapService _coverCapService;
        private readonly IDimensionService _dimensionService;
        private readonly IDirectorService _directorService;
        private readonly IEditionService _editionService;
        private readonly IEditorService _editorService;
        private readonly IEMaterialFileService _eMaterialFileService;
        private readonly IImageService _imageService;
        private readonly IGraphicDesignerService _graphicDesignerService;
        private readonly IGraphicDirectorService _graphicDirectorService;
        private readonly IInterpretersService _interpretersService;
        private readonly IRedactionService _redactionService;
        private readonly ITechnicalNumberService _technicalNumberService;
        private readonly ITechnicalPlaceholderService _technicalPlaceholderService;
        private readonly IWriterService _writerService;
        private readonly IStockService _stockService;

        public IResult Add(Encyclopedia entity)
        {
            IResult result = BusinessRules.Run(EncyclopediaControl(entity));
            if (result != null)
                return result;

            entity.IsDeleted = false;
            _encyclopediaDal.Add(entity);
            return new SuccessResult(EncyclopediaConstants.AddSuccess);
        }

        public IResult Delete(Guid id)
        {
            Encyclopedia encyclopedia = _encyclopediaDal.Get(ep => ep.Id == id);
            if (encyclopedia == null)
                return new ErrorResult(EncyclopediaConstants.NotMatch);

            _encyclopediaDal.Delete(encyclopedia);
            return new SuccessResult(EncyclopediaConstants.DeleteSuccess);
        }

        public IResult ShadowDelete(Guid id)
        {
            Encyclopedia encyclopedia = _encyclopediaDal.Get(ep => ep.Id == id && !ep.IsDeleted);
            if (encyclopedia == null)
                return new ErrorResult(EncyclopediaConstants.NotMatch);

            encyclopedia.IsDeleted = true;
            _encyclopediaDal.Update(encyclopedia);
            return new SuccessResult(EncyclopediaConstants.EfDeletedSuccsess);
        }

        public IResult Update(Encyclopedia entity)
        {
            IResult result = BusinessRules.Run(EncyclopediaControl(entity));
            if (result != null)
                return result;

            entity.IsDeleted = false;
            _encyclopediaDal.Update(entity);
            return new SuccessResult(EncyclopediaConstants.UpdateSuccess);
        }

        public IDataResult<List<Encyclopedia>> GetAll()
        {
            return new SuccessDataResult<List<Encyclopedia>>(_encyclopediaDal.GetAll(ep => !ep.IsDeleted).ToList(), EncyclopediaConstants.DataGet);
        }

        public IDataResult<List<Encyclopedia>> GetAllByFilter(Expression<Func<Encyclopedia, bool>>? filter = null)
        {
            return new SuccessDataResult<List<Encyclopedia>>(_encyclopediaDal.GetAll(filter).ToList(), EncyclopediaConstants.DataGet);
        }

        public IDataResult<List<Encyclopedia>> GetAllBySecret()
        {
            return new SuccessDataResult<List<Encyclopedia>>(_encyclopediaDal.GetAll(ep => ep.IsDeleted).ToList(), EncyclopediaConstants.DataGet);
        }

        public IDataResult<List<Encyclopedia>> GetAllByCategories(int[] categoriesId)
        {
            IDataResult<List<Category>> categoaries = _categoryService.GetAllByIds(categoriesId);
            if (!categoaries.Success)
                return new ErrorDataResult<List<Encyclopedia>>(categoaries.Message);

            List<Encyclopedia> encyclopedias = _encyclopediaDal.GetAll(ep => ep.Categories.Any(c => categoriesId.Contains(c.Id)) && !ep.IsDeleted).ToList();
            return encyclopedias == null
                ? new ErrorDataResult<List<Encyclopedia>>(EncyclopediaConstants.DataNotGet)
                : new SuccessDataResult<List<Encyclopedia>>(encyclopedias, EncyclopediaConstants.DataGet);

        }

        public IDataResult<List<Encyclopedia>> GetAllByCommunication(Guid communicationId)
        {

            IDataResult<Edition> edition = _editionService.GetByCommunicationId(communicationId);
            if (!edition.Success)
                return new ErrorDataResult<List<Encyclopedia>>(edition.Message);

            List<Encyclopedia> encyclopedias = _encyclopediaDal.GetAll(ep => ep.EditionId == edition.Data.Id && !ep.IsDeleted).ToList();
            return encyclopedias == null
                ? new ErrorDataResult<List<Encyclopedia>>(EncyclopediaConstants.DataNotGet)
                : new SuccessDataResult<List<Encyclopedia>>(encyclopedias, EncyclopediaConstants.DataGet);
        }

        public IDataResult<List<Encyclopedia>> GetAllByCoverCap(byte coverCapNum)
        {
            IDataResult<CoverCap> coverCap = _coverCapService.GetById(coverCapNum);
            if (!coverCap.Success)
                return new ErrorDataResult<List<Encyclopedia>>(coverCap.Message);

            List<Encyclopedia> encyclopedias = _encyclopediaDal.GetAll(ep => ep.CoverCapId == coverCapNum && !ep.IsDeleted).ToList();
            return encyclopedias == null
                ? new ErrorDataResult<List<Encyclopedia>>(EncyclopediaConstants.DataNotGet)
                : new SuccessDataResult<List<Encyclopedia>>(encyclopedias, EncyclopediaConstants.DataGet);
        }

        public IDataResult<Encyclopedia> GetByCoverImage(Guid cImageId)
        {
            IDataResult<Image> image = _imageService.GetById(cImageId);
            if (!image.Success)
                return new ErrorDataResult<Encyclopedia>(image.Message);

            Encyclopedia encyclopedia = _encyclopediaDal.Get(ep => ep.CoverImageId == cImageId && !ep.IsDeleted);
            return encyclopedia == null
                ? new ErrorDataResult<Encyclopedia>(EncyclopediaConstants.DataNotGet)
                : new SuccessDataResult<Encyclopedia>(encyclopedia, EncyclopediaConstants.DataGet);
        }

        public IDataResult<List<Encyclopedia>> GetAllByDescriptionFinder(string finderString)
        {
            List<Encyclopedia> encyclopedias = _encyclopediaDal.GetAll(ep => ep.Description.Contains(finderString) && !ep.IsDeleted).ToList();
            return encyclopedias == null
                ? new ErrorDataResult<List<Encyclopedia>>(EncyclopediaConstants.DataNotGet)
                : new SuccessDataResult<List<Encyclopedia>>(encyclopedias, EncyclopediaConstants.DataGet);
        }

        public IDataResult<List<Encyclopedia>> GetAllByDimension(Guid dimensionId)
        {
            IDataResult<Dimension> dimmension = _dimensionService.GetById(dimensionId);
            if (!dimmension.Success)
                return new ErrorDataResult<List<Encyclopedia>>(dimmension.Message);

            List<Encyclopedia> encyclopedias = _encyclopediaDal.GetAll(ep => ep.EditionId == dimensionId && !ep.IsDeleted).ToList();
            return encyclopedias == null
                ? new ErrorDataResult<List<Encyclopedia>>(EncyclopediaConstants.DataNotGet)
                : new SuccessDataResult<List<Encyclopedia>>(encyclopedias, EncyclopediaConstants.DataGet);
        }

        public IDataResult<List<Encyclopedia>> GetAllByDirector(Guid directorId)
        {
            IDataResult<Director> director = _directorService.GetById(directorId);
            if (!director.Success)
                return new ErrorDataResult<List<Encyclopedia>>(director.Message);

            List<Encyclopedia> encyclopedias = _encyclopediaDal.GetAll(ep => ep.DirectorId == directorId && !ep.IsDeleted).ToList();
            return encyclopedias == null
                ? new ErrorDataResult<List<Encyclopedia>>(EncyclopediaConstants.DataNotGet)
                : new SuccessDataResult<List<Encyclopedia>>(encyclopedias, EncyclopediaConstants.DataGet);
        }

        public IDataResult<List<Encyclopedia>> GetAllByEdition(Guid editionId)
        {
            IDataResult<Edition> edition = _editionService.GetById(editionId);
            if (!edition.Success)
                return new ErrorDataResult<List<Encyclopedia>>(edition.Message);

            List<Encyclopedia> encyclopedias = _encyclopediaDal.GetAll(ep => ep.EditionId == editionId && !ep.IsDeleted).ToList();
            return encyclopedias == null
                ? new ErrorDataResult<List<Encyclopedia>>(EncyclopediaConstants.DataNotGet)
                : new SuccessDataResult<List<Encyclopedia>>(encyclopedias, EncyclopediaConstants.DataGet);
        }

        public IDataResult<List<Encyclopedia>> GetAllByEditor(Guid editorId)
        {
            IDataResult<Editor> redaction = _editorService.GetById(editorId);
            if (!redaction.Success)
                return new ErrorDataResult<List<Encyclopedia>>(redaction.Message);

            List<Encyclopedia> encyclopedias = _encyclopediaDal.GetAll(ep => ep.EditorId == editorId && !ep.IsDeleted).ToList();
            return encyclopedias == null
                ? new ErrorDataResult<List<Encyclopedia>>(EncyclopediaConstants.DataNotGet)
                : new SuccessDataResult<List<Encyclopedia>>(encyclopedias, EncyclopediaConstants.DataGet);
        }

        public IDataResult<List<Encyclopedia>> GetAllByEMFile(Guid eMFilesId)
        {
            IDataResult<EMaterialFile> eMFile = _eMaterialFileService.GetById(eMFilesId);
            if (!eMFile.Success)
                return new ErrorDataResult<List<Encyclopedia>>(eMFile.Message);

            List<Encyclopedia> encyclopedias = _encyclopediaDal.GetAll(ep => ep.EMaterialFilesId == eMFilesId && !ep.IsDeleted).ToList();
            return encyclopedias == null
                ? new ErrorDataResult<List<Encyclopedia>>(EncyclopediaConstants.DataNotGet)
                : new SuccessDataResult<List<Encyclopedia>>(encyclopedias, EncyclopediaConstants.DataGet);
        }

        public IDataResult<List<Encyclopedia>> GetAllByGraphicDesign(Guid graphicDesignId)
        {
            IDataResult<GraphicDesigner> graphicDesing = _graphicDesignerService.GetById(graphicDesignId);
            if (!graphicDesing.Success)
                return new ErrorDataResult<List<Encyclopedia>>(graphicDesing.Message);

            List<Encyclopedia> encyclopedias = _encyclopediaDal.GetAll(ep => ep.GraphicDesignId == graphicDesignId && !ep.IsDeleted).ToList();
            return encyclopedias == null
                ? new ErrorDataResult<List<Encyclopedia>>(EncyclopediaConstants.DataNotGet)
                : new SuccessDataResult<List<Encyclopedia>>(encyclopedias, EncyclopediaConstants.DataGet);
        }

        public IDataResult<List<Encyclopedia>> GetAllByGraphicDirector(Guid graphicDirectorId)
        {
            IDataResult<GraphicDirector> graphicDirector = _graphicDirectorService.GetById(graphicDirectorId);
            if (!graphicDirector.Success)
                return new ErrorDataResult<List<Encyclopedia>>(graphicDirector.Message);

            List<Encyclopedia> encyclopedias = _encyclopediaDal.GetAll(ep => ep.GraphicDirectorId == graphicDirectorId && !ep.IsDeleted).ToList();
            return encyclopedias == null
                ? new ErrorDataResult<List<Encyclopedia>>(EncyclopediaConstants.DataNotGet)
                : new SuccessDataResult<List<Encyclopedia>>(encyclopedias, EncyclopediaConstants.DataGet);
        }

        public IDataResult<Encyclopedia> GetById(Guid id)
        {
            Encyclopedia encyclopedia = _encyclopediaDal.Get(ep => ep.Id == id);
            return encyclopedia == null
                ? new ErrorDataResult<Encyclopedia>(EncyclopediaConstants.DataNotGet)
                : new SuccessDataResult<Encyclopedia>(encyclopedia, EncyclopediaConstants.DataGet);
        }

        public IDataResult<List<Encyclopedia>> GetAllByIds(Guid[] ids)
        {
            List<Encyclopedia> encyclopedias = _encyclopediaDal.GetAll(ep => ids.Contains(ep.Id) && !ep.IsDeleted).ToList();
            return encyclopedias == null
                ? new ErrorDataResult<List<Encyclopedia>>(EncyclopediaConstants.DataNotGet)
                : new SuccessDataResult<List<Encyclopedia>>(encyclopedias, EncyclopediaConstants.DataGet);
        }

        public IDataResult<List<Encyclopedia>> GetAllByInterpreter(Guid interpreterId)
        {
            var interpreter = _interpretersService.GetById(interpreterId);
            if (!interpreter.Success)
                return new ErrorDataResult<List<Encyclopedia>>(interpreter.Message);

            List<Encyclopedia> encyclopedias = _encyclopediaDal.GetAll(ep => ep.InterpretersId == interpreterId && !ep.IsDeleted).ToList();
            return encyclopedias == null
                ? new ErrorDataResult<List<Encyclopedia>>(EncyclopediaConstants.DataGet)
                : new SuccessDataResult<List<Encyclopedia>>(encyclopedias, EncyclopediaConstants.DataGet);
        }

        public IDataResult<List<Encyclopedia>> GetAllByName(string name)
        {
            List<Encyclopedia> encyclopedias = _encyclopediaDal.GetAll(ep => ep.Name.Contains(name) && !ep.IsDeleted).ToList();
            return encyclopedias == null
                ? new ErrorDataResult<List<Encyclopedia>>(EncyclopediaConstants.DataNotGet)
                : new SuccessDataResult<List<Encyclopedia>>(encyclopedias, EncyclopediaConstants.DataGet);
        }

        public IDataResult<List<Encyclopedia>> GetAllByPrice(decimal minPrice, decimal? maxPrice = null)
        {
            List<Encyclopedia> encyclopedias = maxPrice == null
                ? _encyclopediaDal.GetAll(ep => ep.Price == minPrice && !ep.IsDeleted).ToList()
                : _encyclopediaDal.GetAll(ep => ep.Price >= minPrice && ep.Price <= maxPrice && !ep.IsDeleted).ToList();

            return encyclopedias == null
                ? new ErrorDataResult<List<Encyclopedia>>(EncyclopediaConstants.DataNotGet)
                : new SuccessDataResult<List<Encyclopedia>>(encyclopedias, EncyclopediaConstants.DataGet);
        }

        public IDataResult<List<Encyclopedia>> GetAllByPublisher(Guid publisherId)
        {
            IDataResult<Edition> edition = _editionService.GetByPublisherId(publisherId);
            if (!edition.Success)
                return new ErrorDataResult<List<Encyclopedia>>(edition.Message);

            List<Encyclopedia> encyclopedias = _encyclopediaDal.GetAll(ep => ep.EditionId == edition.Data.Id && !ep.IsDeleted).ToList();
            return encyclopedias == null
                ? new ErrorDataResult<List<Encyclopedia>>(EncyclopediaConstants.DataNotGet)
                : new SuccessDataResult<List<Encyclopedia>>(encyclopedias, EncyclopediaConstants.DataGet);
        }

        public IDataResult<List<Encyclopedia>> GetAllByRedaction(Guid redactionId)
        {
            IDataResult<Redaction> redaction = _redactionService.GetById(redactionId);
            if (!redaction.Success)
                return new ErrorDataResult<List<Encyclopedia>>(redaction.Message);

            List<Encyclopedia> encyclopedias = _encyclopediaDal.GetAll(ep => ep.RedactionId == redactionId && !ep.IsDeleted).ToList();
            return encyclopedias == null
                ? new ErrorDataResult<List<Encyclopedia>>(EncyclopediaConstants.DataNotGet)
                : new SuccessDataResult<List<Encyclopedia>>(encyclopedias, EncyclopediaConstants.DataGet);
        }

        public IDataResult<List<Encyclopedia>> GetAllBySequenceNumber(uint sequenceNumber)
        {
            List<Encyclopedia> encyclopedias = _encyclopediaDal.GetAll(ep => ep.SequenceNumber == sequenceNumber && !ep.IsDeleted).ToList();
            return encyclopedias == null
                ? new ErrorDataResult<List<Encyclopedia>>(EncyclopediaConstants.DataNotGet)
                : new SuccessDataResult<List<Encyclopedia>>(encyclopedias, EncyclopediaConstants.DataGet);
        }

        public IDataResult<List<Encyclopedia>> GetAllByTechnicalNumber(Guid technicalNumberId)
        {
            IDataResult<TechnicalNumber> techNumber = _technicalNumberService.GetById(technicalNumberId);
            if (!techNumber.Success)
                return new ErrorDataResult<List<Encyclopedia>>(techNumber.Message);

            List<Encyclopedia> encyclopedias = _encyclopediaDal.GetAll(ep => ep.TechnicalNumberId == technicalNumberId && !ep.IsDeleted).ToList();
            return encyclopedias == null
                ? new ErrorDataResult<List<Encyclopedia>>(EncyclopediaConstants.DataNotGet)
                : new SuccessDataResult<List<Encyclopedia>>(encyclopedias, EncyclopediaConstants.DataGet);
        }

        public IDataResult<List<Encyclopedia>> GetAllByTechnicalPlaceholder(Guid technicalPlaceholderId)
        {
            IDataResult<TechnicalPlaceholder> techPlaceHol = _technicalPlaceholderService.GetById(technicalPlaceholderId);
            if (!techPlaceHol.Success)
                return new ErrorDataResult<List<Encyclopedia>>(techPlaceHol.Message);

            List<Encyclopedia> encyclopedias = _encyclopediaDal.GetAll(ep => ep.TechnicalPlaceholdersId == technicalPlaceholderId && !ep.IsDeleted).ToList();
            return encyclopedias == null
                ? new ErrorDataResult<List<Encyclopedia>>(EncyclopediaConstants.DataNotGet)
                : new SuccessDataResult<List<Encyclopedia>>(encyclopedias, EncyclopediaConstants.DataGet);
        }

        public IDataResult<List<Encyclopedia>> GetAllByTitle(string title)
        {
            List<Encyclopedia> encyclopedias = _encyclopediaDal.GetAll(ep => ep.Title.Contains(title) && !ep.IsDeleted).ToList();
            return encyclopedias == null
                ? new ErrorDataResult<List<Encyclopedia>>(EncyclopediaConstants.DataNotGet)
                : new SuccessDataResult<List<Encyclopedia>>(encyclopedias, EncyclopediaConstants.DataGet);
        }

        public IDataResult<List<Encyclopedia>> GetAllByWriter(Guid writerId)
        {
            IDataResult<Writer> writer = _writerService.GetById(writerId);
            if (!writer.Success)
                return new ErrorDataResult<List<Encyclopedia>>(writer.Message);

            List<Encyclopedia> encyclopedias = _encyclopediaDal.GetAll(ep => ep.WriterId == writerId && !ep.IsDeleted).ToList();
            return encyclopedias == null
                ? new ErrorDataResult<List<Encyclopedia>>(EncyclopediaConstants.DataNotGet)
                : new SuccessDataResult<List<Encyclopedia>>(encyclopedias, EncyclopediaConstants.DataGet);
        }

        public IDataResult<byte?> GetSecretLevel(Guid id)
        {
            byte? sLevel = _encyclopediaDal.Get(ep => ep.Id == id && !ep.IsDeleted).SecretLevel;
            return sLevel == null
                ? new ErrorDataResult<byte?>(EncyclopediaConstants.DataNotGet)
                : new SuccessDataResult<byte?>(sLevel, EncyclopediaConstants.DataGet);
        }

        public IDataResult<byte> GetState(Guid id)
        {
            return new SuccessDataResult<byte>(_encyclopediaDal.Get(ep => ep.Id == id && !ep.IsDeleted).State, EncyclopediaConstants.DataGet);
        }

        public IDataResult<Encyclopedia> GetByStock(Guid stockId)
        {
            var stock = _stockService.GetById(stockId);
            if (!stock.Success)
                return new ErrorDataResult<Encyclopedia>(stock.Message);

            Encyclopedia encyclopedia = _encyclopediaDal.Get(e => e.Stock == stock.Data && !e.IsDeleted);
            return encyclopedia == null
                ? new ErrorDataResult<Encyclopedia>(EncyclopediaConstants.NotMatch)
                : new SuccessDataResult<Encyclopedia>(encyclopedia, EncyclopediaConstants.DataGet);
        }

        private IResult EncyclopediaControl(Encyclopedia encyclopedia)
        {
            // todo: check if book control is valid,

            bool checkEncyclopedia = _encyclopediaDal.Get(ep =>
                ep.Name == encyclopedia.Name
             && ep.Title == encyclopedia.Title
             && ep.Description.Contains(encyclopedia.Description)
             && ep.CategoryId == encyclopedia.CategoryId
             && ep.TechnicalPlaceholdersId == encyclopedia.TechnicalPlaceholdersId
             && ep.DimensionsId == encyclopedia.DimensionsId
             && ep.EMaterialFilesId == encyclopedia.EMaterialFilesId
             && ep.State == encyclopedia.State
             && ep.CoverCapId == encyclopedia.CoverCapId
             && ep.CoverImageId == encyclopedia.CoverImageId
             && ep.WriterId == encyclopedia.WriterId
             && ep.EditorId == encyclopedia.EditorId
             && ep.TechnicalNumberId == encyclopedia.TechnicalNumberId
             && ep.EditionId == encyclopedia.EditionId
             && ep.SequenceNumber == encyclopedia.SequenceNumber
                ) != null;

            if (checkEncyclopedia)
                return new ErrorResult(EncyclopediaConstants.AlreadyExists);
            return new SuccessResult();
        }
    }
}
