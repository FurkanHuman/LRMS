using Core.Domain.Concrete.Security.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations.LrmsUser;

public class RefreshTokenConfiguration : IEntityTypeConfiguration<RefreshToken>
{
    public void Configure(EntityTypeBuilder<RefreshToken> builder)
    {
        builder.HasKey(r => r.Id);
        builder.Property(r => r.Id);
        builder.Property(r => r.UserId);
        builder.Property(r => r.Token);
        builder.Property(r => r.Expires);
        builder.Property(r => r.Created);
        builder.Property(r => r.CreatedByIp);
        builder.Property(r => r.Revoked);
        builder.Property(r => r.RevokedByIp);
        builder.Property(r => r.ReplacedByToken);
        builder.Property(r => r.ReasonRevoked);
        builder.Property(r => r.CreatedDate);
        builder.Property(r => r.UpdatedDate);

        builder.Ignore(r => r.Name);
        builder.Ignore(r => r.IsDeleted);

        builder.HasOne(r => r.User);
    }
}
