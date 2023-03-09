// this file was created automatically.
using Domain.Entities.Infos;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations.Lrms;

public class TechnicalNumberConfiguration : IEntityTypeConfiguration<TechnicalNumber>
{
    public void Configure(EntityTypeBuilder<TechnicalNumber> builder)
    {
        builder.HasKey(T => T.Id);
        builder.Property(T => T.Id);
        builder.Property(T => T.Barcode).IsRequired();
        builder.Property(T => T.ISBN).IsRequired();
        builder.Property(T => T.ISSN);
        builder.Property(T => T.CertificateCode);

        builder.Property(T => T.CreatedDate);
        builder.Property(T => T.UpdatedDate);
        builder.Property(T => T.IsDeleted); 
        
        builder.Ignore(T => T.Name);

        builder.HasMany(T => T.Books);
        builder.HasMany(T => T.BookSeries);
        builder.HasMany(T => T.Encyclopedias);
        builder.HasMany(T => T.Magazines);
        builder.HasMany(T => T.NewsPapers);
    }
}