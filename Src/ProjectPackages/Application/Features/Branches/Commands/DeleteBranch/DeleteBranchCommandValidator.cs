// this file was created automatically.
using FluentValidation;

namespace Application.Features.Branches.Commands.DeleteBranch;

public class DeleteBranchCommandValidator : AbstractValidator<DeleteBranchCommand>
{
    public DeleteBranchCommandValidator()
    {
        RuleFor(b => b.Id).GreaterThan(0).NotEmpty().NotNull();
    }
}
