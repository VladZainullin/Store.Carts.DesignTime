using Domain.Entities.Carts;
using Persistence.Contracts.DbSets.Carts.Queries;

namespace Persistence.Contracts.DbSets.Carts;

public interface ICartDbSet : IDbSet<Cart>
{
    Task<Cart> GetAsync(GetClientCartParameters parameters, CancellationToken cancellationToken = default);
}