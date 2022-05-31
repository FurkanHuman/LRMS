using Core.Utilities.Result.Abstract;
using Entities.Concrete.Infos;
using Microsoft.AspNetCore.Http;
using System.Linq.Expressions;

namespace Business.Abstract
{
    public interface IImageService

    {
        IResult Add(IFormFile file, Image image);
        IResult Delete(Guid id);
        IResult ShadowDelete(Guid id);
        IResult Update(IFormFile file, Image image);
        IDataResult<Image> GetById(Guid id);
        IDataResult<List<Image>> GetByFilterLists(Expression<Func<Image, bool>>? filter = null);
        IDataResult<List<Image>> GetAll();
        IDataResult<List<Image>> GetAllBySecrets();
    }
}
