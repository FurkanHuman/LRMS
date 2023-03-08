using Core.Domain.Concrete.Security.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations.LrmsUser;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasKey(u => u.Id);
        builder.Property(u => u.Id);
        builder.Property(u => u.Email);
        builder.HasIndex(u => u.Email).IsUnique();
        builder.Property(u => u.PasswordId);
        builder.Property(u => u.Status).HasDefaultValue(true);
        builder.Property(u => u.AuthenticatorType);
        builder.Property(u => u.CreatedDate);
        builder.Property(u => u.UpdatedDate);
        builder.Property(u => u.IsDeleted).HasDefaultValue(false);

        builder.Ignore(p => p.Name);

        builder.HasOne(u => u.EmailAuthenticator);
        builder.HasOne(u => u.OtpAuthenticator);
        builder.HasOne(u => u.Password);
        builder.HasMany(u => u.RefreshTokens);
        builder.HasMany(u => u.UserOperationClaims);
    }
}
