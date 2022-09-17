namespace Entities.Concrete.Entities.Infos
{
    public class Communication : BaseEntity<Guid>, IEntity
    {
        public string PhoneNumber { get; set; }

        public string? FaxNumber { get; set; }

        public string Email { get; set; }

        public string WebSite { get; set; }
    }
}
