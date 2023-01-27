using Core.Domain.Concrete.Security.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class EmailAuthenticatorConfiguration : IEntityTypeConfiguration<EmailAuthenticator>
{
    public void Configure(EntityTypeBuilder<EmailAuthenticator> builder)
    {
        builder.ToTable("EmailAuthenticators").HasKey(ea => ea.Id);

        builder.Property(ea => ea.UserId).HasColumnName("UserId");
        builder.Property(ea => ea.ActivationKey).HasColumnName("ActivationKey");
        builder.Property(ea => ea.IsVerified).HasColumnName("IsVerified");
        builder.Property(ea => ea.CreatedDate).HasColumnName("CreatedDate");
        builder.Property(ea => ea.UpdatedDate).HasColumnName("UpdatedDate");

        builder.Ignore(ea => ea.Name);
        builder.Ignore(ea => ea.IsDeleted);

        builder.HasOne(ea => ea.User);
    }
}