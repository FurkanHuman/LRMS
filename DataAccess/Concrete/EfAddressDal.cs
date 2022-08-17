namespace DataAccess.Concrete
{
    public class EfAddressDal : EfEntityRepositoryBase<Address, AddressDto, PostgreDbContext>, IAddressDal
    {
    }
}
