namespace Entities.Concrete.Entities.Infos
{
    public class Country : BaseEntity<int>, IEntity
    {
        public string CountryCode { get; set; }

        public IList<City> Cities { get; set; }
    }
}