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
    public class AudioRecordManager : IAudioRecordService
    {
        private readonly IAudioRecordDal _audioRecordDal;
        private readonly ICategoryService _categoryService;
        private readonly ITechnicalPlaceholderService _technicalPlaceholderService;
        private readonly IDimensionService _dimensionService;
        private readonly IEMaterialFileService _eMaterialFileService;
        private readonly IStockService _stockService;

        public AudioRecordManager(IAudioRecordDal audioRecordDal, ICategoryService categoryService, ITechnicalPlaceholderService technicalPlaceholderService, IDimensionService dimensionService, IEMaterialFileService eMaterialFileService, IStockService stockService)
        {
            _audioRecordDal = audioRecordDal;
            _categoryService = categoryService;
            _technicalPlaceholderService = technicalPlaceholderService;
            _dimensionService = dimensionService;
            _eMaterialFileService = eMaterialFileService;
            _stockService = stockService;
        }

        [ValidationAspect(typeof(AudioRecordValidator), Priority = 1)]
        public IResult Add(AudioRecord entity)// add a other services add Todo
        {
            IResult result = BusinessRules.Run(CheckIfAudioRecordExists(entity));
            if (result != null)
                return result;

            entity.IsDeleted = false;
            _audioRecordDal.Add(entity);
            return new SuccessResult(AudioRecordConstants.AddSuccess);
        }

        public IResult Delete(Guid id)
        {
            AudioRecord audioRecord = _audioRecordDal.Get(aj => aj.Id == id);
            if (audioRecord == null)
                return new ErrorResult(AudioRecordConstants.NotMatch);

            _audioRecordDal.Delete(audioRecord);
            return new SuccessResult(AudioRecordConstants.DeleteSuccess);
        }

        public IResult ShadowDelete(Guid id)
        {
            AudioRecord audioRecord = _audioRecordDal.Get(ar => ar.Id == id && ar.IsDeleted);
            if (audioRecord == null)
                return new ErrorResult(AudioRecordConstants.NotMatch);

            audioRecord.IsDeleted = true;
            _audioRecordDal.Update(audioRecord);
            return new SuccessResult(AudioRecordConstants.EfDeletedSuccsess);
        }

        [ValidationAspect(typeof(AudioRecordValidator), Priority = 1)]
        public IResult Update(AudioRecord entity)// other service update add todo
        {
            IResult result = BusinessRules.Run(CheckIfAudioRecordExists(entity));
            if (result != null)
                return result;

            entity.IsDeleted = false;
            _audioRecordDal.Update(entity);
            return new SuccessResult(AudioRecordConstants.UpdateSuccess);
        }

        public IDataResult<IList<AudioRecord>> GetAllByCategories(int[] categoriesId)
        {
            IDataResult<IList<Category>> categories = _categoryService.GetAllByFilter(c => categoriesId.Contains(c.Id));
            if (!categories.Success)
                return new ErrorDataResult<IList<AudioRecord>>(categories.Message);

            IList<AudioRecord> audioRecords = _audioRecordDal.GetAll(ar => categories.Data.Select(c => c.Id).Contains(ar.CategoryId) && !ar.IsDeleted);
            return audioRecords == null
                ? new ErrorDataResult<IList<AudioRecord>>(AudioRecordConstants.DataNotGet)
                : new SuccessDataResult<IList<AudioRecord>>(audioRecords, AudioRecordConstants.DataGet);
        }

        public IDataResult<IList<AudioRecord>> GetAllByDescriptionFinder(string finderString)
        {
            IList<AudioRecord> audioRecords = _audioRecordDal.GetAll(ar => ar.Description.Contains(finderString) && !ar.IsDeleted);
            return audioRecords == null
                ? new ErrorDataResult<IList<AudioRecord>>(AudioRecordConstants.DataNotGet)
                : new SuccessDataResult<IList<AudioRecord>>(audioRecords, AudioRecordConstants.DataGet);
        }

        public IDataResult<IList<AudioRecord>> GetAllByDimension(Guid dimensionId)
        {
            IDataResult<Dimension> dimension = _dimensionService.GetById(dimensionId);
            if (!dimension.Success)
                return new ErrorDataResult<IList<AudioRecord>>(dimension.Message);

            IList<AudioRecord> audioRecords = _audioRecordDal.GetAll(ar => ar.DimensionsId == dimensionId && !ar.IsDeleted);
            return audioRecords == null
                ? new ErrorDataResult<IList<AudioRecord>>(AudioRecordConstants.DataNotGet)
                : new SuccessDataResult<IList<AudioRecord>>(audioRecords, AudioRecordConstants.DataGet);
        }

        public IDataResult<IList<AudioRecord>> GetAllByEMFile(Guid eMFilesId)
        {
            IDataResult<EMaterialFile> eMaterialFile = _eMaterialFileService.GetById(eMFilesId);
            if (!eMaterialFile.Success)
                return new ErrorDataResult<IList<AudioRecord>>(eMaterialFile.Message);

            IList<AudioRecord> audioRecords = _audioRecordDal.GetAll(ar => ar.EMaterialFilesId == eMFilesId && !ar.IsDeleted);
            return audioRecords == null
                ? new ErrorDataResult<IList<AudioRecord>>(AudioRecordConstants.DataNotGet)
                : new SuccessDataResult<IList<AudioRecord>>(audioRecords, AudioRecordConstants.DataGet);
        }

        public IDataResult<AudioRecord> GetById(Guid id)
        {
            AudioRecord audioRecord = _audioRecordDal.Get(ar => ar.Id == id);
            return audioRecord == null
                ? new ErrorDataResult<AudioRecord>(AudioRecordConstants.NotMatch)
                : new SuccessDataResult<AudioRecord>(audioRecord, AudioRecordConstants.DataGet);
        }

        public IDataResult<IList<AudioRecord>> GetAllByIds(Guid[] ids)
        {
            IList<AudioRecord> audioRecords = _audioRecordDal.GetAll(ar => ids.Contains(ar.Id) && !ar.IsDeleted);
            return audioRecords == null
                ? new ErrorDataResult<IList<AudioRecord>>(AudioRecordConstants.DataNotGet)
                : new SuccessDataResult<IList<AudioRecord>>(audioRecords, AudioRecordConstants.DataGet);
        }

        public IDataResult<IList<AudioRecord>> GetAllByName(string name)
        {
            IList<AudioRecord> audioRecords = _audioRecordDal.GetAll(ar => ar.Name.Contains(name) && !ar.IsDeleted);
            return audioRecords == null
                ? new ErrorDataResult<IList<AudioRecord>>(AudioRecordConstants.DataNotGet)
                : new SuccessDataResult<IList<AudioRecord>>(audioRecords, AudioRecordConstants.DataGet);
        }

        public IDataResult<IList<AudioRecord>> GetAllByOwnerName(string name)
        {
            IList<AudioRecord> audioRecords = _audioRecordDal.GetAll(ar => ar.Owner.Contains(name) && !ar.IsDeleted);
            return audioRecords == null
                ? new ErrorDataResult<IList<AudioRecord>>(AudioRecordConstants.DataNotGet)
                : new SuccessDataResult<IList<AudioRecord>>(audioRecords, AudioRecordConstants.DataGet);
        }

        public IDataResult<IList<AudioRecord>> GetAllByPrice(decimal minPrice, decimal? maxPrice = null)
        {
            IList<AudioRecord> audioRecords = maxPrice == null
                ? _audioRecordDal.GetAll(ar => ar.Price == minPrice && !ar.IsDeleted)
                : _audioRecordDal.GetAll(ar => ar.Price >= minPrice && ar.Price <= maxPrice && !ar.IsDeleted);

            return audioRecords == null
                ? new ErrorDataResult<IList<AudioRecord>>(AcademicJournalConstants.DataNotGet)
                : new SuccessDataResult<IList<AudioRecord>>(audioRecords, AudioRecordConstants.DataGet);
        }

        public IDataResult<IList<AudioRecord>> GetAllByRecordDate(DateTime recordDate)
        {
            IList<AudioRecord> audioRecords = _audioRecordDal.GetAll(ar => ar.RecordDate == recordDate && !ar.IsDeleted);
            return audioRecords == null
                 ? new ErrorDataResult<IList<AudioRecord>>(AudioRecordConstants.DataNotGet)
                 : new SuccessDataResult<IList<AudioRecord>>(audioRecords, AudioRecordConstants.DataGet);
        }

        public IDataResult<IList<AudioRecord>> GetAllByRecordDate(DateTime recordDate, DateTime recordEndDate)
        {
            IList<AudioRecord> audioRecords = _audioRecordDal.GetAll(ar => ar.RecordDate >= recordDate && ar.RecordEndDate <= recordEndDate && !ar.IsDeleted);
            return audioRecords.Count > 0
                ? new SuccessDataResult<IList<AudioRecord>>(audioRecords, AudioRecordConstants.DataGet)
                : new ErrorDataResult<IList<AudioRecord>>(AudioRecordConstants.DataNotGet);
        }

        public IDataResult<IList<AudioRecord>> GetAllByRecordingLength(float recordingLength)
        {
            IList<AudioRecord> audioRecords = _audioRecordDal.GetAll(ar => ar.RecordingLength == recordingLength && !ar.IsDeleted);
            return audioRecords != null
                ? new SuccessDataResult<IList<AudioRecord>>(audioRecords, AcademicJournalConstants.DataGet)
                : new ErrorDataResult<IList<AudioRecord>>(AcademicJournalConstants.DataNotGet);
        }

        public IDataResult<IList<AudioRecord>> GetAllByRecordingLength(float recordingLengthMin, float recordingLengthMax)
        {
            IList<AudioRecord> audioRecords = _audioRecordDal.GetAll(ar => ar.RecordingLength >= recordingLengthMin && ar.RecordingLength <= recordingLengthMax && !ar.IsDeleted);
            return audioRecords.Count > 0
                ? new SuccessDataResult<IList<AudioRecord>>(audioRecords, AudioRecordConstants.DataGet)
                : new ErrorDataResult<IList<AudioRecord>>(AudioRecordConstants.DataNotGet);
        }

        public IDataResult<IList<AudioRecord>> GetAllByTitle(string title)
        {
            IList<AudioRecord> audioRecords = _audioRecordDal.GetAll(ar => ar.Title.Contains(title) && !ar.IsDeleted);

            return audioRecords.Count > 0
                ? new SuccessDataResult<IList<AudioRecord>>(audioRecords, AudioRecordConstants.DataGet)
                : new ErrorDataResult<IList<AudioRecord>>(AudioRecordConstants.DataNotGet);
        }

        public IDataResult<IList<AudioRecord>> GetAllByTechnicalPlaceholder(Guid technicalPlaceholderId)
        {
            IDataResult<TechnicalPlaceholder> technicalPlaceholder = _technicalPlaceholderService.GetById(technicalPlaceholderId);
            if (!technicalPlaceholder.Success)
                return new ErrorDataResult<IList<AudioRecord>>(technicalPlaceholder.Message);

            IList<AudioRecord> audioRecords = _audioRecordDal.GetAll(ar => ar.TechnicalPlaceholders == technicalPlaceholder && !ar.IsDeleted);
            return audioRecords == null
                ? new ErrorDataResult<IList<AudioRecord>>(AudioRecordConstants.DataNotGet)
                : new SuccessDataResult<IList<AudioRecord>>(audioRecords, AudioRecordConstants.DataGet);
        }

        public IDataResult<byte?> GetSecretLevel(Guid id)
        {
            AudioRecord audioRecord = _audioRecordDal.Get(ar => ar.Id == id && !ar.IsDeleted);
            return audioRecord == null
                ? new ErrorDataResult<byte?>(AudioRecordConstants.NotMatch)
                : new SuccessDataResult<byte?>(audioRecord.SecretLevel, AudioRecordConstants.DataGet);
        }

        public IDataResult<byte> GetState(Guid id)
        {
            return new SuccessDataResult<byte>(_audioRecordDal.Get(ar => ar.Id == id && !ar.IsDeleted).State, AudioRecordConstants.DataGet);
        }

        public IDataResult<IList<AudioRecord>> GetAllByFilter(Expression<Func<AudioRecord, bool>>? filter = null)
        {
            return new SuccessDataResult<IList<AudioRecord>>(_audioRecordDal.GetAll(filter), AudioRecordConstants.DataGet);
        }

        public IDataResult<IList<AudioRecord>> GetAllByIsDeleted()
        {
            return new SuccessDataResult<IList<AudioRecord>>(_audioRecordDal.GetAll(ar => ar.IsDeleted), AudioRecordConstants.DataGet);
        }

        public IDataResult<IList<AudioRecord>> GetAll()
        {
            return new SuccessDataResult<IList<AudioRecord>>(_audioRecordDal.GetAll(ar => !ar.IsDeleted), AudioRecordConstants.DataGet);
        }

        public IDataResult<AudioRecord> GetByStock(Guid stockId)
        {
            IDataResult<Stock> stock = _stockService.GetById(stockId);
            if (!stock.Success)
                return new ErrorDataResult<AudioRecord>(stock.Message);

            AudioRecord audioRecord = _audioRecordDal.Get(ar => ar.Stock == stock.Data && !ar.IsDeleted);
            return audioRecord == null
                ? new ErrorDataResult<AudioRecord>(AudioRecordConstants.NotMatch)
                : new SuccessDataResult<AudioRecord>(audioRecord, AudioRecordConstants.DataGet);
        }

        private IResult CheckIfAudioRecordExists(AudioRecord entity)
        {
            bool isExists = _audioRecordDal.Get(ar =>
            ar.Id == entity.Id
            && ar.Name == entity.Name
            && ar.Owner == entity.Owner
            && ar.Description == entity.Description
            && ar.Title == entity.Title
            && ar.Price == entity.Price
            && ar.RecordDate == entity.RecordDate
            && ar.RecordEndDate == entity.RecordEndDate
            && ar.RecordingLength == entity.RecordingLength
            ) != null;

            return isExists
                ? new ErrorResult(AudioRecordConstants.AlreadyExists)
                : new SuccessResult();
        }
    }
}
