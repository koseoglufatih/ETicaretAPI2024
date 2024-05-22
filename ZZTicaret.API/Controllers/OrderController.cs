using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ZZTicaret.Application.Features.Commands.Category.Create;
using ZZTicaret.Application.Features.Commands.Category.Remove;
using ZZTicaret.Application.Features.Commands.Category.Update;
using ZZTicaret.Application.Features.Commands.Order.Create;
using ZZTicaret.Application.Features.Queries.Category.GetAllCategory;
using ZZTicaret.Application.Features.Queries.Category.GetByIdCategory;
using ZZTicaret.Application.Features.Queries.Order.GetAllOrder;
using ZZTicaret.Application.Features.Queries.Order.GetOrderById;

namespace ZZTicaret.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        readonly IMediator _mediator;

        public OrderController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        
        public async Task<IActionResult> GetAll([FromQuery] GetAllOrdersQueryRequest getAllOrdersQueryRequest)
        {
            GetAllOrdersQueryResponse response = await _mediator.Send(getAllOrdersQueryRequest);
            return Ok(response);
        }

        [HttpGet("{Id}")]

        public async Task<IActionResult> GetById([FromRoute] GetOrderByIdQueryRequest getOrderByIdQueryRequest)
        {
            GetOrderByIdQueryResponse response = await _mediator.Send(getOrderByIdQueryRequest);
            return Ok(response);
        }

        [HttpPost]
        
        public async Task<IActionResult> Post([FromBody] CreateOrderCommandRequest createOrderCommandRequest)
        {
            CreateOrderCommandResponse response = await _mediator.Send(createOrderCommandRequest);
            return Ok(response);
        }

     
      
    }
}
