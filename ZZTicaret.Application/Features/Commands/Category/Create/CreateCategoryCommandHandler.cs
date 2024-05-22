using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZZTicaret.Application.Features.Commands.Product.Create;
using ZZTicaret.Application.Repositories;

namespace ZZTicaret.Application.Features.Commands.Category.Create
{
    public class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommandRequest, CreateCategoryCommandResponse>
    {
        readonly ICategoryRepository _categoryRepository;

        public CreateCategoryCommandHandler(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task<CreateCategoryCommandResponse> Handle(CreateCategoryCommandRequest request, CancellationToken cancellationToken)
        {
            await _categoryRepository.AddAsync(new(){
                 CreateDate = DateTime.UtcNow,              
                 Name = request.Name,
                 
            });

            await _categoryRepository.SaveAsync();
            return new ();
        }
    }
}
