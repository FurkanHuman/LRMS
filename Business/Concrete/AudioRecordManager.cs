﻿using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Business;
using Core.Utilities.Result.Abstract;
using Core.Utilities.Result.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
using System.Linq.Expressions;

namespace Business.Concrete
{
    public class AudioRecordManager : IAudioRecordService
    {
        private readonly IAudioRecordDal _audioRecordDal;

        public AudioRecordManager(IAudioRecordDal audioRecordDal)
        {
            _audioRecordDal = audioRecordDal;
        }

        [ValidationAspect(typeof(AudioRecordValidator), Priority = 1)]
        public IResult Add(AudioRecord entity)
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
            return new SuccessResult(AudioRecordConstants.EfDeletedSuccsess);
        }

        public IResult ShadowDelete(Guid id)
        {
            AudioRecord audioRecord = _audioRecordDal.Get(ar => ar.Id == id && ar.IsDeleted);
            if (audioRecord == null)
                return new ErrorResult(AudioRecordConstants.NotMatch);

            audioRecord.IsDeleted = true;
            _audioRecordDal.Update(audioRecord);
            return new SuccessResult(AudioRecordConstants.DeleteSuccess);
        }

        [ValidationAspect(typeof(AudioRecordValidator), Priority = 1)]
        public IResult Update(AudioRecord entity)
        {
            IResult result = BusinessRules.Run(CheckIfAudioRecordExists(entity));
            if (result != null)
                return result;

            entity.IsDeleted = false;
            _audioRecordDal.Update(entity);
            return new SuccessResult(AudioRecordConstants.UpdateSuccess);
        }

        public IDataResult<List<AudioRecord>> GetByCategories(int[] categoriesId)
        {
            List<AudioRecord> audioRecords = _audioRecordDal.GetAll(ar => categoriesId.Contains(ar.CategoryId) && !ar.IsDeleted).ToList();
            return audioRecords == null
                ? new ErrorDataResult<List<AudioRecord>>(AudioRecordConstants.DataNotGet)
                : new SuccessDataResult<List<AudioRecord>>(audioRecords, AudioRecordConstants.DataGet);
        }

        public IDataResult<List<AudioRecord>> GetByDescriptionFinder(string finderString)
        {
            List<AudioRecord> audioRecords = _audioRecordDal.GetAll(ar => ar.Description.Contains(finderString) && !ar.IsDeleted).ToList();
            return audioRecords == null
                ? new ErrorDataResult<List<AudioRecord>>(AudioRecordConstants.DataNotGet)
                : new SuccessDataResult<List<AudioRecord>>(audioRecords, AudioRecordConstants.DataGet);
        }

        public IDataResult<List<AudioRecord>> GetByDimension(Guid dimensionId)
        {
            List<AudioRecord> audioRecords = _audioRecordDal.GetAll(ar => ar.DimensionsId == dimensionId && !ar.IsDeleted).ToList();
            return audioRecords == null
                ? new ErrorDataResult<List<AudioRecord>>(AudioRecordConstants.DataNotGet)
                : new SuccessDataResult<List<AudioRecord>>(audioRecords, AudioRecordConstants.DataGet);
        }

        public IDataResult<List<AudioRecord>> GetByEMFiles(Guid eMFilesId)
        {
            List<AudioRecord> audioRecords = _audioRecordDal.GetAll(ar => ar.EMaterialFilesId == eMFilesId && !ar.IsDeleted).ToList();
            return audioRecords == null
                ? new ErrorDataResult<List<AudioRecord>>(AudioRecordConstants.DataNotGet)
                : new SuccessDataResult<List<AudioRecord>>(audioRecords, AudioRecordConstants.DataGet);
        }

        public IDataResult<AudioRecord> GetById(Guid id)
        {
            AudioRecord audioRecord = _audioRecordDal.Get(ar => ar.Id == id);
            return audioRecord == null
                ? new ErrorDataResult<AudioRecord>(AudioRecordConstants.NotMatch)
                : new SuccessDataResult<AudioRecord>(audioRecord, AudioRecordConstants.DataGet);
        }

        public IDataResult<List<AudioRecord>> GetByNames(string name)
        {
            List<AudioRecord> audioRecords = _audioRecordDal.GetAll(ar => ar.Name.Contains(name) && !ar.IsDeleted).ToList();
            return audioRecords == null
                ? new ErrorDataResult<List<AudioRecord>>(AudioRecordConstants.DataNotGet)
                : new SuccessDataResult<List<AudioRecord>>(audioRecords, AudioRecordConstants.DataGet);
        }

        public IDataResult<List<AudioRecord>> GetByOwnerNames(string name)
        {
            List<AudioRecord> audioRecords = _audioRecordDal.GetAll(ar => ar.Owner.Contains(name) && !ar.IsDeleted).ToList();
            return audioRecords == null
                ? new ErrorDataResult<List<AudioRecord>>(AudioRecordConstants.DataNotGet)
                : new SuccessDataResult<List<AudioRecord>>(audioRecords, AudioRecordConstants.DataGet);
        }

        public IDataResult<List<AudioRecord>> GetByPrice(decimal minPrice, decimal? maxPrice = null)
        {
            List<AudioRecord> audioRecords = maxPrice == null
                ? _audioRecordDal.GetAll(ar => ar.Price == minPrice && !ar.IsDeleted).ToList()
                : _audioRecordDal.GetAll(ar => ar.Price >= minPrice && ar.Price <= maxPrice && !ar.IsDeleted).ToList();

            return audioRecords == null
                ? new ErrorDataResult<List<AudioRecord>>(AcademicJournalConstants.DataNotGet)
                : new SuccessDataResult<List<AudioRecord>>(audioRecords, AudioRecordConstants.DataGet);
        }

        public IDataResult<List<AudioRecord>> GetByRecordDate(DateTime recordDate)
        {
            List<AudioRecord> audioRecords = _audioRecordDal.GetAll(ar => ar.RecordDate == recordDate && !ar.IsDeleted).ToList();
            return audioRecords == null
                 ? new ErrorDataResult<List<AudioRecord>>(AudioRecordConstants.DataNotGet)
                 : new SuccessDataResult<List<AudioRecord>>(audioRecords, AudioRecordConstants.DataGet);
        }

        public IDataResult<List<AudioRecord>> GetByRecordDate(DateTime recordDate, DateTime recordEndDate)
        {
            List<AudioRecord> audioRecords = _audioRecordDal.GetAll(ar => ar.RecordDate >= recordDate && ar.RecordEndDate <= recordEndDate && !ar.IsDeleted).ToList();
            return audioRecords.Count > 0
                ? new SuccessDataResult<List<AudioRecord>>(audioRecords, AudioRecordConstants.DataGet)
                : new ErrorDataResult<List<AudioRecord>>(AudioRecordConstants.DataNotGet);
        }

        public IDataResult<List<AudioRecord>> GetByRecordingLength(float recordingLength)
        {
            List<AudioRecord> audioRecords = _audioRecordDal.GetAll(ar => ar.RecordingLength == recordingLength && !ar.IsDeleted).ToList();
            return audioRecords != null
                ? new SuccessDataResult<List<AudioRecord>>(audioRecords, AcademicJournalConstants.DataGet)
                : new ErrorDataResult<List<AudioRecord>>(AcademicJournalConstants.DataNotGet);
        }

        public IDataResult<List<AudioRecord>> GetByRecordingLength(float recordingLengthMin, float recordingLengthMax)
        {
            List<AudioRecord> audioRecords = _audioRecordDal.GetAll(ar => ar.RecordingLength >= recordingLengthMin && ar.RecordingLength <= recordingLengthMax && !ar.IsDeleted).ToList();
            return audioRecords.Count > 0
                ? new SuccessDataResult<List<AudioRecord>>(audioRecords, AudioRecordConstants.DataGet)
                : new ErrorDataResult<List<AudioRecord>>(AudioRecordConstants.DataNotGet);
        }

        public IDataResult<List<AudioRecord>> GetByTitles(string title)
        {
            List<AudioRecord> audioRecords = _audioRecordDal.GetAll(ar => ar.Title.Contains(title) && !ar.IsDeleted).ToList();

            return audioRecords.Count > 0
                ? new SuccessDataResult<List<AudioRecord>>(audioRecords, AudioRecordConstants.DataGet)
                : new ErrorDataResult<List<AudioRecord>>(AudioRecordConstants.DataNotGet);
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
            AudioRecord audioRecord = _audioRecordDal.Get(ar => ar.Id == id && !ar.IsDeleted);
            return audioRecord == null
                ? new ErrorDataResult<byte>(AudioRecordConstants.NotMatch)
                : new SuccessDataResult<byte>(audioRecord.State, AudioRecordConstants.DataGet);
        }

        public IDataResult<List<AudioRecord>> GetAllByFilter(Expression<Func<AudioRecord, bool>>? filter = null)
        {
            return new SuccessDataResult<List<AudioRecord>>(_audioRecordDal.GetAll(filter).ToList(), AudioRecordConstants.DataGet);
        }

        public IDataResult<List<AudioRecord>> GetAllBySecrets()
        {
            return new SuccessDataResult<List<AudioRecord>>(_audioRecordDal.GetAll(ar => ar.IsDeleted).ToList(), AudioRecordConstants.DataGet);
        }

        public IDataResult<List<AudioRecord>> GetAll()
        {
            return new SuccessDataResult<List<AudioRecord>>(_audioRecordDal.GetAll(ar => !ar.IsDeleted).ToList(), AudioRecordConstants.DataGet);
        }

        private IResult CheckIfAudioRecordExists(AudioRecord entity)
        {
            bool isExists = _audioRecordDal.Get(ar =>
            ar.Id == entity.Id
            && ar.Name == entity.Name
            && ar.Owner == entity.Owner
            && ar.Description == entity.Description
            && ar.Title == entity.Title
            && ar.TechnicalPlaceholdersId == entity.TechnicalPlaceholdersId
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