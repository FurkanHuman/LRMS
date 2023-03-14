// this file was created automatically.
using Application.Repositories;
using Application.Features.Branches.Constants;
using Core.Application.Rules;
using Domain.Entities.Infos;
using Core.CrossCuttingConcerns.Exceptions.Types;
using Core.Persistence.Paging;
using Application.Features.Branches.Commands.CreateBranches;

namespace Application.Features.Branches.Rules;

public class BranchBusinessRules : BaseBusinessRules
{

    private readonly IBranchRepository _branchRepository;

    public BranchBusinessRules(IBranchRepository branchRepository)
    {
        _branchRepository = branchRepository;
    }

    internal void BranchIsNullCheck(Branch? branch)
    {
        if (branch == null)
            throw new BusinessException(BranchMessages.IsNull);
    }

    internal void BranchNameIsExist(string branchName)
    {
        if (_branchRepository.Any(b => b.Name == branchName))
            throw new BusinessException(branchName + BranchMessages.IsExit);
    }

    internal void BranchNamesIsExist(CreateBranchesCommand createBranchesCommand)
    {
        IList<string> existingBranchNames = _branchRepository.GetList(b => createBranchesCommand.BranchNames.Contains(b.Name), size: int.MaxValue)
            .Items.Select(b => b.Name).ToList();

        IList<string> missingBranchNames = createBranchesCommand.BranchNames.Except(existingBranchNames).ToList();

        if (missingBranchNames.Count > 0)
        {
            createBranchesCommand.BranchNames = missingBranchNames;
            return;
        }
        
        throw new BusinessException(BranchMessages.MultiIsExit(existingBranchNames));
    }

}
