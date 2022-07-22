using Business.Abstract.Base;
using Core.Utilities.Result.Abstract;
using Entities.Concrete;

namespace Business.Abstract
{
    public interface IEncyclopediaService : IBasePaperService<Encyclopedia>
    {
        IDataResult<List<Encyclopedia>> GetAllBySequenceNumber(uint sequenceNumber);
    }
}
