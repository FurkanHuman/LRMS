using Business.Abstract.Base;
using Core.Utilities.Result.Abstract;
using Entities.Concrete;

namespace Business.Abstract
{
    public interface IAudioRecordService : IMaterialBaseService<AudioRecord>
    {
        IDataResult<List<AudioRecord>> GetAllByOwnerName(string name);
        IDataResult<List<AudioRecord>> GetAllByRecordDate(DateTime recordDate);
        IDataResult<List<AudioRecord>> GetAllByRecordDate(DateTime recordDate, DateTime recordEndDate);
        IDataResult<List<AudioRecord>> GetAllByRecordingLength(float recordingLength);
        IDataResult<List<AudioRecord>> GetAllByRecordingLength(float recordingLengthMin, float recordingLengthMax);
    }
}
