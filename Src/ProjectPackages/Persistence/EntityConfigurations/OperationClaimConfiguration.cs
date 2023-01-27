using Core.Domain.Concrete.Security.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class OperationClaimConfiguration : IEntityTypeConfiguration<OperationClaim>
{
    public void Configure(EntityTypeBuilder<OperationClaim> builder)
    {
        builder.ToTable("OperationClaims").HasKey(o => o.Id);
        builder.Property(o => o.Id).HasColumnName("Id");
        builder.Property(o => o.Name).HasColumnName("Name");
        builder.Property(o => o.CreatedDate).HasColumnName("CreatedDate");
        builder.Property(o => o.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(o => o.IsDeleted).HasColumnName("IsDeleted").HasDefaultValue(false);

        OperationClaim[] operationClaimSeeds = { new(1, "Admin") };
        builder.HasData(operationClaimSeeds);
    }
}
