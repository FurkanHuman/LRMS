// this file was created automatically.
using Domain.Entities.Infos;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Runtime.ConstrainedExecution;

namespace Persistence.EntityConfigurations.Lrms;

public class CloudStorageConfiguration : IEntityTypeConfiguration<CloudStorage>
{
    public void Configure(EntityTypeBuilder<CloudStorage> builder)
    {
        builder.HasKey(C => C.Id);
        builder.Property(C => C.Id).UseIdentityColumn();
        builder.Property(C => C.CompanyName).IsRequired();
        builder.Property(C => C.SubDomain).IsRequired();
        builder.Property(C => C.IsActive).IsRequired();
        builder.Property(C => C.CloudStorageType).IsRequired();
        builder.Property(C => C.CloudStorageTransferType).IsRequired();
        builder.Property(C => C.Continent).IsRequired();

        builder.Property(C => C.CreatedDate).IsRequired();
        builder.Property(C => C.UpdatedDate);
        builder.Property(C => C.IsDeleted).IsRequired();

        builder.Ignore(C => C.Name);

        builder.HasMany(C => C.Images);
        builder.HasMany(C => C.EMaterialFiles);
        builder.HasMany(C => C.ElectronicsResources);
    }
}