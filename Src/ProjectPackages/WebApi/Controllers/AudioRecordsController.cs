// this file was created automatically.
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AudioRecordsController : ControllerBase
{
    private readonly IMediator _mediator;

    public AudioRecordsController(IMediator mediator)
    {
        _mediator = mediator;
    }
}
