// this file was created automatically.
using Domain.Entities.Infos;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations.Lrms;

public class EMaterialFileConfiguration : IEntityTypeConfiguration<EMaterialFile>
{
    public void Configure(EntityTypeBuilder<EMaterialFile> builder)
    {
        builder.HasKey(E => E.Id);
        builder.Property(E => E.Id);
        builder.Property(E => E.Name).IsRequired();
        builder.Property(E => E.Title);
        builder.Property(E => E.FilePath).IsRequired();
        builder.Property(E => E.FileSizeMB).IsRequired();
        builder.Property(E=>E.CloudStorageServiceId).IsRequired();

        builder.Property(E => E.CreatedDate);
        builder.Property(E => E.UpdatedDate);
        builder.Property(E => E.IsDeleted);

        builder.HasMany(E => E.CloudStorageServices);

        builder.HasMany(E => E.AcademicJournals);
        builder.HasMany(E => E.AudioRecords);
        builder.HasMany(E => E.Books);
        builder.HasMany(E => E.BookSeries);
        builder.HasMany(E => E.CartographicMaterials);
        builder.HasMany(E => E.Depictions);
        builder.HasMany(E => E.Dissertations);
        builder.HasMany(E => E.ElectronicsResources);
        builder.HasMany(E => E.Encyclopedias);
        builder.HasMany(E => E.GraphicalImages);
        builder.HasMany(E => E.Magazines);
        builder.HasMany(E => E.Microforms);
        builder.HasMany(E => E.MusicalNotes);
        builder.HasMany(E => E.NewsPapers);
        builder.HasMany(E => E.Object3Ds);
        builder.HasMany(E => E.Paintings);
        builder.HasMany(E => E.Posters);
        builder.HasMany(E => E.Theses);
    }
}