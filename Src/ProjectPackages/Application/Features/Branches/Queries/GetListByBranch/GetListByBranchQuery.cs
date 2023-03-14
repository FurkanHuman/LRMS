// this file was created automatically.
using Core.Application.Requests;
using Core.Persistence.Paging;
using MediatR;

namespace Application.Features.Branches.Queries.GetListByBranch;

public class GetListByBranchQuery : IRequest<GetListResponse<GetListByBranchResponse>>
{
    public PageRequest PageRequest { get; set; }
}
