using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZZTicaret.Application.Features.Commands.Category.Create;
using ZZTicaret.Application.Repositories;

namespace ZZTicaret.Application.Features.Commands.Category.Remove
{
    public class RemoveCategoryCommandHandler : IRequestHandler<RemoveCategoryCommandRequest, RemoveCategoryCommandResponse>
    {
        readonly ICategoryRepository _categoryRepository;

        public RemoveCategoryCommandHandler(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task<RemoveCategoryCommandResponse> Handle(RemoveCategoryCommandRequest request, CancellationToken cancellationToken)
        {
            await _categoryRepository.Delete(request.Id);
            await _categoryRepository.SaveAsync();
            return new ();



        }
    }
}
