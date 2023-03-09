// this file was created automatically.
using Domain.Entities.Infos;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations.Lrms;

public class WriterConfiguration : IEntityTypeConfiguration<Writer>
{
    public void Configure(EntityTypeBuilder<Writer> builder)
    {
        builder.HasKey(W => W.Id);
        builder.Property(W => W.Id);
        builder.Property(W => W.Name).IsRequired();
        builder.Property(W => W.SurName).IsRequired();
        builder.Property(W => W.NamePreAttachment);

        builder.Property(W => W.UpdatedDate);
        builder.Property(W => W.IsDeleted);

        builder.Ignore(W => W.CreatedDate);

        builder.HasMany(W => W.Books);
        builder.HasMany(W => W.BookSeries);
        builder.HasMany(W => W.Encyclopedias);
        builder.HasMany(W => W.Magazines);
        builder.HasMany(W => W.NewsPapers);
    }
}