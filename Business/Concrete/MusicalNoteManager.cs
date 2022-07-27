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
    public class MusicalNoteManager : IMusicalNoteService
    {
        private readonly IMusicalNoteDal _musicalNoteDal;
        private readonly ICategoryService _categoryService;
        private readonly IComposerService _composerService;
        private readonly IDimensionService _dimensionService;
        private readonly IEMaterialFileService _eMaterialFileService;
        private readonly ITechnicalPlaceholderService _technicalPlaceholderService;
        private readonly IStockService _stockService;


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

        public IDataResult<List<MusicalNote>> GetAll()
        {
            return new SuccessDataResult<List<MusicalNote>>(_musicalNoteDal.GetAll(mn => !mn.IsSecret).ToList(), MusicalNoteConstants.DataGet);
        }

        public IDataResult<List<MusicalNote>> GetAllByCategories(int[] categoriesId)
        {
            IDataResult<List<Category>> categories = _categoryService.GetAllByIds(categoriesId);
            if (!categories.Success)
                return new ErrorDataResult<List<MusicalNote>>(categories.Message);

            List<MusicalNote> musicalNotes = _musicalNoteDal.GetAll(mn => mn.Categories == categories && !mn.IsDeleted).ToList();
            return musicalNotes == null
                ? new ErrorDataResult<List<MusicalNote>>(MusicalNoteConstants.DataNotGet)
                : new SuccessDataResult<List<MusicalNote>>(musicalNotes, MusicalNoteConstants.DataGet);
        }

        public IDataResult<List<MusicalNote>> GetAllByComposer(Guid composerId)
        {
            IDataResult<Composer> composer = _composerService.GetById(composerId);
            if (!composer.Success)
                return new ErrorDataResult<List<MusicalNote>>(composer.Message);

            List<MusicalNote> musicalNotes = _musicalNoteDal.GetAll(mn => mn.ComposerId == composerId && !mn.IsDeleted).ToList();
            return musicalNotes == null
                ? new ErrorDataResult<List<MusicalNote>>(MusicalNoteConstants.DataNotGet)
                : new SuccessDataResult<List<MusicalNote>>(musicalNotes, MusicalNoteConstants.DataGet);
        }

        public IDataResult<List<MusicalNote>> GetAllByComposers(Guid[] composerIds)
        {
            IDataResult<List<Composer>> composers = _composerService.GetAllByIds(composerIds);
            if (!composers.Success)
                return new ErrorDataResult<List<MusicalNote>>(composers.Message);

            List<MusicalNote> musicalNotes = _musicalNoteDal.GetAll(mn => mn.Composers == composers && !mn.IsDeleted).ToList();
            return musicalNotes == null
                ? new ErrorDataResult<List<MusicalNote>>(MusicalNoteConstants.DataNotGet)
                : new SuccessDataResult<List<MusicalNote>>(musicalNotes, MusicalNoteConstants.DataGet);
        }

        public IDataResult<List<MusicalNote>> GetAllByDateOfWriting(DateTime dateOfWriting)
        {
            List<MusicalNote> musicalNotes = _musicalNoteDal.GetAll(mn => mn.DateOfWriting == dateOfWriting && !mn.IsDeleted).ToList();
            return musicalNotes == null
                ? new ErrorDataResult<List<MusicalNote>>(MusicalNoteConstants.DataNotGet)
                : new SuccessDataResult<List<MusicalNote>>(musicalNotes, MusicalNoteConstants.DataGet);
        }

        public IDataResult<List<MusicalNote>> GetAllByDescriptionFinder(string finderString)
        {
            List<MusicalNote> musicalNotes = _musicalNoteDal.GetAll(mn => mn.Description.Contains(finderString) && !mn.IsDeleted).ToList();
            return musicalNotes == null
                ? new ErrorDataResult<List<MusicalNote>>(MusicalNoteConstants.DataNotGet)
                : new SuccessDataResult<List<MusicalNote>>(musicalNotes, MusicalNoteConstants.DataGet);
        }

        public IDataResult<List<MusicalNote>> GetAllByDimension(Guid dimensionId)
        {
            IDataResult<Dimension> dimmension = _dimensionService.GetById(dimensionId);
            if (!dimmension.Success)
                return new ErrorDataResult<List<MusicalNote>>(dimmension.Message);

            List<MusicalNote> musicalNotes = _musicalNoteDal.GetAll(mn => mn.DimensionsId == dimensionId && !mn.IsDeleted).ToList();
            return musicalNotes == null
                ? new ErrorDataResult<List<MusicalNote>>(MusicalNoteConstants.DataNotGet)
                : new SuccessDataResult<List<MusicalNote>>(musicalNotes, MusicalNoteConstants.DataGet);
        }

        public IDataResult<List<MusicalNote>> GetAllByEMFile(Guid eMFileId)
        {
            IDataResult<EMaterialFile> eMFile = _eMaterialFileService.GetById(eMFileId);
            if (!eMFile.Success)
                return new ErrorDataResult<List<MusicalNote>>(eMFile.Message);

            List<MusicalNote> musicalNotes = _musicalNoteDal.GetAll(mn => mn.EMaterialFilesId == eMFileId && !mn.IsDeleted).ToList();
            return musicalNotes == null
                ? new ErrorDataResult<List<MusicalNote>>(MusicalNoteConstants.DataNotGet)
                : new SuccessDataResult<List<MusicalNote>>(musicalNotes, MusicalNoteConstants.DataGet);
        }

        public IDataResult<List<MusicalNote>> GetAllByFilter(Expression<Func<MusicalNote, bool>>? filter = null)
        {
            return new SuccessDataResult<List<MusicalNote>>(_musicalNoteDal.GetAll(filter).ToList(), MusicalNoteConstants.DataGet);
        }

        public IDataResult<List<MusicalNote>> GetAllByIds(Guid[] ids)
        {
            List<MusicalNote> musicalNotes = _musicalNoteDal.GetAll(mn => ids.Contains(mn.Id) && !mn.IsDeleted).ToList();
            return musicalNotes == null
                ? new ErrorDataResult<List<MusicalNote>>(MusicalNoteConstants.DataNotGet)
                : new SuccessDataResult<List<MusicalNote>>(musicalNotes, MusicalNoteConstants.DataGet);
        }

        public IDataResult<List<MusicalNote>> GetAllByName(string name)
        {
            List<MusicalNote> musicalNotes = _musicalNoteDal.GetAll(mn => mn.Name.Contains(name) && !mn.IsDeleted).ToList();
            return musicalNotes == null
                ? new ErrorDataResult<List<MusicalNote>>(MusicalNoteConstants.DataNotGet)
                : new SuccessDataResult<List<MusicalNote>>(musicalNotes, MusicalNoteConstants.DataGet);
        }

        public IDataResult<List<MusicalNote>> GetAllByPrice(decimal minPrice, decimal? maxPrice = null)
        {
            List<MusicalNote> musicalNotes = maxPrice == null
                ? _musicalNoteDal.GetAll(mn => mn.Price == minPrice && !mn.IsDeleted).ToList()
                : _musicalNoteDal.GetAll(mn => mn.Price >= minPrice && mn.Price <= maxPrice && !mn.IsDeleted).ToList();

            return musicalNotes == null
                ? new ErrorDataResult<List<MusicalNote>>(MusicalNoteConstants.DataNotGet)
                : new SuccessDataResult<List<MusicalNote>>(musicalNotes, MusicalNoteConstants.DataGet);
        }

        public IDataResult<List<MusicalNote>> GetAllBySecret()
        {
            return new SuccessDataResult<List<MusicalNote>>(_musicalNoteDal.GetAll(mn => mn.IsSecret).ToList(), MusicalNoteConstants.DataGet);
        }

        public IDataResult<List<MusicalNote>> GetAllByTechnicalPlaceholder(Guid technicalPlaceholderId)
        {
            var techPlaceHolder = _technicalPlaceholderService.GetById(technicalPlaceholderId);
            if (!techPlaceHolder.Success)
                return new ErrorDataResult<List<MusicalNote>>(techPlaceHolder.Message);

            List<MusicalNote> musicalNotes = _musicalNoteDal.GetAll(mn => mn.TechnicalPlaceholdersId == technicalPlaceholderId && !mn.IsDeleted).ToList();
            return musicalNotes == null
                ? new ErrorDataResult<List<MusicalNote>>(MusicalNoteConstants.DataNotGet)
                : new SuccessDataResult<List<MusicalNote>>(musicalNotes, MusicalNoteConstants.DataGet);
        }

        public IDataResult<List<MusicalNote>> GetAllByTitle(string title)
        {
            List<MusicalNote> musicalNotes = _musicalNoteDal.GetAll(mn => mn.Title.Contains(title) && !mn.IsDeleted).ToList();
            return musicalNotes == null
                ? new ErrorDataResult<List<MusicalNote>>(MusicalNoteConstants.DataNotGet)
                : new SuccessDataResult<List<MusicalNote>>(musicalNotes, MusicalNoteConstants.DataGet);
        }

        public IDataResult<MusicalNote> GetById(Guid id)
        {
            MusicalNote musicalNote = _musicalNoteDal.Get(mn => mn.Id == id);
            return musicalNote == null
                ? new ErrorDataResult<MusicalNote>(MusicalNoteConstants.NotMatch)
                : new SuccessDataResult<MusicalNote>(musicalNote, MusicalNoteConstants.DataGet);
        }

        public IDataResult<MusicalNote> GetByStock(Guid stockId)
        {
            IDataResult<Stock> stock = _stockService.GetById(stockId);
            if (!stock.Success)
                return new ErrorDataResult<MusicalNote>(stock.Message);

            MusicalNote musicalNote = _musicalNoteDal.Get(mn => mn.StockId == stockId && !mn.IsDeleted);
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
            return new SuccessDataResult<byte>(_musicalNoteDal.Get(mn => !mn.IsSecret).State, MusicalNoteConstants.DataGet);
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
