using Core.Utilities.Result.Abstract;
using Entities.Concrete.Infos;

namespace Business.Abstract
{
    public interface ICategoryService
    {
        IDataResult<Category> GetById(int id);
        IDataResult<Category> GetByName(string name);
        IDataResult<List<Category>> GetList();
        IResult Add(Category category);
        IResult Delete(Category category);
        IResult Update(Category category);
    }
}
