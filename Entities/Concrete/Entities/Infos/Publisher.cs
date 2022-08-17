using Entities.Concrete.Entities.Mains;


namespace Entities.Concrete.Entities.Infos
{
    public class Publisher : IEntity
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public Guid AddressId { get; set; }

        public Address Address { get; set; }

        [Required]
        public Guid CommunicationId { get; set; }

        public Communication Communication { get; set; }

        public DateTime DateOfPublication { get; set; }

        public bool IsDeleted { get; set; }

        public IList<AcademicJournal> AcademicJournals { get; set; }
    }
}