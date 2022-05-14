using Core.DataAccess;
using Entities.Concrete.Infos;

namespace DataAccess.Abstract
{
    public interface ICountryDal : IEntityRepository<Country>
    {
    }
}
