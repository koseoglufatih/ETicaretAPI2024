using MediatR;

namespace ZZTicaret.Application.Features.Queries.User.GetUserById
{
    public class GetUserByIdQueryRequest : IRequest<GetUserByIdQueryResponse>
    {
        public Guid UserId { get; set; }
    }
}