// this file was created automatically.
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class EncyclopediasController : ControllerBase
{
    private readonly IMediator _mediator;

    public EncyclopediasController(IMediator mediator)
    {
        _mediator = mediator;
    }
}
