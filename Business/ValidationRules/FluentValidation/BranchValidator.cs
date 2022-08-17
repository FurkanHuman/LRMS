namespace Business.ValidationRules.FluentValidation
{
    public class BranchValidator : AbstractValidator<Branch>
    {
        public BranchValidator()
        {
            RuleFor<string>(b => b.Name).NotEmpty().NotNull().WithMessage(BranchConstants.BranchNameNull);
        }
    }
}
