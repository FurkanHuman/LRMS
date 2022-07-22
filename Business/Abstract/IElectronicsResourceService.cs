using Business.Abstract.Base;
using Core.Utilities.Result.Abstract;
using Entities.Concrete;

namespace Business.Abstract
{
    public interface IElectronicsResourceService : IMaterialBaseService<ElectronicsResource>
    {
        IDataResult<List<ElectronicsResource>> GetAllByResourceUrlFinderString(string finderStr);
    }
}
