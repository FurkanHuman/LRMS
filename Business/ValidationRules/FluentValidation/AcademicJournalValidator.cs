namespace Business.ValidationRules.FluentValidation
{
    public class AcademicJournalValidator : MaterialBaseValidator<AcademicJournal>
    {
        public AcademicJournalValidator()
        {
            RuleFor(aj => aj.ResearcherId).NotEmpty().NotNull().WithMessage(AcademicJournalConstants.ResearcherIdRequired);
            RuleFor(aj => aj.EditorId).NotEmpty().NotNull().WithMessage(AcademicJournalConstants.EditorIdRequired);
            RuleFor(aj => aj.PublisherId).NotEmpty().NotNull().WithMessage(AcademicJournalConstants.PublisherIdRequired);
            RuleFor(aj => aj.ReferenceId).NotEmpty().NotNull().WithMessage(AcademicJournalConstants.ReferenceIdRequired);
            RuleFor(aj => aj.DateOfYear).NotEmpty().NotNull().WithMessage(AcademicJournalConstants.DateOfYearRequired);
            RuleFor(aj => aj.Volume).NotEmpty().NotNull().WithMessage(AcademicJournalConstants.VolumeRequired);
            RuleFor(aj => aj.AJNumber).NotEmpty().NotNull().WithMessage(AcademicJournalConstants.AJNumberRequired);
            RuleFor(aj => aj.StartPageNumber).NotEmpty().NotNull().WithMessage(AcademicJournalConstants.StartPageNumberRequired);
            RuleFor(aj => aj.EndPageNumber).NotEmpty().NotNull().WithMessage(AcademicJournalConstants.EndPageNumberRequired);
        }
    }
}
