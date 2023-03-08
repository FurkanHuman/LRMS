// this file was created automatically.
using Domain.Entities.Mains;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations.Lrms;

public class ThesisConfiguration : IEntityTypeConfiguration<Thesis>
{
    public void Configure(EntityTypeBuilder<Thesis> builder)
    {
        builder.HasKey(T => T.Id);

    }
}