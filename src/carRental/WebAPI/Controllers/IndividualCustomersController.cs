using Application.Features.IndividualCustomers.Commands.Create;
using Application.Features.IndividualCustomers.Commands.Delete;
using Application.Features.IndividualCustomers.Commands.Update;
using Application.Features.IndividualCustomers.Queries.GetById;
using Application.Features.IndividualCustomers.Queries.GetList;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class IndividualCustomersController : BaseController
{
    [HttpPost]
    public async Task<ActionResult<CreatedIndividualCustomerResponse>> Add([FromBody] CreateIndividualCustomerCommand command)
    {
        CreatedIndividualCustomerResponse response = await Mediator.Send(command);

        return CreatedAtAction(nameof(GetById), new { response.Id }, response);
    }

    [HttpPut]
    public async Task<ActionResult<UpdatedIndividualCustomerResponse>> Update([FromBody] UpdateIndividualCustomerCommand command)
    {
        UpdatedIndividualCustomerResponse response = await Mediator.Send(command);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<DeletedIndividualCustomerResponse>> Delete([FromRoute] Guid id)
    {
        DeleteIndividualCustomerCommand command = new() { Id = id };

        DeletedIndividualCustomerResponse response = await Mediator.Send(command);

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<GetByIdIndividualCustomerResponse>> GetById([FromRoute] Guid id)
    {
        GetByIdIndividualCustomerQuery query = new() { Id = id };

        GetByIdIndividualCustomerResponse response = await Mediator.Send(query);

        return Ok(response);
    }

    [HttpGet]
    public async Task<ActionResult<GetListIndividualCustomerQuery>> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListIndividualCustomerQuery query = new() { PageRequest = pageRequest };

        GetListResponse<GetListIndividualCustomerListItemDto> response = await Mediator.Send(query);

        return Ok(response);
    }
}