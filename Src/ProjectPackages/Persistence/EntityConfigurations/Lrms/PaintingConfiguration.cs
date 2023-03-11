// this file was created automatically.
using Domain.Entities.Mains;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations.Lrms;

public class PaintingConfiguration : IEntityTypeConfiguration<Painting>
{
    public void Configure(EntityTypeBuilder<Painting> builder)
    {
        builder.HasKey(P => P.Id);
        builder.Property(P => P.Id);
        builder.Property(P => P.Name).IsRequired();

        builder.Property(P => P.Title).IsRequired();
        builder.Property(P => P.Description).IsRequired();
        builder.Property(P => P.CategoryId).IsRequired();

        builder.Property(P => P.OtherPeopleId).IsRequired(); 
        builder.Property(P => P.ImageId).IsRequired();
        builder.Property(P => P.IsDestroyed).IsRequired();


        builder.Property(P => P.TechnicalPlaceholdersId).IsRequired();
        builder.Property(P => P.StockId).IsRequired();
        builder.Property(P => P.CounterId).IsRequired();
        builder.Property(P => P.DimensionsId);
        builder.Property(P => P.EMaterialFilesId);
        builder.Property(P => P.Price);
        builder.Property(P => P.State).IsRequired();
        builder.Property(P => P.SecretLevel);

        builder.Property(P => P.CreatedDate);
        builder.Property(P => P.UpdatedDate);
        builder.Property(P => P.IsDeleted);

        builder.HasOne(P => P.Stock);
        builder.HasOne(P => P.Counter);

        builder.HasOne(P => P.Owner);

        builder.HasMany(P => P.Images);
        builder.HasMany(P => P.Kits);

        builder.HasMany(P => P.Categories);
        builder.HasMany(P => P.Dimensions);
        builder.HasMany(P => P.EMaterialFiles);
        builder.HasMany(P => P.TechnicalPlaceholders);

    }
}