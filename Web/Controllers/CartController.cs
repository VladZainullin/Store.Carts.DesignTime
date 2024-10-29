using Application.Contracts.Features.Carts.Commands.AddProductToCart;
using Application.Contracts.Features.Carts.Commands.RemoveProductFromCart;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers;

[Route("api/carts/{cartId:guid}/products/{productId:guid}")]
public sealed class CartController : AppController
{
    [HttpPost]
    public async Task<NoContentResult> AddProductToCartAsync(
        AddProductToCartRequestRouteDto routeDto,
        AddProductToCartRequestBodyDto bodyDto)
    {
        await Sender.Send(new AddProductToCartCommand(routeDto, bodyDto), HttpContext.RequestAborted);

        return NoContent();
    }
    
    [HttpDelete]
    public async Task<NoContentResult> DeleteProductFromCartAsync(
        RemoveProductFromCartRequestRouteDto routeDto,
        RemoveProductFromCartRequestBodyDto bodyDto)
    {
        await Sender.Send(new RemoveProductFromCartCommand(routeDto, bodyDto), HttpContext.RequestAborted);

        return NoContent();
    }
}