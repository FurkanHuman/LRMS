using Business.Abstract.Base;
using Core.Utilities.Result.Abstract;
using Entities.Concrete.Infos;

namespace Business.Abstract
{
    public interface IReferenceService : IBaseEntityService<Reference, Guid>
    {
        IDataResult<List<Reference>> GetAllByOwner(string ownerStr);
        IDataResult<List<Reference>> GetAllByReferenceDate(DateTime date);
        IDataResult<List<Reference>> GetAllBySubText(string subText);
    }
}
