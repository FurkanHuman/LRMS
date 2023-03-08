// this file was created automatically.
using Domain.Entities.Infos;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations.Lrms;

public class CountryConfiguration : IEntityTypeConfiguration<Country>
{
    public void Configure(EntityTypeBuilder<Country> builder)
    {
        builder.HasKey(C => C.Id);
        builder.Property(C => C.Id);
        builder.Property(C => C.Name).IsRequired();
        builder.Property(C => C.CountryCode).IsRequired();

        builder.Property(C => C.IsDeleted);

        builder.Ignore(C => C.CreatedDate);
        builder.Ignore(C => C.UpdatedDate);

        builder.HasMany(C => C.Cities);
    }
}