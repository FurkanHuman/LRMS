using Application.Features.Branches.Rules;
using Application.Repositories;
using AutoMapper;
using Domain.Entities.Infos;
using MediatR;

namespace Application.Features.Branches.Commands.CreateBranch;

public class CreateBranchCommandHandler : IRequestHandler<CreateBranchCommand, CreatedBranchResponse>
{
    private readonly IBranchRepository _branchRepository;
    private readonly BranchBusinessRules _branchBusinessRules;

    public CreateBranchCommandHandler(IBranchRepository branchRepository, BranchBusinessRules branchBusinessRules)
    {
        _branchRepository = branchRepository;
        _branchBusinessRules = branchBusinessRules;
    }

    public async Task<CreatedBranchResponse> Handle(CreateBranchCommand request, CancellationToken cancellationToken)
    {
        _branchBusinessRules.BranchNameIsExist(request.BranchName);

        Branch createdBranch = await _branchRepository.AddAsync(new() { Name = request.BranchName });
        
        CreatedBranchResponse createdBranchResponse = new() { BranchName = createdBranch.Name, Succes = true };
        
        return createdBranchResponse;
    }
}
