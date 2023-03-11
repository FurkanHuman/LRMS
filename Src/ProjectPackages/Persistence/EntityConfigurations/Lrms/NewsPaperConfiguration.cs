// this file was created automatically.
using Domain.Entities.Mains;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations.Lrms;

public class NewsPaperConfiguration : IEntityTypeConfiguration<NewsPaper>
{
    public void Configure(EntityTypeBuilder<NewsPaper> builder)
    {
        builder.HasKey(N => N.Id);
        builder.Property(N => N.Id);
        builder.Property(N => N.Name).IsRequired();

        builder.Property(N => N.Title).IsRequired();
        builder.Property(N => N.Description).IsRequired();
        builder.Property(N => N.CategoryId).IsRequired();

        builder.Property(N => N.CoverCapId).IsRequired();
        builder.Property(N => N.ImageId).IsRequired();
        builder.Property(N => N.WriterId).IsRequired();
        builder.Property(N => N.EditorId).IsRequired();

        builder.Property(N => N.DirectorId);
        builder.Property(N => N.GraphicDesignId);
        builder.Property(N => N.GraphicDirectorId);
        builder.Property(N => N.InterpretersId);
        builder.Property(N => N.RedactionId);
        builder.Property(N => N.OtherPeopleId);

        builder.Property(N => N.TechnicalNumberId).IsRequired();
        builder.Property(N => N.EditionId).IsRequired();

        builder.Property(N => N.TechnicalPlaceholdersId).IsRequired();
        builder.Property(N => N.StockId).IsRequired();
        builder.Property(N => N.CounterId).IsRequired();
        builder.Property(N => N.DimensionsId);
        builder.Property(N => N.EMaterialFilesId);
        builder.Property(N => N.Price);
        builder.Property(N => N.State).IsRequired();
        builder.Property(N => N.SecretLevel);

        builder.Property(N => N.NewsPaperName).IsRequired();
        builder.Property(N => N.Number).IsRequired();
        builder.Property(N => N.Date).IsRequired();
        builder.Property(N => N.IsDestroyed).IsRequired();


        builder.Property(N => N.CreatedDate);
        builder.Property(N => N.UpdatedDate);
        builder.Property(N => N.IsDeleted);

        builder.HasOne(N => N.Stock);
        builder.HasOne(N => N.Counter);

        builder.HasMany(M => M.Kits);

        builder.HasMany(N => N.CoverCaps);
        builder.HasMany(N => N.Images);
        builder.HasMany(N => N.Writers);
        builder.HasMany(N => N.Editors);
        builder.HasMany(N => N.Directors);
        builder.HasMany(N => N.GraphicDesigns);
        builder.HasMany(N => N.GraphicDirectors);
        builder.HasMany(N => N.Interpreters);
        builder.HasMany(N => N.Redactions);
        builder.HasMany(N => N.OtherPeoples);
        builder.HasMany(N => N.TechnicalNumbers);
        builder.HasMany(N => N.Editions);

        builder.HasMany(N => N.Categories);
        builder.HasMany(N => N.Dimensions);
        builder.HasMany(N => N.EMaterialFiles);
        builder.HasMany(N => N.TechnicalPlaceholders);
    }
}