// this file was created automatically.
using Domain.Entities.Infos;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations.Lrms;

public class ImageConfiguration : IEntityTypeConfiguration<Image>
{
    public void Configure(EntityTypeBuilder<Image> builder)
    {
        builder.HasKey(I => I.Id);
        builder.Property(I => I.Id);
        builder.Property(I => I.Url).IsRequired();
        builder.Property(I => I.Date).IsRequired();
        builder.Property(I => I.CloudStorageServiceId).IsRequired();

        builder.Property(I => I.CreatedDate);
        builder.Property(I => I.UpdatedDate);
        builder.Property(I => I.IsDeleted);

        builder.HasMany(I => I.CloudStorageService);
        builder.HasMany(I => I.Books);
        builder.HasMany(I => I.BookSeries);
        builder.HasMany(I => I.CartographicMaterials);
        builder.HasMany(I => I.Encyclopedias);
        builder.HasMany(I => I.Kits);
        builder.HasMany(I => I.Magazines);
        builder.HasMany(I => I.NewsPapers);
        builder.HasMany(I => I.Object3Ds);
        builder.HasMany(I => I.Paintings);
        builder.HasMany(I => I.Posters);




    }
}