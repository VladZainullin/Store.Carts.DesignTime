using Application.Contracts.Features.Carts.Commands.RemoveProductFromCart;
using Clients.Contracts;
using Domain.Entities.Carts.Parameters;
using MediatR;
using Persistence.Contracts;
using Persistence.Contracts.DbSets.Carts.Queries;

namespace Application.Features.Carts.Commands.RemoveProductFromBucket;

internal sealed class RemoveProductFromBucketHandler(
    IDbContext context,
    ICurrentClient<Guid> currentClient,
    TimeProvider timeProvider) : 
    IRequestHandler<RemoveProductFromCartCommand>
{
    public async Task Handle(RemoveProductFromCartCommand request, CancellationToken cancellationToken)
    {
        var bucket = await context.Carts.GetAsync(new GetClientCartParameters
        {
            ClientId = currentClient.ClientId,
            AsTracking = true,
            IncludeProducts = true
        }, cancellationToken);
        
        bucket.RemoveProduct(new RemoveProductFromCartParameters
        {
            ProductId = request.RouteDto.ProductId,
            Quantity = request.BodyDto.Quantity,
            TimeProvider = timeProvider
        });

        await context.SaveChangesAsync(cancellationToken);
    }
}