using MediatR;

namespace ZZTicaret.Application.Features.Commands.User.Delete
{
    public class DeleteUserCommandRequest : IRequest<DeleteUserCommandResponse>
    {
        public Guid UserId { get; set; }
    }
}