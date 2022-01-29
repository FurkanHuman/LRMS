using Business.Abstract.Base;
using Core.Utilities.Result.Abstract;
using Entities.Concrete;

namespace Business.Abstract
{
    public interface IMagazineService : IBasePaperService<Magazine>
    {
        IDataResult<Magazine> GetBySubject(string title);
    }
}