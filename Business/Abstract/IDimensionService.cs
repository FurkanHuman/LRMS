using Business.Abstract.Base;
using Core.Utilities.Result.Abstract;
using Entities.Concrete.Infos;

namespace Business.Abstract
{
    public interface IDimensionService : IBaseEntityService<Dimension, Guid>
    {
        IDataResult<Dimension> GetByDimension(Dimension dimension);
        IDataResult<List<Dimension>> GetByX(double xMM);
        IDataResult<List<Dimension>> GetByY(double yMM);
        IDataResult<List<Dimension>> GetByZ(double zMM);
    }
}
