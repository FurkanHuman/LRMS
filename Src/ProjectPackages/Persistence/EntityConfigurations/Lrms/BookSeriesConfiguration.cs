// this file was created automatically.
using Domain.Entities.Mains;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations.Lrms;

public class BookSeriesConfiguration : IEntityTypeConfiguration<BookSeries>
{
    public void Configure(EntityTypeBuilder<BookSeries> builder)
    {
        builder.HasKey(B => B.Id);

    }
}