using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZZTicaret.Application.Features.Queries.Basket
{
    public class GetBasketByUserIdCommandHandler : IRequestHandler<GetBasketByUserIdCommandRequest, GetBasketByUserIdCommandResponse>
    {
        public Task<GetBasketByUserIdCommandResponse> Handle(GetBasketByUserIdCommandRequest request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
