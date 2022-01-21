using Core.Entities.Abstract;
using System.ComponentModel.DataAnnotations;

namespace Entities.Concrete.BookFirstPage
{
    public class Edition : Publisher, IEntity
    {
        public Edition(string name, string address, string phoneNumber, string? faxNumber, string webSite) : base(name, address, phoneNumber, faxNumber, webSite)
        {
        }

        [Required]
        public int EditionNumber { get; set; }
    }
}
