using Core.Domain.Concrete.Security.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable("Users").HasKey(u => u.Id);
        builder.Property(u => u.Id).HasColumnName("Id");
        builder.Property(u => u.FirstName).HasColumnName("FirstName");
        builder.Property(u => u.LastName).HasColumnName("LastName");
        builder.Property(u => u.Email).HasColumnName("Email");
        builder.HasIndex(u => u.Email, "UK_Users_Email").IsUnique();
        builder.Property(u => u.PasswordId).HasColumnName("PasswordId");
        builder.Property(u => u.Status).HasColumnName("Status").HasDefaultValue(true);
        builder.Property(u => u.AuthenticatorType).HasColumnName("AuthenticatorType");
        builder.Property(u => u.CreatedDate).HasColumnName("CreatedDate");
        builder.Property(u => u.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(u => u.IsDeleted).HasColumnName("IsDeleted").HasDefaultValue(false);

        builder.Ignore(p => p.Name);

        builder.HasOne(u => u.EmailAuthenticator);
        builder.HasOne(u => u.OtpAuthenticator);
        builder.HasOne(u => u.Password);
        builder.HasMany(u => u.RefreshTokens);
        builder.HasMany(u => u.UserOperationClaims);
    }
}
