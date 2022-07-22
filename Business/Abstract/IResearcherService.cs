using Business.Abstract.Base;
using Core.Utilities.Result.Abstract;
using Entities.Concrete.Infos;

namespace Business.Abstract
{
    public interface IResearcherService : IFirstPersonBaseService<Researcher>
    {
        IDataResult<List<Researcher>> GetAllNamePreAttachment(string namePreAttachment);
        IDataResult<List<Researcher>> GetAllSpecialty(string Specialty);
    }
}
