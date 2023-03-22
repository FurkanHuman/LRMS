// this file was created automatically.
using Domain.Entities.Infos;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations.Lrms;

public class TechnicalPlaceholderConfiguration : IEntityTypeConfiguration<TechnicalPlaceholder>
{
    public void Configure(EntityTypeBuilder<TechnicalPlaceholder> builder)
    {
        builder.HasKey(T => T.Id);
        builder.Property(T => T.Id);
        builder.Property(T => T.LibraryId).IsRequired();
        builder.Property(T => T.ColumnCode).IsRequired();
        builder.Property(T => T.RowCode).IsRequired();
        builder.Property(T => T.SpecialLocation);
        
        builder.Property(T => T.CreatedDate);
        builder.Property(T => T.UpdatedDate);
        builder.Property(T => T.IsDeleted);

        builder.Ignore(T => T.Name);

        builder.HasMany(T => T.AcademicJournals);
        builder.HasMany(T => T.AudioRecords);
        builder.HasMany(T => T.Books);
        builder.HasMany(T => T.BookSeries);
        builder.HasMany(T => T.CartographicMaterials);
        builder.HasMany(T => T.Depictions);
        builder.HasMany(T => T.Dissertations);
        builder.HasMany(T => T.ElectronicsResources);
        builder.HasMany(T => T.Encyclopedias);
        builder.HasMany(T => T.GraphicalImages);
        builder.HasMany(T => T.Magazines);
        builder.HasMany(T => T.Microforms);
        builder.HasMany(T => T.MusicalNotes);
        builder.HasMany(T => T.NewsPapers);
        builder.HasMany(T => T.Object3Ds);
        builder.HasMany(T => T.Paintings);
        builder.HasMany(T => T.Posters);
        builder.HasMany(T => T.Theses);
    }
}