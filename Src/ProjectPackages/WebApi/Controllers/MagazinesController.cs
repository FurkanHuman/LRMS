// this file was created automatically.
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class MagazinesController : ControllerBase
{
    private readonly IMediator _mediator;

    public MagazinesController(IMediator mediator)
    {
        _mediator = mediator;
    }
}
