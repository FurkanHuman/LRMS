using Business.Abstract.Base;
using Core.Utilities.Result.Abstract;
using Entities.Concrete;

namespace Business.Abstract
{
    public interface IElectronicsResourceService : IMaterialBaseService<ElectronicsResource>
    {
        IDataResult<IList<ElectronicsResource>> GetAllByResourceUrlFinderString(string finderStr);
    }
}
