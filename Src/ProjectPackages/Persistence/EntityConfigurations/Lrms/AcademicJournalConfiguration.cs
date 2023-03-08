// this file was created automatically.
using Domain.Entities.Mains;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations.Lrms;

public class AcademicJournalConfiguration : IEntityTypeConfiguration<AcademicJournal>
{
    public void Configure(EntityTypeBuilder<AcademicJournal> builder)
    {
        builder.HasKey(A => A.Id);

    }
}