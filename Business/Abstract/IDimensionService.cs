using Business.Abstract.Base;
using Core.Utilities.Result.Abstract;
using Entities.Concrete.Infos;

namespace Business.Abstract
{
    public interface IDimensionService : IBaseEntityService<Dimension, Guid>
    {
        IDataResult<Dimension> GetByDimension(Dimension dimension);
        IDataResult<List<Dimension>> GetAllByX(double xMM);
        IDataResult<List<Dimension>> GetAllByY(double yMM);
        IDataResult<List<Dimension>> GetAllByZ(double zMM);
        IDataResult<List<Dimension>> GetAllByXandY(double xMM, double yMM);
        IDataResult<List<Dimension>> GetAllByYandZ(double yMM, double zMM);
        IDataResult<List<Dimension>> GetAllByZandX(double zMM, double xMM);
        IDataResult<List<Dimension>> GetAllByXYZMinMax(double minXmm, double? maxXmm, double minYmm, double? maxYmm, double minZmm, double? maxZmm);
    }
}
