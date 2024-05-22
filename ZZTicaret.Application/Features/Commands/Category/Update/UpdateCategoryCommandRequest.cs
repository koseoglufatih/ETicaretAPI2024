using MediatR;

namespace ZZTicaret.Application.Features.Commands.Category.Update
{
    public class UpdateCategoryCommandRequest : IRequest<UpdateCategoryCommandResponse>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}