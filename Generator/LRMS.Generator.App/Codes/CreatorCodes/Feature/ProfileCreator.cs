using PluralizeService.Core;

namespace LRMS.Generator.App.Codes.CreatorCodes.Feature;

internal class ProfileCreator
{
    public static string MappingProfileCreator(Type type)
    {
        return
            $@"// this file was created automatically.
using AutoMapper;
using {type.Namespace};

namespace Application.Features.{PluralizationProvider.Pluralize(type.Name)}.Profiles;

public class MappingProfiles : Profile
{{
    public MappingProfiles()
    {{
    
    }}
}}
";
    }
}
