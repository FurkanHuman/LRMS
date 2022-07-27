using Business.Constants;
using Business.ValidationRules.FluentValidation.Base;
using Entities.Concrete;

namespace Business.ValidationRules.FluentValidation
{
    public class MusicalNoteValidator : MaterialBaseValidator<MusicalNote>
    {
        public MusicalNoteValidator()
        {
            RuleFor(mn => mn.ComposerId).NotNull().NotEmpty().WithMessage(MusicalNoteConstants.ComposerNull);
            RuleFor(mn => mn.DateOfWriting).NotNull().NotEmpty().WithMessage(MusicalNoteConstants.DateNull);
        }
    }
}
