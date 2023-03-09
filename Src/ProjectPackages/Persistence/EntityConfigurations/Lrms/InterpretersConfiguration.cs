// this file was created automatically.
using Domain.Entities.Infos;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations.Lrms;

public class InterpretersConfiguration : IEntityTypeConfiguration<Interpreters>
{
    public void Configure(EntityTypeBuilder<Interpreters> builder)
    {
        builder.HasKey(I => I.Id);
        builder.Property(I => I.Id);
        builder.Property(I => I.Name).IsRequired();
        builder.Property(I => I.SurName).IsRequired();
        builder.Property(I => I.WhichToLanguage).IsRequired();

        builder.Property(I => I.UpdatedDate);
        builder.Property(I => I.IsDeleted);

        builder.Ignore(I => I.CreatedDate);

        builder.HasMany(I => I.Books);
        builder.HasMany(I => I.BookSeries);
        builder.HasMany(I => I.Encyclopedias);
        builder.HasMany(I => I.Magazines);
        builder.HasMany(I => I.NewsPapers);
    }
}