// this file was created automatically.
using Domain.Entities.Mains;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations.Lrms;

public class MagazineConfiguration : IEntityTypeConfiguration<Magazine>
{
    public void Configure(EntityTypeBuilder<Magazine> builder)
    {
        builder.HasKey(M => M.Id);
        builder.Property(M => M.Id);
        builder.Property(M => M.Name).IsRequired();

        builder.Property(M => M.Title).IsRequired();
        builder.Property(M => M.Description).IsRequired();
        builder.Property(M => M.CategoryId).IsRequired();

        builder.Property(M => M.CoverCapId).IsRequired();
        builder.Property(M => M.ImageId).IsRequired();
        builder.Property(M => M.WriterId).IsRequired();
        builder.Property(M => M.EditorId).IsRequired();

        builder.Property(M => M.DirectorId);
        builder.Property(M => M.GraphicDesignId);
        builder.Property(M => M.GraphicDirectorId);
        builder.Property(M => M.InterpretersId);
        builder.Property(M => M.RedactionId);
        builder.Property(M => M.OtherPeopleId);

        builder.Property(M => M.TechnicalNumberId).IsRequired();
        builder.Property(M => M.EditionId).IsRequired();

        builder.Property(M => M.TechnicalPlaceholdersId).IsRequired();
        builder.Property(M => M.StockId).IsRequired();
        builder.Property(M => M.CounterId).IsRequired();
        builder.Property(M => M.DimensionsId);
        builder.Property(M => M.EMaterialFilesId);
        builder.Property(M => M.Price);
        builder.Property(M => M.State).IsRequired();
        builder.Property(M => M.SecretLevel);

        builder.Property(M => M.MagazineType).IsRequired();
        builder.Property(M => M.Volume).IsRequired();

        builder.Property(M => M.CreatedDate);
        builder.Property(M => M.UpdatedDate);
        builder.Property(M => M.IsDeleted);

        builder.HasOne(M => M.Stock);
        builder.HasOne(M => M.Counter);

        builder.HasMany(M => M.Kits);

        builder.HasMany(M => M.CoverCaps);
        builder.HasMany(M => M.Images);
        builder.HasMany(M => M.Writers);
        builder.HasMany(M => M.Editors);
        builder.HasMany(M => M.Directors);
        builder.HasMany(M => M.GraphicDesigns);
        builder.HasMany(M => M.GraphicDirectors);
        builder.HasMany(M => M.Interpreters);
        builder.HasMany(M => M.Redactions);
        builder.HasMany(M => M.OtherPeoples);
        builder.HasMany(M => M.TechnicalNumbers);
        builder.HasMany(M => M.Editions);

        builder.HasMany(M => M.Categories);
        builder.HasMany(M => M.Dimensions);
        builder.HasMany(M => M.EMaterialFiles);
        builder.HasMany(M => M.TechnicalPlaceholders);
    }
}