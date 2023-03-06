using PluralizeService.Core;

namespace LRMS.Generator.App.Codes.CreatorCodes.Feature;

internal class ResponseCreator : ICreatorCode
{
    public ResponseCreator(Type type)
    {
        Type = type;
    }

    public Type Type { get; set; }

    public string GetByIdResponseCreate()
    {
        string plural = PluralizationProvider.Pluralize(Type.Name);
        return

$@"// this file was created automatically.

using Core.Application.Dtos;

namespace Application.Features.{plural}.Queries.GetById{Type.Name};

public class GetById{Type.Name}Response : IDto
{{
}}
";
    }

    public string GetListByResponseCreate()
    {
        string plural = PluralizationProvider.Pluralize(Type.Name);
        return

$@"// this file was created automatically.

using Core.Application.Dtos;

namespace Application.Features.{plural}.Queries.GetListBy{Type.Name};

public class GetListBy{Type.Name}Response : IDto
{{
}}
";
    }

    public string GetListByDynamicResponseCreate()
    {
        string plural = PluralizationProvider.Pluralize(Type.Name);
        return

$@"// this file was created automatically.

using Core.Application.Dtos;

namespace Application.Features.{plural}.Queries.GetListBy{Type.Name}Dynamic;

public class GetListBy{Type.Name}DynamicQueryResponse : IDto
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
