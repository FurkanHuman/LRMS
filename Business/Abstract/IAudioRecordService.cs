using Business.Abstract.Base;
using Core.Utilities.Result.Abstract;
using Entities.Concrete;

namespace Business.Abstract
{
    public interface IAudioRecordService : IMaterialBaseService<AudioRecord>
    {
        IDataResult<List<AudioRecord>> GetByOwnerNames(string name);
        IDataResult<List<AudioRecord>> GetByRecordDate(DateTime recordDate);
        IDataResult<List<AudioRecord>> GetByRecordDate(DateTime recordDate, DateTime recordEndDate);
        IDataResult<List<AudioRecord>> GetByRecordingLength(float recordingLength);
        IDataResult<List<AudioRecord>> GetByRecordingLength(float recordingLengthMin, float recordingLengthMax);
    }
}
