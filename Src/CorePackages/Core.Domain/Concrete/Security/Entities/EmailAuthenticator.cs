using Core.Domain.Abstract;
using Core.Domain.Bases;

namespace Core.Domain.Concrete.Security.Entities;
// todo: add persistence entity configration.. 
public class EmailAuthenticator : BaseEntity<Guid>, IEntity
{
    public Guid UserId { get; set; }
    public string? ActivationKey { get; set; }
    public bool IsVerified { get; set; }

    public virtual User User { get; set; }

    public EmailAuthenticator() { }

    public EmailAuthenticator(Guid id, Guid userId, string? activationKey, bool isVerified) : this()
    {
        Id = id;
        UserId = userId;
        ActivationKey = activationKey;
        IsVerified = isVerified;
    }
}