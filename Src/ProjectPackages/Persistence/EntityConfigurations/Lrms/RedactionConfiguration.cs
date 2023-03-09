// this file was created automatically.
using Domain.Entities.Infos;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations.Lrms;

public class RedactionConfiguration : IEntityTypeConfiguration<Redaction>
{
    public void Configure(EntityTypeBuilder<Redaction> builder)
    {
        builder.HasKey(R => R.Id);
        builder.Property(R => R.Id);
        builder.Property(R => R.Name).IsRequired();
        builder.Property(R => R.SurName).IsRequired();

        builder.Property(R => R.IsDeleted);

        builder.Ignore(R => R.CreatedDate);
        builder.Ignore(R => R.UpdatedDate);

        builder.HasMany(R => R.Books);
        builder.HasMany(R => R.BookSeries);
        builder.HasMany(R => R.Encyclopedias);
        builder.HasMany(R => R.Magazines);
        builder.HasMany(R => R.NewsPapers);
    }
}