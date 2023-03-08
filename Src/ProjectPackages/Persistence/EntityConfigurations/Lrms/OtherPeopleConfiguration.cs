// this file was created automatically.
using Domain.Entities.Infos;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations.Lrms;

public class OtherPeopleConfiguration : IEntityTypeConfiguration<OtherPeople>
{
    public void Configure(EntityTypeBuilder<OtherPeople> builder)
    {
        builder.HasKey(O => O.Id);

    }
}