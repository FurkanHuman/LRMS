using Core.Domain.Concrete.Security.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations.LrmsUser;

public class OperationClaimConfiguration : IEntityTypeConfiguration<OperationClaim>
{
    public void Configure(EntityTypeBuilder<OperationClaim> builder)
    {
        builder.HasKey(o => o.Id);
        builder.Property(o => o.Id);
        builder.Property(o => o.Name);
        builder.Property(o => o.CreatedDate);
        builder.Property(o => o.UpdatedDate);
        builder.Property(o => o.IsDeleted).HasDefaultValue(false);

        OperationClaim[] operationClaimSeeds = { new(1, "Admin") };
        builder.HasData(operationClaimSeeds);
    }
}
