using Azure;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ZZTicaret.Application.Features.Commands.Category.Create;
using ZZTicaret.Application.Features.Commands.Category.Remove;
using ZZTicaret.Application.Features.Commands.Category.Update;
using ZZTicaret.Application.Features.Queries.Category.GetAllCategory;
using ZZTicaret.Application.Features.Queries.Category.GetByIdCategory;
using ZZTicaret.Application.Features.Queries.Product.GetAllProduct;

namespace ZZTicaret.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        readonly IMediator _mediator;

        public CategoryController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        
        public async Task<IActionResult> GetAll([FromQuery] GetAllCategoryQueryRequest getAllCategoryQueryRequest)
        {
            GetAllCategoryQueryResponse response = await _mediator.Send(getAllCategoryQueryRequest);
            return Ok(response);
        }

        [HttpGet("{Id}")]
        
        public async Task<IActionResult> GetById([FromRoute] GetByIdCategoryQueryRequest getByIdCategoryQueryRequest)
        {
            GetByIdCategoryQueryResponse response = await _mediator.Send(getByIdCategoryQueryRequest); 
            return Ok(response);
        }

        [HttpPost]
        
        public async Task<IActionResult> Post([FromBody] CreateCategoryCommandRequest createCategoryCommandRequest)
        {
            CreateCategoryCommandResponse response = await _mediator.Send(createCategoryCommandRequest);
            return Ok(response);
        }

        [HttpDelete("{Id}")]
        
        public async Task<IActionResult> Delete([FromRoute] RemoveCategoryCommandRequest removeCategoryCommandRequest)
        {
            RemoveCategoryCommandResponse response = await _mediator.Send(removeCategoryCommandRequest);
            return Ok(response);
        }
        [HttpPut]
        
        public async Task<IActionResult> Update([FromBody] UpdateCategoryCommandRequest updateCategoryCommandRequest)
        {
            UpdateCategoryCommandResponse response = await _mediator.Send(updateCategoryCommandRequest);
            return Ok(response);
        }
    } 
}
