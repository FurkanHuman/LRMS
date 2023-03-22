// this file was created automatically.
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AcademicJournalsController : ControllerBase
{
    private readonly IMediator _mediator;

    public AcademicJournalsController(IMediator mediator)
    {
        _mediator = mediator;
    }
}
