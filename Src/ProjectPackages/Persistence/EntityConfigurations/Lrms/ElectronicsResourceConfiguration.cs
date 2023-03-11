// this file was created automatically.
using Domain.Entities.Mains;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations.Lrms;

public class ElectronicsResourceConfiguration : IEntityTypeConfiguration<ElectronicsResource>
{
    public void Configure(EntityTypeBuilder<ElectronicsResource> builder)
    {
        builder.HasKey(E => E.Id);
        builder.Property(E => E.Id);
        builder.Property(E => E.Name).IsRequired();

        builder.Property(E => E.Title).IsRequired();
        builder.Property(E => E.Description).IsRequired();
        builder.Property(E => E.CategoryId).IsRequired();

        builder.Property(E => E.ResourceUrl).IsRequired();

        builder.Property(E => E.TechnicalPlaceholdersId).IsRequired();
        builder.Property(E => E.StockId).IsRequired();
        builder.Property(E => E.CounterId).IsRequired();
        builder.Property(E => E.DimensionsId);
        builder.Property(E => E.EMaterialFilesId);
        builder.Property(E => E.Price);
        builder.Property(E => E.State).IsRequired();
        builder.Property(E => E.SecretLevel);

        builder.Property(E => E.CreatedDate);
        builder.Property(E => E.UpdatedDate);
        builder.Property(E => E.IsDeleted);

        builder.HasMany(E => E.CloudStorageService);
        builder.HasMany(E => E.Kits);

        builder.HasOne(E => E.Stock);
        builder.HasOne(E => E.Counter);

        builder.HasMany(E => E.Categories);
        builder.HasMany(E => E.Dimensions);
        builder.HasMany(E => E.EMaterialFiles);
        builder.HasMany(E => E.TechnicalPlaceholders);
    }
}