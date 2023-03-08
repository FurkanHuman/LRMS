// this file was created automatically.
using Domain.Entities.Infos;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations.Lrms;

public class WriterConfiguration : IEntityTypeConfiguration<Writer>
{
    public void Configure(EntityTypeBuilder<Writer> builder)
    {
        builder.HasKey(W => W.Id);

    }
}