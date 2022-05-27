using Business.Constants.Base;

namespace Business.Constants
{
    public class CommunicationConstants : BaseConstants
    {
        protected CommunicationConstants() { }

        public const string CommNameError = "Communication name must be between 5 and 50 characters and must not be empty.";
        public const string AddressNull = "The address must not be empty.";
        public const string PhoneNull = "The Phone must not be empty.";
        public const string EmailNull = "The email must not be empty.";
        public const string WebSiteNull = "The web site must not be empty.";
        public const string commExist = "Address already exists";
    }
}
