// this file was created automatically.
using Domain.Entities.Mains;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations.Lrms;

public class ElectronicsResourceConfiguration : IEntityTypeConfiguration<ElectronicsResource>
{
    public void Configure(EntityTypeBuilder<ElectronicsResource> builder)
    {
        builder.HasKey(E => E.Id);

    }
}