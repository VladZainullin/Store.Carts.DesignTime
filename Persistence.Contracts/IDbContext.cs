using Persistence.Contracts.DbSets.Carts;

namespace Persistence.Contracts;

public interface IDbContext
{
    ICartDbSet Carts { get; }
    
    Task SaveChangesAsync(CancellationToken cancellationToken = default);
}