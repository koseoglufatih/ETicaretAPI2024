using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZZTicaret.Application.Services;

namespace ZZTicaret.Application.Features.Commands.User.Update
{
    public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommandRequest, UpdateUserCommandResponse>
    {
        private readonly IUserService _userService;

        public UpdateUserCommandHandler(IUserService userService)
        {
            _userService = userService;
        }

        public async Task<UpdateUserCommandResponse> Handle(UpdateUserCommandRequest request, CancellationToken cancellationToken)
        {

            Domain.User user = await _userService.GetUserById(request.UserId);

            
            user.Id = request.UserId;
            user.Email = request.Email;
            user.Password = request.Password;
            await _userService.UpdateUser(user);
            return new UpdateUserCommandResponse();
            

        }

    }
}