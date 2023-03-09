// this file was created automatically.
using Domain.Entities.Infos;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations.Lrms;

public class StockConfiguration : IEntityTypeConfiguration<Stock>
{
    public void Configure(EntityTypeBuilder<Stock> builder)
    {
        builder.HasKey(S => S.Id);
        builder.Property(S => S.Id);
        builder.Property(S => S.LibraryId).IsRequired();
        builder.Property(S => S.StockCode).IsRequired();
        builder.Property(S => S.Quantity).IsRequired().HasDefaultValue(1);
        
        builder.Property(S => S.CreatedDate);
        builder.Property(S => S.UpdatedDate);
        builder.Property(S => S.IsDeleted).HasDefaultValue(false);
        
        builder.Ignore(S => S.Name);

        builder.HasOne(S => S.Library);
    }
}