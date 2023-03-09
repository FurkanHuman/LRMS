// this file was created automatically.
using Domain.Entities.Infos;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations.Lrms;

public class LibraryConfiguration : IEntityTypeConfiguration<Library>
{
    public void Configure(EntityTypeBuilder<Library> builder)
    {
        builder.HasKey(L => L.Id);
        builder.Property(L => L.Id);
        builder.Property(L => L.Name).IsRequired();
        builder.Property(L => L.LibraryType).IsRequired();
        builder.Property(L => L.AddressId).IsRequired();
        builder.Property(L => L.CommunicationId).IsRequired();

        builder.Property(L => L.CreatedDate);
        builder.Property(L => L.UpdatedDate);
        builder.Property(L => L.IsDeleted);

        builder.HasOne(L => L.Address);
        builder.HasOne(L => L.Communication);
    }
}