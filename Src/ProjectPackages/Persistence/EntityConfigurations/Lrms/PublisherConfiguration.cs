// this file was created automatically.
using Domain.Entities.Infos;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations.Lrms;

public class PublisherConfiguration : IEntityTypeConfiguration<Publisher>
{
    public void Configure(EntityTypeBuilder<Publisher> builder)
    {
        builder.HasKey(P => P.Id);
        builder.Property(P => P.Id);
        builder.Property(P => P.Name).IsRequired();
        builder.Property(P => P.AddressId).IsRequired();
        builder.Property(P => P.CommunicationId).IsRequired();
        builder.Property(P => P.DateOfPublication).IsRequired();

        builder.Property(P => P.CreatedDate);
        builder.Property(P => P.UpdatedDate);
        builder.Property(P => P.IsDeleted);

        builder.HasOne(P => P.Address);
        builder.HasOne(P => P.Communication);
        builder.HasMany(P => P.AcademicJournals);
    }
}