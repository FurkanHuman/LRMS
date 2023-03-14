// this file was created automatically.

using Core.Application.Dtos;

namespace Application.Features.Branches.Commands.CreateBranches;

public class CreatedBranchesResponse : IDto
{
    public IList<string> BranchNames { get; set; }
    public bool Succes { get; set; }
}
