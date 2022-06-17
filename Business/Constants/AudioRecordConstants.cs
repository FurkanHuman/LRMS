using Business.Constants.Base;

namespace Business.Constants
{
    public class AudioRecordConstants : BaseConstants
    {
        protected AudioRecordConstants() { }

        public const string OwnerNull = "Owner can not be null";
        public const string RecordDateNull = "RecordDate can not be null";
        public const string RecordingLengthNull = "RecordingLength can not be null";
    }
}
