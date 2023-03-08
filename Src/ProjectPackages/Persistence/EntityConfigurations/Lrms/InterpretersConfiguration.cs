// this file was created automatically.
using Domain.Entities.Infos;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations.Lrms;

public class InterpretersConfiguration : IEntityTypeConfiguration<Interpreters>
{
    public void Configure(EntityTypeBuilder<Interpreters> builder)
    {
        builder.HasKey(I => I.Id);

    }
}