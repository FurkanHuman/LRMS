using Business.Abstract.Base;
using Core.Utilities.Result.Abstract;
using Entities.Concrete.Infos;

namespace Business.Abstract
{
    public interface IReferenceService : IBaseEntityService<Reference, Guid>
    {
        IDataResult<List<Reference>> GetByOwner(string ownerStr);
        IDataResult<List<Reference>> GetByReferenceDate(DateOnly date);
        IDataResult<List<Reference>> GetBySubText(string subText);
    }
}
