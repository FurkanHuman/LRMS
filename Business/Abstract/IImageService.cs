using Core.Utilities.Result.Abstract;
using Entities.Concrete.Infos;
using Microsoft.AspNetCore.Http;

namespace Business.Abstract
{
    public interface IImageService
    {
        IDataResult<Image> GetById(int id);
        IDataResult<List<Image>> GetList();
        IResult Add(IFormFile file, Image image);
        IResult Delete(Image image);
        IResult EfDelete(Image efImage, bool isdel);
        IResult Update(IFormFile file, Image image);
    }
}
