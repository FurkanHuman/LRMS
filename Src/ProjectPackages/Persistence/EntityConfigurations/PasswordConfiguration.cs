using Core.Domain.Concrete.Security.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class PasswordConfiguration : IEntityTypeConfiguration<Password>
{
    public void Configure(EntityTypeBuilder<Password> builder)
    {
        builder.ToTable("Passwords").HasKey(p => p.Id);
        builder.Property(p => p.PasswordHash).HasColumnName("PasswordHash");
        builder.Property(p => p.PasswordSalt).HasColumnName("PasswordSalt");
        builder.Property(p => p.ExpiresDate).HasColumnName("ExpiresDate");
        builder.Property(p => p.CreatedDate).HasColumnName("CreatedDate");
        builder.Property(p => p.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(p => p.IsDeleted).HasColumnName("IsDeleted");

        builder.Ignore(p => p.Name);
        builder.Ignore(p => p.IsDeleted);

        builder.HasOne(p => p.User);
    }
}
