// this file was created automatically.
using FluentValidation;

namespace Application.Features.Languages.Commands.CreateLanguage;

public class CreateLanguageCommandValidator : AbstractValidator<CreateLanguageCommand>
{
    public CreateLanguageCommandValidator()
    {
        RuleFor(l => l.Name).NotEmpty().NotNull().MinimumLength(2).MaximumLength(64);
    }
}
