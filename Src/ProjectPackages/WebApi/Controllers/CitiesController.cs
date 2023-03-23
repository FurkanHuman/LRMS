// this file was created automatically.
using Application.Features.Cities.Commands.CreateCity;
using Application.Features.Cities.Commands.DeleteCity;
using Application.Features.Cities.Commands.UpdateCity;
using Application.Features.Cities.Queries.GetByIdCity;
using Application.Features.Cities.Queries.GetListByCity;
using Core.Application.Requests;
using Core.Persistence.Paging;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CitiesController : ControllerBase
{
    private readonly IMediator _mediator;

    public CitiesController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet("{Id}")]
    public async Task<IActionResult> GetById([FromRoute] GetByIdCityQuery getByIdCityQuery)
    {
        GetByIdCityResponse result = await _mediator.Send(getByIdCityQuery);
        return Ok(result);
    }

    [HttpGet("GetList")]
    public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListByCityQuery getListByCityQuery = new() { PageRequest = pageRequest };
        GetListResponse<GetListByCityResponse> result = await _mediator.Send(getListByCityQuery);
        return Ok(result);
    }


    [HttpPost("Add")]
    public async Task<IActionResult> Add([FromBody] CreateCityCommand createCityCommand)
    {
        CreatedCityResponse result = await _mediator.Send(createCityCommand);
        return Created(uri: "", result);
    }

    [HttpPut("Update")]
    public async Task<IActionResult> Update([FromBody] UpdateCityCommand updateCityCommand)
    {
        UpdatedCityResponse result = await _mediator.Send(updateCityCommand);
        return Ok(result);
    }

    [HttpDelete("Delete")]
    public async Task<IActionResult> Delete([FromBody] DeleteCityCommand deleteCityCommand)
    {
        DeletedCityResponse result = await _mediator.Send(deleteCityCommand);
        return Ok(result);
    }
}
