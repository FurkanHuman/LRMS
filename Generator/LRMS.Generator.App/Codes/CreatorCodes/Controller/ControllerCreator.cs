using PluralizeService.Core;

namespace LRMS.Generator.App.Codes.CreatorCodes.Controller;

internal class ControllerCreator
{
    public ControllerCreator(Type type)
    {
        Type = type;
    }

    public Type Type;

    public string ControllerCreate()
    {
        string plural = PluralizationProvider.Pluralize(Type.Name);
        return $@"// this file was created automatically.
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route(""api/[controller]"")]
[ApiController]
public class {plural}Controller : ControllerBase
{{
    private readonly IMediator _mediator;

    public {plural}Controller(IMediator mediator)
    {{
        _mediator = mediator;
    }}
}}
";
    }
}
