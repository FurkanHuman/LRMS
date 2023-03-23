// this file was created automatically.
using FluentValidation;

namespace Application.Features.Languages.Commands.UpdateLanguage;

public class UpdateLanguageCommandValidator : AbstractValidator<UpdateLanguageCommand>
{
    public UpdateLanguageCommandValidator()
    {
        RuleFor(l => l.Id).NotEmpty().NotNull().GreaterThan(0);
        RuleFor(l => l.Name).NotEmpty().NotNull().MinimumLength(3).MaximumLength(56);
    }
}
