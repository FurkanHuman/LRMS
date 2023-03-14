// this file was created automatically.
using Core.Application.Pipelines.Authorization;
using MediatR;

using Core.Application.Pipelines.Authorization;

namespace Application.Features.Branches.Commands.DeleteBranch;

public class DeleteBranchCommand : IRequest<DeletedBranchResponse>, ISecuredRequest
{
    public int Id { get; set; }
    public string[] Roles =>new[] {"Admin"};
}
