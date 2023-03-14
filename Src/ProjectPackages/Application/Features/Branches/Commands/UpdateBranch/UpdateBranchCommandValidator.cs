// this file was created automatically.
using FluentValidation;

namespace Application.Features.Branches.Commands.UpdateBranch;

public class UpdateBranchCommandValidator : AbstractValidator<UpdateBranchCommand>
{
    public UpdateBranchCommandValidator()
    {
        RuleFor(b => b.Id).GreaterThan(0).NotNull().NotEmpty();
        RuleFor(b => b.NewName).MinimumLength(2).NotNull().NotEmpty();

    }
}
