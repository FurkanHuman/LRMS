namespace Business.ValidationRules.FluentValidation
{
    public class DepictionValidator : MaterialBaseValidator<Depiction>
    {
        public DepictionValidator()
        {
            RuleFor(d => d.Image).NotEmpty().NotNull().WithMessage(DepictionConstants.ImageIdRequired);
        }
    }
}
