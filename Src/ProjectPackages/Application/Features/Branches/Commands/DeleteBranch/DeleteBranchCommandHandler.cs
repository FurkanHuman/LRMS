// this file was created automatically.
using Application.Features.Branches.Rules;
using Application.Repositories;
using AutoMapper;
using Domain.Entities.Infos;
using MediatR;

namespace Application.Features.Branches.Commands.DeleteBranch;
 
public class DeleteBranchCommandHandler : IRequestHandler<DeleteBranchCommand, DeletedBranchResponse>
{
    private readonly IBranchRepository _branchRepository;    
    private readonly BranchBusinessRules _branchBusinessRules;

    public DeleteBranchCommandHandler(IBranchRepository branchRepository, BranchBusinessRules branchBusinessRules)
    {
        _branchRepository = branchRepository;
        _branchBusinessRules = branchBusinessRules;
    }

    public async Task<DeletedBranchResponse> Handle(DeleteBranchCommand request, CancellationToken cancellationToken)
    {
        Branch getedBranch = _branchRepository.Get(b => b.Id == request.Id);

        _branchBusinessRules.BranchIsNullCheck(getedBranch);

        _branchRepository.DeleteAsync(getedBranch);

        DeletedBranchResponse deletedBranchResponse = new() {Success=true };

        return deletedBranchResponse;
    }
}
