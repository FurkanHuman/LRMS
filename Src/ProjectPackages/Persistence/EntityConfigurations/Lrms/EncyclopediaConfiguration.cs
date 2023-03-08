// this file was created automatically.
using Domain.Entities.Mains;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations.Lrms;

public class EncyclopediaConfiguration : IEntityTypeConfiguration<Encyclopedia>
{
    public void Configure(EntityTypeBuilder<Encyclopedia> builder)
    {
        builder.HasKey(E => E.Id);

    }
}