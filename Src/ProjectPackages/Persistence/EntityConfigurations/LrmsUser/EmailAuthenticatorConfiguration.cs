using Core.Domain.Concrete.Security.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations.LrmsUser;

public class EmailAuthenticatorConfiguration : IEntityTypeConfiguration<EmailAuthenticator>
{
    public void Configure(EntityTypeBuilder<EmailAuthenticator> builder)
    {
        builder.HasKey(ea => ea.Id);
        builder.Property(ea => ea.Id);
        builder.Property(ea => ea.UserId);
        builder.Property(ea => ea.ActivationKey);
        builder.Property(ea => ea.IsVerified);
        builder.Property(ea => ea.CreatedDate);
        builder.Property(ea => ea.UpdatedDate);

        builder.Ignore(ea => ea.Name);
        builder.Ignore(ea => ea.IsDeleted);

        builder.HasOne(ea => ea.User);
    }
}