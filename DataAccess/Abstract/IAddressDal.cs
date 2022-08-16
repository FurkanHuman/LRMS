using Core.DataAccess;
using Entities.Concrete.Infos;
using Entities.DTOs.Infos;

namespace DataAccess.Abstract
{
    public interface IAddressDal : IEntityRepository<Address>,IDtoRepository<Address,AddressDto>
    {
    }
}
