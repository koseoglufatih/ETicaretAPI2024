using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ZZTicaret.Application.Features.Commands.Product.Create;
using ZZTicaret.Application.Features.Commands.Product.Remove;
using ZZTicaret.Application.Features.Commands.Product.Update;
using ZZTicaret.Application.Features.Commands.User.Create;
using ZZTicaret.Application.Features.Commands.User.Delete;
using ZZTicaret.Application.Features.Commands.User.Update;
using ZZTicaret.Application.Features.Queries.Product.GetAllProduct;
using ZZTicaret.Application.Features.Queries.Product.GetByCategoryId;
using ZZTicaret.Application.Features.Queries.Product.GetByIdProduct;
using ZZTicaret.Application.Features.Queries.User.GetAllUser;
using ZZTicaret.Application.Features.Queries.User.GetUserById;

namespace ZZTicaret.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {

        readonly IMediator _mediator;

        public UserController(

            IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        
        public async Task<IActionResult> GetAll([FromQuery] GetAllUserQueryRequest getAllUserQueryRequest)
        {
            GetAllUserQueryResponse response = await _mediator.Send(getAllUserQueryRequest);
            return Ok(response);
        }

        [HttpGet("{Id}")]

        public async Task<IActionResult> GetById([FromRoute] GetUserByIdQueryRequest getUserByIdQueryRequest)
        {
            GetUserByIdQueryResponse response = await _mediator.Send(getUserByIdQueryRequest);
            return Ok(response);
        }

        [HttpPost]
        
        public async Task<IActionResult> Post([FromBody] CreateUserCommandRequest createUserCommandRequest)
        {
            CreateUserCommandResponse response = await _mediator.Send(createUserCommandRequest);
            return Ok(response);
        }

        [HttpDelete("{Id}")]
        
        public async Task<IActionResult> Delete([FromRoute] DeleteUserCommandRequest deleteUserCommandRequest)
        {
            DeleteUserCommandResponse response = await _mediator.Send(deleteUserCommandRequest);
            return Ok(response);
        }

        [HttpPut]

        public async Task<IActionResult> Put([FromBody] UpdateUserCommandRequest updateUserCommandRequest)
        {
            UpdateUserCommandResponse response = await _mediator.Send(updateUserCommandRequest);
            return Ok(response);
        }

    }
}
