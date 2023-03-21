// this file was created automatically.
using FluentValidation;

namespace Application.Features.CoverCaps.Commands.UpdateCoverCap;

public class UpdateCoverCapCommandValidator : AbstractValidator<UpdateCoverCapCommand>
{
    public UpdateCoverCapCommandValidator()
    {
        RuleFor(c => c.Id).NotNull().NotEmpty();
        RuleFor(c => c.Name).NotNull().NotEmpty().MaximumLength(64);
    }
}
