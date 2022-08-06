using Business.Abstract.Base;
using Entities.Concrete.Infos;

namespace Business.Abstract
{
    public interface ICategoryService : IBaseEntityService<Category, int>
    {
    }
}
