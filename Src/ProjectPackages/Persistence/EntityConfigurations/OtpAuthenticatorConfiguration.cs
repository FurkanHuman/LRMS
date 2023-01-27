using Core.Domain.Concrete.Security.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class OtpAuthenticatorConfiguration : IEntityTypeConfiguration<OtpAuthenticator>
{
    public void Configure(EntityTypeBuilder<OtpAuthenticator> builder)
    {
        builder.ToTable("OtpAuthenticators").HasKey(oa => oa.Id);

        builder.Property(oa => oa.UserId).HasColumnName("UserId");
        builder.Property(oa => oa.SecretKey).HasColumnName("SecretKey");
        builder.Property(oa => oa.IsVerified).HasColumnName("IsVerified");
        builder.Property(oa => oa.CreatedDate).HasColumnName("CreatedDate");
        builder.Property(oa => oa.UpdatedDate).HasColumnName("UpdatedDate");

        builder.Ignore(oa => oa.Name);
        builder.Ignore(oa => oa.IsDeleted);

        builder.HasOne(oa => oa.User);
    }
}