// this file was created automatically.

using Core.Application.Dtos;

namespace Application.Features.Branches.Queries.GetListByBranch;

public class GetListByBranchResponse : IDto
{
     public string Name { get; set; }
    public bool IsDeleted { get; set; }
}
