namespace Business.ValidationRules.FluentValidation
{
    public class OtherPeopleValidator : AbstractValidator<OtherPeople>
    {
        public OtherPeopleValidator()
        {
            RuleFor(op => op.Name).MinimumLength(2).MaximumLength(75).WithMessage(OtherPeopleConstants.NameLength);
            RuleFor(op => op.Name).NotEmpty().NotNull().WithMessage(OtherPeopleConstants.NameNull);

            RuleFor(op => op.SurName).MinimumLength(2).MaximumLength(75).WithMessage(OtherPeopleConstants.SurNameLength);
            RuleFor(op => op.SurName).NotEmpty().NotNull().WithMessage(OtherPeopleConstants.SurNameNull);

            RuleFor(op => op.Title).MinimumLength(3).MaximumLength(30).WithMessage(OtherPeopleConstants.TitleLength);
            RuleFor(op => op.Title).NotEmpty().NotNull().WithMessage(OtherPeopleConstants.TitleNull);

            RuleFor(op => op.NamePreAttachment).MinimumLength(3).MaximumLength(15).WithMessage(OtherPeopleConstants.NamePreAttacLength);
        }
    }
}
