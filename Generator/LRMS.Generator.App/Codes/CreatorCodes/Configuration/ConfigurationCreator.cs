using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace LRMS.Generator.App.Codes.CreatorCodes.Configuration
{
    internal class ConfigurationCreator : ICreatorCode
    {
        public ConfigurationCreator(Type type)
        {
            Type = type;
        }

        public Type Type { get; set; }


        public string CreateEntityConfiguration()
        {
            if (Type.Assembly.FullName == "Core.Domain")
                return
    $@"// this file was created automatically.
using {Type.Namespace};
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations.LrmsUser;

public class {Type.Name}Configuration : IEntityTypeConfiguration<{Type.Name}>
{{
    public void Configure(EntityTypeBuilder<{Type.Name}> builder)
    {{
        builder.HasKey({Type.Name.ToLowerInvariant()[0]} => {Type.Name.ToLowerInvariant()[0]}.Id);

        builder.Property({Type.Name.ToLowerInvariant()[0]} => {Type.Name.ToLowerInvariant()[0]}.Id);
    }}
}}";


            return
$@"// this file was created automatically.
using {Type.Namespace};
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations.Lrms;

public class {Type.Name}Configuration : IEntityTypeConfiguration<{Type.Name}>
{{
    public void Configure(EntityTypeBuilder<{Type.Name}> builder)
    {{
        builder.HasKey({Type.Name.ToLowerInvariant()[0]} => {Type.Name.ToLowerInvariant()[0]}.Id);

        builder.Property({Type.Name.ToLowerInvariant()[0]} => {Type.Name.ToLowerInvariant()[0]}.Id);
    }}
}}";
        }
    }
}
