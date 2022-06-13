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
        IDataResult<List<Dimension>> GetByXandY(double xMM, double yMM);
        IDataResult<List<Dimension>> GetByYandZ(double yMM, double zMM);
        IDataResult<List<Dimension>> GetByZandX(double zMM, double xMM);
        IDataResult<List<Dimension>> GetByXYZMinMax(double minXmm, double? maxXmm, double minYmm, double? maxYmm, double minZmm, double? maxZmm);
    }
}
