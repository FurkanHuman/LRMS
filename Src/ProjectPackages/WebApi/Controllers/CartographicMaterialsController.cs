// this file was created automatically.
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CartographicMaterialsController : ControllerBase
{
    private readonly IMediator _mediator;

    public CartographicMaterialsController(IMediator mediator)
    {
        _mediator = mediator;
    }
}
