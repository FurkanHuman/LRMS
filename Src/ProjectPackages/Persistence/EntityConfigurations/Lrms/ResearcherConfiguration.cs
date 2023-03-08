// this file was created automatically.
using Domain.Entities.Infos;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations.Lrms;

public class ResearcherConfiguration : IEntityTypeConfiguration<Researcher>
{
    public void Configure(EntityTypeBuilder<Researcher> builder)
    {
        builder.HasKey(R => R.Id);

    }
}