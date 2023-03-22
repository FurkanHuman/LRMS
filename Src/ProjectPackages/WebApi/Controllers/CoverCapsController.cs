// this file was created automatically.
using Application.Features.CoverCaps.Commands.CreateCoverCap;
using Application.Features.CoverCaps.Commands.DeleteCoverCap;
using Application.Features.CoverCaps.Commands.UpdateCoverCap;
using Application.Features.CoverCaps.Queries.GetByIdCoverCap;
using Application.Features.CoverCaps.Queries.GetListByCoverCap;
using Core.Application.Requests;
using Core.Persistence.Paging;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CoverCapsController : ControllerBase
{
    private readonly IMediator _mediator;

    public CoverCapsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet("{Id}")]
    public async Task<IActionResult> GetById([FromRoute] GetByIdCoverCapQuery getByIdCoverCapQuery)
    {
        GetByIdCoverCapResponse result = await _mediator.Send(getByIdCoverCapQuery);
        return Ok(result);
    }

    [HttpGet("GetList")]
    public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListByCoverCapQuery getListByCoverCapQuery = new() { PageRequest = pageRequest };
        GetListResponse<GetListByCoverCapResponse> result = await _mediator.Send(getListByCoverCapQuery);
        return Ok(result);
    }

    [HttpPost("Add")]
    public async Task<IActionResult> Add([FromBody] CreateCoverCapCommand createCoverCapCommand)
    {
        CreatedCoverCapResponse result = await _mediator.Send(createCoverCapCommand);
        return Created(uri: "", result);
    }

    [HttpPut("Update")]
    public async Task<IActionResult> Update([FromBody] UpdateCoverCapCommand updateCoverCapCommand)
    {
        UpdatedCoverCapResponse result = await _mediator.Send(updateCoverCapCommand);
        return Ok(result);
    }

    [HttpDelete("Delete")]
    public async Task<IActionResult> Delete([FromBody] DeleteCoverCapCommand deleteCoverCapCommand)
    {
        DeletedCoverCapResponse result = await _mediator.Send(deleteCoverCapCommand);
        return Ok(result);
    }
}
