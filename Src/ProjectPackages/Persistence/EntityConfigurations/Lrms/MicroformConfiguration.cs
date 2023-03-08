// this file was created automatically.
using Domain.Entities.Mains;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations.Lrms;

public class MicroformConfiguration : IEntityTypeConfiguration<Microform>
{
    public void Configure(EntityTypeBuilder<Microform> builder)
    {
        builder.HasKey(M => M.Id);

    }
}