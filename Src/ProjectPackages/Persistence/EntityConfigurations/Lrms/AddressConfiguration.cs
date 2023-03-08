// this file was created automatically.
using Domain.Entities.Infos;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations.Lrms;

public class AddressConfiguration : IEntityTypeConfiguration<Address>
{
    public void Configure(EntityTypeBuilder<Address> builder)
    {
        builder.HasKey(A => A.Id);

        builder.Property(A => A.Id);
        builder.Property(A => A.Name);
        builder.Property(A => A.CountryId).IsRequired();
        builder.Property(A => A.CityId).IsRequired();
        builder.Property(A => A.PostalCode);
        builder.Property(A => A.AddressLine1).IsRequired();
        builder.Property(A => A.AddressLine2);
        builder.Property(A => A.GeoLocation);

        builder.Property(A => A.UpdatedDate);

        builder.Ignore(A => A.CreatedDate);
        builder.Ignore(A => A.IsDeleted);

        builder.HasOne(A => A.Country);
        builder.HasOne(A => A.City);


    }
}