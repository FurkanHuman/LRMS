using PluralizeService.Core;

namespace LRMS.Generator.App.Codes.CreatorCodes.Feature;

internal class RuleCreator
{
    public static string RuleCreate(Type type)
    {
        string plural = PluralizationProvider.Pluralize(type.Name);
        return
            $@"// this file was created automatically.
using Application.Repositories;
using Application.Features.{plural}.Constants;
using Core.Application.Rules;

using {type.Namespace};

namespace Application.Features.{plural}.Rules;

public class {type.Name}BusinessRules : BaseBusinessRules
{{

    private readonly I{type.Name}Repository _{type.Name.ToLower()}Repository;

    public {type.Name}BusinessRules(I{type.Name}Repository {type.Name.ToLower()}Repository)
    {{
        _{type.Name.ToLower()}Repository = {type.Name.ToLower()}Repository;
    }}
}}
";
    }
}
