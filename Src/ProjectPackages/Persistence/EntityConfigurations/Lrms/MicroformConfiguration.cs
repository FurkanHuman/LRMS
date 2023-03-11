// this file was created automatically.
using Domain.Entities.Mains;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations.Lrms;

public class MicroformConfiguration : IEntityTypeConfiguration<Microform>
{
    public void Configure(EntityTypeBuilder<Microform> builder)
    {
        builder.HasKey(M => M.Id);
        builder.Property(M => M.Id);
        builder.Property(M => M.Name).IsRequired();

        builder.Property(M => M.Title).IsRequired();
        builder.Property(M => M.Description).IsRequired();
        builder.Property(M => M.CategoryId).IsRequired();

        builder.Property(M => M.Scale).IsRequired();



        builder.Property(M => M.TechnicalPlaceholdersId).IsRequired();
        builder.Property(M => M.StockId).IsRequired();
        builder.Property(M => M.CounterId).IsRequired();
        builder.Property(M => M.DimensionsId);
        builder.Property(M => M.EMaterialFilesId);
        builder.Property(M => M.Price);
        builder.Property(M => M.State).IsRequired();
        builder.Property(M => M.SecretLevel);

        builder.Property(M => M.CreatedDate);
        builder.Property(M => M.UpdatedDate);
        builder.Property(M => M.IsDeleted);

        builder.HasOne(M => M.Stock);
        builder.HasOne(M => M.Counter);

        builder.HasMany(M => M.Kits);

        builder.HasMany(M => M.Categories);
        builder.HasMany(M => M.Dimensions);
        builder.HasMany(M => M.EMaterialFiles);
        builder.HasMany(M => M.TechnicalPlaceholders);
    }
}