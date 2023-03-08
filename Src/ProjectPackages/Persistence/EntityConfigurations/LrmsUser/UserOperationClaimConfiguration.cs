using Core.Domain.Concrete.Security.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations.LrmsUser;

public class UserOperationClaimConfiguration : IEntityTypeConfiguration<UserOperationClaim>
{
    public void Configure(EntityTypeBuilder<UserOperationClaim> builder)
    {
        builder.HasKey(u => u.Id);
        builder.Property(u => u.Id);
        builder.Property(u => u.UserId);
        builder.Property(u => u.OperationClaimId);
        builder.HasIndex(u => new { u.UserId, u.OperationClaimId }).IsUnique();

        builder.Ignore(u => u.Name);
        builder.Ignore(u => u.IsDeleted);

        builder.HasOne(u => u.User);
        builder.HasOne(u => u.OperationClaim);
    }
}
