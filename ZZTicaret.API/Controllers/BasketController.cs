using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ZZTicaret.Application.Features.Commands.Basket.AddProductToBasket;
using ZZTicaret.Application.Features.Commands.Basket.RemoveBasketItem;
using ZZTicaret.Application.Features.Queries.Basket.GetBasketItems;

namespace ZZTicaret.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BasketController : ControllerBase
    {
        readonly IMediator  _mediator;

        public BasketController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetBasketItems([FromQuery] GetBasketTotalQueryRequest getBasketTotalQueryRequest)
        {
            GetBasketTotalQueryResponse response = await  _mediator.Send(getBasketTotalQueryRequest);
            return Ok(response);

        }

        [HttpPost]
        public async Task<IActionResult> AddItemToBasket(AddProductToBasketCommandRequest  addProductToBasket)
        {
            AddProductToBasketCommandResponse response = await _mediator.Send(addProductToBasket);
            return Ok(response);

        }

        [HttpDelete("{BasketItemId}")]
        public async Task<IActionResult> RemoveBasketItem([FromRoute] RemoveBasketItemCommandRequest removeBasketItemCommandRequest)
        {
            RemoveBasketItemCommandResponse response = await _mediator.Send(removeBasketItemCommandRequest);
            return Ok(response);
        }

    }
}
