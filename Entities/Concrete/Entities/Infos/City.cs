namespace Entities.Concrete.Entities.Infos
{
    public class City : BaseEntity<int>, IEntity
    {
        public int CountryId { get; set; }

        public Country Country { get; set; }
    }
}