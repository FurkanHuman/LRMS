// this file was created automatically.
using Domain.Entities.Infos;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations.Lrms;

public class ResearcherConfiguration : IEntityTypeConfiguration<Researcher>
{
    public void Configure(EntityTypeBuilder<Researcher> builder)
    {
        builder.HasKey(R => R.Id);
        builder.Property(R => R.Id);
        builder.Property(R => R.Name).IsRequired();
        builder.Property(R => R.SurName).IsRequired();
        builder.Property(R => R.NamePreAttachment).IsRequired();
        builder.Property(R => R.Specialty).IsRequired();
        builder.Property(R => R.UniversityId).IsRequired();

        builder.Property(R => R.UpdatedDate);

        builder.Ignore(R => R.CreatedDate);
        builder.Ignore(R => R.IsDeleted);

        builder.HasOne(R => R.University);
      
        builder.HasMany(R => R.AcademicJournals);
        builder.HasMany(R => R.Dissertations);
    }
}