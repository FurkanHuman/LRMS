namespace Business.Constants
{
    public class ReferenceConstants : BaseConstants
    {
        protected ReferenceConstants() { }

        public const string OwnerNull = "The Reference owner must contain at least 3 characters and cannot be blank";
        public const string StartPageNumber = "the start page cannot be blank";
        public const string DateNull = "The reference date cannot be blank";
        public const string ReferenceExist = "this Reference already exists";
        public const string TechNull = "technical number id cannot be empty";
        public const string DateError = "The reference date cannot be greater than 10 days";
    }
}
