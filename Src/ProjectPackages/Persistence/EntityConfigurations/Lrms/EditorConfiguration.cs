// this file was created automatically.
using Domain.Entities.Infos;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations.Lrms;

public class EditorConfiguration : IEntityTypeConfiguration<Editor>
{
    public void Configure(EntityTypeBuilder<Editor> builder)
    {
        builder.HasKey(E => E.Id);
        builder.Property(E => E.Id);
        builder.Property(E => E.Name).IsRequired();
        builder.Property(E => E.SurName).IsRequired();

        builder.Property(E => E.UpdatedDate);
        builder.Property(E => E.IsDeleted);

        builder.Ignore(E => E.CreatedDate);

        builder.HasMany(E => E.Books);
        builder.HasMany(E => E.BookSeries);
        builder.HasMany(E => E.Encyclopedias);
        builder.HasMany(E => E.Magazines);
        builder.HasMany(E => E.NewsPapers);
    }
}