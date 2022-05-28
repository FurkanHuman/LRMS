using Business.Abstract.Base;
using Core.Utilities.Result.Abstract;
using Entities.Concrete.Infos;
using Microsoft.AspNetCore.Http;

namespace Business.Abstract
{
    public interface IImageService : IBaseEntityService<Image>

    {
        IDataResult<Image> GetById(Guid id);
        IResult Add(IFormFile file, Image image);
        IResult Delete(Guid id);
        IResult ShadowDelete(Guid id);
        IResult Update(IFormFile file, Image image);
    }
}
