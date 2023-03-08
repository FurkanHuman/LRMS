// this file was created automatically.
using Domain.Entities.Mains;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations.Lrms;

public class MagazineConfiguration : IEntityTypeConfiguration<Magazine>
{
    public void Configure(EntityTypeBuilder<Magazine> builder)
    {
        builder.HasKey(M => M.Id);

    }
}