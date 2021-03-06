using Business.Abstract.Base;
using Core.Utilities.Result.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;

namespace Business.Abstract
{
    public interface IDepictionService : IMaterialBaseService<Depiction>
    {
        IResult Add(IFormFile formFile, Depiction depiction);
        IResult Update(IFormFile formFile, Depiction depiction, Guid imageId);
        IDataResult<Depiction> GetByImage(Guid imageId);
    }
}
