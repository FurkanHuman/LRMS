using PluralizeService.Core;

namespace LRMS.Generator.App.Codes.CreatorCodes.Feature;

internal class ConstantsCreator : ICreatorCode
{
    public ConstantsCreator(Type type)
    {
        Type = type;
    }

    public Type Type { get; set; }

    public string ConstantsCreate()
    {

        string plural = PluralizationProvider.Pluralize(Type.Name);
        return
            $@"// this file was created automatically.
namespace Application.Features.{plural}.Constants;

public static class {Type.Name}Messages
{{
}}";
    }
    public string EntityOperationClaimsCreate()
    {

        string plural = PluralizationProvider.Pluralize(Type.Name);
        return
            $@"// this file was created automatically.
namespace Application.Features.{plural}.Constants;

public static class {Type.Name}OperationClaims
{{
}}";
    }
}
