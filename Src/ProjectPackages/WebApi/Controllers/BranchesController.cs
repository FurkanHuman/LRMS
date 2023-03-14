// this file was created automatically.
using Application.Features.Branches.Commands.CreateBranch;
using Application.Features.Branches.Commands.CreateBranches;
using Application.Features.Branches.Commands.DeleteBranch;
using Application.Features.Branches.Commands.UpdateBranch;
using Application.Features.Branches.Queries.GetByIdBranch;
using Application.Features.Branches.Queries.GetListByBranch;
using Core.Application.Requests;
using Core.Persistence.Paging;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BranchesController : ControllerBase
{
    private readonly IMediator _mediator;

    public BranchesController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet("{Id}")]
    public async Task<IActionResult> GetById([FromRoute] GetByIdBranchQuery getByIdBranchQuery)
    {
        GetByIdBranchResponse result = await _mediator.Send(getByIdBranchQuery);
        return Ok(result);
    }

    [HttpGet("GetList")]
    public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListByBranchQuery getListByBranchQuery = new() { PageRequest = pageRequest };
        GetListResponse<GetListByBranchResponse> result = await _mediator.Send(getListByBranchQuery);
        return Ok(result);
    }

    [HttpPost("Add")]
    public async Task<IActionResult> Add([FromBody] CreateBranchCommand createBranchCommand)
    {
        CreatedBranchResponse result = await _mediator.Send(createBranchCommand);
        return Created(uri: "", result);
    }

    [HttpPut("Update")]
    public async Task<IActionResult> Update([FromBody] UpdateBranchCommand updateBranchCommand)
    {
        UpdatedBranchResponse result = await _mediator.Send(updateBranchCommand);
        return Ok(result);
    }

    [HttpDelete("Delete")]
    public async Task<IActionResult> Delete([FromBody] DeleteBranchCommand deleteBranchCommand)
    {
        DeletedBranchResponse result = await _mediator.Send(deleteBranchCommand);
        return Ok(result);
    }

    [HttpPost("BulkInsert")]
    public async Task<IActionResult> BulkInsert([FromBody] CreateBranchesCommand bulkBranchesCommand)
    {
        CreatedBranchesResponse result = await _mediator.Send(bulkBranchesCommand);
        return Created(uri: "", result);
    }
}
