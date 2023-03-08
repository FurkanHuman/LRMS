// this file was created automatically.
using Domain.Entities.Infos;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations.Lrms;

public class EMaterialFileConfiguration : IEntityTypeConfiguration<EMaterialFile>
{
    public void Configure(EntityTypeBuilder<EMaterialFile> builder)
    {
        builder.HasKey(E => E.Id);

    }
}