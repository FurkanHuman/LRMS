using Core.Domain.Concrete.Security.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations
{
    public class UserOperationClaimConfiguration : IEntityTypeConfiguration<UserOperationClaim>
    {
        public void Configure(EntityTypeBuilder<UserOperationClaim> builder)
        {
            builder.ToTable("UserOperationClaims").HasKey(u => u.Id);
            builder.Property(u => u.Id).HasColumnName("Id");
            builder.Property(u => u.UserId).HasColumnName("UserId");
            builder.Property(u => u.OperationClaimId).HasColumnName("OperationClaimId");
            builder.HasIndex(u => new { u.UserId, u.OperationClaimId }, "UK_UserOperationClaims_UserId_OperationClaimId").IsUnique();

            builder.Ignore(u => u.Name);
            builder.Ignore(u => u.IsDeleted);

            builder.HasOne(u => u.User);
            builder.HasOne(u => u.OperationClaim);
        }
    }
}
