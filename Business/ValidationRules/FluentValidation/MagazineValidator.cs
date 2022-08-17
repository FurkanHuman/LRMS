namespace Business.ValidationRules.FluentValidation
{
    public class MagazineValidator : BasePaperValidator<Magazine>
    {
        public MagazineValidator()
        {
            RuleFor(m => m.MagazineType).NotEmpty().NotNull().WithMessage(MagazineConstants.TypeNull);
            RuleFor(m => m.Volume).NotEmpty().NotNull().WithMessage(MagazineConstants.VolumeNull);
        }
    }
}
