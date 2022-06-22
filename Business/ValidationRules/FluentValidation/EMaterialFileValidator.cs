using Business.Constants;
using Entities.Concrete.Infos;

namespace Business.ValidationRules.FluentValidation
{
    public class EMaterialFileValidator : AbstractValidator<EMaterialFile>
    {
        public EMaterialFileValidator()
        {
            RuleFor<string>(EM => EM.FileName).NotNull().NotEmpty().WithMessage(EMaterialFileConstants.FileNameNull);
            RuleFor<string>(EM => EM.Title).NotNull().NotEmpty().WithMessage(EMaterialFileConstants.FileTitleNull);

        }
    }
}
