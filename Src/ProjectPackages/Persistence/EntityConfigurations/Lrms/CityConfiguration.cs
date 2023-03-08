// this file was created automatically.
using Domain.Entities.Infos;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations.Lrms;

public class CityConfiguration : IEntityTypeConfiguration<City>
{
    public void Configure(EntityTypeBuilder<City> builder)
    {
        builder.HasKey(C => C.Id);
        builder.Property(C => C.Id);
        builder.Property(C => C.Name).IsRequired();
        builder.Property(C => C.CountryId).IsRequired();

        builder.Property(C => C.UpdatedDate);
        builder.Property(C => C.IsDeleted);

        builder.Ignore(C => C.CreatedDate);

        builder.HasOne(C => C.Country);
    }
}