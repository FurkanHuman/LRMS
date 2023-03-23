// this file was created automatically.
using Application.Features.Languages.Commands.CreateLanguage;
using Application.Features.Languages.Commands.DeleteLanguage;
using Application.Features.Languages.Commands.UpdateLanguage;
using Application.Features.Languages.Queries.GetByIdLanguage;
using Application.Features.Languages.Queries.GetListByLanguage;
using Core.Application.Requests;
using Core.Persistence.Paging;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class LanguagesController : ControllerBase
{
    private readonly IMediator _mediator;

    public LanguagesController(IMediator mediator)
    {
        _mediator = mediator;
    }


    [HttpGet("{Id}")]
    public async Task<IActionResult> GetById([FromRoute] GetByIdLanguageQuery getByIdLanguageQuery)
    {
        GetByIdLanguageResponse result = await _mediator.Send(getByIdLanguageQuery);
        return Ok(result);
    }

    [HttpGet("GetList")]
    public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListByLanguageQuery getListByLanguageQuery = new() { PageRequest = pageRequest };
        GetListResponse<GetListByLanguageResponse> result = await _mediator.Send(getListByLanguageQuery);
        return Ok(result);
    }


    [HttpPost("Add")]
    public async Task<IActionResult> Add([FromBody] CreateLanguageCommand createLanguageCommand)
    {
        CreatedLanguageResponse result = await _mediator.Send(createLanguageCommand);
        return Created(uri: "", result);
    }

    [HttpPut("Update")]
    public async Task<IActionResult> Update([FromBody] UpdateLanguageCommand updateLanguageCommand)
    {
        UpdatedLanguageResponse result = await _mediator.Send(updateLanguageCommand);
        return Ok(result);
    }

    [HttpDelete("Delete")]
    public async Task<IActionResult> Delete([FromBody] DeleteLanguageCommand deleteLanguageCommand)
    {
        DeletedLanguageResponse result = await _mediator.Send(deleteLanguageCommand);
        return Ok(result);
    }
}
