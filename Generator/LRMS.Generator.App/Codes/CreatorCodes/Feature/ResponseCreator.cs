using PluralizeService.Core;

namespace LRMS.Generator.App.Codes.CreatorCodes.Feature;

internal class ResponseCreator : ICreatorCode
{
    public ResponseCreator(Type type)
    {
        Type = type;
    }

    public Type Type { get; set; }

    public string ResponseCreate()
    {
        string plural = PluralizationProvider.Pluralize(Type.Name);
        return

$@"// this file was created automatically.

using Core.Application.Dtos;

namespace Application.Features.{plural}.Queries.GetById{Type.Name};

public class {Type.Name}Response : IDto
{{
}}
";
    }

    public string ListResponseCreate()
    {
        string plural = PluralizationProvider.Pluralize(Type.Name);
        return

$@"// this file was created automatically.

using Core.Application.Dtos;

namespace Application.Features.{plural}.Queries.GetList{Type.Name};

public class {Type.Name}ListResponse : IDto
{{
}}
";
    }

    public string ByDynamicQueryResponseCreate()
    {
        string plural = PluralizationProvider.Pluralize(Type.Name);
        return

$@"// this file was created automatically.

using Core.Application.Dtos;

namespace Application.Features.{plural}.Queries.GetList{Type.Name}ByDynamic;

public class {Type.Name}ByDynamicQueryResponse : IDto
{{
}}
";
    }

    public string CreatedResponseCreate()
    {
        string plural = PluralizationProvider.Pluralize(Type.Name);
        return

$@"// this file was created automatically.

using Core.Application.Dtos;

namespace Application.Features.{plural}.Commands.Create{Type.Name};

public class Created{Type.Name}Response : IDto
{{
}}
";
    }
    
    public string DeletedResponseCreate()
    {
        string plural = PluralizationProvider.Pluralize(Type.Name);
        return

$@"// this file was created automatically.

using Core.Application.Dtos;

namespace Application.Features.{plural}.Commands.Delete{Type.Name};

public class Deleted{Type.Name}Response : IDto
{{
}}
";
    }
    
    public string UpdatedResponseCreate()
    {
        string plural = PluralizationProvider.Pluralize(Type.Name);
        return

$@"// this file was created automatically.

using Core.Application.Dtos;

namespace Application.Features.{plural}.Commands.Update{Type.Name};

public class Updated{Type.Name}Response : IDto
{{
}}
";
    }
}
