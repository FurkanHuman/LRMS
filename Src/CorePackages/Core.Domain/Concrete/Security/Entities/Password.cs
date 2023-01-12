using Core.Domain.Abstract;
using Core.Domain.Bases;

namespace Core.Domain.Concrete.Security.Entities
{
    public class Password : BaseEntity<Guid>, IEntity
    {
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public DateTime ExpiresDate { get; set; } = DateTime.Now.AddMonths(6);

        public User User { get; set; }
    }
}