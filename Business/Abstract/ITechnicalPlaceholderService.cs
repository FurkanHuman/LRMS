using Business.Abstract.Base;
using Core.Utilities.Result.Abstract;
using Entities.Concrete.Infos;

namespace Business.Abstract
{
    public interface ITechnicalPlaceholderService : IBaseEntityService<TechnicalPlaceholder, Guid>
    {
        IDataResult<List<TechnicalPlaceholder>> GetAllByColumnCode(string columnCode);
        IDataResult<List<TechnicalPlaceholder>> GetAllByRowCode(string rowCode);
        IDataResult<List<TechnicalPlaceholder>> GetAllBySpecialLocation(string specialLocation);
    }
}
