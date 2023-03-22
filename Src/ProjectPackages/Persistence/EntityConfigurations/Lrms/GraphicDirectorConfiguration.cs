// this file was created automatically.
using Domain.Entities.Infos;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations.Lrms;

public class GraphicDirectorConfiguration : IEntityTypeConfiguration<GraphicDirector>
{
    public void Configure(EntityTypeBuilder<GraphicDirector> builder)
    {
        builder.HasKey(G => G.Id);
        builder.Property(G => G.Id);
        builder.Property(G => G.Name).IsRequired();
        builder.Property(G => G.SurName).IsRequired();
        builder.Property(G => G.IsDeleted);

        builder.Ignore(G => G.CreatedDate);
        builder.Ignore(G => G.UpdatedDate);

        builder.HasMany(G => G.Books);
        builder.HasMany(G => G.BookSeries);
        builder.HasMany(G => G.Encyclopedias);
        builder.HasMany(G => G.Magazines);
        builder.HasMany(G => G.NewsPapers);
    }
}