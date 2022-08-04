using Business.Abstract.Base;
using Core.Utilities.Result.Abstract;
using Entities.Concrete.Infos;

namespace Business.Abstract
{
    public interface ITechnicalPlaceholderService : IBaseEntityService<TechnicalPlaceholder, Guid>
    {
        IDataResult<IList<TechnicalPlaceholder>> GetAllByColumnCode(string columnCode);
        IDataResult<IList<TechnicalPlaceholder>> GetAllByRowCode(string rowCode);
        IDataResult<IList<TechnicalPlaceholder>> GetAllBySpecialLocation(string specialLocation);
    }
}
