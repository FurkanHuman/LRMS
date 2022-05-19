using Core.Utilities.Result.Abstract;
using Entities.Concrete.Infos;

namespace Business.Abstract
{
    public interface IBranchService
    {
        IResult Add(string branchName);
        IResult Delete(int bId);
        IResult ShadowDelete(int bId);
        IResult Update(int oldBId, string newBranchName);
        IDataResult<Branch> Get(int bId);
        IDataResult<List<Branch>> GetAll();
    }
}
