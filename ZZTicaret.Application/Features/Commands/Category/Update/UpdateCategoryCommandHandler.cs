using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZZTicaret.Application.Repositories;

namespace ZZTicaret.Application.Features.Commands.Category.Update
{
    public class UpdateCategoryCommandHandler : IRequestHandler<UpdateCategoryCommandRequest, UpdateCategoryCommandResponse>
    {
        readonly ICategoryRepository _categoryRepository;

        public UpdateCategoryCommandHandler(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task<UpdateCategoryCommandResponse> Handle(UpdateCategoryCommandRequest request, CancellationToken cancellationToken)
        {
           ZZTicaret.Domain.Category category = await _categoryRepository.GetByIdAsync(request.Id);
            category.CreateDate = DateTime.Now;
            category.Id = request.Id;
            category.Name = request.Name;
            await _categoryRepository.SaveAsync();
            return new ();



        }
    }
}
