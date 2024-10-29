using Application.Contracts.Features.Carts.Commands.CleanCart;
using Clients.Contracts;
using Domain.Entities.Carts.Parameters;
using MediatR;
using Persistence.Contracts;
using Persistence.Contracts.DbSets.Carts.Queries;

namespace Application.Features.Carts.Commands.CleanBucket;

internal sealed class CleanBucketHandler(
    IDbContext context,
    ICurrentClient<Guid> currentClient,
    TimeProvider timeProvider) : IRequestHandler<CleanCartCommand>
{
    public async Task Handle(CleanCartCommand request, CancellationToken cancellationToken)
    {
        var bucket = await context.Carts.GetAsync(new GetClientCartParameters
        {
            ClientId = currentClient.ClientId,
            AsTracking = true,
            IncludeProducts = false
        }, cancellationToken);

        bucket.Clean(new CleanCartParameters
        {
            TimeProvider = timeProvider
        });

        await context.SaveChangesAsync(cancellationToken);
    }
}