namespace Business.Constants.Base
{
    public class BaseConstants
    {
        protected BaseConstants() { }

        protected enum SecretLevels
        {
            NotSecret
        }

        public const string AlreadyExists = "Data already exists";
        public const string AddSuccess = "Adding succeeded.";
        public const string UpdateSuccess = "Update succeeded.";
        public const string DeleteSuccess = "Delete succeeded.";
        public const string ShadowDeleteSuccess = "Shadow delete succeeded.";
        public const string NameOrSurnameExists = "Name or Surname conflicts.";
        public const string DataNotGet = "Data not get.";
        public const string NotMatch = "No match found.";
        public const string InvalidFileSize = "Invalid file size.";
        public const string InvalidFileExtension = "Invalid file extension.";
        public const string DataNotSet = "Data not set.";
        public const string DataGet = "Data fetch succeeded.";
        public const string EfDeletedSuccsess = "Effectively deleted.";
        public const string Disabled = "Disabled";
        public const string Maintenance = "In maintenance phase.";
        public const string Test = "Testing, there may be an incorrect result";
        public const string BuildedTime = "this medhod builded a time ago, but not was write a code.";
    }
}
