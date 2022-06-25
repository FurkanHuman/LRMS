using Business.Constants.Base;

namespace Business.Constants
{
    public class DimensionConstants : BaseConstants
    {
        protected DimensionConstants() { }

        public const string WidthNull = "Width cannot be empty.";
        public const string LengthNull = "Length cannot be length.";
        public const string HeightNull = "Height can be zero. cannot be empty.";
        public const string DimensionAlreadyExists = "Dimension already exists.";
        public const string NameLengthError = "name length error. Must be between 2 and 25";
    }
}
