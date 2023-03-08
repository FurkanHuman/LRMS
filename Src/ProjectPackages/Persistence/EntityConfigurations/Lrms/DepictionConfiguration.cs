// this file was created automatically.
using Domain.Entities.Mains;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations.Lrms;

public class DepictionConfiguration : IEntityTypeConfiguration<Depiction>
{
    public void Configure(EntityTypeBuilder<Depiction> builder)
    {
        builder.HasKey(D => D.Id);

    }
}