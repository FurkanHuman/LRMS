// this file was created automatically.

using Application.Features.Categories.Commands.CreateCategory;
using Application.Features.Categories.Commands.DeleteCategory;
using Application.Features.Categories.Commands.UpdateCategory;
using Application.Features.Categories.Queries.GetByIdCategory;
using Application.Features.Categories.Queries.GetListByCategory;
using Core.Application.Requests;
using Core.Persistence.Paging;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CategoriesController : ControllerBase
{
    private readonly IMediator _mediator;

    public CategoriesController(IMediator mediator)
    {
        _mediator = mediator;
    }


    [HttpGet("{Id}")]
    public async Task<IActionResult> GetById([FromRoute] GetByIdCategoryQuery getByIdCategoryQuery)
    {
        GetByIdCategoryResponse result = await _mediator.Send(getByIdCategoryQuery);
        return Ok(result);
    }

    [HttpGet("GetList")]
    public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListByCategoryQuery getListByCategoryQuery = new() { PageRequest = pageRequest };
        GetListResponse<GetListByCategoryResponse> result = await _mediator.Send(getListByCategoryQuery);
        return Ok(result);
    }

    [HttpPost("Add")]
    public async Task<IActionResult> Add([FromBody] CreateCategoryCommand createCategoryCommand)
    {
        CreatedCategoryResponse result = await _mediator.Send(createCategoryCommand);
        return Created(uri: "", result);
    }

    [HttpPut("Update")]
    public async Task<IActionResult> Update([FromBody] UpdateCategoryCommand updateCategoryCommand)
    {
        UpdatedCategoryResponse result = await _mediator.Send(updateCategoryCommand);
        return Ok(result);
    }

    [HttpDelete("Delete")]
    public async Task<IActionResult> Delete([FromBody] DeleteCategoryCommand deleteCategoryCommand)
    {
        DeletedCategoryResponse result = await _mediator.Send(deleteCategoryCommand);
        return Ok(result);
    }
}
