namespace Business.ValidationRules.FluentValidation
{
    public class EditorValidator : AbstractValidator<Editor>
    {
        public EditorValidator()
        {
            RuleFor(r => r.Name).NotEmpty().NotNull().WithMessage(EditorConstants.EditorNameNull);
            RuleFor(r => r.Name).MinimumLength(3).WithMessage(EditorConstants.EditorNameLengthNotEnough);
            RuleFor(r => r.SurName).NotEmpty().NotNull().WithMessage(EditorConstants.EditorSurnameNull);
        }
    }
}
