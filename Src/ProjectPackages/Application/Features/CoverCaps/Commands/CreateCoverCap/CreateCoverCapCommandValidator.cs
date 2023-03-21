// this file was created automatically.
using FluentValidation;

namespace Application.Features.CoverCaps.Commands.CreateCoverCap;

public class CreateCoverCapCommandValidator : AbstractValidator<CreateCoverCapCommand>
{
    public CreateCoverCapCommandValidator()
    {
        RuleFor(c => c.Name).NotNull().NotEmpty().MaximumLength(64);
    }
}
