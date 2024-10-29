using Application.Contracts.Features.Carts.Commands.AddProductToCart;
using Clients.Contracts;
using Domain.Entities.Carts.Parameters;
using MediatR;
using Persistence.Contracts;
using Persistence.Contracts.DbSets.Carts.Queries;

namespace Application.Features.Carts.Commands.AddProductToCart;

internal sealed class AddProductToCartHandler(
    IDbContext context,
    ICurrentClient<Guid> currentClient,
    TimeProvider timeProvider) : 
    IRequestHandler<AddProductToCartCommand>
{
    public async Task Handle(AddProductToCartCommand request, CancellationToken cancellationToken)
    {
        var bucket = await context.Carts.GetAsync(new GetClientCartParameters
        {
            ClientId = currentClient.ClientId,
            AsTracking = true,
            IncludeProducts = true
        }, cancellationToken);
        
        bucket.AddProduct(new AddProductToCartParameters
        {
            ProductId = request.RouteDto.ProductId,
            Quantity = request.BodyDto.Quantity,
            TimeProvider = timeProvider
        });

        await context.SaveChangesAsync(cancellationToken);
    }
}