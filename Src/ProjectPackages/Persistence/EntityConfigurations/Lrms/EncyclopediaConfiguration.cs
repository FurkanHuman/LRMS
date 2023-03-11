// this file was created automatically.
using Domain.Entities.Mains;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations.Lrms;

public class EncyclopediaConfiguration : IEntityTypeConfiguration<Encyclopedia>
{
    public void Configure(EntityTypeBuilder<Encyclopedia> builder)
    {
        builder.HasKey(E => E.Id);
        builder.Property(E => E.Id);
        builder.Property(E => E.Name).IsRequired();

        builder.Property(E => E.Title).IsRequired();
        builder.Property(E => E.Description).IsRequired();
        builder.Property(E => E.CategoryId).IsRequired();

        builder.Property(E => E.CoverCapId).IsRequired();
        builder.Property(E => E.ImageId).IsRequired();
        builder.Property(E => E.WriterId).IsRequired();
        builder.Property(E => E.EditorId).IsRequired();

        builder.Property(E => E.DirectorId);
        builder.Property(E => E.GraphicDesignId);
        builder.Property(E => E.GraphicDirectorId);
        builder.Property(E => E.InterpretersId);
        builder.Property(E => E.RedactionId);
        builder.Property(E => E.OtherPeopleId);

        builder.Property(E => E.TechnicalNumberId).IsRequired();
        builder.Property(E => E.EditionId).IsRequired();

        builder.Property(E => E.TechnicalPlaceholdersId).IsRequired();
        builder.Property(E => E.StockId).IsRequired();
        builder.Property(E => E.CounterId).IsRequired();
        builder.Property(E => E.DimensionsId);
        builder.Property(E => E.EMaterialFilesId);
        builder.Property(E => E.Price);
        builder.Property(E => E.State).IsRequired();
        builder.Property(E => E.SecretLevel);

        builder.Property(E => E.SequenceNumber).IsRequired();
        builder.Property(E => E.ReferenceId).IsRequired();

        builder.Property(E => E.CreatedDate);
        builder.Property(E => E.UpdatedDate);
        builder.Property(E => E.IsDeleted);

        builder.HasOne(E => E.Stock);
        builder.HasOne(E => E.Counter);

        builder.HasMany(E => E.References);
        builder.HasMany(E => E.Kits);

        builder.HasMany(E => E.CoverCaps);
        builder.HasMany(E => E.Images);
        builder.HasMany(E => E.Writers);
        builder.HasMany(E => E.Editors);
        builder.HasMany(E => E.Directors);
        builder.HasMany(E => E.GraphicDesigns);
        builder.HasMany(E => E.GraphicDirectors);
        builder.HasMany(E => E.Interpreters);
        builder.HasMany(E => E.Redactions);
        builder.HasMany(E => E.OtherPeoples);
        builder.HasMany(E => E.TechnicalNumbers);
        builder.HasMany(E => E.Editions);

        builder.HasMany(E => E.Categories);
        builder.HasMany(E => E.Dimensions);
        builder.HasMany(E => E.EMaterialFiles);
        builder.HasMany(E => E.TechnicalPlaceholders);
    }
}