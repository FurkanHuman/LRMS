namespace DataAccess.Concrete
{
    public class EfStockDal : EfEntityRepositoryBase<Stock, PostgreDbContext>, IStockDal
    {
    }
}
