using Application.Features.CorporateCustomers.Commands.Create;
using Application.Features.CorporateCustomers.Commands.Delete;
using Application.Features.CorporateCustomers.Commands.Update;
using Application.Features.CorporateCustomers.Queries.GetById;
using Application.Features.CorporateCustomers.Queries.GetList;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CorporateCustomersController : BaseController
{
    [HttpPost]
    public async Task<ActionResult<CreatedCorporateCustomerResponse>> Add([FromBody] CreateCorporateCustomerCommand command)
    {
        CreatedCorporateCustomerResponse response = await Mediator.Send(command);

        return CreatedAtAction(nameof(GetById), new { response.Id }, response);
    }

    [HttpPut]
    public async Task<ActionResult<UpdatedCorporateCustomerResponse>> Update([FromBody] UpdateCorporateCustomerCommand command)
    {
        UpdatedCorporateCustomerResponse response = await Mediator.Send(command);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<DeletedCorporateCustomerResponse>> Delete([FromRoute] Guid id)
    {
        DeleteCorporateCustomerCommand command = new() { Id = id };

        DeletedCorporateCustomerResponse response = await Mediator.Send(command);

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<GetByIdCorporateCustomerResponse>> GetById([FromRoute] Guid id)
    {
        GetByIdCorporateCustomerQuery query = new() { Id = id };

        GetByIdCorporateCustomerResponse response = await Mediator.Send(query);

        return Ok(response);
    }

    [HttpGet]
    public async Task<ActionResult<GetListCorporateCustomerQuery>> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListCorporateCustomerQuery query = new() { PageRequest = pageRequest };

        GetListResponse<GetListCorporateCustomerListItemDto> response = await Mediator.Send(query);

        return Ok(response);
    }
}