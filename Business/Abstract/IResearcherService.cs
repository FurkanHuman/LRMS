using Business.Abstract.Base;
using Core.Utilities.Result.Abstract;
using Entities.Concrete.Infos;

namespace Business.Abstract
{
    public interface IResearcherService : IFirstPersonBaseService<Researcher>
    {
        IDataResult<IList<Researcher>> GetAllNamePreAttachment(string namePreAttachment);
        IDataResult<IList<Researcher>> GetAllSpecialty(string Specialty);
    }
}
