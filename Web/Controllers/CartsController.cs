using Application.Contracts.Features.Carts.Commands.AddProductToCart;
using Application.Contracts.Features.Carts.Commands.CleanCart;
using Application.Contracts.Features.Carts.Commands.RemoveProductFromCart;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers;

[Route("api/carts")]
public sealed class CartsController : AppController
{
    [HttpDelete]
    public async Task<NoContentResult> CleanCart()
    {
        await Sender.Send(new CleanCartCommand(), HttpContext.RequestAborted);

        return NoContent();
    }
}