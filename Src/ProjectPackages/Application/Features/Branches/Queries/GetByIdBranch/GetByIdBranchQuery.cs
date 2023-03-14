// this file was created automatically.
using MediatR;

namespace Application.Features.Branches.Queries.GetByIdBranch;

public class GetByIdBranchQuery : IRequest<GetByIdBranchResponse>
{
    public int Id { get; set; }
}
