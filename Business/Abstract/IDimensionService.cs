using Business.Abstract.Base;
using Core.Utilities.Result.Abstract;
using Entities.Concrete.Infos;

namespace Business.Abstract
{
    public interface IDimensionService : IBaseEntityService<Dimension, Guid>
    {
        IDataResult<Dimension> GetByDimension(Dimension dimension);
        IDataResult<IList<Dimension>> GetAllByX(double xMM);
        IDataResult<IList<Dimension>> GetAllByY(double yMM);
        IDataResult<IList<Dimension>> GetAllByZ(double zMM);
        IDataResult<IList<Dimension>> GetAllByXandY(double xMM, double yMM);
        IDataResult<IList<Dimension>> GetAllByYandZ(double yMM, double zMM);
        IDataResult<IList<Dimension>> GetAllByZandX(double zMM, double xMM);
        IDataResult<IList<Dimension>> GetAllByXYZMinMax(double minXmm, double? maxXmm, double minYmm, double? maxYmm, double minZmm, double? maxZmm);
    }
}
