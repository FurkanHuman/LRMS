using Business.Abstract.Base;
using Core.Utilities.Result.Abstract;
using Entities.Concrete.Infos;

namespace Business.Abstract
{
    public interface ICoverCapService : IBaseEntityService<CoverCap>
    {
        IResult Delete(int id);
        IResult ShadowDelete(int id);
        IDataResult<CoverCap> GetById(int id);
    }
}
