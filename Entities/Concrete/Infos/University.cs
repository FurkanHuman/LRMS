using Core.Entities.Abstract;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace Entities.Concrete.Infos
{
    public class University : IEntity
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public string UniversityName { get; set; }

        public string Institute { get; set; }

        [Required]
        public Guid AddressId { get; set; }

        public Address Address { get; set; }

        [Required]
        public int BranchId { get; set; }

        public Branch Branch { get; set; }

        public bool IsDeleted { get; set; }

        public IList<Dissertation> Dissertations { get; set; }
    }
}