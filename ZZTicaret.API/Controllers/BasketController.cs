using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ZZTicaret.Application.Features.Commands.Basket.AddItemToBasket;
using ZZTicaret.Application.Features.Commands.Category.Create;
using ZZTicaret.Application.Features.Commands.Category.Remove;
using ZZTicaret.Application.Features.Commands.Category.Update;
using ZZTicaret.Application.Features.Queries.Basket.BetBasketByUserId;
using ZZTicaret.Application.Features.Queries.Category.GetAllCategory;
using ZZTicaret.Application.Features.Queries.Category.GetByIdCategory;


namespace ZZTicaret.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BasketController : ControllerBase
    {

        readonly IMediator _mediator;

        public BasketController(IMediator mediator)
        {
            _mediator = mediator;
        }


        [HttpPost]
        public async Task<IActionResult> Post([FromBody] AddItemToBasketCommandRequest  addItemToBasketCommandRequest)
        {
            AddItemToBasketCommandResponse response = await _mediator.Send(addItemToBasketCommandRequest);
            return Ok(response);
        }


        [HttpGet("{Id}")]

        public async Task<IActionResult> GetBasketByUserId([FromRoute] GetBasketByUserIdCommandRequest getBasketByUserIdCommandRequest)
        {
            GetBasketByUserIdCommandResponse response = await _mediator.Send(getBasketByUserIdCommandRequest);
            return Ok(response);
        }

    }
 }


