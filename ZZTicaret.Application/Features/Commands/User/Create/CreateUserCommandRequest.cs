using MediatR;

namespace ZZTicaret.Application.Features.Commands.User.Create
{
    public class CreateUserCommandRequest : IRequest<CreateUserCommandResponse>
    {

        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public DateTime CreateDate { get; set; }
    }
}