// this file was created automatically.
using FluentValidation;

namespace Application.Features.Branches.Commands.CreateBranches;

public class CreateBranchesCommandValidator : AbstractValidator<CreateBranchesCommand>
{
    public CreateBranchesCommandValidator()
    {
        RuleFor(b => b.BranchNames).NotNull().NotEmpty();
    }
}
