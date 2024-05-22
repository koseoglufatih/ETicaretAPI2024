using MediatR;

namespace ZZTicaret.Application.Features.Commands.Category.Create
{
    public class CreateCategoryCommandRequest : IRequest<CreateCategoryCommandResponse>
    {
        
        public string Name { get; set; }
        public DateTime CreateDate { get; set; }

    }
}