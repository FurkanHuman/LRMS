using Core.Domain.Concrete.Security.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations.LrmsUser;

public class OtpAuthenticatorConfiguration : IEntityTypeConfiguration<OtpAuthenticator>
{
    public void Configure(EntityTypeBuilder<OtpAuthenticator> builder)
    {
        builder.HasKey(oa => oa.Id);
        builder.Property(oa => oa.UserId);
        builder.Property(oa => oa.SecretKey);
        builder.Property(oa => oa.IsVerified);
        builder.Property(oa => oa.CreatedDate);
        builder.Property(oa => oa.UpdatedDate);

        builder.Ignore(oa => oa.Name);
        builder.Ignore(oa => oa.IsDeleted);

        builder.HasOne(oa => oa.User);
    }
}