using Business.Abstract.Base;
using Core.Utilities.Result.Abstract;
using Entities.Concrete;

namespace Business.Abstract
{
    public interface IMicroformService : IMaterialBaseService<Microform>
    {
        IDataResult<List<Microform>> GetAllByScale(string scale);
    }
}
