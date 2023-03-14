// this file was created automatically.
using Application.Features.Branches.Rules;
using Application.Repositories;
using AutoMapper;
using Domain.Entities.Infos;
using MediatR;

namespace Application.Features.Branches.Commands.UpdateBranch;

public class UpdateBranchCommandHandler : IRequestHandler<UpdateBranchCommand, UpdatedBranchResponse>
{
    private readonly IBranchRepository _branchRepository;
    private readonly BranchBusinessRules _branchBusinessRules;

    public UpdateBranchCommandHandler(IBranchRepository branchRepository, BranchBusinessRules branchBusinessRules)
    {
        _branchRepository = branchRepository;
        _branchBusinessRules = branchBusinessRules;
    }

    public async Task<UpdatedBranchResponse> Handle(UpdateBranchCommand request, CancellationToken cancellationToken)
    {

        _branchBusinessRules.BranchNameIsExist(request.NewName);

        Branch GetedBranch = _branchRepository.Get(b => b.Id == request.Id);

        _branchBusinessRules.BranchIsNullCheck(GetedBranch);

        GetedBranch.Name = request.NewName;

        Branch updatedBranch = _branchRepository.Update(GetedBranch);

        UpdatedBranchResponse createdBranchResponse = new() { Id = updatedBranch.Id, NewName = updatedBranch.Name, Success = true };
        return createdBranchResponse;
    }
}
