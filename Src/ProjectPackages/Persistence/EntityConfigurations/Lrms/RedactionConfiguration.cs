// this file was created automatically.
using Domain.Entities.Infos;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations.Lrms;

public class RedactionConfiguration : IEntityTypeConfiguration<Redaction>
{
    public void Configure(EntityTypeBuilder<Redaction> builder)
    {
        builder.HasKey(R => R.Id);

    }
}