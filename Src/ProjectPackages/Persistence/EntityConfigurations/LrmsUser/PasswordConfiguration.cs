using Core.Domain.Concrete.Security.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations.LrmsUser;

public partial class PasswordConfiguration : IEntityTypeConfiguration<Password>
{
    public void Configure(EntityTypeBuilder<Password> builder)
    {
        builder.HasKey(p => p.Id);
        builder.Property(p => p.Id);
        builder.Property(p => p.PasswordHash);
        builder.Property(p => p.PasswordSalt);
        builder.Property(p => p.ExpiresDate);
        builder.Property(p => p.CreatedDate);
        builder.Property(p => p.UpdatedDate);

        builder.Ignore(p => p.Name);
        builder.Ignore(p => p.IsDeleted);

        builder.HasOne(p => p.User);
    }
}
