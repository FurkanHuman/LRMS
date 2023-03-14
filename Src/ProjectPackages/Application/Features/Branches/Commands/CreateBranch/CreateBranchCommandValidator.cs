// this file was created automatically.
using FluentValidation;

namespace Application.Features.Branches.Commands.CreateBranch;

public class CreateBranchCommandValidator : AbstractValidator<CreateBranchCommand>
{
    public CreateBranchCommandValidator()
    {
        RuleFor(b => b.BranchName).NotEmpty().NotNull().MinimumLength(2);
    }
}
