// this file was created automatically.
using Application.Features.Branches.Rules;
using Application.Repositories;
using AutoMapper;
using Domain.Entities.Infos;
using MediatR;

namespace Application.Features.Branches.Queries.GetByIdBranch;

public class GetByIdBranchQueryHandler : IRequestHandler<GetByIdBranchQuery, GetByIdBranchResponse>
{
    private readonly IBranchRepository _branchRepository;
    private readonly IMapper _mapper;
    private readonly BranchBusinessRules _branchBusinessRules;

    public GetByIdBranchQueryHandler(IBranchRepository branchRepository, BranchBusinessRules branchBusinessRules, IMapper mapper)
    {
        _branchRepository = branchRepository;
        _branchBusinessRules = branchBusinessRules;
        _mapper = mapper;
    }

    public async Task<GetByIdBranchResponse> Handle(GetByIdBranchQuery request, CancellationToken cancellationToken)
    {

        Branch? branch = await _branchRepository.GetAsync(b => b.Id == request.Id, cancellationToken: cancellationToken);

        _branchBusinessRules.BranchIsNullCheck(branch);

        GetByIdBranchResponse branchListModelResponse = _mapper.Map<GetByIdBranchResponse>(branch);
        return branchListModelResponse;
    }
}
