// this file was created automatically.
using Core.Application.Pipelines.Authorization;
using MediatR;

namespace Application.Features.Branches.Commands.UpdateBranch;

public class UpdateBranchCommand : IRequest<UpdatedBranchResponse>, ISecuredRequest
{
    public int Id { get; set; }

    public string NewName { get; set; }

    public string[] Roles =>new[] {"Admin"};
}
