using Domain.Entities.Carts;
using Microsoft.EntityFrameworkCore;
using Persistence.Contracts.DbSets.Carts;
using Persistence.Contracts.DbSets.Carts.Queries;

namespace Persistence.DbSets;

internal sealed class CartDbSetAdapter(AppDbContext context) : DbSetAdapter<Cart>(context), ICartDbSet
{
    public Task<Cart> GetAsync(GetClientCartParameters parameters, CancellationToken cancellationToken = default)
    {
        var queryable = context.Carts.AsQueryable();

        if (parameters.AsTracking)
        {
            queryable = queryable.AsTracking();
        }

        if (parameters.IncludeProducts)
        {
            queryable = queryable.Include(static b => b.Products);
        }

        return queryable.Where(b => b.ClientId == parameters.ClientId).SingleAsync(cancellationToken);
    }
}