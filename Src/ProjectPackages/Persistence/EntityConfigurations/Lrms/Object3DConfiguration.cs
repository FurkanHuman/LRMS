// this file was created automatically.
using Domain.Entities.Mains;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations.Lrms;

public class Object3DConfiguration : IEntityTypeConfiguration<Object3D>
{
    public void Configure(EntityTypeBuilder<Object3D> builder)
    {
        builder.HasKey(O => O.Id);

    }
}