namespace Entities.Concrete.Entities.Infos
{
    public class Library : BaseEntity<Guid>, IEntity
    {
        public byte LibraryType { get; set; }

        [Required]
        public Guid AddressId { get; set; }

        public Address Address { get; set; }

        [Required]
        public Guid CommunicationId { get; set; }
        public Communication Communication { get; set; }
    }
}