namespace DataAccess.Abstract
{
    public interface IAddressDal : IEntityRepository<Address>, IDtoRepository<Address, AddressDto>
    {
    }
}
