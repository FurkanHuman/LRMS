using Core.Entities.Abstract;
using System.ComponentModel.DataAnnotations;

namespace Entities.Concrete.Infos
{
    public class Library : IEntity
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public string LibraryName { get; set; }

        public byte LibraryType { get; set; }

        [Required]
        public Guid AddressId { get; set; }

        public Address Address { get; set; }

        [Required]
        public Guid CommunicationId { get; set; }
        public Communication Communication { get; set; }

        public bool IsDestroyed { get; set; }
    }
}