using Application.Features.Rentals.Commands.Create;
using Application.Features.Rentals.Commands.Delete;
using Application.Features.Rentals.Commands.Update;
using Application.Features.Rentals.Queries.GetById;
using Application.Features.Rentals.Queries.GetList;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class RentalsController : BaseController
{
    [HttpPost]
    public async Task<ActionResult<CreatedRentalResponse>> Add([FromBody] CreateRentalCommand command)
    {
        CreatedRentalResponse response = await Mediator.Send(command);

        return CreatedAtAction(nameof(GetById), new { response.Id }, response);
    }

    [HttpPut]
    public async Task<ActionResult<UpdatedRentalResponse>> Update([FromBody] UpdateRentalCommand command)
    {
        UpdatedRentalResponse response = await Mediator.Send(command);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<DeletedRentalResponse>> Delete([FromRoute] Guid id)
    {
        DeleteRentalCommand command = new() { Id = id };

        DeletedRentalResponse response = await Mediator.Send(command);

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<GetByIdRentalResponse>> GetById([FromRoute] Guid id)
    {
        GetByIdRentalQuery query = new() { Id = id };

        GetByIdRentalResponse response = await Mediator.Send(query);

        return Ok(response);
    }

    [HttpGet]
    public async Task<ActionResult<GetListRentalQuery>> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListRentalQuery query = new() { PageRequest = pageRequest };

        GetListResponse<GetListRentalListItemDto> response = await Mediator.Send(query);

        return Ok(response);
    }
}