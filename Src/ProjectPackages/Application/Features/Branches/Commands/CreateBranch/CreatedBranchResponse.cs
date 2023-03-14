// this file was created automatically.

using Core.Application.Dtos;

namespace Application.Features.Branches.Commands.CreateBranch;

public class CreatedBranchResponse : IDto
{
    public string BranchName { get; set; }
    public bool Succes { get; set; }
}
