// this file was created automatically.
using Domain.Entities.Mains;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations.Lrms;

public class AudioRecordConfiguration : IEntityTypeConfiguration<AudioRecord>
{
    public void Configure(EntityTypeBuilder<AudioRecord> builder)
    {
        builder.HasKey(A => A.Id);
        builder.Property(A => A.Id);
        builder.Property(A => A.Name).IsRequired();

        builder.Property(A => A.Title).IsRequired();
        builder.Property(A => A.Description).IsRequired();
        builder.Property(A => A.CategoryId).IsRequired();

        builder.Property(A => A.OwnerId).IsRequired();
        builder.Property(A => A.RecordDate).IsRequired();
        builder.Property(A => A.RecordEndDate).IsRequired();
        builder.Property(A => A.RecordingLength).IsRequired();

        builder.Property(A => A.TechnicalPlaceholdersId).IsRequired();
        builder.Property(A => A.StockId).IsRequired();
        builder.Property(A => A.CounterId).IsRequired();
        builder.Property(A => A.DimensionsId);
        builder.Property(A => A.EMaterialFilesId);
        builder.Property(A => A.Price);
        builder.Property(A => A.State).IsRequired();
        builder.Property(A => A.SecretLevel);

        builder.Property(A => A.CreatedDate);
        builder.Property(A => A.UpdatedDate);
        builder.Property(A => A.IsDeleted);

        builder.HasOne(A => A.Owner);
        builder.HasMany(A => A.Kits);

        builder.HasOne(A => A.Stock);
        builder.HasOne(A => A.Counter);
        builder.HasMany(A => A.Categories);
        builder.HasMany(A => A.Dimensions);
        builder.HasMany(A => A.EMaterialFiles);
        builder.HasMany(A => A.TechnicalPlaceholders);

    }
}