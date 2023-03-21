// this file was created automatically.
using FluentValidation;

namespace Application.Features.CoverCaps.Commands.DeleteCoverCap;

public class DeleteCoverCapCommandValidator : AbstractValidator<DeleteCoverCapCommand>
{
    public DeleteCoverCapCommandValidator()
    {
        RuleFor(c => c.Id).NotNull().NotEmpty();
    }
}
