// this file was created automatically.
using Domain.Entities.Mains;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations.Lrms;

public class DepictionConfiguration : IEntityTypeConfiguration<Depiction>
{
    public void Configure(EntityTypeBuilder<Depiction> builder)
    {
        builder.HasKey(D => D.Id);
        builder.Property(D => D.Id);
        builder.Property(D => D.Name).IsRequired();

        builder.Property(D => D.Title).IsRequired();
        builder.Property(D => D.Description).IsRequired();
        builder.Property(D => D.CategoryId).IsRequired();

        builder.Property(D => D.ImageId).IsRequired();

        builder.Property(D => D.TechnicalPlaceholdersId).IsRequired();
        builder.Property(D => D.StockId).IsRequired();
        builder.Property(D => D.CounterId).IsRequired();
        builder.Property(D => D.DimensionsId);
        builder.Property(D => D.EMaterialFilesId);
        builder.Property(D => D.Price);
        builder.Property(D => D.State).IsRequired();
        builder.Property(D => D.SecretLevel);

        builder.Property(D => D.CreatedDate);
        builder.Property(D => D.UpdatedDate);
        builder.Property(D => D.IsDeleted);

        builder.HasOne(D => D.Stock);
        builder.HasOne(D => D.Counter);

        builder.HasOne(D => D.Image);
        builder.HasMany(D => D.Kits);

        builder.HasMany(D => D.Categories);
        builder.HasMany(D => D.Dimensions);
        builder.HasMany(D => D.EMaterialFiles);
        builder.HasMany(D => D.TechnicalPlaceholders);
    }
}