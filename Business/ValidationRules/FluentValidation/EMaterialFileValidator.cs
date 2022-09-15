namespace Business.ValidationRules.FluentValidation
{
    public class EMaterialFileValidator : AbstractValidator<EMaterialFile>
    {
        public EMaterialFileValidator()
        {
            RuleFor<string>(EM => EM.Name).NotNull().NotEmpty().WithMessage(EMaterialFileConstants.FileNameNull);
            RuleFor<string>(EM => EM.Title).NotNull().NotEmpty().WithMessage(EMaterialFileConstants.FileTitleNull);

        }
    }
}
