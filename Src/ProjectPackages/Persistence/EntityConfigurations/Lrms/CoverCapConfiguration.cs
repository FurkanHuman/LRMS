// this file was created automatically.
using Domain.Entities.Infos;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations.Lrms;

public class CoverCapConfiguration : IEntityTypeConfiguration<CoverCap>
{
    public void Configure(EntityTypeBuilder<CoverCap> builder)
    {
        builder.HasKey(C => C.Id);
        builder.Property(C => C.Id);
        builder.Property(C => C.Name).IsRequired();

        builder.Ignore(C => C.CreatedDate);
        builder.Ignore(C => C.UpdatedDate);
        builder.Ignore(C => C.IsDeleted);

        builder.HasMany(C => C.Books);
        builder.HasMany(C => C.BookSeries);
        builder.HasMany(C => C.Encyclopedias);
        builder.HasMany(C => C.Magazines);
        builder.HasMany(C => C.NewsPapers);
    }
}