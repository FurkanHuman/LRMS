using Business.Constants.Base;

namespace Business.Constants
{
    public class LibraryConstants : BaseConstants
    {
        protected LibraryConstants() { }
        // todo re turn Code.research a lib type
        public enum LibraryTypes
        {
            Other
        }

        public const string LibraryExist = "this library is exist.";
        public const string NameNull = "Library name is null.";
        public const string LibraryTypeNull = "Library Type Null.";
    }
}
