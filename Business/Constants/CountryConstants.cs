using Business.Constants.Base;

namespace Business.Constants
{
    public class CountryConstants : BaseConstants
    {
        protected CountryConstants() { }

        public const string CountryNameNull = "Country name is null.";
        public const string CountryNameLong = "Country name too long.";
        public const string CountryCodeNull = "Country code is null.";
        public const string CountryCodeLong = "Country code too long.";
        public const string CountryNameAndCodeNotMatch = "Country Name And Code do not match.";
        public const string CountryNotFound = "Country not found.";
    }
}
