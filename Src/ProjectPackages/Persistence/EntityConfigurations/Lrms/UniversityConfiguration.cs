// this file was created automatically.
using Domain.Entities.Infos;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations.Lrms;

public class UniversityConfiguration : IEntityTypeConfiguration<University>
{
    public void Configure(EntityTypeBuilder<University> builder)
    {
        builder.HasKey(U => U.Id);
        builder.Property(U => U.Id);
        builder.Property(U => U.Name).IsRequired();
        builder.Property(U => U.AddressId).IsRequired();
        builder.Property(U => U.BranchId).IsRequired();

        builder.Property(U => U.CreatedDate);
        builder.Property(U => U.UpdatedDate);
        builder.Property(U => U.IsDeleted);

        builder.HasOne(U => U.Address);
        builder.HasOne(U => U.Branch);
 
        builder.HasMany(U => U.Dissertations);
    }
}