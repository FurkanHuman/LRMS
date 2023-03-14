using Application.Features.Branches.Rules;
using Application.Repositories;
using Domain.Entities.Infos;
using MediatR;

namespace Application.Features.Branches.Commands.CreateBranches;

public class CreateBranchesCommandHandler : IRequestHandler<CreateBranchesCommand, CreatedBranchesResponse>
{
    private readonly IBranchRepository _branchRepository;
    private readonly BranchBusinessRules _branchBusinessRules;

    public CreateBranchesCommandHandler(IBranchRepository branchRepository, BranchBusinessRules branchBusinessRules)
    {
        _branchRepository = branchRepository;
        _branchBusinessRules = branchBusinessRules;
    }

    public async Task<CreatedBranchesResponse> Handle(CreateBranchesCommand request, CancellationToken cancellationToken)
    {
        _branchBusinessRules.BranchNamesIsExist(request);

        IList<Branch> newBranches = request.BranchNames.Select(bName => new Branch() { Name = bName }).ToList();

        IList<Branch> createdBranches = await _branchRepository.AddRangeAsync(newBranches);
        
        CreatedBranchesResponse createdBranchesResponse = new() { BranchNames = createdBranches.Select(b=>b.Name).ToList(), Succes = true };
        
        return createdBranchesResponse;
    }
}
