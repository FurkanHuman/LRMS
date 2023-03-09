// this file was created automatically.
using Domain.Entities.Infos;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations.Lrms;

public class DirectorConfiguration : IEntityTypeConfiguration<Director>
{
    public void Configure(EntityTypeBuilder<Director> builder)
    {
        builder.HasKey(D => D.Id);
        builder.Property(D => D.Id);
        builder.Property(D => D.Name).IsRequired();
        builder.Property(D => D.SurName).IsRequired();

        builder.Property(D => D.UpdatedDate);
        builder.Property(D => D.IsDeleted);

        builder.Ignore(D => D.CreatedDate);

        builder.HasMany(D => D.Books);
        builder.HasMany(D => D.BookSeries);
        builder.HasMany(D => D.Encyclopedias);
        builder.HasMany(D => D.Magazines);
        builder.HasMany(D => D.NewsPapers);

    }
}