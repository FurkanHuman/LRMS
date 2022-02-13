using Core.Utilities.Result.Abstract;
using Entities.Concrete.Infos;

namespace Business.Abstract
{
    public interface IDimensionService
    {
        IResult Add(Dimension dimension);
        IResult Delete(Dimension dimension);
        IResult Update(Dimension dimension);
        IDataResult<Dimension> Get(Dimension dimension);
        IDataResult<Dimension> GetById(int id);
        IDataResult<List<Dimension>> GetAll();
        IDataResult<List<Dimension>> GetByX(double xMM);
        IDataResult<List<Dimension>> GetByY(double yMM);
        IDataResult<List<Dimension>> GetByZ(double zMM);
    }
}
