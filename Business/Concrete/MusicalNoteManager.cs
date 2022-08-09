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
    public class MusicalNoteManager : IMusicalNoteService
    {
        private readonly IMusicalNoteDal _musicalNoteDal;
        private readonly IFacadeService _facadeService;

        public MusicalNoteManager(IMusicalNoteDal musicalNoteDal, IFacadeService facadeService)
        {
            _musicalNoteDal = musicalNoteDal;
            _facadeService = facadeService;
        }

        [ValidationAspect(typeof(MusicalNoteValidator), Priority = 1)]
        public IResult Add(MusicalNote musicalNote)
        {
            IResult result = BusinessRules.Run(MusicalNoteControl(musicalNote));
            if (result != null)
                return result;

            musicalNote.IsDeleted = false;
            _musicalNoteDal.Add(musicalNote);
            return new SuccessResult(MusicalNoteConstants.AddSuccess);
        }

        public IResult Delete(Guid id)
        {
            MusicalNote musicalNote = _musicalNoteDal.Get(mn => mn.Id == id);
            if (musicalNote == null)
                return new ErrorResult(MagazineConstants.NotMatch);

            _musicalNoteDal.Delete(musicalNote);
            return new SuccessResult(MusicalNoteConstants.DeleteSuccess);
        }

        public IResult ShadowDelete(Guid id)
        {
            MusicalNote musicalNote = _musicalNoteDal.Get(mn => mn.Id == id && !mn.IsDeleted);
            if (musicalNote == null)
                return new ErrorResult(MagazineConstants.NotMatch);

            musicalNote.IsDeleted = true;
            _musicalNoteDal.Update(musicalNote);
            return new SuccessResult(MusicalNoteConstants.DeleteSuccess);
        }

        [ValidationAspect(typeof(MusicalNoteValidator), Priority = 1)]
        public IResult Update(MusicalNote musicalNote)
        {
            IResult result = BusinessRules.Run(MusicalNoteControl(musicalNote));
            if (result != null)
                return result;

            musicalNote.IsDeleted = false;
            _musicalNoteDal.Update(musicalNote);
            return new SuccessResult(MusicalNoteConstants.UpdateSuccess);
        }

        public IDataResult<IList<MusicalNote>> GetAll()
        {
            return new SuccessDataResult<IList<MusicalNote>>(_musicalNoteDal.GetAll(mn => !mn.IsDeleted), MusicalNoteConstants.DataGet);
        }

        public IDataResult<IList<MusicalNote>> GetAllByCategories(int[] categoriesId)
        {
            IDataResult<IList<Category>> categories = _facadeService.CategoryService().GetAllByIds(categoriesId);
            if (!categories.Success)
                return new ErrorDataResult<IList<MusicalNote>>(categories.Message);

            IList<MusicalNote> musicalNotes = _musicalNoteDal.GetAll(mn => mn.Categories == categories && !mn.IsDeleted);
            return musicalNotes == null
                ? new ErrorDataResult<IList<MusicalNote>>(MusicalNoteConstants.DataNotGet)
                : new SuccessDataResult<IList<MusicalNote>>(musicalNotes, MusicalNoteConstants.DataGet);
        }

        public IDataResult<IList<MusicalNote>> GetAllByComposer(Guid composerId)
        {
            IDataResult<Composer> composer = _facadeService.ComposerService().GetById(composerId);
            if (!composer.Success)
                return new ErrorDataResult<IList<MusicalNote>>(composer.Message);

            IList<MusicalNote> musicalNotes = _musicalNoteDal.GetAll(mn => mn.ComposerId == composerId && !mn.IsDeleted);
            return musicalNotes == null
                ? new ErrorDataResult<IList<MusicalNote>>(MusicalNoteConstants.DataNotGet)
                : new SuccessDataResult<IList<MusicalNote>>(musicalNotes, MusicalNoteConstants.DataGet);
        }

        public IDataResult<IList<MusicalNote>> GetAllByComposers(Guid[] composerIds)
        {
            IDataResult<IList<Composer>> composers = _facadeService.ComposerService().GetAllByIds(composerIds);
            if (!composers.Success)
                return new ErrorDataResult<IList<MusicalNote>>(composers.Message);

            IList<MusicalNote> musicalNotes = _musicalNoteDal.GetAll(mn => mn.Composers == composers && !mn.IsDeleted);
            return musicalNotes == null
                ? new ErrorDataResult<IList<MusicalNote>>(MusicalNoteConstants.DataNotGet)
                : new SuccessDataResult<IList<MusicalNote>>(musicalNotes, MusicalNoteConstants.DataGet);
        }

        public IDataResult<IList<MusicalNote>> GetAllByDateOfWriting(DateTime dateOfWriting)
        {
            IList<MusicalNote> musicalNotes = _musicalNoteDal.GetAll(mn => mn.DateOfWriting == dateOfWriting && !mn.IsDeleted);
            return musicalNotes == null
                ? new ErrorDataResult<IList<MusicalNote>>(MusicalNoteConstants.DataNotGet)
                : new SuccessDataResult<IList<MusicalNote>>(musicalNotes, MusicalNoteConstants.DataGet);
        }

        public IDataResult<IList<MusicalNote>> GetAllByDescriptionFinder(string finderString)
        {
            IList<MusicalNote> musicalNotes = _musicalNoteDal.GetAll(mn => mn.Description.Contains(finderString) && !mn.IsDeleted);
            return musicalNotes == null
                ? new ErrorDataResult<IList<MusicalNote>>(MusicalNoteConstants.DataNotGet)
                : new SuccessDataResult<IList<MusicalNote>>(musicalNotes, MusicalNoteConstants.DataGet);
        }

        public IDataResult<IList<MusicalNote>> GetAllByDimension(Guid dimensionId)
        {
            IDataResult<Dimension> dimmension = _facadeService.DimensionService().GetById(dimensionId);
            if (!dimmension.Success)
                return new ErrorDataResult<IList<MusicalNote>>(dimmension.Message);

            IList<MusicalNote> musicalNotes = _musicalNoteDal.GetAll(mn => mn.DimensionsId == dimensionId && !mn.IsDeleted);
            return musicalNotes == null
                ? new ErrorDataResult<IList<MusicalNote>>(MusicalNoteConstants.DataNotGet)
                : new SuccessDataResult<IList<MusicalNote>>(musicalNotes, MusicalNoteConstants.DataGet);
        }

        public IDataResult<IList<MusicalNote>> GetAllByEMFile(Guid eMFileId)
        {
            IDataResult<EMaterialFile> eMFile = _facadeService.EMaterialFileService().GetById(eMFileId);
            if (!eMFile.Success)
                return new ErrorDataResult<IList<MusicalNote>>(eMFile.Message);

            IList<MusicalNote> musicalNotes = _musicalNoteDal.GetAll(mn => mn.EMaterialFilesId == eMFileId && !mn.IsDeleted);
            return musicalNotes == null
                ? new ErrorDataResult<IList<MusicalNote>>(MusicalNoteConstants.DataNotGet)
                : new SuccessDataResult<IList<MusicalNote>>(musicalNotes, MusicalNoteConstants.DataGet);
        }

        public IDataResult<IList<MusicalNote>> GetAllByFilter(Expression<Func<MusicalNote, bool>>? filter = null)
        {
            return new SuccessDataResult<IList<MusicalNote>>(_musicalNoteDal.GetAll(filter), MusicalNoteConstants.DataGet);
        }

        public IDataResult<IList<MusicalNote>> GetAllByIds(Guid[] ids)
        {
            IList<MusicalNote> musicalNotes = _musicalNoteDal.GetAll(mn => ids.Contains(mn.Id) && !mn.IsDeleted);
            _facadeService.CounterService().Count(musicalNotes);
            return musicalNotes == null
                ? new ErrorDataResult<IList<MusicalNote>>(MusicalNoteConstants.DataNotGet)
                : new SuccessDataResult<IList<MusicalNote>>(musicalNotes, MusicalNoteConstants.DataGet);
        }

        public IDataResult<IList<MusicalNote>> GetAllByName(string name)
        {
            IList<MusicalNote> musicalNotes = _musicalNoteDal.GetAll(mn => mn.Name.Contains(name) && !mn.IsDeleted);
            return musicalNotes == null
                ? new ErrorDataResult<IList<MusicalNote>>(MusicalNoteConstants.DataNotGet)
                : new SuccessDataResult<IList<MusicalNote>>(musicalNotes, MusicalNoteConstants.DataGet);
        }

        public IDataResult<IList<MusicalNote>> GetAllByPrice(decimal minPrice, decimal? maxPrice = null)
        {
            IList<MusicalNote> musicalNotes = maxPrice == null
                ? _musicalNoteDal.GetAll(mn => mn.Price == minPrice && !mn.IsDeleted)
                : _musicalNoteDal.GetAll(mn => mn.Price >= minPrice && mn.Price <= maxPrice && !mn.IsDeleted);

            return musicalNotes == null
                ? new ErrorDataResult<IList<MusicalNote>>(MusicalNoteConstants.DataNotGet)
                : new SuccessDataResult<IList<MusicalNote>>(musicalNotes, MusicalNoteConstants.DataGet);
        }

        public IDataResult<IList<MusicalNote>> GetAllByIsDeleted()
        {
            return new SuccessDataResult<IList<MusicalNote>>(_musicalNoteDal.GetAll(mn => mn.IsDeleted), MusicalNoteConstants.DataGet);
        }

        public IDataResult<IList<MusicalNote>> GetAllByTechnicalPlaceholder(Guid technicalPlaceholderId)
        {
            IDataResult<TechnicalPlaceholder> techPlaceHolder = _facadeService.TechnicalPlaceholderService().GetById(technicalPlaceholderId);
            if (!techPlaceHolder.Success)
                return new ErrorDataResult<IList<MusicalNote>>(techPlaceHolder.Message);

            IList<MusicalNote> musicalNotes = _musicalNoteDal.GetAll(mn => mn.TechnicalPlaceholdersId == technicalPlaceholderId && !mn.IsDeleted);
            return musicalNotes == null
                ? new ErrorDataResult<IList<MusicalNote>>(MusicalNoteConstants.DataNotGet)
                : new SuccessDataResult<IList<MusicalNote>>(musicalNotes, MusicalNoteConstants.DataGet);
        }

        public IDataResult<IList<MusicalNote>> GetAllByTitle(string title)
        {
            IList<MusicalNote> musicalNotes = _musicalNoteDal.GetAll(mn => mn.Title.Contains(title) && !mn.IsDeleted);
            return musicalNotes == null
                ? new ErrorDataResult<IList<MusicalNote>>(MusicalNoteConstants.DataNotGet)
                : new SuccessDataResult<IList<MusicalNote>>(musicalNotes, MusicalNoteConstants.DataGet);
        }

        public IDataResult<MusicalNote> GetById(Guid id)
        {
            MusicalNote musicalNote = _musicalNoteDal.Get(mn => mn.Id == id);
            _facadeService.CounterService().Count(musicalNote);
            return musicalNote == null
                ? new ErrorDataResult<MusicalNote>(MusicalNoteConstants.NotMatch)
                : new SuccessDataResult<MusicalNote>(musicalNote, MusicalNoteConstants.DataGet);
        }

        public IDataResult<MusicalNote> GetByStock(Guid stockId)
        {
            IDataResult<Stock> stock = _facadeService.StockService().GetById(stockId);
            if (!stock.Success)
                return new ErrorDataResult<MusicalNote>(stock.Message);

            MusicalNote musicalNote = _musicalNoteDal.Get(mn => mn.StockId == stockId && !mn.IsDeleted);
            _facadeService.CounterService().Count(musicalNote);
            return musicalNote == null
                ? new ErrorDataResult<MusicalNote>(MusicalNoteConstants.DataNotGet)
                : new SuccessDataResult<MusicalNote>(musicalNote, MusicalNoteConstants.DataGet);
        }

        public IDataResult<byte?> GetSecretLevel(Guid id)
        {
            byte? sLevel = _musicalNoteDal.Get(mn => mn.Id == id && !mn.IsDeleted).SecretLevel;

            return sLevel == null
                ? new ErrorDataResult<byte?>(MusicalNoteConstants.DataNotGet)
                : new ErrorDataResult<byte?>(sLevel, MusicalNoteConstants.DataGet);
        }

        public IDataResult<byte> GetState(Guid id)
        {
            return new SuccessDataResult<byte>(_musicalNoteDal.Get(mn => mn.Id == id && !mn.IsDeleted).State, MusicalNoteConstants.DataGet);
        }

        private IResult MusicalNoteControl(MusicalNote musicalNote)
        {
            bool mNControl = _musicalNoteDal.Get(mn =>
               mn.Name == musicalNote.Name
            && mn.Title == musicalNote.Title
            && mn.Description == musicalNote.Description
            && mn.CategoryId == musicalNote.CategoryId
            && mn.TechnicalPlaceholdersId == musicalNote.TechnicalPlaceholdersId
            && mn.DimensionsId == musicalNote.DimensionsId
            && mn.EMaterialFilesId == musicalNote.EMaterialFilesId
            && mn.State == musicalNote.State
            && mn.StockId == musicalNote.StockId
            && mn.ComposerId == musicalNote.ComposerId
            && mn.DateOfWriting == musicalNote.DateOfWriting
            ) != null;

            if (mNControl)
                return new ErrorResult(MusicalNoteConstants.AlreadyExists);

            return new SuccessResult();
        }
    }
}
