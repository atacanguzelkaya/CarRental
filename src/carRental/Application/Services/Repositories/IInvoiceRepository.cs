using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;

namespace Application.Services.Repositories;

public interface IInvoiceRepository : IAsyncRepository<Invoice, Guid>, IRepository<Invoice, Guid>
{
}