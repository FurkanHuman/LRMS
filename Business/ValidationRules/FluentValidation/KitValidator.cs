namespace Business.ValidationRules.FluentValidation
{
    public class KitValidator : MaterialBaseValidator<Kit>
    {
        public KitValidator()
        {
            RuleFor(k => k.IsKitBroken).NotEmpty().NotNull().WithMessage(KitConstants.KitBrokenNull);
        }
    }
}
