using MediatR;

namespace ZZTicaret.Application.Features.Commands.Category.Remove
{
    public class RemoveCategoryCommandRequest : IRequest<RemoveCategoryCommandResponse>
    {
        public Guid Id { get; set; }
    }
}