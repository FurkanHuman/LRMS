using Core.Domain.Abstract;
using Core.Domain.Bases;

namespace Core.Domain.Concrete.Security.Entities;
// todo: add persistence entity configration..
public class OtpAuthenticator : BaseEntity<Guid>, IEntity
{
    public Guid UserId { get; set; }
    public byte[] SecretKey { get; set; }
    public bool IsVerified { get; set; }

    public virtual User User { get; set; }

    public OtpAuthenticator() { }

    public OtpAuthenticator(Guid id, Guid userId, byte[] secretKey, bool isVerified) : this()
    {
        Id = id;
        UserId = userId;
        SecretKey = secretKey;
        IsVerified = isVerified;
    }
}