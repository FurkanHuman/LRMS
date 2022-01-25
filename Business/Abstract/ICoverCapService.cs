using Core.Utilities.Result.Abstract;
using Entities.Concrete.Infos;

namespace Business.Abstract
{
    public interface ICoverCapService
    {
        IDataResult<CoverCap> GetById(int id);
        IDataResult<CoverCap> GetByName(string name);
        IDataResult<List<CoverCap>> GetList();
        IResult Add(CoverCap CoverCap);
        IResult Delete(CoverCap coverCap);
        IResult Update(CoverCap coverCap);
    }
}
