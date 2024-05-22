using MediatR;

namespace ZZTicaret.Application.Features.Commands.User.Update
{
    public class UpdateUserCommandRequest :IRequest<UpdateUserCommandResponse>
    {
        public Guid UserId { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}