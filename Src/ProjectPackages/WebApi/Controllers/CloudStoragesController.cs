// this file was created automatically.
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CloudStoragesController : ControllerBase
{
    private readonly IMediator _mediator;

    public CloudStoragesController(IMediator mediator)
    {
        _mediator = mediator;
    }
}
