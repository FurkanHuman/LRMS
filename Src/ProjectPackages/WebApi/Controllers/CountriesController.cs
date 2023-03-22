// this file was created automatically.
using Application.Features.Countries.Commands.CreateCountries;
using Application.Features.Countries.Commands.CreateCountry;
using Application.Features.Countries.Commands.DeleteCountry;
using Application.Features.Countries.Commands.UpdateCountry;
using Application.Features.Countries.Queries.GetByIdCountry;
using Application.Features.Countries.Queries.GetListByCountry;
using Core.Application.Requests;
using Core.Persistence.Paging;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CountriesController : ControllerBase
{
    private readonly IMediator _mediator;

    public CountriesController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet("{Id}")]
    public async Task<IActionResult> GetById([FromRoute] GetByIdCountryQuery getByIdCountryQuery)
    {
        GetByIdCountryResponse result = await _mediator.Send(getByIdCountryQuery);
        return Ok(result);
    }

    [HttpGet("GetList")]
    public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListByCountryQuery getListByCountryQuery = new() { PageRequest = pageRequest };
        GetListResponse<GetListByCountryResponse> result = await _mediator.Send(getListByCountryQuery);
        return Ok(result);
    }

    [HttpPost("Add")]
    public async Task<IActionResult> Add([FromBody] CreateCountryCommand createCountry)
    {
        CreatedCountryResponse result = await _mediator.Send(createCountry);
        return Created("", result);
    }

    [HttpPut("Update")]
    public async Task<IActionResult> Update([FromBody] UpdateCountryCommand updateBranch)
    {
        UpdatedCountryResponse result = await _mediator.Send(updateBranch);
        return Ok(result);
    }

    [HttpDelete("Delete")]
    public async Task<IActionResult> Delete([FromBody] DeleteCountryCommand deleteCountry)
    {
        DeletedCountryResponse result = await _mediator.Send(deleteCountry);
        return Ok(result);
    }

    [HttpPost("BulkInsert")]
    public async Task<IActionResult> BulkInsert([FromBody] CreateCountriesCommand bulkInsert)
    {
        CreatedCountriesResponse result = await _mediator.Send(bulkInsert);
        return Created(uri: "", result);        
    }
}
