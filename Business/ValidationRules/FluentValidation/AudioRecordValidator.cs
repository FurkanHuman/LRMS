using Business.Constants;
using Business.ValidationRules.FluentValidation.Base;
using Entities.Concrete;

namespace Business.ValidationRules.FluentValidation
{
    public class AudioRecordValidator : MaterialBaseValidator<AudioRecord>
    {
        public AudioRecordValidator()
        {
            RuleFor(x => x.Owner).NotEmpty().NotNull().WithMessage(AudioRecordConstants.OwnerNull);
            RuleFor(x => x.RecordDate).NotEmpty().NotNull().WithMessage(AudioRecordConstants.RecordDateNull);
            RuleFor(x => x.RecordingLength).NotEmpty().NotNull().WithMessage(AudioRecordConstants.RecordingLengthNull);
        }
    }
}
