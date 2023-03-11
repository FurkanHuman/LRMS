// this file was created automatically.
using Domain.Entities.Mains;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations.Lrms;

public class Object3DConfiguration : IEntityTypeConfiguration<Object3D>
{
    public void Configure(EntityTypeBuilder<Object3D> builder)
    {
        builder.HasKey(O => O.Id);
        builder.Property(O => O.Id);
        builder.Property(O => O.Name).IsRequired();

        builder.Property(O => O.Title).IsRequired();
        builder.Property(O => O.Description).IsRequired();
        builder.Property(O => O.CategoryId).IsRequired();

        builder.Property(O => O.OwnerId).IsRequired();
        builder.Property(O => O.ImageId).IsRequired();
        builder.Property(O => O.IsDestroyed).IsRequired();

        builder.Property(O => O.TechnicalPlaceholdersId).IsRequired();
        builder.Property(O => O.StockId).IsRequired();
        builder.Property(O => O.CounterId).IsRequired();
        builder.Property(O => O.DimensionsId);
        builder.Property(O => O.EMaterialFilesId);
        builder.Property(O => O.Price);
        builder.Property(O => O.State).IsRequired();
        builder.Property(O => O.SecretLevel);

        builder.Property(O => O.CreatedDate);
        builder.Property(O => O.UpdatedDate);
        builder.Property(O => O.IsDeleted);

        builder.HasOne(O => O.Owner);
        
        builder.HasOne(O => O.Stock);
        builder.HasOne(O => O.Counter);

        builder.HasMany(O => O.Images);
        builder.HasMany(O => O.Kits);
        
        builder.HasMany(O => O.Categories);
        builder.HasMany(O => O.Dimensions);
        builder.HasMany(O => O.EMaterialFiles);
        builder.HasMany(O => O.TechnicalPlaceholders);
    }
}