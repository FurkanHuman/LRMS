// this file was created automatically.
using Domain.Entities.Mains;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations.Lrms;

public class CartographicMaterialConfiguration : IEntityTypeConfiguration<CartographicMaterial>
{
    public void Configure(EntityTypeBuilder<CartographicMaterial> builder)
    {
        builder.HasKey(C => C.Id);
        builder.Property(C => C.Id);
        builder.Property(C => C.Name).IsRequired();

        builder.Property(C => C.Title).IsRequired();
        builder.Property(C => C.Description).IsRequired();
        builder.Property(C => C.CategoryId).IsRequired();

        builder.Property(C => C.ImageId).IsRequired();
        builder.Property(C => C.Date).IsRequired();

        builder.Property(C => C.TechnicalPlaceholdersId).IsRequired();
        builder.Property(C => C.StockId).IsRequired();
        builder.Property(C => C.CounterId).IsRequired();
        builder.Property(C => C.DimensionsId);
        builder.Property(C => C.EMaterialFilesId);
        builder.Property(C => C.Price);
        builder.Property(C => C.State).IsRequired();
        builder.Property(C => C.SecretLevel);

        builder.Property(C => C.CreatedDate);
        builder.Property(C => C.UpdatedDate);
        builder.Property(C => C.IsDeleted);

        builder.HasOne(C => C.Stock);
        builder.HasOne(C => C.Counter);

        builder.HasMany(C => C.Images);
        builder.HasMany(C => C.Kits);

        builder.HasMany(C => C.Categories);
        builder.HasMany(C => C.Dimensions);
        builder.HasMany(C => C.EMaterialFiles);
        builder.HasMany(C => C.TechnicalPlaceholders);
    }
}