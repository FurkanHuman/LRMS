// this file was created automatically.
using Domain.Entities.Infos;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations.Lrms;

public class DimensionConfiguration : IEntityTypeConfiguration<Dimension>
{
    public void Configure(EntityTypeBuilder<Dimension> builder)
    {
        builder.HasKey(D => D.Id);
        builder.Property(D => D.Id);
        builder.Property(D => D.Name).IsRequired(false);
        builder.HasIndex(D => D.Name).IsUnique();

        builder.Ignore(D => D.CreatedDate);
        builder.Ignore(D => D.UpdatedDate);
        builder.Ignore(D => D.IsDeleted);

        builder.HasMany(D => D.AcademicJournals);
        builder.HasMany(D => D.AudioRecords);
        builder.HasMany(D => D.Books);
        builder.HasMany(D => D.BookSeries);
        builder.HasMany(D => D.CartographicMaterials);
        builder.HasMany(D => D.Depictions);
        builder.HasMany(D => D.Dissertations);
        builder.HasMany(D => D.ElectronicsResources);
        builder.HasMany(D => D.Encyclopedias);
        builder.HasMany(D => D.GraphicalImages);
        builder.HasMany(D => D.Magazines);
        builder.HasMany(D => D.Microforms);
        builder.HasMany(D => D.MusicalNotes);
        builder.HasMany(D => D.NewsPapers);
        builder.HasMany(D => D.Object3Ds);
        builder.HasMany(D => D.Paintings);
        builder.HasMany(D => D.Posters);
        builder.HasMany(D => D.Theses);
    }
}