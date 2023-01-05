using PluralizeService.Core;

namespace LRMS.Generator.App.Codes.CreatorCodes.Feature;

internal class DtoCreator
{
    public string DtoCreate(Type type)
    {
        string plural = PluralizationProvider.Pluralize(type.Name);
        return

$@"// this file was created automatically.

namespace Application.Features.{plural}.Dtos;

public class {type.Name}Dto
{{
}}
";
    }
    public string ListDtoCreate(Type type)
    {
        string plural = PluralizationProvider.Pluralize(type.Name);
        return

$@"// this file was created automatically.

namespace Application.Features.{plural}.Dtos;

public class {type.Name}ListDto
{{
}}
";
    }
    public string CreatedDtoCreate(Type type)
    {
        string plural = PluralizationProvider.Pluralize(type.Name);
        return

$@"// this file was created automatically.

namespace Application.Features.{plural}.Dtos;

public class {type.Name}CraetedDto
{{
}}
";
    }
    public string DeletedDtoCreate(Type type)
    {
        string plural = PluralizationProvider.Pluralize(type.Name);
        return

$@"// this file was created automatically.

namespace Application.Features.{plural}.Dtos;

public class {type.Name}DeletedDto
{{
}}
";
    }
    public string UpdatedDtoCreate(Type type)
    {
        string plural = PluralizationProvider.Pluralize(type.Name);
        return

$@"// this file was created automatically.

namespace Application.Features.{plural}.Dtos;

public class {type.Name}UpdatedDto
{{
}}
";
    }
}
