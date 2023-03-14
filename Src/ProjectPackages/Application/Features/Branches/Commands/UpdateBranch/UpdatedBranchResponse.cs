// this file was created automatically.

using Core.Application.Dtos;

namespace Application.Features.Branches.Commands.UpdateBranch;

public class UpdatedBranchResponse : IDto
{
    public int Id { get; internal set; }
    public string NewName { get; internal set; }
    public bool Success { get; internal set; }
}
