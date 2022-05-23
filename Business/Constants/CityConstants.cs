using Business.Constants.Base;

namespace Business.Constants
{
    public class CityConstants : BaseConstants
    {
        protected CityConstants() { }

        public const string CityExist = "City already exist.";
        public const string CityNameNull = "City name is null";
        public const string CityAddedNotDeleted = "It cannot be deleted as a shadow when adding a city. Don't try :)";
        public const string CityNotFound = "City not found.";
        public const string CityNamelength = "The city name is too long. Don't you get tired of saying?";
    }
}
