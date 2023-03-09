// this file was created automatically.
using Domain.Entities.Infos;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations.Lrms;

public class ReferenceConfiguration : IEntityTypeConfiguration<Reference>
{
    public void Configure(EntityTypeBuilder<Reference> builder)
    {
        builder.HasKey(R => R.Id);
        builder.Property(R => R.Id);
        builder.Property(R => R.Name).IsRequired();
        builder.Property(R => R.OwnerId).IsRequired();
        builder.Property(R => R.StartPageNumber).IsRequired();
        builder.Property(R => R.EndPageNumber).IsRequired();
        builder.Property(R => R.TechnicalNumber).IsRequired();
        builder.Property(R => R.ReferenceDate).IsRequired();

        builder.Property(R => R.CreatedDate).IsRequired();
        builder.Property(R => R.UpdatedDate).IsRequired();
        builder.Property(R => R.IsDeleted).IsRequired();

        builder.HasOne(R => R.Owner);
        builder.HasOne(R => R.TechnicalNumber);

        builder.HasMany(R => R.AcademicJournals);
        builder.HasMany(R => R.Encyclopedias);
        builder.HasMany(R => R.Books);
    }
}