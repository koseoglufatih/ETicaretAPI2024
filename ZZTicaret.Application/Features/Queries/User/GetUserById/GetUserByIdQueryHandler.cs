using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZZTicaret.Application.Services;

namespace ZZTicaret.Application.Features.Queries.User.GetUserById
{
    public class GetUserByIdQueryHandler : IRequestHandler<GetUserByIdQueryRequest, GetUserByIdQueryResponse>
    {
        readonly IUserService _userService;

        public GetUserByIdQueryHandler(IUserService userService)
        {
            _userService = userService;
        }

        public async Task<GetUserByIdQueryResponse> Handle(GetUserByIdQueryRequest request, CancellationToken cancellationToken)
        {
            var user = await _userService.GetUserById(request.UserId);

            if (user == null)
            {
                
                throw new Exception($"Bu İd'ye ait {request.UserId} Bir kullanıcı bulunamadı.");
            }
            return new GetUserByIdQueryResponse
            {
                UserId = user.Id,
                UserName = user.NameSurname,
            
            };
            

        }
    }
}
