namespace Business.Constants.Base
{
    public class BaseConstants
    {
        protected BaseConstants() { }

        protected enum SecretLevels
        {
            NotSecret
        }

        protected enum StateLevels
        {
            Anormal,
            Normal,
            obsolete,
            sensitive,
            Lost
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
        public const string NameRequired = "Name is required";
        public const string FpNameLengthRangeMinMax = "Name length must be between {0} and {1} characters.";
        public const string SurnameRequired = "Surname is required";
        public const string FpSurnameLengthRangeMinMax = "Surname length must be between {0} and {1} characters.";
        public const string NameLengthRangeMinMax = "Name length must be between 3 and 56";
        public const string TitleRequired = "Title is required";
        public const string TitleLengthRangeMinMax = "Title length must be between 3 and 75";
        public const string DescriptionRequired = "Description is required";
        public const string DescriptionLengthRangeMinMax = "Description length must be between 3 and 500";
        public const string CategoryIdRequired = "Category is required";
        public const string TechnicalPlaceholdersIdRequired = "TechnicalPlaceholders is required";
        public const string StateRequired = "State is required";
        public const string CoverCapIdRequired = "CoverCapId is required";
        public const string CoverImageIdRequired = "CoverImageId is required";
        public const string WriterIdRequired = "WriterId is required";
        public const string EditorIdRequired = "EditorId is required";
        public const string TechnicalNumberIdRequired = "TechnicalNumberId is required";
        public const string EditionIdRequired = "EditionId is required";
        public const string ReferenceIdRequired = "ReferenceId is required";
        public const string BookSeriesIdRequired = "BookSeriesId is required";
        public const string ImageIdRequired = "ImageId is required";
        public const string UniversityIdRequired = "UniversityId is required";
        public const string ResearcherIdRequired = "ResearcherId is required";

    }
}
