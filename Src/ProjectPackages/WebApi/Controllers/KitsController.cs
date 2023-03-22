// this file was created automatically.
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class KitsController : ControllerBase
{
    private readonly IMediator _mediator;

    public KitsController(IMediator mediator)
    {
        _mediator = mediator;
    }
}
