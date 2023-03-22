// this file was created automatically.
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class Object3DController : ControllerBase
{
    private readonly IMediator _mediator;

    public Object3DController(IMediator mediator)
    {
        _mediator = mediator;
    }
}
