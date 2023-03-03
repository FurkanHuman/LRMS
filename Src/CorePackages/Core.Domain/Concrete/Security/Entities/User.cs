using Core.Domain.Abstract;
using Core.Domain.Bases;
using Core.Domain.Concrete.Security.Enums;

namespace Core.Domain.Concrete.Security.Entities;

public class User : BaseEntity<Guid>, IEntity
{
    public string Email { get; set; }
    public Guid PasswordId { get; set; }
    public bool Status { get; set; }
    public AuthenticatorType AuthenticatorType { get; set; }

    public Password Password { get; set; }
    
    public virtual EmailAuthenticator EmailAuthenticator { get; set; }
    public virtual OtpAuthenticator OtpAuthenticator { get; set; }

    public virtual ICollection<UserOperationClaim> UserOperationClaims { get; set; }
    public virtual ICollection<RefreshToken> RefreshTokens { get; set; }
    
    public User()
    {
        UserOperationClaims = new HashSet<UserOperationClaim>();
        RefreshTokens = new HashSet<RefreshToken>();
    }

    public User(Guid id, string firstName, string lastName, string email, Guid passwordId,
                bool status, AuthenticatorType authenticatorType) : this()
    {
        Id = id;
        Email = email;
        PasswordId = passwordId;
        Status = status;
        AuthenticatorType = authenticatorType;
    }
}