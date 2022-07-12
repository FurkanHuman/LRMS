using Business.Abstract.Base;
using Core.Utilities.Result.Abstract;
using Entities.Concrete.Infos;

namespace Business.Abstract
{
    public interface ITechnicalPlaceholderService : IBaseEntityService<TechnicalPlaceholder, Guid>
    {
        IDataResult<List<TechnicalPlaceholder>> GetByColumnCode(string columnCode);
        IDataResult<List<TechnicalPlaceholder>> GetByRowCode(string rowCode);
        IDataResult<List<TechnicalPlaceholder>> GetBySpecialLocation(string specialLocation);
    }
}
