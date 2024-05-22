using MediatR;

namespace ZZTicaret.Application.Features.Commands.Product.Remove
{
    public class RemoveProductCommandRequest : IRequest<RemoveProductCommandResponse>
    {
        public Guid Id { get; set; }
    }
}