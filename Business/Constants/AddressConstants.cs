using Business.Constants.Base;

namespace Business.Constants
{
    public class AddressConstants : BaseConstants
    {
        protected AddressConstants() { }

        public const string PostalCodeNull = "Postal code is null.";
        public const string PostalCodeLength = "the Postal code length must be between 3 and 10. ";
        public const string AddressLengthNull = "Address null.";
        public const string AddressLength = "the Address length must be between 5 and 50.";
        public const string CountryIdNull = "Country id is null";
        public const string CityIdNull = "City id is null";
    }
}