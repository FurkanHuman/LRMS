using Business.Constants.Base;

namespace Business.Constants
{
    public class CountryConstants : BaseConstants
    {
        public const string CountryNameNull = "Country name is null.";
        public const string CountryNameLong = "Country name too long.";
        public const string CountryCodeNull = "Country code is null.";
        public const string CountryCodeLong = "Country code too long.";
        public const string CountryCityNull = "Must be at least one city";
        public const string CountryNameAndCodeAndCitiesNotMatch = "Country Name And Code And Cities do not match.";
    }
}
