namespace Entities.Concrete.Entities.Infos
{
    public class Communication : BaseEntity<Guid>, IEntity
    {
        [Required]
        public string PhoneNumber { get; set; }

        public string? FaxNumber { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string WebSite { get; set; }
    }
}
