// this file was created automatically.
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PostersController : ControllerBase
{
    private readonly IMediator _mediator;

    public PostersController(IMediator mediator)
    {
        _mediator = mediator;
    }
}
