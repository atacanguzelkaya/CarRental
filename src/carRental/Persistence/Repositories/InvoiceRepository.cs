using Application.Services.Repositories;
using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class InvoiceRepository : EfRepositoryBase<Invoice, Guid, BaseDbContext>, IInvoiceRepository
{
    public InvoiceRepository(BaseDbContext context) : base(context)
    {
    }
}