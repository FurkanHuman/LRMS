// this file was created automatically.
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TechnicalNumbersController : ControllerBase
{
    private readonly IMediator _mediator;

    public TechnicalNumbersController(IMediator mediator)
    {
        _mediator = mediator;
    }
}
