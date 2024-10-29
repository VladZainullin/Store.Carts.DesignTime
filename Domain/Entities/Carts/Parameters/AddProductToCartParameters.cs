// ReSharper disable UnusedAutoPropertyAccessor.Global
namespace Domain.Entities.Carts.Parameters;

public readonly struct AddProductToCartParameters
{
    public required Guid ProductId { get; init; }

    public required int Quantity { get; init; }

    public required TimeProvider TimeProvider { get; init; }
}