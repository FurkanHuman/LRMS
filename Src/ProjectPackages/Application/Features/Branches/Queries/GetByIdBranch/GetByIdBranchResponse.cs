// this file was created automatically.

using Core.Application.Dtos;

namespace Application.Features.Branches.Queries.GetByIdBranch;

public class GetByIdBranchResponse : IDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public bool IsDeleted { get; set; }
}