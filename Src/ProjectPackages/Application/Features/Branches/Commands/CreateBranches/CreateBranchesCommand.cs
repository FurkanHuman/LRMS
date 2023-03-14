// this file was created automatically.
using Core.Application.Pipelines.Authorization;
using MediatR;

namespace Application.Features.Branches.Commands.CreateBranches;

public class CreateBranchesCommand : IRequest<CreatedBranchesResponse>, ISecuredRequest
{
    public IList<string> BranchNames { get; set; }
    public string[] Roles => new[] { "Admin" };
}
