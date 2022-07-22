using Core.Entities.Abstract;
using Core.Utilities.Result.Abstract;
using Entities.DTOs.Base;

namespace Business.Abstract.Base
{
    public interface IFirstPersonBaseDtoService<D> : IBaseDtoService<D, Guid> where D : FirstPagePersonBaseDto, IDto, new()
    {
        IDataResult<List<D>> DtoGetAllBySurname(string surname);
    }
}
