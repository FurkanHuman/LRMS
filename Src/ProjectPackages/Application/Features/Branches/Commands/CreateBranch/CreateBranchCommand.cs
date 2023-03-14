// this file was created automatically.
using Core.Application.Pipelines.Authorization;
using MediatR;

namespace Application.Features.Branches.Commands.CreateBranch;

public class CreateBranchCommand : IRequest<CreatedBranchResponse>, ISecuredRequest
{
    public string BranchName { get; set; }
    public string[] Roles => new[] { "Admin" };
}
