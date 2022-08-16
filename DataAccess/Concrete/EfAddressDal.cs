using Core.DataAccess.PostgreDb;
using DataAccess.Abstract;
using DataAccess.Contexts;
using Entities.Concrete.Infos;
using Entities.DTOs.Infos;

namespace DataAccess.Concrete
{
    public class EfAddressDal : EfEntityRepositoryBase<Address, AddressDto, PostgreDbContext>, IAddressDal
    {
    }
}
