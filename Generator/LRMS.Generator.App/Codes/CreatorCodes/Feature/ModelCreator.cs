using PluralizeService.Core;

namespace LRMS.Generator.App.Codes.CreatorCodes.Feature;

internal class ModelCreator
{
    public static string ListModelCreate(Type type)
    {
        string plural = PluralizationProvider.Pluralize(type.Name);

        return
            @$"// this file was created automatically.
using Application.Features.{plural}.Dtos;
using Core.Persistence.Paging;

namespace Application.Features.{plural}.Models;

public class {type.Name}ListModel : BasePageableModel
{{
    public IList<{type.Name}ListDto> Items {{ get; set; }}
}}
";
    }
}
