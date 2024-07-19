using Application.Features.Invoices.Commands.Create;
using Application.Features.Invoices.Commands.Delete;
using Application.Features.Invoices.Commands.Update;
using Application.Features.Invoices.Queries.GetById;
using Application.Features.Invoices.Queries.GetList;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class InvoicesController : BaseController
{
    [HttpPost]
    public async Task<ActionResult<CreatedInvoiceResponse>> Add([FromBody] CreateInvoiceCommand command)
    {
        CreatedInvoiceResponse response = await Mediator.Send(command);

        return CreatedAtAction(nameof(GetById), new { response.Id }, response);
    }

    [HttpPut]
    public async Task<ActionResult<UpdatedInvoiceResponse>> Update([FromBody] UpdateInvoiceCommand command)
    {
        UpdatedInvoiceResponse response = await Mediator.Send(command);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<DeletedInvoiceResponse>> Delete([FromRoute] Guid id)
    {
        DeleteInvoiceCommand command = new() { Id = id };

        DeletedInvoiceResponse response = await Mediator.Send(command);

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<GetByIdInvoiceResponse>> GetById([FromRoute] Guid id)
    {
        GetByIdInvoiceQuery query = new() { Id = id };

        GetByIdInvoiceResponse response = await Mediator.Send(query);

        return Ok(response);
    }

    [HttpGet]
    public async Task<ActionResult<GetListInvoiceQuery>> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListInvoiceQuery query = new() { PageRequest = pageRequest };

        GetListResponse<GetListInvoiceListItemDto> response = await Mediator.Send(query);

        return Ok(response);
    }
}