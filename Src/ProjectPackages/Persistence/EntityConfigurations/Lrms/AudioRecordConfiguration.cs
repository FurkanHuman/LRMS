// this file was created automatically.
using Domain.Entities.Mains;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations.Lrms;

public class AudioRecordConfiguration : IEntityTypeConfiguration<AudioRecord>
{
    public void Configure(EntityTypeBuilder<AudioRecord> builder)
    {
        builder.HasKey(A => A.Id);

    }
}