using Core.Utilities.Result.Abstract;
using Entities.Concrete.Infos;
using Microsoft.AspNetCore.Http;

namespace Business.Abstract
{
    public interface IBookImageService
    {
        IDataResult<CoverImage> GetById(int id);
        IDataResult<List<CoverImage>> GetList();
        IResult Add(IFormFile file, CoverImage coverImage);
        IResult Delete(CoverImage coverImage);
        IResult Update(IFormFile file, CoverImage coverImage);
    }
}
