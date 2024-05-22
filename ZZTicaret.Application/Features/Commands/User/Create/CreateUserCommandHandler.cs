using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZZTicaret.Application.DTO.User;
using ZZTicaret.Application.Features.Queries.Order.GetOrderById;
using ZZTicaret.Application.Repositories;
using ZZTicaret.Application.Services;

namespace ZZTicaret.Application.Features.Commands.User.Create
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommandRequest, CreateUserCommandResponse>
    {
        private readonly IUserRepository _userRepository;

        public CreateUserCommandHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

       

        public async Task<CreateUserCommandResponse> Handle(CreateUserCommandRequest request, CancellationToken cancellationToken)
        {

            var user = new Domain.User
            {
               Id = Guid.NewGuid(),
               NameSurname = request.Name,
               Email = request.Email,   
               Password = request.Password,
            };

            await _userRepository.AddAsync(user);

            return new CreateUserCommandResponse { UserId = user.Id};
        }
    }
}