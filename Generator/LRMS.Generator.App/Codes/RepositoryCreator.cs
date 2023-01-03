namespace LRMS.Generator.App.Codes;

internal class RepositoryCreator
{
    public string ISyncAndAsyncRepository(Type type)
    {
        return
$@"// this file was created automatically.
using Core.Persistence.Repositories;
using {type.Namespace};

namespace Application.Repositories;

public interface I{type.Name}Repository : IAsyncRepository<{type.Name}>, IRepository<{type.Name}>
{{
}}
";
    }
    public string NormalRepository(Type type)
    {
        return
$@"// this file was created automatically.
using Core.Persistence.Repositories;
using {type.Namespace};
using Persistence.Contexts;
using Application.Repositories;

namespace Persistence.Repositories;

public class {type.Name}Repository : EfRepositoryBase<{type.Name}, PostgreLRMSDbContext>, I{type.Name}Repository
{{
    public {type.Name}Repository(PostgreLRMSDbContext context) : base(context) {{ }}
}}
";
    }

    public string UserRepository(Type type)
    {
        return
$@"// this file was created automatically.
using Core.Persistence.Repositories;
using {type.Namespace};
using Persistence.Contexts;
using Application.Repositories;

namespace Persistence.Repositories;

public class {type.Name}Repository : EfRepositoryBase<{type.Name}, PostgreLRMSDbContext>, I{type.Name}Repository
{{
    public {type.Name}Repository(PostgreLRMSDbContext context) : base(context) {{ }}
{type.Name}
}}
";
    }

    public string ISyncRepository(Type type)
    {

        return
$@"// this file was created automatically.
using Core.Persistence.Repositories;
using {type.Namespace};

namespace Application.Repositories;

public interface I{type.Name}Repository : IRepository<{type.Name}>
{{
}}
";
    }
    public string IAsyncRepository(Type type)
    {
        return
            $@"// this file was created automatically.
using Core.Persistence.Repositories;
using {type.Namespace};

namespace Application.Repositories;

public interface I{type.Name}Repository : IAsyncRepository<{type.Name}>
{{
}}
";

    }
    public string IEmptyRepository(Type type)
    {
        return
$@"// this file was created automatically.
using Core.Persistence.Repositories;
using {type.Namespace};

namespace Application.Repositories;

public interface I{type.Name}Repository : 
{{
}}
";
    }
}
