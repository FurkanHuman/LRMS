using Business.Abstract;
using Business.Constants;
using Business.DependencyResolvers.Facade;
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
        private readonly IFacadeService _facadeService;

        public EncyclopediaManager(IEncyclopediaDal encyclopediaDal, IFacadeService facadeService)
        {
            _encyclopediaDal = encyclopediaDal;
            _facadeService = facadeService;
        }

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

        public IDataResult<IList<Encyclopedia>> GetAll()
        {
            return new SuccessDataResult<IList<Encyclopedia>>(_encyclopediaDal.GetAll(ep => !ep.IsDeleted), EncyclopediaConstants.DataGet);
        }

        public IDataResult<IList<Encyclopedia>> GetAllByFilter(Expression<Func<Encyclopedia, bool>>? filter = null)
        {
            return new SuccessDataResult<IList<Encyclopedia>>(_encyclopediaDal.GetAll(filter), EncyclopediaConstants.DataGet);
        }

        public IDataResult<IList<Encyclopedia>> GetAllByIsDeleted()
        {
            return new SuccessDataResult<IList<Encyclopedia>>(_encyclopediaDal.GetAll(ep => ep.IsDeleted), EncyclopediaConstants.DataGet);
        }

        public IDataResult<IList<Encyclopedia>> GetAllByCategories(int[] categoriesId)
        {
            IDataResult<IList<Category>> categoaries = _facadeService.CategoryService().GetAllByIds(categoriesId);
            if (!categoaries.Success)
                return new ErrorDataResult<IList<Encyclopedia>>(categoaries.Message);

            IList<Encyclopedia> encyclopedias = _encyclopediaDal.GetAll(ep => ep.Categories.Any(c => categoriesId.Contains(c.Id)) && !ep.IsDeleted);
            return encyclopedias == null
                ? new ErrorDataResult<IList<Encyclopedia>>(EncyclopediaConstants.DataNotGet)
                : new SuccessDataResult<IList<Encyclopedia>>(encyclopedias, EncyclopediaConstants.DataGet);
        }

        public IDataResult<IList<Encyclopedia>> GetAllByCommunication(Guid communicationId)
        {
            IDataResult<Edition> edition = _facadeService.EditionService().GetByCommunicationId(communicationId);
            if (!edition.Success)
                return new ErrorDataResult<IList<Encyclopedia>>(edition.Message);

            IList<Encyclopedia> encyclopedias = _encyclopediaDal.GetAll(ep => ep.EditionId == edition.Data.Id && !ep.IsDeleted);
            return encyclopedias == null
                ? new ErrorDataResult<IList<Encyclopedia>>(EncyclopediaConstants.DataNotGet)
                : new SuccessDataResult<IList<Encyclopedia>>(encyclopedias, EncyclopediaConstants.DataGet);
        }

        public IDataResult<IList<Encyclopedia>> GetAllByCoverCap(byte coverCapNum)
        {
            IDataResult<CoverCap> coverCap = _facadeService.CoverCapService().GetById(coverCapNum);
            if (!coverCap.Success)
                return new ErrorDataResult<IList<Encyclopedia>>(coverCap.Message);

            IList<Encyclopedia> encyclopedias = _encyclopediaDal.GetAll(ep => ep.CoverCapId == coverCapNum && !ep.IsDeleted);
            return encyclopedias == null
                ? new ErrorDataResult<IList<Encyclopedia>>(EncyclopediaConstants.DataNotGet)
                : new SuccessDataResult<IList<Encyclopedia>>(encyclopedias, EncyclopediaConstants.DataGet);
        }

        public IDataResult<Encyclopedia> GetByCoverImage(Guid cImageId)
        {
            IDataResult<Image> image = _facadeService.ImageService().GetById(cImageId);
            if (!image.Success)
                return new ErrorDataResult<Encyclopedia>(image.Message);

            Encyclopedia encyclopedia = _encyclopediaDal.Get(ep => ep.CoverImageId == cImageId && !ep.IsDeleted);
            return encyclopedia == null
                ? new ErrorDataResult<Encyclopedia>(EncyclopediaConstants.DataNotGet)
                : new SuccessDataResult<Encyclopedia>(encyclopedia, EncyclopediaConstants.DataGet);
        }

        public IDataResult<IList<Encyclopedia>> GetAllByDescriptionFinder(string finderString)
        {
            IList<Encyclopedia> encyclopedias = _encyclopediaDal.GetAll(ep => ep.Description.Contains(finderString) && !ep.IsDeleted);
            return encyclopedias == null
                ? new ErrorDataResult<IList<Encyclopedia>>(EncyclopediaConstants.DataNotGet)
                : new SuccessDataResult<IList<Encyclopedia>>(encyclopedias, EncyclopediaConstants.DataGet);
        }

        public IDataResult<IList<Encyclopedia>> GetAllByDimension(Guid dimensionId)
        {
            IDataResult<Dimension> dimmension = _facadeService.DimensionService().GetById(dimensionId);
            if (!dimmension.Success)
                return new ErrorDataResult<IList<Encyclopedia>>(dimmension.Message);

            IList<Encyclopedia> encyclopedias = _encyclopediaDal.GetAll(ep => ep.EditionId == dimensionId && !ep.IsDeleted);
            return encyclopedias == null
                ? new ErrorDataResult<IList<Encyclopedia>>(EncyclopediaConstants.DataNotGet)
                : new SuccessDataResult<IList<Encyclopedia>>(encyclopedias, EncyclopediaConstants.DataGet);
        }

        public IDataResult<IList<Encyclopedia>> GetAllByDirector(Guid directorId)
        {
            IDataResult<Director> director = _facadeService.DirectorService().GetById(directorId);
            if (!director.Success)
                return new ErrorDataResult<IList<Encyclopedia>>(director.Message);

            IList<Encyclopedia> encyclopedias = _encyclopediaDal.GetAll(ep => ep.DirectorId == directorId && !ep.IsDeleted);
            return encyclopedias == null
                ? new ErrorDataResult<IList<Encyclopedia>>(EncyclopediaConstants.DataNotGet)
                : new SuccessDataResult<IList<Encyclopedia>>(encyclopedias, EncyclopediaConstants.DataGet);
        }

        public IDataResult<IList<Encyclopedia>> GetAllByEdition(Guid editionId)
        {
            IDataResult<Edition> edition = _facadeService.EditionService().GetById(editionId);
            if (!edition.Success)
                return new ErrorDataResult<IList<Encyclopedia>>(edition.Message);

            IList<Encyclopedia> encyclopedias = _encyclopediaDal.GetAll(ep => ep.EditionId == editionId && !ep.IsDeleted);
            return encyclopedias == null
                ? new ErrorDataResult<IList<Encyclopedia>>(EncyclopediaConstants.DataNotGet)
                : new SuccessDataResult<IList<Encyclopedia>>(encyclopedias, EncyclopediaConstants.DataGet);
        }

        public IDataResult<IList<Encyclopedia>> GetAllByEditor(Guid editorId)
        {
            IDataResult<Editor> redaction = _facadeService.EditorService().GetById(editorId);
            if (!redaction.Success)
                return new ErrorDataResult<IList<Encyclopedia>>(redaction.Message);

            IList<Encyclopedia> encyclopedias = _encyclopediaDal.GetAll(ep => ep.EditorId == editorId && !ep.IsDeleted);
            return encyclopedias == null
                ? new ErrorDataResult<IList<Encyclopedia>>(EncyclopediaConstants.DataNotGet)
                : new SuccessDataResult<IList<Encyclopedia>>(encyclopedias, EncyclopediaConstants.DataGet);
        }

        public IDataResult<IList<Encyclopedia>> GetAllByEMFile(Guid eMFileId)
        {
            IDataResult<EMaterialFile> eMFile = _facadeService.EMaterialFileService().GetById(eMFileId);
            if (!eMFile.Success)
                return new ErrorDataResult<IList<Encyclopedia>>(eMFile.Message);

            IList<Encyclopedia> encyclopedias = _encyclopediaDal.GetAll(ep => ep.EMaterialFilesId == eMFileId && !ep.IsDeleted);
            return encyclopedias == null
                ? new ErrorDataResult<IList<Encyclopedia>>(EncyclopediaConstants.DataNotGet)
                : new SuccessDataResult<IList<Encyclopedia>>(encyclopedias, EncyclopediaConstants.DataGet);
        }

        public IDataResult<IList<Encyclopedia>> GetAllByGraphicDesign(Guid graphicDesignId)
        {
            IDataResult<GraphicDesigner> graphicDesing = _facadeService.GraphicDesignerService().GetById(graphicDesignId);
            if (!graphicDesing.Success)
                return new ErrorDataResult<IList<Encyclopedia>>(graphicDesing.Message);

            IList<Encyclopedia> encyclopedias = _encyclopediaDal.GetAll(ep => ep.GraphicDesignId == graphicDesignId && !ep.IsDeleted);
            return encyclopedias == null
                ? new ErrorDataResult<IList<Encyclopedia>>(EncyclopediaConstants.DataNotGet)
                : new SuccessDataResult<IList<Encyclopedia>>(encyclopedias, EncyclopediaConstants.DataGet);
        }

        public IDataResult<IList<Encyclopedia>> GetAllByGraphicDirector(Guid graphicDirectorId)
        {
            IDataResult<GraphicDirector> graphicDirector = _facadeService.GraphicDirectorService().GetById(graphicDirectorId);
            if (!graphicDirector.Success)
                return new ErrorDataResult<IList<Encyclopedia>>(graphicDirector.Message);

            IList<Encyclopedia> encyclopedias = _encyclopediaDal.GetAll(ep => ep.GraphicDirectorId == graphicDirectorId && !ep.IsDeleted);
            return encyclopedias == null
                ? new ErrorDataResult<IList<Encyclopedia>>(EncyclopediaConstants.DataNotGet)
                : new SuccessDataResult<IList<Encyclopedia>>(encyclopedias, EncyclopediaConstants.DataGet);
        }

        public IDataResult<Encyclopedia> GetById(Guid id)
        {
            Encyclopedia encyclopedia = _encyclopediaDal.Get(ep => ep.Id == id);
            return encyclopedia == null
                ? new ErrorDataResult<Encyclopedia>(EncyclopediaConstants.DataNotGet)
                : new SuccessDataResult<Encyclopedia>(encyclopedia, EncyclopediaConstants.DataGet);
        }

        public IDataResult<IList<Encyclopedia>> GetAllByIds(Guid[] ids)
        {
            IList<Encyclopedia> encyclopedias = _encyclopediaDal.GetAll(ep => ids.Contains(ep.Id) && !ep.IsDeleted);
            return encyclopedias == null
                ? new ErrorDataResult<IList<Encyclopedia>>(EncyclopediaConstants.DataNotGet)
                : new SuccessDataResult<IList<Encyclopedia>>(encyclopedias, EncyclopediaConstants.DataGet);
        }

        public IDataResult<IList<Encyclopedia>> GetAllByInterpreter(Guid interpreterId)
        {
            IDataResult<Interpreters> interpreter = _facadeService.InterpretersService().GetById(interpreterId);
            if (!interpreter.Success)
                return new ErrorDataResult<IList<Encyclopedia>>(interpreter.Message);

            IList<Encyclopedia> encyclopedias = _encyclopediaDal.GetAll(ep => ep.InterpretersId == interpreterId && !ep.IsDeleted);
            return encyclopedias == null
                ? new ErrorDataResult<IList<Encyclopedia>>(EncyclopediaConstants.DataGet)
                : new SuccessDataResult<IList<Encyclopedia>>(encyclopedias, EncyclopediaConstants.DataGet);
        }

        public IDataResult<IList<Encyclopedia>> GetAllByName(string name)
        {
            IList<Encyclopedia> encyclopedias = _encyclopediaDal.GetAll(ep => ep.Name.Contains(name) && !ep.IsDeleted);
            return encyclopedias == null
                ? new ErrorDataResult<IList<Encyclopedia>>(EncyclopediaConstants.DataNotGet)
                : new SuccessDataResult<IList<Encyclopedia>>(encyclopedias, EncyclopediaConstants.DataGet);
        }

        public IDataResult<IList<Encyclopedia>> GetAllByPrice(decimal minPrice, decimal? maxPrice = null)
        {
            IList<Encyclopedia> encyclopedias = maxPrice == null
                ? _encyclopediaDal.GetAll(ep => ep.Price == minPrice && !ep.IsDeleted)
                : _encyclopediaDal.GetAll(ep => ep.Price >= minPrice && ep.Price <= maxPrice && !ep.IsDeleted);

            return encyclopedias == null
                ? new ErrorDataResult<IList<Encyclopedia>>(EncyclopediaConstants.DataNotGet)
                : new SuccessDataResult<IList<Encyclopedia>>(encyclopedias, EncyclopediaConstants.DataGet);
        }

        public IDataResult<IList<Encyclopedia>> GetAllByPublisher(Guid publisherId)
        {
            IDataResult<Edition> edition = _facadeService.EditionService().GetByPublisherId(publisherId);
            if (!edition.Success)
                return new ErrorDataResult<IList<Encyclopedia>>(edition.Message);

            IList<Encyclopedia> encyclopedias = _encyclopediaDal.GetAll(ep => ep.EditionId == edition.Data.Id && !ep.IsDeleted);
            return encyclopedias == null
                ? new ErrorDataResult<IList<Encyclopedia>>(EncyclopediaConstants.DataNotGet)
                : new SuccessDataResult<IList<Encyclopedia>>(encyclopedias, EncyclopediaConstants.DataGet);
        }

        public IDataResult<IList<Encyclopedia>> GetAllByRedaction(Guid redactionId)
        {
            IDataResult<Redaction> redaction = _facadeService.RedactionService().GetById(redactionId);
            if (!redaction.Success)
                return new ErrorDataResult<IList<Encyclopedia>>(redaction.Message);

            IList<Encyclopedia> encyclopedias = _encyclopediaDal.GetAll(ep => ep.RedactionId == redactionId && !ep.IsDeleted);
            return encyclopedias == null
                ? new ErrorDataResult<IList<Encyclopedia>>(EncyclopediaConstants.DataNotGet)
                : new SuccessDataResult<IList<Encyclopedia>>(encyclopedias, EncyclopediaConstants.DataGet);
        }

        public IDataResult<IList<Encyclopedia>> GetAllBySequenceNumber(uint sequenceNumber)
        {
            IList<Encyclopedia> encyclopedias = _encyclopediaDal.GetAll(ep => ep.SequenceNumber == sequenceNumber && !ep.IsDeleted);
            return encyclopedias == null
                ? new ErrorDataResult<IList<Encyclopedia>>(EncyclopediaConstants.DataNotGet)
                : new SuccessDataResult<IList<Encyclopedia>>(encyclopedias, EncyclopediaConstants.DataGet);
        }

        public IDataResult<IList<Encyclopedia>> GetAllByTechnicalNumber(Guid technicalNumberId)
        {
            IDataResult<TechnicalNumber> techNumber = _facadeService.TechnicalNumberService().GetById(technicalNumberId);
            if (!techNumber.Success)
                return new ErrorDataResult<IList<Encyclopedia>>(techNumber.Message);

            IList<Encyclopedia> encyclopedias = _encyclopediaDal.GetAll(ep => ep.TechnicalNumberId == technicalNumberId && !ep.IsDeleted);
            return encyclopedias == null
                ? new ErrorDataResult<IList<Encyclopedia>>(EncyclopediaConstants.DataNotGet)
                : new SuccessDataResult<IList<Encyclopedia>>(encyclopedias, EncyclopediaConstants.DataGet);
        }

        public IDataResult<IList<Encyclopedia>> GetAllByTechnicalPlaceholder(Guid technicalPlaceholderId)
        {
            IDataResult<TechnicalPlaceholder> techPlaceHol = _facadeService.TechnicalPlaceholderService().GetById(technicalPlaceholderId);
            if (!techPlaceHol.Success)
                return new ErrorDataResult<IList<Encyclopedia>>(techPlaceHol.Message);

            IList<Encyclopedia> encyclopedias = _encyclopediaDal.GetAll(ep => ep.TechnicalPlaceholdersId == technicalPlaceholderId && !ep.IsDeleted);
            return encyclopedias == null
                ? new ErrorDataResult<IList<Encyclopedia>>(EncyclopediaConstants.DataNotGet)
                : new SuccessDataResult<IList<Encyclopedia>>(encyclopedias, EncyclopediaConstants.DataGet);
        }

        public IDataResult<IList<Encyclopedia>> GetAllByTitle(string title)
        {
            IList<Encyclopedia> encyclopedias = _encyclopediaDal.GetAll(ep => ep.Title.Contains(title) && !ep.IsDeleted);
            return encyclopedias == null
                ? new ErrorDataResult<IList<Encyclopedia>>(EncyclopediaConstants.DataNotGet)
                : new SuccessDataResult<IList<Encyclopedia>>(encyclopedias, EncyclopediaConstants.DataGet);
        }

        public IDataResult<IList<Encyclopedia>> GetAllByWriter(Guid writerId)
        {
            IDataResult<Writer> writer = _facadeService.WriterService().GetById(writerId);
            if (!writer.Success)
                return new ErrorDataResult<IList<Encyclopedia>>(writer.Message);

            IList<Encyclopedia> encyclopedias = _encyclopediaDal.GetAll(ep => ep.WriterId == writerId && !ep.IsDeleted);
            return encyclopedias == null
                ? new ErrorDataResult<IList<Encyclopedia>>(EncyclopediaConstants.DataNotGet)
                : new SuccessDataResult<IList<Encyclopedia>>(encyclopedias, EncyclopediaConstants.DataGet);
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
            IDataResult<Stock> stock = _facadeService.StockService().GetById(stockId);
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
