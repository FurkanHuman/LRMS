// this file was created automatically.
using Domain.Entities.Mains;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations.Lrms;

public class GraphicalImageConfiguration : IEntityTypeConfiguration<GraphicalImage>
{
    public void Configure(EntityTypeBuilder<GraphicalImage> builder)
    {
        builder.HasKey(G => G.Id);
        builder.Property(G => G.Id);
        builder.Property(G => G.Name).IsRequired();

        builder.Property(G => G.Title).IsRequired();
        builder.Property(G => G.Description).IsRequired();
        builder.Property(G => G.CategoryId).IsRequired();

        builder.Property(G => G.ImageCreatedDate).IsRequired();
        builder.Property(G => G.ImageId).IsRequired();
        builder.Property(G => G.OtherPeopleId).IsRequired();
        builder.Property(G => G.IsDestroyed).IsRequired();


        builder.Property(G => G.TechnicalPlaceholdersId).IsRequired();
        builder.Property(G => G.StockId).IsRequired();
        builder.Property(G => G.CounterId).IsRequired();
        builder.Property(G => G.DimensionsId);
        builder.Property(G => G.EMaterialFilesId);
        builder.Property(G => G.Price);
        builder.Property(G => G.State).IsRequired();
        builder.Property(G => G.SecretLevel);

        builder.Property(G => G.CreatedDate);
        builder.Property(G => G.UpdatedDate);
        builder.Property(G => G.IsDeleted);

        builder.HasOne(G => G.Image);
        builder.HasOne(G => G.OtherPeople);

        builder.HasOne(G => G.Stock);
        builder.HasOne(G => G.Counter);

        builder.HasMany(G => G.Categories);
        builder.HasMany(G => G.Dimensions);
        builder.HasMany(G => G.EMaterialFiles);
        builder.HasMany(G => G.TechnicalPlaceholders);

    }
}