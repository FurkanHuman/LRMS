// this file was created automatically.
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CoverCapsController : ControllerBase
{
    private readonly IMediator _mediator;

    public CoverCapsController(IMediator mediator)
    {
        _mediator = mediator;
    }
}
