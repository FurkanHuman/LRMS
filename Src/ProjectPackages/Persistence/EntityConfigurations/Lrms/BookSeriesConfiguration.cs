// this file was created automatically.
using Domain.Entities.Mains;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations.Lrms;

public class BookSeriesConfiguration : IEntityTypeConfiguration<BookSeries>
{
    public void Configure(EntityTypeBuilder<BookSeries> builder)
    {
        builder.HasKey(B => B.Id);
        builder.Property(B => B.Id);
        builder.Property(B => B.Name).IsRequired();

        builder.Property(B => B.Title).IsRequired();
        builder.Property(B => B.Description).IsRequired();
        builder.Property(B => B.CategoryId).IsRequired();

        builder.Property(B => B.CoverCapId).IsRequired();
        builder.Property(B => B.ImageId).IsRequired();
        builder.Property(B => B.WriterId).IsRequired();
        builder.Property(B => B.EditorId).IsRequired();

        builder.Property(B => B.DirectorId);
        builder.Property(B => B.GraphicDesignId);
        builder.Property(B => B.GraphicDirectorId);
        builder.Property(B => B.InterpretersId);
        builder.Property(B => B.RedactionId);
        builder.Property(B => B.OtherPeopleId);

        builder.Property(B => B.TechnicalNumberId).IsRequired();
        builder.Property(B => B.EditionId).IsRequired();

        builder.Property(B => B.TechnicalPlaceholdersId).IsRequired();
        builder.Property(B => B.StockId).IsRequired();
        builder.Property(B => B.CounterId).IsRequired();
        builder.Property(B => B.DimensionsId);
        builder.Property(B => B.EMaterialFilesId);
        builder.Property(B => B.Price);
        builder.Property(B => B.State).IsRequired();
        builder.Property(B => B.SecretLevel);

        builder.Property(B => B.BooksIds).IsRequired();

        builder.Property(B => B.CreatedDate);
        builder.Property(B => B.UpdatedDate);
        builder.Property(B => B.IsDeleted);

        builder.HasOne(B => B.Stock);
        builder.HasOne(B => B.Counter);

        builder.HasMany(B => B.Books);
        builder.HasMany(B => B.Kits);

        builder.HasMany(B => B.CoverCaps);
        builder.HasMany(B => B.Images);
        builder.HasMany(B => B.Writers);
        builder.HasMany(B => B.Editors);
        builder.HasMany(B => B.Directors);
        builder.HasMany(B => B.GraphicDesigns);
        builder.HasMany(B => B.GraphicDirectors);
        builder.HasMany(B => B.Interpreters);
        builder.HasMany(B => B.Redactions);
        builder.HasMany(B => B.OtherPeoples);
        builder.HasMany(B => B.TechnicalNumbers);
        builder.HasMany(B => B.Editions);

        builder.HasMany(B => B.Categories);
        builder.HasMany(B => B.Dimensions);
        builder.HasMany(B => B.EMaterialFiles);
        builder.HasMany(B => B.TechnicalPlaceholders);
    }
}