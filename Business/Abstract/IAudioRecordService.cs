using Business.Abstract.Base;
using Core.Utilities.Result.Abstract;
using Entities.Concrete;

namespace Business.Abstract
{
    public interface IAudioRecordService : IMaterialBaseService<AudioRecord>
    {
        IDataResult<IList<AudioRecord>> GetAllByOwnerName(string name);
        IDataResult<IList<AudioRecord>> GetAllByRecordDate(DateTime recordDate);
        IDataResult<IList<AudioRecord>> GetAllByRecordDate(DateTime recordDate, DateTime recordEndDate);
        IDataResult<IList<AudioRecord>> GetAllByRecordingLength(float recordingLength);
        IDataResult<IList<AudioRecord>> GetAllByRecordingLength(float recordingLengthMin, float recordingLengthMax);
    }
}
