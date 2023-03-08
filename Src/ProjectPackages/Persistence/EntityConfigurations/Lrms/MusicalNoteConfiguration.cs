// this file was created automatically.
using Domain.Entities.Mains;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations.Lrms;

public class MusicalNoteConfiguration : IEntityTypeConfiguration<MusicalNote>
{
    public void Configure(EntityTypeBuilder<MusicalNote> builder)
    {
        builder.HasKey(M => M.Id);

    }
}