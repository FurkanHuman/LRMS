// this file was created automatically.
using Domain.Entities.Mains;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations.Lrms;

public class NewsPaperConfiguration : IEntityTypeConfiguration<NewsPaper>
{
    public void Configure(EntityTypeBuilder<NewsPaper> builder)
    {
        builder.HasKey(N => N.Id);

    }
}