// this file was created automatically.
using Domain.Entities.Infos;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations.Lrms;

public class EditionConfiguration : IEntityTypeConfiguration<Edition>
{
    public void Configure(EntityTypeBuilder<Edition> builder)
    {
        builder.HasKey(E => E.Id);
        builder.Property(E => E.Id);
        builder.Property(E => E.PublisherId).IsRequired();
        builder.Property(E => E.EditionNumber).IsRequired();

        builder.Ignore(E => E.CreatedDate);
        builder.Ignore(E => E.UpdatedDate);
        builder.Ignore(E => E.IsDeleted);

        builder.HasOne(E => E.Publisher);

        builder.HasMany(E => E.Books);
        builder.HasMany(E => E.BookSeries);
        builder.HasMany(E => E.Encyclopedias);
        builder.HasMany(E => E.Magazines);
        builder.HasMany(E => E.NewsPapers);
    }
}