using Business.Constants.Base;

namespace Business.Constants
{
    public class EMaterialFileConstants : BaseConstants
    {
        protected EMaterialFileConstants() { }

        public static readonly string[] FileExtension = { ".pdf", ".docx", ".doc", ".tiff", ".epub" };
        public const string FileNameNull = "File Name not null.";
        public const string FileTitleNull = "File Title not null.";
        public const string DeleteFailed = "invalid ID, File deletion failed";
    }
}
