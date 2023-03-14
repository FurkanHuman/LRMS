// this file was created automatically.
using Application.Repositories;
using AutoMapper;
using Domain.Entities.Infos;
using Core.Persistence.Paging;
using MediatR;

namespace Application.Features.Branches.Queries.GetListByBranch;

public class GetListByBranchQueryHandler : IRequestHandler<GetListByBranchQuery, GetListResponse<GetListByBranchResponse>>
{
    private readonly IBranchRepository _branchRepository;
    private readonly IMapper _mapper;

    public GetListByBranchQueryHandler(IBranchRepository branchRepository, IMapper mapper)
    {
        _branchRepository = branchRepository;
        _mapper = mapper;
    }

    public async Task<GetListResponse<GetListByBranchResponse>> Handle(GetListByBranchQuery request, CancellationToken cancellationToken)
    {
        IPaginate<Branch> branches = await _branchRepository.GetListAsync(index: request.PageRequest.Page,
                                                                          size: request.PageRequest.PageSize,
                                                                          cancellationToken: cancellationToken);

        GetListResponse<GetListByBranchResponse> mappedGetListResponse = _mapper.Map<GetListResponse<GetListByBranchResponse>>(branches);
        return mappedGetListResponse;
    }
}
