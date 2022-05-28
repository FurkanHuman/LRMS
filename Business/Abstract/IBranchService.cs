using Business.Abstract.Base;
using Core.Utilities.Result.Abstract;
using Entities.Concrete.Infos;

namespace Business.Abstract
{
    public interface IBranchService : IBaseEntityService<Branch>
    {
        IResult Delete(int id);
        IResult ShadowDelete(int id);
        IDataResult<Branch> GetById(int id);
    }
}
